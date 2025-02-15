﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.SocialMediaDto;
using SignalR.EntityLayer.Entities;

namespace SignalR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialManagerController : ControllerBase
    {
        private readonly ISocialMediaService _socialMediaService;
        private readonly IMapper _mapper;

        public SocialManagerController(ISocialMediaService socialMediaService, IMapper mapper)
        {
            _socialMediaService = socialMediaService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ListSocialMedia()
        {
            var value =_mapper.Map<List<ResultSocialMediaDto>>(_socialMediaService.TGetListAll());
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateSocialMedia(CreateSocialMediaDto createSocialMedia)
        {
            SocialMedia socialMedia = new()
            {
                Title = createSocialMedia.Title,
                URL = createSocialMedia.URL,
                Icon = createSocialMedia.Icon,
            };
            if (ModelState.IsValid)
            {
                _socialMediaService.TAdd(socialMedia);
                return Ok("Sosyal medya eklendi.");
            }
            return BadRequest(ModelState);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteSocialMedia(int id)
        {
            var value = _socialMediaService.TGetById(id);
            if (value != null)
            {
                _socialMediaService.TDelete(value);
                return Ok("Sosyal medya silindi.");
            }
            return BadRequest("Sosyal medya bulunamadı.");
        }
        [HttpPut]
        public IActionResult UpdateSocialMedia(UpdateSocialMediaDto updateSocialMedia)
        {
            SocialMedia socialMedia = new()
            {
                SocialMediaID= updateSocialMedia.SocialMediaID,
                Title = updateSocialMedia.Title,
                URL = updateSocialMedia.URL,
                Icon = updateSocialMedia.Icon,
            };
            if (ModelState.IsValid)
            {
                _socialMediaService.TUpdate(socialMedia);
                return Ok("Sosyal medya güncellendi.");
            }
            return BadRequest(ModelState);
        }
        [HttpGet("{id}")]
        public IActionResult GetSocialMedia(int id)
        {
            var value = _socialMediaService.TGetById(id);
            if (value != null)
            {
                return Ok(value);
            }
            return BadRequest("Sosyal medya bulunamadı.");
        }

    }
}
