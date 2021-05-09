namespace MusicOnlineDB.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Song")]
    public partial class Song
    {
        public int songID { get; set; }

        [StringLength(100)]
        public string songName { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? dayUp { get; set; }

        [StringLength(500)]
        public string songImg { get; set; }

        [StringLength(500)]
        public string songUrl { get; set; }

        public int? type { get; set; }

        public int? genreID { get; set; }
    }
}
