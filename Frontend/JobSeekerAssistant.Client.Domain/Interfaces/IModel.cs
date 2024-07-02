namespace JobSeekerAssistant.Client.Domain.Interfaces;

public interface IModel<TId>
{
    public TId Id { get; set; }
}