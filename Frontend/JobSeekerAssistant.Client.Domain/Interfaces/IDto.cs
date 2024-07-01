namespace JobSeekerAssistant.Client.Domain.Interfaces;

public interface IDto<TId>
{
    public TId Id { get; set; }
}