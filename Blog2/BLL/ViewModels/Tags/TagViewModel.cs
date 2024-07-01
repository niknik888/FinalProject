using System.ComponentModel.DataAnnotations;

namespace Blog2.BLL.ViewModels.Tags
{
    public class TagViewModel
    {
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        public bool IsSelected { get; set; }
    }
}
