void FindCommonDivisors(int firstNumber, int secondNumber, int firstDivisor, int secondDivisor)
{

    for (int number = firstNumber; number < secondNumber; number++)
    {
        int divisor = 0;

        if (number % firstDivisor == 0 && number % secondDivisor == 0)
            divisor++;

        if (divisor != 0)
            System.Console.WriteLine($"Common Divisor Number: {number}");

    }
}

System.Console.Write($"Lower Limit: ");
int lowerLimit = Convert.ToInt32(Console.ReadLine());

System.Console.Write($"Upper Limit: ");
int upperLimit = Convert.ToInt32(Console.ReadLine());

System.Console.Write($"First Divisor: ");
int firstDivisor = Convert.ToInt32(Console.ReadLine());

System.Console.Write($"Second Divisor: ");
int secondDivisor = Convert.ToInt32(Console.ReadLine());

int firstNumber = lowerLimit;
int secondNumber = upperLimit;

// Control
if (lowerLimit > upperLimit)
{
    firstNumber = upperLimit;
    secondNumber = lowerLimit;
}

FindCommonDivisors(firstNumber, secondNumber, firstDivisor, secondDivisor);
