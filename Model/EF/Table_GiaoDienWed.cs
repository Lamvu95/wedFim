namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Table_GiaoDienWed
    {
        [Key]
        public int IDGiaoDien { get; set; }

        public string NameGiaoDien { get; set; }

        public string ThuMucChua { get; set; }
    }
}
