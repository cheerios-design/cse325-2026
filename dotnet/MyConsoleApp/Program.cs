Console.WriteLine("Hello, World!");
Console.WriteLine("The current time is: " + DateTime.Now);
int daysUntilNewYear = (new DateTime(DateTime.Now.Year + 1, 1, 1) - DateTime.Now).Days;
Console.WriteLine("Days until New Year: " + daysUntilNewYear);
