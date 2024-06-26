using Amazon.Runtime;
using JobSeekerAssistant.Application.Interfaces.Services;
using JobSeekerAssistant.Application.Services;
using JobSeekerAssistant.Domain.Dtos;
using JobSeekerAssistant.Domain.Entities;
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
        private readonly HttpClient _httpClient = httpClientFactory.CreateClient("GptApi");
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
        public async Task<IResult> Post(string resumeId, [FromBody] PromptRequestDto promptRequestDto )
        {
            
            var resume = await _resumeService.GetByIdAsync(resumeId);

            if (resume is null)
                return Results.NotFound($"Resume with id: {resumeId} could not be found");

            var prompt =
                await promptService.GeneratePromptForLetterAsync(promptRequestDto.JobDto, resume,
                    promptRequestDto.Language);

            var systemMessage = new GptMessageDto()
            {
                Role = "system",
                Content = prompt
            };

            var gptDto = new GptDto()
            {
                Messages = new GptMessageDto[1] { systemMessage }
            };

            var response = await _httpClient.PostAsJsonAsync<GptDto>("/v1/chat/completions", gptDto);

            var result = await response.Content.ReadFromJsonAsync<GptAnswerDto>();

            var message = result.choices[0].message;

            var letter = new Letter() { Text = message.content, UserId = resume.UserId };

            await _letterService.AddAsync(letter);

            return Results.Ok(letter);

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
