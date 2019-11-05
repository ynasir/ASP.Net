using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Mortgage_Calculator.Models
{
    public class MortgageInfo
    {
        [Required]
        public double Principal { get; set; }

        [Required]
        [DisplayName("Rate of Interest(%)")]
        public double InterestRate { get; set; }

        [Required]
        [DisplayName("Duration in Years")]
        public double DurationYears { get; set; }
    }
}