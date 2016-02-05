using System.Threading.Tasks;
using System.Web.Http;
using PaymentServiceExample.Services;

namespace PaymentServiceExample.Controllers
{
    public class TestApiController : ApiController
    {
        private readonly IPaymentService _paymentService;

        public TestApiController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        // GET: api/TestApi
        public async Task<PaymentResponse> Get()
        {
            return await _paymentService.TakePaymentAsync(new PaymentRequest());
        }

        /*

        // GET: api/TestApi/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/TestApi
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/TestApi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/TestApi/5
        public void Delete(int id)
        {
        }

    */
    }
}
