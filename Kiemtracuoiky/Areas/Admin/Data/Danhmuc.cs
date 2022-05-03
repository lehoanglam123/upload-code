namespace Kiemtracuoiky.Areas.Admin.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Danhmuc")]
    public partial class Danhmuc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Danhmuc()
        {
            Sanphams = new HashSet<Sanpham>();
        }

        public int id { get; set; }

        [StringLength(50)]
        public string tendanhmuc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sanpham> Sanphams { get; set; }
    }
}
