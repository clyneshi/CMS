namespace CMS.DAL.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Keyword")]
    public partial class Keyword
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Keyword()
        {
            ConferenceTopics = new HashSet<ConferenceTopic>();
            Expertises = new HashSet<Expertise>();
            PaperTopics = new HashSet<PaperTopic>();
        }

        [Key]
        public int keywrdId { get; set; }

        [Required]
        [StringLength(50)]
        public string keywrdGenre { get; set; }

        [Required]
        [StringLength(50)]
        public string keywrdName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ConferenceTopic> ConferenceTopics { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Expertise> Expertises { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PaperTopic> PaperTopics { get; set; }
    }
}
