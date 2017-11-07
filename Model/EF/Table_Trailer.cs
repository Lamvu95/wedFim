namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Table_Trailer
    {
        [Key]
        public int IDTrailer { get; set; }

        public string NameTrailer { get; set; }

        public string UrlTrailer { get; set; }

        public int? IDFim { get; set; }

        public virtual Table_Fim Table_Fim { get; set; }
    }
}
