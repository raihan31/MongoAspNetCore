using System.Collections.Generic;
using newApp.Models;
using newApp.Services;
using Microsoft.AspNetCore.Mvc;
using newApp.Repository;
using System.Threading.Tasks;

namespace newApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorRepository _authorRepository;
        public AuthorsController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }
        // GET: api/book
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return new ObjectResult(await _authorRepository.GetAllAuthors());
        }
        // GET: api/book/name
        [HttpGet("{name}", Name = "Get")]
        public async Task<IActionResult> Get(string Id)
        {
            var author = await _authorRepository.GetAuthor(Id);
            if (author == null)
                return new NotFoundResult();
            return new ObjectResult(author);
        }
        // POST: api/book
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Author author)
        {
            await _authorRepository.Create(author);
            return new OkObjectResult(author);
        }
        // PUT: api/book/5
        [HttpPut("{name}")]
        public async Task<IActionResult> Put(string Id, [FromBody]Author author)
        {
            var bookFromDb = await _authorRepository.GetAuthor(Id);
            if (bookFromDb == null)
                return new NotFoundResult();
            author.Id = bookFromDb.Id;
            await _authorRepository.Update(author);
            return new OkObjectResult(author);
        }
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{name}")]
        public async Task<IActionResult> Delete(string Id)
        {
            var bookFromDb = await _authorRepository.GetAuthor(Id);
            if (bookFromDb == null)
                return new NotFoundResult();
            await _authorRepository.Delete(Id);
            return new OkResult();
        }
    }
}