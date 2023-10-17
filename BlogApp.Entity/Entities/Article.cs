using BlogApp.Core.Entities;

namespace BlogApp.Entity.Entities
{
    public class Article : EntityBase, IEntityBase
    {
        public Article()
        {

        }
        public Article(string title, string content, Guid userId, string CreatedBy, Guid categoryId, Guid imageId)
        {
            this.Title = title;
            this.Content = content;
            this.UserId = userId;
            this.CategoryId = categoryId;
            this.ImageId = imageId;
            this.CreatedBy = CreatedBy;

        }

        public string Title { get; set; }
        public Guid İmageId { get; }
        public string Content { get; set; }
        public int ViewCount { get; set; } = 0;

        public Guid CategoryId { get; set; }
        public Category Category { get; set; }

        public Guid? ImageId { get; set; }
        public Image Image { get; set; }

        public Guid UserId { get; set; }
        public AppUser User { get; set; }

        public ICollection<ArticleVisitor> ArticleVisitors { get; set; }

    }
}
