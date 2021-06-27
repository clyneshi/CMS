namespace CMS.DAL.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

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
