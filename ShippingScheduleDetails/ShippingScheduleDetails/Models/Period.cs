namespace ShippingScheduleDetails.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Period")]
    public partial class Period
    {
        public int ID { get; set; }

        public int? AnalyteMatrixID { get; set; }

        [Column("Period")]
        public int? Period1 { get; set; }

        public int? PeriodLength { get; set; }
    }
}
