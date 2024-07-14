using JobSeekerAssistant.Client.Application.Interfaces;
using JobSeekerAssistant.Client.Domain.Models;
using JobSeekerAssistant.Domain.Dtos;
using System.Net.Http.Json;

namespace JobSeekerAssistant.Client.Infrastructure.Services;

public class LetterService(IHttpClientFactory httpClientFactory) : ILetterService
{
    private readonly HttpClient _httpClient = httpClientFactory.CreateClient("JobSeekerAssistantApi");
    public async Task<IEnumerable<LetterModel>> GetAllByUserIdAsync(string id)
    {
        var response = await _httpClient.GetAsync($"Letter/all/{id}");

        if (response.IsSuccessStatusCode is false)
            return new List<LetterModel>();

        var result = await response.Content.ReadFromJsonAsync<List<LetterModel>>();

        return result!;
    }

    public async Task<IEnumerable<LetterModel>> GetAllByUserEmailAsync(string email)
    {
        var response = await _httpClient.GetAsync($"Letter/user/{email}");

        if (response.IsSuccessStatusCode is false)
            return new List<LetterModel>();

        var result = await response.Content.ReadFromJsonAsync<List<LetterModel>>();

        return result!;
    }

    public async Task<bool> UpdateAsync(string id, LetterModel model)
    {
        var response = await _httpClient.PutAsJsonAsync<LetterModel>($"letter/{id}", model);

        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteAsync(string id)
    {
        var response = await _httpClient.DeleteAsync($"letter/{id}");

        return response.IsSuccessStatusCode;
    }

    public async Task<LetterModel?> GenerateLetterAsync(string resumeId, PromptRequestDto promptRequest)
    {
        var response = await _httpClient.PostAsJsonAsync<PromptRequestDto>($"letter/generate/{resumeId}", promptRequest);

        if (response.IsSuccessStatusCode is false)
            return null;

        var result = await response.Content.ReadFromJsonAsync<LetterModel>();

        return result;
    }

    public async Task<LetterModel?> GetByIdAsync(string letterId)
    {
        var response = await _httpClient.GetAsync($"letter/{letterId}");

        if (response.IsSuccessStatusCode is false)
            return null;

        var result = await response.Content.ReadFromJsonAsync<LetterModel>();

        return result;
    }
}