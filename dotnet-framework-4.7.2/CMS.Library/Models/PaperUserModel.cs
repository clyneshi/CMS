using System;

namespace CMS.Library.Models
{
    public class PaperUserModel
    {
        public int Id { get; set; }
        public string User { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime? SubmisionDate { get; set; }
        public string Length { get; set; }
        public string Status { get; set; }
    }
}
