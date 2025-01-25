using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.ContactDto;
using SignalR.EntityLayer.Entities;

namespace SignalR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public IActionResult ListContact()
        {
            var value = _contactService.TGetListAll();
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateContact(CreateContactDto createContact)
        {
            Contact contact = new()
            {
                ContactEmail = createContact.ContactEmail,
                FooterDescription = createContact.FooterDescription,
                Location = createContact.Location,
                Phone = createContact.Phone,
            };
            if (ModelState.IsValid)
            {
                _contactService.TAdd(contact);
                return Ok("İletişim eklendi.");
            }
            return BadRequest(ModelState);
        }
        [HttpDelete]
        public IActionResult DeleteContact(int id)
        {
            var value = _contactService.TGetById(id);
            if (value != null)
            {
                _contactService.TDelete(value);
            }
            return BadRequest("İletişim bilgisi bulunamadı");
        }
        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDto updateContact)
        {
            Contact contact = new()
            {
                ContactID = updateContact.ContactID,
                ContactEmail = updateContact.ContactEmail,
                FooterDescription = updateContact.FooterDescription,
                Location = updateContact.Location,
                Phone = updateContact.Phone,
            };
            if (ModelState.IsValid)
            {
                _contactService.TUpdate(contact);
                return Ok("İletişim güncellendi.");
            }
            return BadRequest(ModelState);
        }
        [HttpGet("GetContact")]
        public IActionResult GetContact(int id)
        {
            var value = _contactService.TGetById(id);
            if (value != null)
            {
                return Ok(value);
            }
            return BadRequest("İletişim bilgisi bulunamadı.");
        }
    }
}
