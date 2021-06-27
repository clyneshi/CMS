namespace CMS.DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Conference")]
    public partial class Conference
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Conference()
        {
            ConferenceMembers = new HashSet<ConferenceMember>();
            ConferenceTopics = new HashSet<ConferenceTopic>();
            Papers = new HashSet<Paper>();
            RegisterRequests = new HashSet<RegisterRequest>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int confId { get; set; }

        public int chairId { get; set; }

        [Required]
        [StringLength(100)]
        public string confTitle { get; set; }

        [Required]
        [StringLength(100)]
        public string confLocation { get; set; }

        [Column(TypeName = "date")]
        public DateTime confBeginDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime confEndDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime paperDeadline { get; set; }

        public virtual User User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ConferenceMember> ConferenceMembers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ConferenceTopic> ConferenceTopics { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Paper> Papers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RegisterRequest> RegisterRequests { get; set; }
    }
}
