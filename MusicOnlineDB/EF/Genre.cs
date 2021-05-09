namespace MusicOnlineDB.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Genre")]
    public partial class Genre
    {
        public int genreID { get; set; }

        [StringLength(200)]
        public string genreName { get; set; }

        [StringLength(500)]
        public string genreImg { get; set; }
    }
}
