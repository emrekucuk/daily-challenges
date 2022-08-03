void FindCommonDivisors(int lowerLimit, int upperLimit, int firstDivisor, int secondDivisor)
{
    for (int number = lowerLimit; number < upperLimit; number++)
    {
        bool isDivisor = false;

        if (number % firstDivisor == 0 && number % secondDivisor == 0)
            isDivisor = true;

        if (isDivisor)
            System.Console.WriteLine($"Common Divisor Number: {number}");

    }
}

System.Console.Write($"Lower Limit: ");
int firstNumber = Convert.ToInt32(Console.ReadLine());

System.Console.Write($"Upper Limit: ");
int secondNumber = Convert.ToInt32(Console.ReadLine());

System.Console.Write($"First Divisor: ");
int firstDivisor = Convert.ToInt32(Console.ReadLine());

System.Console.Write($"Second Divisor: ");
int secondDivisor = Convert.ToInt32(Console.ReadLine());

int lowerLimit = firstNumber;
int upperLimit = secondNumber;

// Control
if (firstNumber > secondNumber)
{
    lowerLimit = secondNumber;
    upperLimit = firstNumber;
}

FindCommonDivisors(lowerLimit, upperLimit, firstDivisor, secondDivisor);