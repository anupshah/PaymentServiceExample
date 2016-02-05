using System.Threading.Tasks;

namespace PaymentServiceExample.Services
{
    public interface IPaymentService
    {
        Task<PaymentResponse> TakePaymentAsync(PaymentRequest request);
    }

    public class PaymentRequest
    {
        public SellingPoint SellingPoint { get; set; }
        public CardPayment CardPayment { get; set; }
    }

    public class CardPayment
    {
        public string Name { get; set; }
        public long CardNumber { get; set; }
        public int CVV { get; set; }
    }

    public class SellingPoint
    {
    }

    public class PaymentResponse
    {
    }
}