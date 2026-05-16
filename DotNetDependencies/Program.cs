// See https://aka.ms/new-console-template for more information
using Humanizer;

Console.WriteLine("Quantities:");
HumanizeQuantities();

Console.WriteLine("\nDates/Time Manipulation:");
HumanizeDates();

static void HumanizeQuantities()
{
    Console.WriteLine("case".ToQuantity(0)); // 0 cases
    Console.WriteLine("case".ToQuantity(1)); // 1 case
    Console.WriteLine("case".ToQuantity(5)); // 5 cases
}

static void HumanizeDates()
{
    Console.WriteLine(DateTime.UtcNow.AddHours(-24).Humanize()); // a day ago
    Console.WriteLine(DateTime.UtcNow.AddHours(-2).Humanize()); // 2 hours ago
    Console.WriteLine(TimeSpan.FromDays(1).Humanize()); // a day
    Console.WriteLine(TimeSpan.FromDays(16).Humanize()); // 16 days
}