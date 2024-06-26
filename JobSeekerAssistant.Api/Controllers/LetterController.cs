using Amazon.Runtime;
using JobSeekerAssistant.Application.Interfaces.Services;
using JobSeekerAssistant.Application.Services;
using JobSeekerAssistant.Domain.Dtos;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JobSeekerAssistant.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LetterController(
        IResumeService<string> resumeService, 
        ILetterService<string> letterService,
        IPromptService promptService,
        IHttpClientFactory httpClientFactory) : ControllerBase
    {
        private readonly IResumeService<string> _resumeService = resumeService;
        private readonly ILetterService<string> _letterService= letterService;
        private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;
        // GET: api/<LetterController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost("generate/{resumeId}")]
        public void Post(string resumeId, [FromBody] JobDto jobDto)
        {

        }

        // PUT api/<LetterController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LetterController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
