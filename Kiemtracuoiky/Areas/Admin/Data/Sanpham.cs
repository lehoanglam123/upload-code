namespace Kiemtracuoiky.Areas.Admin.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sanpham")]
    public partial class Sanpham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sanpham()
        {
            Donhangs = new HashSet<Donhang>();
        }

        [StringLength(50)]
        public string id { get; set; }

        public int idDM { get; set; }

        [Required]
        [StringLength(50)]
        public string Tensanpham { get; set; }

        [StringLength(50)]
        public string Giamgia { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Ngaysanxuat { get; set; }

        [StringLength(500)]
        public string Thongtin { get; set; }

        [StringLength(20)]
        public string Hinhanh { get; set; }

        public virtual Danhmuc Danhmuc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Donhang> Donhangs { get; set; }
    }
}
