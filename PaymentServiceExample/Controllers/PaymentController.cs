using System.Threading.Tasks;
using System.Web.Mvc;
using PaymentServiceExample.Models.Payment;
using PaymentServiceExample.Services;

namespace PaymentServiceExample.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        // GET: FormExample
        public ActionResult TakePayment()
        {
            return View();
        }

        // POST: FormExample/TakePayment
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> TakePayment(TakePaymentModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("GenericErrorKeyExample", "Generic error message example");
                return View(model);
            }

            var response = await _paymentService.TakePaymentAsync(new PaymentRequest
            {
                SellingPoint  = new SellingPoint(),
                CardPayment   = new CardPayment
                {
                    Name       = model.Name,
                    CardNumber = model.CardNumber
                }
            });

            if (response != null)
            {
                ViewBag.Success = true;
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CancelTakePayment()
        {
            return View("TakePayment");
        }
    }
}
