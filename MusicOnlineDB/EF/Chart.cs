namespace MusicOnlineDB.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Chart")]
    public partial class Chart
    {
        public int chartID { get; set; }

        public int? songID { get; set; }
    }
}
