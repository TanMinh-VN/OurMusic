namespace MusicOnlineDB.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MyDB : DbContext
    {
        public MyDB()
            : base("name=MyDB")
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Artist> Artists { get; set; }
        public virtual DbSet<Chart> Charts { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Personal> Personals { get; set; }
        public virtual DbSet<Show> Shows { get; set; }
        public virtual DbSet<Song> Songs { get; set; }
        public virtual DbSet<SongTag> SongTags { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
