using Stripe.Checkout;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebTruyen.Controllers
{
    public class PaymentController : Controller
    {
        // GET: Payment
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateCheckoutSession(int gia)
        {
            var options = new Stripe.Checkout.SessionCreateOptions
            {
                LineItems = new List<SessionLineItemOptions>
        {
          new SessionLineItemOptions
          {
            PriceData = new SessionLineItemPriceDataOptions
            {
              UnitAmount =(gia*100)/24000,
              Currency = "USD",
              ProductData = new SessionLineItemPriceDataProductDataOptions
              {
                Name = "Truyen",
              },

            },
            Quantity = 1,
          },
        },
                Mode = "payment",
                SuccessUrl = "https://localhost:44319/Payment/success",
                CancelUrl = "https://localhost:44319/Payment/cancel",
            };

            var service = new Stripe.Checkout.SessionService();
            Stripe.Checkout.Session session = service.Create(options);

            Response.Headers.Add("Location", session.Url);
            return new HttpStatusCodeResult(303);
        }
        [HttpPost]
        public ActionResult GetPayment()
        {
            var service = new PaymentIntentService();
            var options = new PaymentIntentCreateOptions
            {
                Amount = 1099,
                SetupFutureUsage = "off_session",
                Currency = "USD",
            };
            var paymentIntent = service.Create(options);
            return Json(paymentIntent);
        }

        public ActionResult success()
        {

            return View();
        }

        public ActionResult cancel()
        {

            return View();
        }

    }
}