namespace EfNewsDz
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class News
    {     
        public News()
        {
            Comments = new List<Comment>();
        }

        public int Id { get; set; }
       
        public string Header { get; set; }

        public string Content { get; set; }
       
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
