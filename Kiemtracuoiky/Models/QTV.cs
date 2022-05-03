namespace Kiemtracuoiky.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("QTV")]
    public partial class QTV
    {
        public string id { get; set; }

        [Required]
        [StringLength(50)]
        public string Hoten { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string Matkhau { get; set; }
    }
}
