using System;
namespace JiggysCarRental.Models.ViewModel
{
	public class RentalViewModel
	{
		public Vehicle? Vehicle { get; set; }
		public virtual Rental? Rental { get; set; }
    }
}

