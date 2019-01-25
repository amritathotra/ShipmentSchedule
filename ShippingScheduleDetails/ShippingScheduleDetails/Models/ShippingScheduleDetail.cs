namespace ShippingScheduleDetails.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ShippingScheduleDetail : DbContext
    {
        public ShippingScheduleDetail()
            : base("name=ShippingScheduleDetail")
        {
        }

        public virtual DbSet<AnalyteMatrix> AnalyteMatrices { get; set; }
        public virtual DbSet<MasterProtocolLookupTable> MasterProtocolLookupTables { get; set; }
        public virtual DbSet<Period> Periods { get; set; }
        public virtual DbSet<ShippingSchedule> ShippingSchedules { get; set; }
        public virtual DbSet<TimePoint> TimePoints { get; set; }
        public virtual DbSet<VisitDate> VisitDates { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnalyteMatrix>()
                .Property(e => e.Analyte)
                .IsUnicode(false);

            modelBuilder.Entity<AnalyteMatrix>()
                .Property(e => e.Matrix)
                .IsUnicode(false);

            modelBuilder.Entity<AnalyteMatrix>()
                .Property(e => e.Assessment)
                .IsUnicode(false);

            modelBuilder.Entity<AnalyteMatrix>()
                .Property(e => e.Shipping_Temp)
                .IsUnicode(false);

            modelBuilder.Entity<AnalyteMatrix>()
                .Property(e => e.SRFVersion)
                .IsUnicode(false);

            modelBuilder.Entity<AnalyteMatrix>()
                .Property(e => e.ESILTAT)
                .IsUnicode(false);
        }
    }
}
