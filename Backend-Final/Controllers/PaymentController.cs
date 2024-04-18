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
        public IActionResult Charge(string stripeEmail,string stripeToken,double amount=1)
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
                Amount= (long)amount*100,
                Description="Hello",
                Currency="usd",
                Customer = customer.Id,
                ReceiptEmail=stripeEmail,
                Metadata=new Dictionary<string, string>()
                {
                    {"OrderId","111"},
                    {"Postcode","LEE111"}
                }
            });
            if (charge.Status == "Successed")
            {
                string balanceTransition=charge.BalanceTransactionId;
                return RedirectToAction("index", "home");
            }
            else
            {
                return RedirectToAction("index");
            }
           
        }
    }
}
