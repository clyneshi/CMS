namespace CMS.DAL.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

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
