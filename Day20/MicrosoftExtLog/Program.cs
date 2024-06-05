
using System;
using Microsoft.Extensions.Logging;
class Program {
    static void Main()
    {
        ILoggerFactory loggerFactory = LoggerFactory.Create(builder => 
        {
            builder.AddConsole()
            .SetMinimumLevel(LogLevel.Debug);
        });

        ILogger logger = loggerFactory.CreateLogger<Program>();
        logger.LogDebug("This is a debug message");
        logger.LogInformation("This is an information message");
        //contoh utk di method create user: print tambah info
        logger.LogWarning("This is an warning message");
        logger.LogError("This is an error message");
        logger.LogCritical("This is a critical message");
    }
}