using System.Threading.Tasks;

namespace PaymentServiceExample.Services
{
    public class PaymentService: IPaymentService
    {
        public async Task<PaymentResponse> TakePaymentAsync(PaymentRequest request)
        {
            // TODO: Implementation goes here

            // await something here

            return new PaymentResponse();
        }
    }
}