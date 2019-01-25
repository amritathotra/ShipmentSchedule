namespace ShippingScheduleDetails.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AnalyteMatrix")]
    public partial class AnalyteMatrix
    {
        public int ID { get; set; }

        public int? MasterProtocolID { get; set; }

        public string Analyte { get; set; }

        public string Matrix { get; set; }

        public string Assessment { get; set; }

        public string Shipping_Temp { get; set; }

        public string SRFVersion { get; set; }

        public string ESILTAT { get; set; }

        public bool isActive { get; set; }
    }
}
