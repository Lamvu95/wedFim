namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Table_TinTuc
    {
        [Key]
        public int IDTintuc { get; set; }

        public string NameTucTuc { get; set; }

        public string NameAciss { get; set; }

        public int? IDUserNane { get; set; }

        public virtual Table_Username Table_Username { get; set; }
    }
}
