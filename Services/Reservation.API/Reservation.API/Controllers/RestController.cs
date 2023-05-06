using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reservation.API.Infrastructure;
using Reservation.API.Models;

namespace Reservation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestController : ControllerBase
    {
        private readonly IReservationService reservationService;

        public RestController(IReservationService ReservationService)
        {
            reservationService = ReservationService;
        }
        [HttpGet("{Id}")]
        public ReservationDTO Get(int id) 
        {
            return reservationService.GetResByBkgNumber(id);
        }
    }
}
