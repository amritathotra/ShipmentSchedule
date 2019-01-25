using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Services.Description;

namespace ShipmentScheduleTracker.Models
{

    public class Shipping
    {
        public enum ShipType {
            [Description("Day of Collection")]
            DayOfCollection,

            Day,

            Weekly,

            Monthly,

            TimePoint
        }
        
    }
    
        


}