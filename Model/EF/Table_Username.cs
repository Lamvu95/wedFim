namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Table_Username
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Table_Username()
        {
            Table_CaTaLog = new HashSet<Table_CaTaLog>();
            Table_CauHinh = new HashSet<Table_CauHinh>();
            table_QuangCao = new HashSet<table_QuangCao>();
            Table_TinTuc = new HashSet<Table_TinTuc>();
        }

        [Key]
        public int IDUserName { get; set; }

        public string NameUser { get; set; }
        [Required]
        public string PassUser { get; set; }
        [Required]
        [NotMapped]
        [Compare("PassUser",ErrorMessage ="ko trung")]
        public string ConfirmPassUser { get; set; }


        [Column(TypeName = "date")]
        public DateTime? NgaySinh { get; set; }

        [StringLength(255)]
        public string GioiTinh { get; set; }

        public int? SDT { get; set; }

        [StringLength(255)]
        public string Chucvu { get; set; }
        public string ImageUser { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Table_CaTaLog> Table_CaTaLog { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Table_CauHinh> Table_CauHinh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<table_QuangCao> table_QuangCao { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Table_TinTuc> Table_TinTuc { get; set; }
    }
}
