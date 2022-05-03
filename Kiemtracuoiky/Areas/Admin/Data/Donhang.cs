namespace Kiemtracuoiky.Areas.Admin.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Donhang")]
    public partial class Donhang
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idKH { get; set; }

        [StringLength(50)]
        public string idSP { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Ngaylap { get; set; }

        public int? Soluong { get; set; }

        public double? GiaSP { get; set; }

        public virtual Khachhang Khachhang { get; set;}

        public virtual Sanpham Sanpham { get; set; }
    }
}
