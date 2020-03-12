namespace CMS.DAL.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

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
