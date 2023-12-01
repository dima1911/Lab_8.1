using System;

class ConfigurationManager
{
    private static ConfigurationManager instance;
    private string loggingMode;
    private string databaseConnection;

    private ConfigurationManager()
    {
        loggingMode = "DefaultLogging";
        databaseConnection = "DefaultConnection";
    }

    public static ConfigurationManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new ConfigurationManager();
            }
            return instance;
        }
    }

    public string LoggingMode
    {
        get { return loggingMode; }
        set
        {
            loggingMode = value;
            Console.WriteLine($"Logging mode set to: {loggingMode}");
        }
    }

    public string DatabaseConnection
    {
        get { return databaseConnection; }
        set
        {
            databaseConnection = value;
            Console.WriteLine($"Database connection set to: {databaseConnection}");
        }
    }

    public void SaveConfiguration()
    {
        // Збереження конфігурації
        Console.WriteLine("Configuration saved.");
    }
}

class Program
{
    static void Main()
    {
        ConfigurationManager configManager = ConfigurationManager.Instance;

        // Вивід поточних конфігураційних налаштувань
        Console.WriteLine($"Logging Mode: {configManager.LoggingMode}");
        Console.WriteLine($"Database Connection: {configManager.DatabaseConnection}");

        // Зміна конфігураційних параметрів через консольний інтерфейс
        Console.Write("Enter new logging mode: ");
        configManager.LoggingMode = Console.ReadLine();

        Console.Write("Enter new database connection: ");
        configManager.DatabaseConnection = Console.ReadLine();

        configManager.SaveConfiguration();

        // Перевіряємо, що зміни відображаються у єдиному екземплярі 
        ConfigurationManager anotherConfigManager = ConfigurationManager.Instance;
        Console.WriteLine($"Logging Mode from another instance: {anotherConfigManager.LoggingMode}");
        Console.WriteLine($"Database Connection from another instance: {anotherConfigManager.DatabaseConnection}");
    }
}
