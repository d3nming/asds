namespace HouseholdRepair.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Requests
    {
        public int Id { get; set; }

        public DateTime? DateStart { get; set; }

        public DateTime? DateEnd { get; set; }

        [StringLength(50)]
        public string TypeEquipment { get; set; }

        [StringLength(50)]
        public string DescriptionRepair { get; set; }

        public int? UserId { get; set; }

        [StringLength(50)]
        public string RequestStatus { get; set; }

        public int? EmployeeId { get; set; }

        [StringLength(50)]
        public string Comments { get; set; }
    }
}
