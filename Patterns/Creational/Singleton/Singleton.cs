namespace DESIGN_PATTERN.Patterns.Creational.Singleton;

// Ensures only one instance of this class ever exists, and gives every
// caller access to that same instance.
public sealed class ConfigurationManager
{
    // Lazy<T> defers creation until first access and is thread-safe by
    // default, so we get lazy initialization without manual locking.
    private static readonly Lazy<ConfigurationManager> _instance =
        new(() => new ConfigurationManager());

    public static ConfigurationManager Instance => _instance.Value;

    public string Environment { get; private set; } = "Development";

    // Private constructor blocks callers from using 'new', which is what
    // forces everyone through Instance.
    private ConfigurationManager()
    {
        Console.WriteLine("ConfigurationManager created.");
    }

    public void SetEnvironment(string environment) => Environment = environment;
}
