using System.ComponentModel.DataAnnotations;

namespace PaymentServiceExample.Models.Payment
{
    public class TakePaymentModel
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }

        [Display(Name = "Card Number")]
        /* [CreditCard] - commented out as the JavaScript and server side validation seems to be different. Investigating. */
        [Required(ErrorMessage = "Card number is required")]
        [RegularExpression(@"^\d{13,19}$", ErrorMessage = "The card number must have between 13 and 19 digits only")]
        public long CardNumber { get; set; }

        [Range(1, 12, ErrorMessage = "Please select a month")]
        [Required(ErrorMessage = "Please select a month")]
        public int Month { get; set; }

        [Required(ErrorMessage = "Please select a year")]
        public int Year { get; set; }

        [Range(0, 999)]
        [Required]
        public int CVV { get; set; }
    }
}