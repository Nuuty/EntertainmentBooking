namespace EntertainmentBooking.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("member")]
    public partial class member
    {
        public int id { get; set; }

        [Required]
        [StringLength(20)]
        public string first_name { get; set; }

        [Required]
        [StringLength(50)]
        public string last_name { get; set; }

        public int band_id { get; set; }

        public virtual band band { get; set; }
    }
}
