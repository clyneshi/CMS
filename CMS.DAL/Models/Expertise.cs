namespace CMS.DAL.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

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
