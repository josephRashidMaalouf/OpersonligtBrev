using JobSeekerAssistant.Application.Interfaces.Services;
using JobSeekerAssistant.Application.Services;
using JobSeekerAssistant.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JobSeekerAssistant.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ResumeController(IResumeService<string> resumeService) : ControllerBase
    {
        private readonly IResumeService<string> _resumeService = resumeService;
       
        [HttpGet("all/{userId}")]
        public async Task<IResult> GetAllByUserIdAsync(string userId)
        {
            var resumes = await _resumeService.GetAllByUserIdAsync(userId);

            return Results.Ok(resumes);
        }

        [HttpGet("{resumeId}")]
        public async Task<IResult> GetByIdAsync(string resumeId)
        {
            var resume = await _resumeService.GetByIdAsync(resumeId);

            return resume is null ? Results.NotFound(null) : Results.Ok(resume);
        }

        
        [HttpPost]
        public async Task<IResult> Post([FromBody] Resume resume)
        {
            await _resumeService.AddAsync(resume);

            return Results.Ok();
        }

       
        [HttpPut("{resumeId}")]
        public async Task<IResult> Put(string resumeId, [FromBody] Resume resume)
        {
            await _resumeService.UpdateAsync(resume, resumeId);

            return Results.Ok();
        }
// DELETE api/<Resume>/5
        [HttpDelete("{resumeId}")]
        public async Task<IResult> Delete(string resumeId)
        {
            await _resumeService.DeleteAsync(resumeId);

            return Results.Ok();
        }
    }
}
