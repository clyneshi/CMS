namespace CMS.DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ConferenceTopic")]
    public partial class ConferenceTopic
    {
        public int Id { get; set; }

        public int confId { get; set; }

        public int keywrdId { get; set; }

        public virtual Conference Conference { get; set; }

        public virtual Keyword Keyword { get; set; }
    }
}
