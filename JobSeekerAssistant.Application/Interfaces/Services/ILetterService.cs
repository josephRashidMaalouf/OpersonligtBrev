﻿using JobSeekerAssistant.Domain.Dtos;
using JobSeekerAssistant.Domain.Entities;

namespace JobSeekerAssistant.Application.Interfaces.Services;

public interface ILetterService<TUserId> : IService<Letter, string>
{
    Task<IEnumerable<Letter>> GetAllByUserIdAsync(TUserId userId);
    Task<IEnumerable<Letter>> GetAllByUserEmailAsync(string userEmail);


}