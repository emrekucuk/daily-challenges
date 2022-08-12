int[] numbers = new int[] { 15, 13, 16, 12, 7, 24, 1, 30, 21 };

int[] ArraySorting(int[] numberArray)
{
    int temp;
    for (int i = 0; i < numberArray.Length - 1; i++)
    {
        for (int j = i + 1; j < numberArray.Length; j++)
        {
            if (numberArray[i] > numberArray[j])
            {
                temp = numberArray[j];
                numberArray[j] = numberArray[i];
                numberArray[i] = temp;
            }
        }
    }
    return numberArray;
}

numbers = ArraySorting(numbers);

foreach (int number in numbers)
{
    System.Console.Write($"{number} ");
}
