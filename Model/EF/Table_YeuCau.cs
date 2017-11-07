namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Table_YeuCau
    {
        [Key]
        public int IDYeuCau { get; set; }

        public string NameYeuCau { get; set; }

        public string DiaChiYeuCau { get; set; }

        public int? IDFim { get; set; }

        public virtual Table_Fim Table_Fim { get; set; }
    }
}
