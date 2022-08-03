
TimeSpan time = new TimeSpan(1, 0, 0, 0, 0);
Console.WriteLine(time);
System.Console.WriteLine($"Day: {time.TotalDays}");
System.Console.WriteLine($"Hour: {time.TotalHours}");
System.Console.WriteLine($"Minute: {time.TotalMinutes}");
System.Console.WriteLine($"Second: {time.TotalSeconds}");
System.Console.WriteLine($"Milisecond: {time.TotalMilliseconds}");
System.Console.WriteLine("------------------------------------------------------");

// Add day, hour etc. after From

TimeSpan timeDay = TimeSpan.FromDays(5);
TimeSpan timeHour = TimeSpan.FromHours(1);
TimeSpan timeMinute = TimeSpan.FromMinutes(1);
TimeSpan timeSecond = TimeSpan.FromSeconds(1);
TimeSpan timeMiliSecond = TimeSpan.FromMilliseconds(1);
System.Console.WriteLine(timeDay);
System.Console.WriteLine(timeHour);
System.Console.WriteLine(timeMinute);
System.Console.WriteLine(timeSecond);
System.Console.WriteLine(timeMiliSecond);
System.Console.WriteLine("---------------------------------------------");

// Finds the difference between two dates
System.Console.WriteLine(timeDay.Subtract(timeHour));