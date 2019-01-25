namespace ShippingScheduleDetails.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VisitDate")]
    public partial class VisitDate
    {
        public int ID { get; set; }

        public int? PeriodID { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CollectionDate { get; set; }

        public bool? ShippingStatus { get; set; }

        public int? PatientID { get; set; }

        public int? TimePointID { get; set; }

        public int? AnalyteMatrixID { get; set; }

        public bool? IsScreening { get; set; }
    }
}
