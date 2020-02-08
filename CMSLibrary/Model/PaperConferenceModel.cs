using System;

namespace CMSLibrary.Model
{
    public class PaperConferenceModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public Nullable<System.DateTime> SubmisionDate { get; set; }
        public string Length { get; set; }
    }
}
