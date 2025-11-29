
#:package DotNetEnv@3.1.1

using DotNetEnv;
using DotNetEnv.Configuration;
using Microsoft.Extensions.Configuration;

// Load .env file from current directory
Env.Load();

// Environment variables are now available to configuration
var myValue = Env.GetString("WelcomeMessage", "Default Value");
Console.WriteLine("Welcome Message:{0}", myValue);

var envMessage = Environment.GetEnvironmentVariable("EnvironmentMessage");
Console.WriteLine("Environment Message: {0}", envMessage);

var configuration = new ConfigurationBuilder()
    .AddDotNetEnv(".env", LoadOptions.TraversePath()) // Simply add the DotNetEnv configuration source!
    .Build();

var configValue = configuration["WelcomeMessage"];
Console.WriteLine("Configuration Welcome Message: {0}", configValue);

var dict = DotNetEnv.Env.NoEnvVars().Load();
foreach (var kvp in dict)
{
    Console.WriteLine($"{kvp.Key}={kvp.Value}");
}