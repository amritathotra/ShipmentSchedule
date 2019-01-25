namespace ShippingScheduleDetails.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MasterProtocolLookupTable")]
    public partial class MasterProtocolLookupTable
    {
        public long ID { get; set; }

        [StringLength(255)]
        public string Sponsor { get; set; }

        [StringLength(255)]
        public string ProtocolOwner { get; set; }

        [StringLength(255)]
        public string Protocol { get; set; }

        public int? ProtocolFileSystemID { get; set; }

        public Guid? AcctivateID { get; set; }

        public bool isActive { get; set; }
    }
}
