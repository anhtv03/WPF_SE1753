using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AutomobileLibrary.DataAccess
{
    public partial class Car
    {
        [Required]
        public int CarId { get; set; }

        [MaxLength(100)]
        public string CarName { get; set; } = null!;

        [MaxLength(100)]
        public string Manufacturer { get; set; } = null!;

        [DataType(DataType.Currency)] // chuyen ve tien te
        public decimal Price { get; set; }

        public int ReleasedYear { get; set; }
    }
}
