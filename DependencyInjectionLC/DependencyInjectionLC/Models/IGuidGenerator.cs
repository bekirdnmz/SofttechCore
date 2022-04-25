namespace DependencyInjectionLC.Models
{
    public interface IGuidGenerator
    {
         Guid Guid { get; }
    }

    public interface ISingletonGuidGenerator : IGuidGenerator
    {

    }

    public interface ITransientGuidGenerator : IGuidGenerator
    {

    }

    public interface IScopedGuidGenerator : IGuidGenerator
    {

    }

    public class Singleton : ISingletonGuidGenerator
    {
        private Guid guid;
        public Singleton()
        {
            guid = Guid.NewGuid();
        }
        public Guid Guid { get => guid; }
    }

    public class Scoped : IScopedGuidGenerator
    {
        private Guid guid;
        public Scoped()
        {
            guid = Guid.NewGuid();
        }
        public Guid Guid => guid;
    }

    public class Transient : ITransientGuidGenerator
    {
        private Guid guid;
        public Transient()
        {
            guid = Guid.NewGuid();

        }
        public Guid Guid => guid;
    }


}

