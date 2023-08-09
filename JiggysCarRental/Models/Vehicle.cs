using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JiggysCarRental.Models
{
	public class Vehicle
	{
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Vehicle Name")]
        public string? VehicleName { get; set; }

        [DisplayName("Vehicle Image")]
        public string? Image { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Details")]
        public string? Details { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Rent Cost")]
        public string? RentCost { get; set; }

        [DisplayName("Number Of Passengers")]
        public int NumberOfPassengers { get; set; }

        [DisplayName("Number of Large Bags")]
        public int NumberOLargeBags { get; set; }

        [DisplayName("Usb Adapter")]
        public bool UsbAdapter { get; set; }

        [DisplayName("Reverse Camera")]
        public bool ReverseCamera { get; set; }


        [DisplayName("Push Start")]
        public bool PushStart { get; set; }

        [DisplayName("Bluetooth")]
        public bool Bluetooth { get; set; }

        [DisplayName("Tools Control")]
        public bool ToolsControl { get; set; }

        [DisplayName("Steering Control")]
        public bool SteeringControl { get; set; }

        [DisplayName("Thermal Control")]
        public bool ThermalControl { get; set; }

        [DisplayName("Heated Seat")]
        public bool HeatedSeat { get; set; }

        [DisplayName("Automatic Transition")]
        public bool AutomaticTransmission { get; set; }

        [DisplayName("4 Wheel Drive")]
        public bool FourWheelDrive { get; set; }

        [DisplayName("LeatherSeats")]
        public bool LeatherSeats { get; set; }

        [DisplayName("AUX")]
        public bool Aux { get; set; }

        [DisplayName("Start Date Available")]
        [DisplayFormat(DataFormatString = "{0:MMM-dd-yy}")]
        public DateTime StartDateAvailable { get; set; }

        [DisplayName("End Date Available")]
        [DisplayFormat(DataFormatString = "{0:MMM-dd-yy}")]
        public DateTime EndDateAvailable { get; set; }
    }
}

