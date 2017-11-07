namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Table_CaTaLog
    {
        [Key]
        public int IDCatalog { get; set; }

        public string NameCatalog { get; set; }

        public string NameAscii { get; set; }

        public int? IDUserName { get; set; }

        public virtual Table_Username Table_Username { get; set; }
    }
}
