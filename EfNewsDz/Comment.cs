namespace EfNewsDz
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Comment
    {
        public int Id { get; set; }
        public String Text { get; set; }
      
        public virtual News News { get; set; }

        public virtual User User { get; set; }
    }
}
