namespace CMS.DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PaperTopic")]
    public partial class PaperTopic
    {
        public int Id { get; set; }

        public int paperId { get; set; }

        public int keywrdId { get; set; }

        public virtual Keyword Keyword { get; set; }

        public virtual Paper Paper { get; set; }
    }
}
