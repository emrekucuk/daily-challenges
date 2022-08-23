int[] numbers = new int[] { 15, 13, 16, 12, 7, 24, 1, 30, 21 };

void Write(int[] numberArray)
{
    foreach (int number in numberArray)
    {
        System.Console.Write($"{number} ");
    }
    System.Console.WriteLine();
}


int[] ArraySorting(int[] numberArray)
{
    int temp;
    for (int i = 0; i < numberArray.Length - 1; i++)
    {
        for (int j = i + 1; j < numberArray.Length; j++)
        {
            if (numberArray[i] > numberArray[j])
            {
                System.Console.WriteLine($"Yer Degisti: {numberArray[i]} > {numberArray[j]}");
                temp = numberArray[j];
                numberArray[j] = numberArray[i];
                numberArray[i] = temp;
            }
        }
        System.Console.Write($"Yer Degistikten Sonra Dizi: ");
        Write(numberArray);
    }
    return numberArray;
}

System.Console.Write($"Dizinin Ilk Hali: ");
Write(numbers);

numbers = ArraySorting(numbers);

System.Console.Write($"Dizinin Son Hali: ");
Write(numbers);