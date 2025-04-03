namespace ApiPlatform.Kernel.Core.Results;

public interface IApplicationMessages
{
    IReadOnlyCollection<string> Messages { get; }
}

public class ApplicationMessages : IApplicationMessages
{
    private readonly List<string> _messages;

    public IReadOnlyCollection<string> Messages => _messages.AsReadOnly();

    private ApplicationMessages()
    {
        _messages = [];
    }

    public static ApplicationMessages Empty()
    {
        return new ApplicationMessages();
    }

    public ApplicationMessages Add(string message)
    {
        _messages.Add(message);
        return this;
    }

    public void Aggregate(IApplicationMessages applicationMessages)
    {
        _messages.AddRange(applicationMessages.Messages);
    }
}
