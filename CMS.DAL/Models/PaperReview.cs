namespace CMS.DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PaperReview")]
    public partial class PaperReview
    {
        public int Id { get; set; }

        public int paperId { get; set; }

        public int userId { get; set; }

        public int? paperRating { get; set; }

        public virtual Paper Paper { get; set; }

        public virtual User User { get; set; }
    }
}
