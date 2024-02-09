using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using TasaCambioAPI.Repository.Contrato;
using System.Net.NetworkInformation;
using TasaCambioAPI.Utilidades;
using TasaCambioAPI.Models;

namespace TasaCambioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasaCambioController : ControllerBase
    {
        public readonly ITasaCambioService _tasaCambioService;
        public TasaCambioController(ITasaCambioService tasaCambioService)
        {
            _tasaCambioService = tasaCambioService;
        }

        [HttpPost]
        public async Task<IActionResult> postTasaMes()
        {
            DateTime fecha = DateTime.Now; //pasa la fecha de tu servidor

            bool tasa = await _tasaCambioService.ObtenerTasaCambio(fecha);
            if (!tasa)
            {
                return NotFound();
            }

            return Ok(tasa);
        }

        [HttpGet] 
        public async Task<IActionResult> getTasaCambioMes()
        {
            DateTime fecha = DateTime.Now;
            TasaCambio list = await _tasaCambioService.GetTasaCambio(fecha);
            if (list == null)
            {
                return NotFound();
            }
            return Ok(list);
        }

        //[HttpGet]
        //[Route("/getFechaActual")]
        //public IActionResult getFechaActual()
        //{
        //    DateTimeOffset? fechaActual = InternetTime.GetCurrentTime(); 

        //    if (fechaActual.HasValue) 
        //    {
        //        return Ok(fechaActual.Value); 
        //    }
        //    else
        //    {
        //        // Manejar el caso en que el DateTimeOffset sea nulo
        //        return BadRequest("No se pudo obtener la fecha actual");
        //    }
        //    //DateTimeOffset fechaActual = InternetTime.GetCurrentTime(); // Obtener la fecha actual como DateTimeOffset
        //    //DateTime fechaActualConvertida = fechaActual.DateTime; // Convertir DateTimeOffset a DateTime
        //    //return Ok(InternetTime.GetCurrentTime());
        //}
    }
}
