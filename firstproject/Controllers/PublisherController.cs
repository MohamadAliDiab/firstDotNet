using firstproject.data.viewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using firstproject.data.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using firstproject.Exceptions;
using Microsoft.Extensions.Logging;

namespace firstproject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private PublishersService _publisherService;
        private readonly ILogger<PublisherController> _logger;
        public PublisherController(PublishersService publisherService, ILogger<PublisherController> logger)
        {
            _publisherService = publisherService;
            _logger = logger;
        }
        [HttpGet("get-all-publishers")]
        public IActionResult GetAllPublishers(string sortBy, string searchString, int pageNumber)
        {
            try
            {
                _logger.LogInformation("this is just a log in GetAllPublishers()");
                var _result = _publisherService.GetAllPublishers(sortBy, searchString, pageNumber);
                return Ok(_result);
            }
            catch (Exception)
            {

                return BadRequest("Sorry we could not load the publishers");
            }
        }

        [HttpPost("add-publisher")]
        public IActionResult AddPublisher([FromBody] PublisherVM publisher)
        {
            try
            {
                var newPublisher = _publisherService.AddPublisher(publisher);
                return Created(nameof(AddPublisher), newPublisher);
            }
            catch (PublisherNameException ex)
            {
                return BadRequest($"{ex.Message}, Publisher name: {ex.PublisherName}");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
        [HttpGet("get-publisher-books-with-authors/{id}")]
        public IActionResult GetPublisherData(int id)
        {
            var _response = _publisherService.GetPublisherData(id);
            return Ok(_response);
        }
        [HttpGet("get-publisher-by-id/{id}")]
        public IActionResult GetPublisherById(int id)
        {
            var _response = _publisherService.GetPublisherById(id);
            if(_response != null)
            {
                return Ok(_response);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpDelete("delete-publisher-by-id")]
        public IActionResult DeletePublisherById(int id)
        {
            try
            {
                _publisherService.DeletePublisherById(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
