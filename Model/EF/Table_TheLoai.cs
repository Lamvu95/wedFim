namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Table_TheLoai
    {
        [Key]
        public int IDTheLoai { get; set; }

        public string NameTheLoai { get; set; }

        public string MoTa { get; set; }

        public bool? HienThiTL { get; set; }
    }
}
