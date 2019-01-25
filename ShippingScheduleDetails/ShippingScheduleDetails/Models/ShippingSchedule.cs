namespace ShippingScheduleDetails.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ShippingSchedule")]
    public partial class ShippingSchedule
    {
        public int ID { get; set; }

        public int? AnalyteMatrixID { get; set; }

        [StringLength(50)]
        public string ShippingType { get; set; }

        [StringLength(50)]
        public string ShippingDay { get; set; }

        public int? ShippingWeek { get; set; }

        public int? ShippingMonth { get; set; }

        public int? TriggerPoint { get; set; }

        public string Sponsor { get; set; }

        public int? MasterProtocolid { get; set; }

        [Display(Name = "Assessment")]
        public int AnalyteMatrix { get; set; }
    }
}
