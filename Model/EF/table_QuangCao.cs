namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class table_QuangCao
    {
        [Key]
        public int IDQuangCao { get; set; }

        public string NameQC { get; set; }

        public string DiaChiUrlQC { get; set; }

        public string AnhQC { get; set; }

        public int? IDUserName { get; set; }

        public virtual Table_Username Table_Username { get; set; }
    }
}
