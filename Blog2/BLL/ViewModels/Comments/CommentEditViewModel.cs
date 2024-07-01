using System.ComponentModel.DataAnnotations;

namespace Blog2.BLL.ViewModels.Comments
{
    public class CommentEditViewModel
    {
        [DataType(DataType.Text)]
        [Display(Name = "Заголовок", Prompt = "Заголовок")]
        public string Title { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Описание", Prompt = "Описание")]
        public string Description { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Автор", Prompt = "Автор")]
        public string Author { get; set; }

        public Guid Id { get; set; }
    }
}
