
DateTime date = DateTime.UtcNow;

Console.WriteLine("Kind Before Using Method: " + date.Kind);

// getting DateTime of same DateTime 
// instance using SpecifyKind() method
DateTime value = DateTime.SpecifyKind(date, DateTimeKind.Local);

Console.WriteLine($"Kind After Using Method: {value.Kind}");

Console.WriteLine($"DateTime is {value}");