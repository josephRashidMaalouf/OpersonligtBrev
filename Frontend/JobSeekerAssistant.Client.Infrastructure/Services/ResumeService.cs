using System.Net.Http.Json;
using JobSeekerAssistant.Client.Application.Interfaces;
using JobSeekerAssistant.Client.Domain.Models;

namespace JobSeekerAssistant.Client.Infrastructure.Services;

public class ResumeService(IHttpClientFactory httpFactory) : IResumeService
{
    private readonly HttpClient _httpClient = httpFactory.CreateClient("JobSeekerAssistantApi");
    public async Task<IEnumerable<ResumeModel>> GetAllByUserIdAsync(string id)
    {
        var response = await _httpClient.GetAsync($"Resume/all/{id}");

        if (response.IsSuccessStatusCode is false)
            return new List<ResumeModel>();

        var result = await response.Content.ReadFromJsonAsync<List<ResumeModel>>();

        return result!;
    }

    public async Task<IEnumerable<ResumeModel>> GetAllByUserEmailAsync(string email)
    {
        var response = await _httpClient.GetAsync($"Resume/user/{email}");

        if (response.IsSuccessStatusCode is false)
            return new List<ResumeModel>();

        var result = await response.Content.ReadFromJsonAsync<List<ResumeModel>>();

        return result!;
    }

    public async Task<bool> UpdateAsync(string id, ResumeModel model)
    {
        var response = await _httpClient.PutAsJsonAsync<ResumeModel>($"resume/{id}", model);

        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteAsync(string id)
    {
        var response = await _httpClient.DeleteAsync($"resume/{id}");

        return response.IsSuccessStatusCode;
    }

    public async Task<bool> PostAsync(ResumeModel resumeModel)
    {
        var getAll = await GetAllByUserEmailAsync(resumeModel.UserEmail);

        if (getAll.Any())
            return false;

        var response = await _httpClient.PostAsJsonAsync<ResumeModel>($"/resume", resumeModel);

        return response.IsSuccessStatusCode;
    }
}