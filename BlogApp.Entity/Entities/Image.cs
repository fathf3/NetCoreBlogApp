using BlogApp.Core.Entities;

namespace BlogApp.Entity.Entities
{
    public class Image : EntityBase, IEntityBase
    {

        public Image()
        {
            
        }

        public Image(string fileName, string fileType, string createdBy)
        {
            this.FileName = fileName;
            this.FileType = fileType;
            this.CreatedBy = createdBy;
        }

        public string FileType { get; set; }
        public string FileName { get; set; }
        public ICollection<Article> Articles { get; set; }
        public ICollection<AppUser> Users { get; set; }
    }
}
