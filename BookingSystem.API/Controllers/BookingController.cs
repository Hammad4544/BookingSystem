using BookingSystem.Application.DTOS.BookingDTOS;
using BookingSystem.Application.InterfaceService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BookingSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {

            _bookingService = bookingService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBooking([FromBody] CreateBookingDto createBookingDto)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); 
                if (string.IsNullOrEmpty(userId))
                    return Unauthorized("User not authenticated");
                await _bookingService.CreateBookingAsync(userId, createBookingDto.TimeSlotId);
                return Ok("Booking created successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
