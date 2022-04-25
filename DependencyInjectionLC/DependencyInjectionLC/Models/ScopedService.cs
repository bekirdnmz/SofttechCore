namespace DependencyInjectionLC.Models
{
    public class ScopedService
    {
        public ScopedService(ITransientGuidGenerator transient, IScopedGuidGenerator scoped, ISingletonGuidGenerator singleton)
        {
            Transient = transient;
            Scoped = scoped;
            Singleton = singleton;
        }

        public ITransientGuidGenerator Transient { get; }
        public IScopedGuidGenerator Scoped { get; }
        public ISingletonGuidGenerator Singleton { get; }
    }
}
