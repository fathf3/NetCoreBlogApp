using BlogApp.Core.Entities;

namespace BlogApp.Entity.Entities
{
    public class Category : EntityBase, IEntityBase
    {

        public Category()
        {
            
        }
        public Category(string name, string userMail)
        {
            this.Name = name;
            CreatedBy = userMail;
        }

        public string Name { get; set; }


        public ICollection<Article> Articles { get; set; }  
    }
}
