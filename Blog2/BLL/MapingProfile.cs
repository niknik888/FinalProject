using AutoMapper;
using Blog2.BLL.ViewModels.Comments;
using Blog2.BLL.ViewModels.Posts;
using Blog2.BLL.ViewModels.Tags;
using Blog2.BLL.ViewModels.User;
using Blog2.DAL.Models;
using Microsoft.AspNetCore.Identity.Data;

namespace Blog2.BLL
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserRegisterViewModel, User>()
                .ForMember(x => x.Email, opt => opt.MapFrom(c => c.Email))
                .ForMember(x => x.UserName, opt => opt.MapFrom(c => c.UserName));

            CreateMap<CommentCreateViewModel, Comment>();
            CreateMap<CommentEditViewModel, Comment>();
            CreateMap<PostCreateViewModel, Post>();
            CreateMap<PostEditViewModel, Post>();
            CreateMap<TagCreateViewModel, Tag>();
            CreateMap<TagEditViewModel, Tag>();
            CreateMap<UserEditViewModel, User>();
        }
    }
}
