internal partial class EventNaming
{
    public EventNaming(string eventName, string argumentType)
    {
        EventName = eventName;
        ArgumentType = argumentType;
    }
    public readonly string EventName;
    public readonly string ArgumentType;
    public string MethodName => $"On{EventName}";
    public string InterfaceName => $"I{EventName}EventHandler";
    public string WithHandlerSuffix => $"{EventName}Handler";
}