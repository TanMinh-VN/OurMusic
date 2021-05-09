namespace MusicOnlineDB.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Personal")]
    public partial class Personal
    {
        public int personalID { get; set; }

        public int? accountID { get; set; }

        public int? songID { get; set; }

        public int? genreID { get; set; }

        public int? artistID { get; set; }
    }
}
