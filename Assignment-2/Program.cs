using System;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            try
            {
                Console.WriteLine("\n===== MENU DRIVEN CONSOLE APP =====");
                Console.WriteLine("1. Even or Odd");
                Console.WriteLine("2. Factorial");
                Console.WriteLine("3. Prime Check");
                Console.WriteLine("4. Reverse Number / String");
                Console.WriteLine("5. Palindrome Check");
                Console.WriteLine("6. Sum of Digits");
                Console.WriteLine("7. Fibonacci Series");
                Console.WriteLine("8. Maximum of 3 Numbers");
                Console.WriteLine("9. Simple Interest");
                Console.WriteLine("10. Unit Converter");
                Console.WriteLine("0. Exit");

                int choice = ReadInt("Enter your choice: ");

                switch (choice)
                {
                    case 1:
                    {
                        int num = ReadInt("Enter a number: ");
                        bool result = IsEven(num);
                        Console.WriteLine($"{num} is {(result ? "Even" : "Odd")}.");
                        break;
                    }

                    case 2:
                    {
                        int num = ReadInt("Enter a number: ");
                        if (num < 0)
                        {
                            Console.WriteLine("Factorial is not defined for negative numbers.");
                        }
                        else
                        {
                            long fact = CalculateFactorial(num);
                            Console.WriteLine($"Factorial of {num} is {fact}");
                        }
                        break;
                    }

                    case 3:
                    {
                        int num = ReadInt("Enter a number: ");
                        bool result = IsPrime(num);
                        Console.WriteLine($"{num} is {(result ? "a Prime number." : "not a Prime number.")}");
                        break;
                    }

                    case 4:
                    {
                        ReverseNumberOrString();
                        break;
                    }

                    case 5:
                    {
                        PalindromeCheck();
                        break;
                    }

                    case 6:
                    {
                        int num = ReadInt("Enter a number: ");
                        int sum = GetSumOfDigits(num);
                        Console.WriteLine($"Sum of digits = {sum}");
                        break;
                    }

                    case 7:
                    {
                        int n = ReadInt("Enter number of terms: ");
                        if (n <= 0)
                        {
                            Console.WriteLine("Please enter a positive number.");
                        }
                        else
                        {
                            PrintFibonacci(n);
                        }
                        break;
                    }

                    case 8:
                    {
                        int a = ReadInt("Enter first number: ");
                        int b = ReadInt("Enter second number: ");
                        int c = ReadInt("Enter third number: ");

                        int max = GetMaxOfThree(a, b, c);
                        Console.WriteLine($"Maximum number is: {max}");
                        break;
                    }

                    case 9:
                    {
                        double principal = ReadDouble("Enter Principal Amount: ");
                        double rate = ReadDouble("Enter Rate of Interest: ");
                        double time = ReadDouble("Enter Time (in years): ");

                        double si = CalculateSimpleInterest(principal, rate, time);
                        Console.WriteLine($"Simple Interest = {si}");
                        break;
                    }

                    case 10:
                    {
                        UnitConverter();
                        break;
                    }

                    case 0:
                    {
                        Console.WriteLine("Exiting program...");
                        return;
                    }

                    default:
                    {
                        Console.WriteLine("Invalid choice! Try again.");
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected error occurred: " + ex.Message);
            }
        }
    }

    // ---------------- INPUT METHODS ----------------
    static int ReadInt(string message)
    {
        int value;
        while (true)
        {
            Console.Write(message);
            if (int.TryParse(Console.ReadLine(), out value))
            {
                return value;
            }
            Console.WriteLine("Invalid input! Please enter a valid integer.");
        }
    }

    static double ReadDouble(string message)
    {
        double value;
        while (true)
        {
            Console.Write(message);
            if (double.TryParse(Console.ReadLine(), out value))
            {
                return value;
            }
            Console.WriteLine("Invalid input! Please enter a valid number.");
        }
    }

    // ---------------- LOGIC METHODS ----------------
    static bool IsEven(int num)
    {
        return num % 2 == 0;
    }

    static long CalculateFactorial(int num)
    {
        long fact = 1;
        for (int i = 1; i <= num; i++)
        {
            fact *= i;
        }
        return fact;
    }

    static bool IsPrime(int num)
    {
        if (num <= 1)
            return false;

        for (int i = 2; i <= Math.Sqrt(num); i++)
        {
            if (num % i == 0)
                return false;
        }

        return true;
    }

    static int ReverseNumber(int num)
    {
        int reversed = 0;

        while (num != 0)
        {
            int digit = num % 10;
            reversed = reversed * 10 + digit;
            num /= 10;
        }

        return reversed;
    }

    static string ReverseString(string input)
    {
        char[] arr = input.ToCharArray();
        Array.Reverse(arr);
        return new string(arr);
    }

    static void ReverseNumberOrString()
    {
        Console.WriteLine("1. Reverse Number");
        Console.WriteLine("2. Reverse String");
        int option = ReadInt("Choose option: ");

        if (option == 1)
        {
            int num = ReadInt("Enter a number: ");
            int reversed = ReverseNumber(num);
            Console.WriteLine($"Reversed Number: {reversed}");
        }
        else if (option == 2)
        {
            Console.Write("Enter a string: ");
            string input = Console.ReadLine() ?? "";
            string reversed = ReverseString(input);

            Console.WriteLine($"Reversed String: {reversed}");
        }
        else
        {
            Console.WriteLine("Invalid option!");
        }
    }

    static bool IsPalindromeNumber(int num)
    {
        return num == ReverseNumber(num);
    }

    static bool IsPalindromeString(string input)
    {
        string lowerInput = input.ToLower();
        string reversed = ReverseString(lowerInput);
        return lowerInput == reversed;
    }

    static void PalindromeCheck()
    {
        Console.WriteLine("1. Palindrome Number");
        Console.WriteLine("2. Palindrome String");
        int option = ReadInt("Choose option: ");

        if (option == 1)
        {
            int num = ReadInt("Enter a number: ");
            bool result = IsPalindromeNumber(num);

            Console.WriteLine($"{num} is {(result ? "a Palindrome Number." : "not a Palindrome Number.")}");
        }
        else if (option == 2)
        {
            Console.Write("Enter a string: ");
            string input = Console.ReadLine() ?? "";
            bool result = IsPalindromeString(input);

            Console.WriteLine($"{input} is {(result ? "a Palindrome String." : "not a Palindrome String.")}");
        }
        else
        {
            Console.WriteLine("Invalid option!");
        }
    }

    static int GetSumOfDigits(int num)
    {
        num = Math.Abs(num);
        int sum = 0;

        while (num != 0)
        {
            sum += num % 10;
            num /= 10;
        }

        return sum;
    }

    static void PrintFibonacci(int n)
    {
        int a = 0, b = 1;
        Console.Write("Fibonacci Series: ");

        for (int i = 0; i < n; i++)
        {
            Console.Write(a + " ");
            int temp = a + b;
            a = b;
            b = temp;
        }

        Console.WriteLine();
    }

    static int GetMaxOfThree(int a, int b, int c)
    {
        return Math.Max(a, Math.Max(b, c));
    }

    static double CalculateSimpleInterest(double principal, double rate, double time)
    {
        return (principal * rate * time) / 100;
    }

    static void UnitConverter()
    {
        Console.WriteLine("1. Kilometers to Meters");
        Console.WriteLine("2. Celsius to Fahrenheit");
        Console.WriteLine("3. Kilograms to Grams");
        int option = ReadInt("Choose conversion: ");

        switch (option)
        {
            case 1:
            {
                double km = ReadDouble("Enter kilometers: ");
                Console.WriteLine($"{km} km = {ConvertKmToMeters(km)} meters");
                break;
            }

            case 2:
            {
                double c = ReadDouble("Enter Celsius: ");
                Console.WriteLine($"{c}°C = {ConvertCelsiusToFahrenheit(c)}°F");
                break;
            }

            case 3:
            {
                double kg = ReadDouble("Enter kilograms: ");
                Console.WriteLine($"{kg} kg = {ConvertKgToGrams(kg)} grams");
                break;
            }

            default:
            {
                Console.WriteLine("Invalid conversion option!");
                break;
            }
        }
    }

    static double ConvertKmToMeters(double km)
    {
        return km * 1000;
    }

    static double ConvertCelsiusToFahrenheit(double c)
    {
        return (c * 9 / 5) + 32;
    }

    static double ConvertKgToGrams(double kg)
    {
        return kg * 1000;
    }
}