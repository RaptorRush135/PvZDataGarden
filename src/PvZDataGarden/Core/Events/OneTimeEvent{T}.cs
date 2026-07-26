namespace PvZDataGarden.Events;

using System.Diagnostics.CodeAnalysis;

using MelonLoader;

public sealed class OneTimeEvent<T>
{
    private readonly MelonEvent<T> @event = new();

    private readonly MelonLogger.Instance logger;

    public OneTimeEvent()
        : this(Melon<Core>.Logger)
    {
    }

    public OneTimeEvent(MelonLogger.Instance logger)
    {
        ArgumentNullException.ThrowIfNull(logger);

        this.logger = logger;
    }

    public T? Value { get; private set; }

    public bool Disposed => this.@event.Disposed;

    [MemberNotNullWhen(true, nameof(Value))]
    public bool Invoked { get; private set; }

    public void Subscribe(Action<T> action)
    {
        if (this.Disposed)
        {
            return;
        }

        if (this.Invoked)
        {
            action.Invoke(this.Value);
            return;
        }

        this.@event.Subscribe(new(action));
    }

    public void Invoke(T value)
    {
        if (this.Invoked)
        {
            this.logger.Warning($"One-time event was already invoked ({typeof(T).Name})");
            return;
        }

        if (this.Disposed)
        {
            return;
        }

        this.Value = value;
        this.Invoked = true;
        this.@event.Invoke(value);
    }
}
