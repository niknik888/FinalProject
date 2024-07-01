using Blog2.BLL.ViewModels.Tags;

namespace Blog2.BLL.ViewModels.Posts
{
    public class ShowPostViewModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string AuthorId { get; set; }
        public List<TagViewModel> Tags { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}
