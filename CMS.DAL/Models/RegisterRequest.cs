namespace CMS.DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RegisterRequest")]
    public partial class RegisterRequest
    {
        public int Id { get; set; }

        public int? confId { get; set; }

        [Required]
        [StringLength(20)]
        public string name { get; set; }

        [StringLength(20)]
        public string password { get; set; }

        [StringLength(10)]
        public string contact { get; set; }

        [Required]
        [StringLength(50)]
        public string email { get; set; }

        [Required]
        [StringLength(20)]
        public string status { get; set; }

        public int roleId { get; set; }

        public virtual Conference Conference { get; set; }

        public virtual Role Role { get; set; }
    }
}
