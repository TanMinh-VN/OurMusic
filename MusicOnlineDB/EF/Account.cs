namespace MusicOnlineDB.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Account")]
    public partial class Account
    {
        public int accountID { get; set; }

        [Required]
        [StringLength(100)]
        public string username { get; set; }

        [Required]
        [StringLength(200)]
        public string password { get; set; }

        [Required]
        [StringLength(200)]
        public string fullname { get; set; }

        [Column(TypeName = "date")]
        public DateTime? date { get; set; }

        public int? type { get; set; }
    }
}
