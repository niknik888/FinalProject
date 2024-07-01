using AutoMapper;
using Blog2.BLL.Services.IServices;
using Blog2.BLL.ViewModels.Posts;
using Blog2.BLL.ViewModels.Tags;
using Blog2.DAL.Models;
using Blog2.DAL.Repositories.IRepositories;
using Microsoft.AspNetCore.Identity;

namespace Blog2.BLL.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _repo;
        private readonly ITagRepository _tagRepo;
        private readonly UserManager<User> _userManager;
        private readonly ICommentRepository _commentRepo;
        private IMapper _mapper;

        public PostService(ITagRepository tagRepo, IPostRepository repo, IMapper mapper, UserManager<User> userManager, ICommentRepository commentRepo)
        {
            _repo = repo;
            _tagRepo = tagRepo;
            _mapper = mapper;
            _userManager = userManager;
            _commentRepo = commentRepo;
        }

        public async Task<PostCreateViewModel> CreatePost()
        {
            Post post = new Post();

            var allTags = _tagRepo.GetAllTags().Select(t => new TagViewModel() { Id = t.Id, Name = t.Name }).ToList();

            PostCreateViewModel model = new PostCreateViewModel
            {
                Title = post.Title = string.Empty,
                Body = post.Body = string.Empty,
                Tags = allTags
            };

            return model;
        }

        public async Task<Guid> CreatePost(PostCreateViewModel model)
        {
            var dbTags = new List<Tag>();

            if (model.Tags != null)
            {
                var postTags = model.Tags.Where(t => t.IsSelected == true).ToList();
                var tagsId = postTags.Select(t => t.Id).ToList();
                dbTags = _tagRepo.GetAllTags().Where(t => tagsId.Contains(t.Id)).ToList();
            }

            Post post = new Post
            {
                Id = model.Id,
                Title = model.Title,
                Body = model.Body,
                Tags = dbTags,
                AuthorId = model.AuthorId
            };

            var user = await _userManager.FindByIdAsync(model.AuthorId);
            user.Posts.Add(post);

            await _repo.AddPost(post);
            await _userManager.UpdateAsync(user);

            return post.Id;
        }

        public async Task<PostEditViewModel> EditPost(Guid id)
        {
            var post = _repo.GetPost(id);

            var tags = _tagRepo.GetAllTags().Select(t => new TagViewModel() { Id = t.Id, Name = t.Name }).ToList();

            foreach (var tag in tags)
            {
                foreach (var postTag in post.Tags)
                {
                    if (postTag.Id == tag.Id)
                    {
                        tag.IsSelected = true;
                        break;
                    }
                }
            }

            var model = new PostEditViewModel()
            {
                id = id,
                Title = post.Title,
                Body = post.Body,
                Tags = tags
            };

            return model;
        }

        public async Task EditPost(PostEditViewModel model, Guid Id)
        {
            var post = _repo.GetPost(Id);

            post.Title = model.Title;
            post.Body = model.Body;

            foreach (var tag in model.Tags)
            {
                var tagChanged = _tagRepo.GetTag(tag.Id);
                if (tag.IsSelected)
                {
                    post.Tags.Add(tagChanged);
                }
                else
                {
                    post.Tags.Remove(tagChanged);
                }
            }

            await _repo.UpdatePost(post);
        }

        public async Task RemovePost(Guid id)
        {
            await _repo.RemovePost(id);
        }

        public async Task<List<Post>> GetPosts()
        {
            var posts = _repo.GetAllPosts().ToList();

            return posts;
        }

        public async Task<Post> ShowPost(Guid id)
        {
            var post = _repo.GetPost(id);
            var user = await _userManager.FindByIdAsync(post.AuthorId.ToString());

            var comments = _commentRepo.GetCommentsByPostId(post.Id);
            post.Id = id;

            foreach (var comment in comments)
            {
                if (post.Comments.FirstOrDefault(c => c.Id == comment.Id) == null)
                {
                    post.Comments.Add(comment);
                }
            }

            if (!string.IsNullOrEmpty(user.UserName))
            {
                post.AuthorId = user.UserName;
            }
            else
            {
                post.AuthorId = "nonUsernamed";
            }

            return post;
        }
    }
}
