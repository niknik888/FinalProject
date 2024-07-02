using AutoMapper;
using Blog2.API.Contracts.Services.IServises;
using Blog2.API.Data.Models.Request.Comments;
using Blog2.API.Data.Models.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog2.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;

        public CommentController(ICommentService commentService, IMapper mapper)
        {
            _commentService = commentService;
            _mapper = mapper;
        }

        /// <summary>
        /// Получение всех комментариев поста
        /// </summary>
        [Authorize(Roles = "Администратор")]
        [HttpGet]
        [Route("GetPostComment")]
        public async Task<IEnumerable<Comment>> GetUsers(Guid id)
        {
            var comment = await _commentService.GetComments();
            return comment.Where(c => c.PostId == id);
        }

        /// <summary>
        /// Создание комментария к посту
        /// </summary>
        [Authorize(Roles = "Администратор")]
        [HttpPost]
        [Route("CreateComment")]
        public async Task<IActionResult> CreateComment(CommentCreateRequest request)
        {
            var result = await _commentService.CreateComment(request);
            return StatusCode(201);
        }

        /// <summary>
        /// Редактирование комментария
        /// </summary>
        [Authorize(Roles = "Администратор")]
        [HttpPatch]
        [Route("EditComment")]
        public async Task<IActionResult> EditComment(CommentEditRequest request)
        {
            var result = await _commentService.EditComment(request);
            if (result == 1)
                return StatusCode(201);
            else
                return StatusCode(204);
        }

        /// <summary>
        /// Удаление комментария
        /// </summary>
        [Authorize(Roles = "Администратор")]
        [HttpDelete]
        [Route("RemoveComment")]
        public async Task<IActionResult> RemoveComment(Guid id)
        {
            await _commentService.RemoveComment(id);

            return StatusCode(201);
        }
    }
}
