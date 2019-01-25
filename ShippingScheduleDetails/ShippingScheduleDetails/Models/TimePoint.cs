namespace ShippingScheduleDetails.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TimePoint")]
    public partial class TimePoint
    {
        public int ID { get; set; }

        public int? PeriodID { get; set; }

        public int? DayNominal { get; set; }

        public int? WeekNominal { get; set; }

        public int? MinuteNominal { get; set; }

        public int? HourNominal { get; set; }

        public int? AnalyteMatrixID { get; set; }

        [Column("Timepoint")]
        public int? Timepoint1 { get; set; }
    }
}
