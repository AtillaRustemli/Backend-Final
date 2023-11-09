using Microsoft.AspNetCore.Mvc;
using Stripe;

namespace Backend_Final.Controllers
{
    public class PaymentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Charge(string stripeEmail,string stripeToken)
        {
            var customers = new CustomerService();
            var charges=new ChargeService();
            var customer = customers.Create(new CustomerCreateOptions
            {
              Email = stripeEmail,
              Source = stripeToken,
            });
            var charge = charges.Create(new ChargeCreateOptions
            {
                Amount=500,
                Description="Hello",
                Currency="usd",
                Customer = customer.Id
            });
            if (charge.Status == "Succeeded")
            {
                string balanceTransition=charge.BalanceTransactionId;
                return View();
            }
            else
            {

            }
            return View();
        }
    }
}
