using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Entities
{
    public class MeasurementEntry : BaseEntity
    {
        public decimal Height { get; set; }
        public decimal Weight { get; set; }
        public decimal Shoulders { get; set; }
        public decimal Chest { get; set; }
        public decimal Waist { get; set; }
        public decimal Hip { get; set; }
        public decimal RelaxedRightArm { get; set; }
        public decimal RelaxedLeftArm { get; set; }
        public decimal ContractedRightArm { get; set; }
        public decimal ContractedLeftArm { get; set; }
        public decimal RightForearm { get; set; }
        public decimal LeftForearm { get; set; }
        public decimal RightThigh { get; set; }
        public decimal LeftThigh { get; set; }
        public decimal RightCalf { get; set; }
        public decimal LeftCalf { get; set; }
        public DateTime EntryDate { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}
