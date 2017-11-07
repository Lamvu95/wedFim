namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Table_CauHinh
    {
        [Key]
        public int IDCauHinh { get; set; }

        public string NameCauHinh { get; set; }

        public int? IDUserName { get; set; }

        public bool? GiaTriTrangThai { get; set; }

        public string SkinMD { get; set; }

        public int? SoTrangWed { get; set; }

        public string ThongBao { get; set; }

        public string CauHinhNow { get; set; }

        public virtual Table_Username Table_Username { get; set; }
    }
}
