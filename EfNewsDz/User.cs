namespace EfNewsDz
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
      
        public User()
        {
            Comments = new List<Comment>();
        }

        public int Id { get; set; }
     
        public string Login { get; set; }
        public string Password { get; set; }
    
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
