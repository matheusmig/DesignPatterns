namespace DesignPatterns._1_DecoratorCompositeAdapter
{
    public interface IEventBus
    {
        void PublishEvent<T>(T @event)
            where T : IEvent;
    }
}
