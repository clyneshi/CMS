using System;
using System.Collections.Generic;

#nullable disable

namespace CMS.DAL.Models
{
    public partial class Expertise
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int KeywordId { get; set; }

        public virtual Keyword Keyword { get; set; }
        public virtual User User { get; set; }
    }
}
