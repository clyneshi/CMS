namespace CMS.DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Paper")]
    public partial class Paper
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Paper()
        {
            Feedbacks = new HashSet<Feedback>();
            PaperReviews = new HashSet<PaperReview>();
            PaperTopics = new HashSet<PaperTopic>();
        }

        public int paperId { get; set; }

        [Required]
        [StringLength(20)]
        public string paperTitle { get; set; }

        [Required]
        [StringLength(20)]
        public string paperAuthor { get; set; }

        [Column(TypeName = "date")]
        public DateTime paperSubDate { get; set; }

        [StringLength(5)]
        public string paperLength { get; set; }

        [Required]
        public byte[] paperContent { get; set; }

        public int confId { get; set; }

        public int auId { get; set; }

        [StringLength(10)]
        public string paperFormat { get; set; }

        [Required]
        [StringLength(15)]
        public string paperStatus { get; set; }

        [Required]
        [StringLength(50)]
        public string paperFileName { get; set; }

        public virtual Conference Conference { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Feedback> Feedbacks { get; set; }

        public virtual User User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PaperReview> PaperReviews { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PaperTopic> PaperTopics { get; set; }
    }
}
