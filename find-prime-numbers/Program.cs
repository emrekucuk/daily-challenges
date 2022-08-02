void PrimeNumber(int firstNumber, int secondNumber)
{
    for (int number = firstNumber; number < secondNumber; number++)
    {
        int prime = 0;
        for (int i = 2; i < number; i++)
        {
            if (number % i == 0)
                prime++;
        }
        if (prime == 0)
            System.Console.WriteLine($"Prime Number: {number}");

    }
}

System.Console.Write($"Lower Limit: ");
int lowerLimit = Convert.ToInt32(Console.ReadLine());

System.Console.Write($"Upper Limit: ");
int upperLimit = Convert.ToInt32(Console.ReadLine());

int firstNumber = lowerLimit;
int secondNumber = upperLimit;

// Control
if (lowerLimit > upperLimit)
{
    firstNumber = upperLimit;
    secondNumber = lowerLimit;
}

PrimeNumber(firstNumber, secondNumber);
