namespace CMS.DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Expertise")]
    public partial class Expertise
    {
        public int Id { get; set; }

        public int userId { get; set; }

        public int keywrdId { get; set; }

        public virtual Keyword Keyword { get; set; }

        public virtual User User { get; set; }
    }
}
