// See https://aka.ms/new-console-template for more information


using Configuration.Console;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

//Using Generic Host Approach
using IHost host = Host.CreateApplicationBuilder(args)
    .Build();

IConfiguration configuration = host.Services.GetRequiredService<IConfiguration>();

/*
 Code Using Configuration Builder. 
Comment Above code and uncomment below to run using configuration builder.
 */
//var configuration = new ConfigurationBuilder()
//    .AddJsonFile("appsettings.json")
//    .Build();

var settings = configuration.GetSection("AppSettings").Get<AppSettings>();

Console.WriteLine("Configuration accessed using Keys.");
//Access using Configuration Keys
Console.WriteLine($"ApiUrl = {configuration["AppSettings:ApiUrl"]}");
//Access using Configuration Keys - 2nd Level
Console.WriteLine($"Hostname = {configuration["AppSettings:EmailConfig:Hostname"]}");
//Access using Configuration Keys - Array Element
Console.WriteLine($"IpAddress = {configuration["AppSettings:IpAddress:1:Ip"]}"); // Index 1
Console.WriteLine($"Status = {configuration["AppSettings:IpAddress:0:Status"]}"); // Index 0

Console.WriteLine("\nConfiguration accessed using AppSettings Option");
Console.WriteLine($"ApiUrl = {settings.ApiUrl}");
Console.WriteLine($"Hostname = {settings.EmailConfig.Hostname}");
Console.WriteLine($"IpAddress = {settings.IpAddress[1].Ip}"); // Index 1
Console.WriteLine($"Status = {settings.IpAddress[0].Status}"); // Index 0

await host.RunAsync();





//Console.WriteLine(configuration["Key1"]);