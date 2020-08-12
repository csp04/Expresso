using ExpressoApi.Data;
using ExpressoApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Expresso.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationsController : ControllerBase
    {
        private ExpressoDbContext expressoDbContext;

        public ReservationsController(ExpressoDbContext expressoDbContext)
        {
            this.expressoDbContext = expressoDbContext;
        }

        [HttpPost]
        public IActionResult Post(Reservation reservation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            expressoDbContext.Reservations.Add(reservation);
            expressoDbContext.SaveChanges();
            return StatusCode((int)HttpStatusCode.Created);
        }
    }
}