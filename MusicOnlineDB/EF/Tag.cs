namespace MusicOnlineDB.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tag")]
    public partial class Tag
    {
        public int tagID { get; set; }

        [StringLength(100)]
        public string tagName { get; set; }

        [StringLength(500)]
        public string tagImg { get; set; }
    }
}
