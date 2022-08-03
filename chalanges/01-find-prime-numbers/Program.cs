void FindPrimeNumbers(int lowerLimit, int upperLimit)
{
    for (int number = lowerLimit; number < upperLimit; number++)
    {
        bool isPrime = true;
        for (int i = 2; i < number; i++)
        {
            if (number % i == 0)
            {
                isPrime = false;
                break;
            }
        }
        if (isPrime)
            System.Console.WriteLine($"Prime Number: {number}");

    }
}

System.Console.Write($"Lower Limit: ");
int firstNumber = Convert.ToInt32(Console.ReadLine());

System.Console.Write($"Upper Limit: ");
int secondNumber = Convert.ToInt32(Console.ReadLine());

int lowerLimit = firstNumber;
int upperLimit = secondNumber;

// Control
if (firstNumber > secondNumber)
{
    lowerLimit = secondNumber;
    upperLimit = firstNumber;
}
FindPrimeNumbers(lowerLimit, upperLimit);