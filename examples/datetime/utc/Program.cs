using System.Diagnostics;

Stopwatch timer = Stopwatch.StartNew();

DateTime dateTime = DateTime.UtcNow;
TimeSpan timeSpan = TimeSpan.FromHours(1);

System.Console.WriteLine($"UtcNow: {dateTime}");
System.Console.WriteLine($"Add: {dateTime.Add(timeSpan)}");
System.Console.WriteLine($"Add Days: {dateTime.AddDays(1)}");
System.Console.WriteLine($"Add Years: {dateTime.AddYears(1)}");
System.Console.WriteLine($"Date: {dateTime.Date}");
System.Console.WriteLine($"Day of Week: {dateTime.DayOfWeek}");
System.Console.WriteLine($"Time of Day: {dateTime.TimeOfDay}");
System.Console.WriteLine($"Kind: {dateTime.Kind}");
System.Console.WriteLine($"To Local Time: {dateTime.ToLocalTime()}");

timer.Stop();
System.Console.WriteLine("----------------------");
System.Console.WriteLine($"Timer: {timer.Elapsed}");
