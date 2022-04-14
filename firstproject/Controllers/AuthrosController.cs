using firstproject.data.services;
using firstproject.data.viewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace firstproject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthrosController : ControllerBase
    {
        private AuthorsService _authorsService;
        public AuthrosController(AuthorsService authorsService)
        {
            _authorsService = authorsService;
        }
        [HttpPost("add-author")]
        public IActionResult AddAuthor([FromBody] AuthorVM author)
        {
            _authorsService.AddAuthor(author);
            return Ok();
        }
        [HttpGet("get-author-with-books-by-id/{id}")]

        public IActionResult GetAuthorwithBooks(int id)
        {
            var response = _authorsService.GetAuthorwithBooks(id);
            return Ok(response);
        }
    }
}
