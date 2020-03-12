namespace CMS.DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Feedback")]
    public partial class Feedback
    {
        public int Id { get; set; }

        public int paperId { get; set; }

        public int userId { get; set; }

        [StringLength(10)]
        public string fnlDecision { get; set; }

        [Column("feedback")]
        public string feedback1 { get; set; }

        public virtual Paper Paper { get; set; }

        public virtual User User { get; set; }
    }
}
