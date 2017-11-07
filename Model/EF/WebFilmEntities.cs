namespace Model.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class WebFilmEntities : DbContext
    {
        public WebFilmEntities()
            : base("name=WebFilmEntities")
        {
        }

        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Table_CaTaLog> Table_CaTaLog { get; set; }
        public virtual DbSet<Table_CauHinh> Table_CauHinh { get; set; }
        public virtual DbSet<Table_Comment> Table_Comment { get; set; }
        public virtual DbSet<Table_Fim> Table_Fim { get; set; }
        public virtual DbSet<Table_GiaoDienWed> Table_GiaoDienWed { get; set; }
        public virtual DbSet<table_QuangCao> table_QuangCao { get; set; }
        public virtual DbSet<Table_TheLoai> Table_TheLoai { get; set; }
        public virtual DbSet<Table_TinTuc> Table_TinTuc { get; set; }
        public virtual DbSet<Table_Trailer> Table_Trailer { get; set; }
        public virtual DbSet<Table_Username> Table_Username { get; set; }
        public virtual DbSet<Table_YeuCau> Table_YeuCau { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Table_Username>()
                .HasMany(e => e.Table_TinTuc)
                .WithOptional(e => e.Table_Username)
                .HasForeignKey(e => e.IDUserNane);
        }
    }
}
