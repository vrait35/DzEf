namespace EfNewsDz
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class NewsContext : DbContext
    {
        public NewsContext()
            : base("name=NewsContext")
        {
        }

        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<User> Users { get; set; }
       
    }
}
