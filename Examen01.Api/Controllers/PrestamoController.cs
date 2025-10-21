using System.Security.Cryptography.X509Certificates;
using Examen01.Api.Entities;
using ExamenPOO.Api.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Examen01.Api.Controllers
{
    [ApiController]
    [Route("api/prestamo")]
    public class PrestamoController : ControllerBase
    {
        private readonly PrestamoController _prestamo;
        public PrestamoController(PrestamoController prestamo)
        {
            _prestamo = prestamo;
        }

        public object CalcularCuota(PrestamoEntity p)
        {
            double P = p.Monto;
            double r = p.TasaInteresAnual / 12.0 / 100.0;
            int n = p.NumeroMeses;

            if (n <= 0) n = 1;
            double cuota = 0;
            if (r == 0)
            {
                cuota = P / n;
            }
            else
            {
                cuota = P * (r * Math.Pow(1 + r, n)) / (Math.Pow(1 + r, n) - 1);
            }

            return new
            {
                Monto = P,
                TasaInteresAnual = p.TasaInteresAnual,
                TasaInteresMensual = r,
                NumeroMeses = n,
                CuotaMensual = Math.Round(cuota, 6)
            };


        }

        [HttpPost("Calcular")]
        public IActionResult Calcular([FromBody]PrestamoEntity p)
        {
            
        }
    }
}