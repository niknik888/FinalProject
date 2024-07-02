using Blog2.API.Data.Models.Request.Tags;
using System.ComponentModel.DataAnnotations;

namespace Blog2.API.Data.Models.Request.Posts
{
    public class PostEditRequest
    {
        public Guid id { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Заголовок", Prompt = "Заголовок")]
        public string? Title { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Описание", Prompt = "Описание")]
        public string? Body { get; set; }

        [Display(Name = "Теги", Prompt = "Теги")]
        public List<TagRequest>? Tags { get; set; }
    }
}
