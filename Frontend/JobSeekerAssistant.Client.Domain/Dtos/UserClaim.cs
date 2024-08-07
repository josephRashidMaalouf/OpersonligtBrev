﻿namespace JobSeekerAssistant.Client.Domain.Dtos;

public class UserClaim
{
    public string Email { get; set; } = string.Empty;

    public bool IsEmailConfirmed { get; set; }

    public Dictionary<string, string> Claims { get; set; } = [];
}