namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Table_Fim
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Table_Fim()
        {
            Table_Comment = new HashSet<Table_Comment>();
            Table_Trailer = new HashSet<Table_Trailer>();
            Table_YeuCau = new HashSet<Table_YeuCau>();
        }

        [Key]
        public int IDFim { get; set; }

        public string NameFim { get; set; }

        public int? IDTheLoai { get; set; }

        public string TenDienVien { get; set; }

        public string AnhDienVien { get; set; }

        public string ThongTinBoFim { get; set; }

        public string DaoDien { get; set; }

        public int? NamSanXuat { get; set; }

        public string NoiSanXuat { get; set; }

        public string Rating { get; set; }

        public int? IDUserName { get; set; }

        public string AnhPhim { get; set; }

        public string Slide { get; set; }

        public string url { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Table_Comment> Table_Comment { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Table_Trailer> Table_Trailer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Table_YeuCau> Table_YeuCau { get; set; }
    }
}
