using Microsoft.AspNetCore.Mvc;
using Stripe;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace farmaciaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagoLinea : ControllerBase
    {
        private const string StripeSecretKey = "sk_test_51NdQwhK5dimFIS68J0BDGlqeEky2d4YV2hWgTFMbCNkpxC2BDCrNpKqqt8ZRVqZfwV89Up13vTquP9HVHan0S1YO00VQvoA6GU";

        [HttpPost]
        public async Task<IActionResult> RealizarPago([FromBody] PagoRequest request)
        {
            try
            {
                // Configura la clave secreta de Stripe
                StripeConfiguration.ApiKey = StripeSecretKey;

                // Crea un cargo en Stripe
                var options = new PaymentIntentCreateOptions
                {
                    Amount = request.Amount,
                    Currency = "usd",
                    PaymentMethodTypes = new List<string> { "card" },
                };
                var service = new PaymentIntentService();
                var paymentIntent = await service.CreateAsync(options);

                // Confirma el PaymentIntent recién creado
                var confirmOptions = new PaymentIntentConfirmOptions
                {
                    PaymentMethod = request.Id
                };
                var confirmedIntent = await service.ConfirmAsync(paymentIntent.Id, confirmOptions);

                // Retorna la confirmación del pago
                return Ok(new { PaymentIntentId = confirmedIntent.Id, PaymentIntentStatus = confirmedIntent.Status });
            }
            catch (Exception ex)
            {
                return BadRequest(new { ErrorMessage = ex.Message });
            }


        }
    }
    public class PagoRequest
    {
        public long Amount { get; set; }
        public string Id { get; set; }
    }
};