using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSLibrary.Model
{
    public class ReviewPaperModel
    {
        public int PaperId { get; set; }
        public string PaperTitle { get; set; }
        public int? PaperRating { get; set; }
    }
}
