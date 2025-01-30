using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.BookingDto;
using SignalR.EntityLayer.Entities;

namespace SignalR.Api.Controllers
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

        [HttpGet]
        public IActionResult ListBooking()
        {
            var value = _bookingService.TGetListAll();
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateBooking(CreateBookingDto createBooking)
        {
            if (ModelState.IsValid)
            {
                Booking booking = new Booking
                {
                    
                    Name = createBooking.Name,
                    Phone = createBooking.Phone,
                    Email = createBooking.Email,
                    PersonCount = createBooking.PersonCount,
                    Date = createBooking.Date
                };
                _bookingService.TAdd(booking);
                return Ok("Rezervasyon eklendi");
            }
            return BadRequest(ModelState);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            var value = _bookingService.TGetById(id);
            if (value != null)
            {
                _bookingService.TDelete(value);
                return Ok("Rezervasyon silindi");
            }
            return BadRequest("Rezervasyon bulunamadı");
        }

        [HttpPut]
        public IActionResult UpdateBooking(UpdateBookingDto updateBooking)
        {
            Booking booking= new Booking
            {
                BookingID = updateBooking.BookingID,
                Name = updateBooking.Name,
                Phone = updateBooking.Phone,
                Email = updateBooking.Email,
                PersonCount = updateBooking.PersonCount,
                Date = updateBooking.Date
            };
            if (ModelState.IsValid)
            {
                _bookingService.TUpdate(booking);
                return Ok("Rezervasyon güncellendi");
            }
            return BadRequest(ModelState);
        }
        [HttpGet("{id}")]
        public IActionResult GetBooking(int id)
        {
            var value = _bookingService.TGetById(id);
            if (value != null)
            {
                return Ok(value);
            }
            return BadRequest("Rezervasyon bulunamadı");
        }
    }
}
