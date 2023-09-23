// See https://aka.ms/new-console-template for more information
using FirstWebAPIClient;

Console.WriteLine("API CLIENT");
EmployeeAPIClient.CallGetAllEmployee().Wait();
Console.ReadLine();
