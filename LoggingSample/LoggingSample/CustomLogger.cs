
using System.Collections.Concurrent;

namespace LoggingSample
{
    public class CustomLogger
    {
    }

    public class ColoredConsoleLoggerConfiguration
    {
        public LogLevel LogLevel { get; set; } = LogLevel.Warning;
        public int EventId { get; set; } = 0;
        public ConsoleColor Color { get; set; } = ConsoleColor.Red;
    }

    public class ColoredConsoleLoggerProvider : ILoggerProvider
    {
        ColoredConsoleLoggerConfiguration config;
        ConcurrentDictionary<string, ColoredConsoleLogger> loggers = new ConcurrentDictionary<string, ColoredConsoleLogger>();

        public ColoredConsoleLoggerProvider(ColoredConsoleLoggerConfiguration configuration)
        {
            this.config = configuration;

        }

        public ILogger CreateLogger(string categoryName)
        {
            return loggers.GetOrAdd(categoryName, name => new ColoredConsoleLogger(name, config));

        }

        public void Dispose()
        {
           loggers.Clear();
        }
    }

    public class ColoredConsoleLogger : ILogger
    {
        private readonly string name;
        private readonly ColoredConsoleLoggerConfiguration configuration;

        public ColoredConsoleLogger(string name, ColoredConsoleLoggerConfiguration configuration)
        {
            this.name = name;
            this.configuration = configuration;
        }
        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return logLevel == configuration.LogLevel;
        }

        private static object _lock = new object();
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }
            lock (_lock)
            {
                if (configuration.EventId == 0 || configuration.EventId == eventId.Id)
                {
                    var color = Console.ForegroundColor;
                    Console.ForegroundColor = configuration.Color;
                    Console.Write($"{logLevel} - {eventId.Id} - {name} - ");
                    Console.Write($"{formatter(state, exception)}\n");
                    Console.ForegroundColor = color;
                }
            }
        }
    }

}
