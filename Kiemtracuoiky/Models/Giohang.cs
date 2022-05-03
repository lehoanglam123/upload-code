namespace Kiemtracuoiky.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Giohang")]
    public partial class Giohang
    {
        public int id { get; set; }

        public int? idKH { get; set; }

        [StringLength(50)]
        public string idSP { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Ngaythem { get; set; }

        public int? Soluong { get; set; }

        public double? Tongtien { get; set; }

        public bool? Trangthai { get; set; }

        public virtual Sanpham Sanpham { get; set; }

        public virtual Khachhang Khachhang { get; set; }
    }
}
