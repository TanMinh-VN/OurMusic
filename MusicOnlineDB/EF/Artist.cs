namespace MusicOnlineDB.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Artist")]
    public partial class Artist
    {
        public int artistID { get; set; }

        [StringLength(200)]
        public string artistName { get; set; }

        [Column(TypeName = "date")]
        public DateTime? date { get; set; }

        public int? sex { get; set; }

        [StringLength(100)]
        public string nation { get; set; }

        [StringLength(500)]
        public string artistImg { get; set; }

        [StringLength(2000)]
        public string about { get; set; }
    }
}
