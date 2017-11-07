namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Table_Comment
    {
        [Key]
        public int IDComment { get; set; }

        public string NameCommenFim { get; set; }

        public string NamePoster { get; set; }

        public string NDComment { get; set; }

        public int? IDFim { get; set; }

        public virtual Table_Fim Table_Fim { get; set; }
    }
}
