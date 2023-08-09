using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JiggysCarRental.Models
{
	public class Rental
	{
        [Key]
        public int TransactionId { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Vehicle Name")]
        public string? VehicleName { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [DisplayName("Rent Cost")]
        public string? RentCost { get; set; }

        [DisplayName("Pickup Date")]
        [DisplayFormat(DataFormatString = "{0:MMM-dd-yy}")]
        public DateTime PickupDate { get; set; }

        [DisplayName("Return Date")]
        [DisplayFormat(DataFormatString = "{0:MMM-dd-yy}")]
        public DateTime ReturnDate { get; set; }

        [DisplayName("GPS Navigation")]
        public bool GPSNavigation { get; set; }

        [DisplayName("Infant & Child Seats")]
        public bool InfantAndChildSeats { get; set; }
    }
}

