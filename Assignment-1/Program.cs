using System;

public class Program
{
    public static void Main(string[] args)
    {
        do
        {
            Console.WriteLine("\n==== MENU DRIVEN CONSOLE APP ====");
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
            Console.Write("Enter your choice: ");

            int choice = int.Parse(Console.ReadLine() ?? "0");

            switch (choice)
            {
                case 1: // Even or Odd
                {
                    Console.Write("Enter a number: ");
                    int num = int.Parse(Console.ReadLine() ?? "0");

                    if (num % 2 == 0)
                    {
                        Console.WriteLine($"{num} is an even number.");
                    }
                    else
                    {
                        Console.WriteLine($"{num} is an odd number.");
                    }
                    break;
                }

                case 2: // Factorial
                {
                    Console.Write("Enter a number: ");
                    int num = int.Parse(Console.ReadLine() ?? "0");
                    long factorial = 1;

                    for (int i = 1; i <= num; i++)
                    {
                        factorial *= i;
                    }

                    Console.WriteLine($"Factorial of {num} is {factorial}");
                    break;
                }

                case 3: // Prime Check
                {
                    Console.Write("Enter a number: ");
                    int num = int.Parse(Console.ReadLine() ?? "0");

                    if (num <= 1)
                    {
                        Console.WriteLine($"{num} is not a prime number.");
                    }
                    else
                    {
                        bool isPrime = true;
                        int i = 2;

                        while (i <= num / 2)
                        {
                            if (num % i == 0)
                            {
                                isPrime = false;
                                break;
                            }
                            i++;
                        }

                        Console.WriteLine($"{num} is {(isPrime ? "a prime number." : "not a prime number.")}");
                    }
                    break;
                }

                case 4: // Reverse Number / String
                {
                    Console.WriteLine("1. Reverse Number");
                    Console.WriteLine("2. Reverse String");
                    Console.Write("Choose option: ");
                    int option = int.Parse(Console.ReadLine() ?? "0");

                    if (option == 1)
                    {
                        Console.Write("Enter a number: ");
                        int num = int.Parse(Console.ReadLine() ?? "0");
                        int rev = 0;

                        while (num != 0)
                        {
                            int digit = num % 10;
                            rev = rev * 10 + digit;
                            num /= 10;
                        }

                        Console.WriteLine($"Reversed Number: {rev}");
                    }
                    else if (option == 2)
                    {
                        Console.Write("Enter a string: ");
                        string input = Console.ReadLine() ?? "";

                        char[] arr = input.ToCharArray();
                        int mid = arr.Length / 2;
                        int len = arr.Length - 1;

                        for (int i = 0; i < mid; i++)
                        {
                            char temp = arr[i];
                            arr[i] = arr[len];
                            arr[len] = temp;
                            len--;
                        }

                        Console.Write("Reversed String: ");
                        for (int i = 0; i < arr.Length; i++)
                        {
                            Console.Write(arr[i]);
                        }
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("Invalid option!");
                    }
                    break;
                }

                case 5: // Palindrome Number / String
                {
                    Console.WriteLine("1. Palindrome Number");
                    Console.WriteLine("2. Palindrome String");
                    Console.Write("Choose option: ");
                    int palOption = int.Parse(Console.ReadLine() ?? "0");

                    if (palOption == 1)
                    {
                        Console.Write("Enter a number: ");
                        int num = int.Parse(Console.ReadLine() ?? "0");
                        int originalNum = num;
                        int rev = 0;

                        while (num != 0)
                        {
                            int digit = num % 10;
                            rev = rev * 10 + digit;
                            num /= 10;
                        }

                        if (originalNum == rev)
                        {
                            Console.WriteLine($"{originalNum} is a palindrome number.");
                        }
                        else
                        {
                            Console.WriteLine($"{originalNum} is not a palindrome number.");
                        }
                    }
                    else if (palOption == 2)
                    {
                        Console.Write("Enter a string: ");
                        string input = Console.ReadLine() ?? "";

                        char[] arr = input.ToCharArray();
                        int mid = arr.Length / 2;
                        int len = arr.Length - 1;
                        bool isPalindrome = true;

                        for (int i = 0; i < mid; i++)
                        {
                            if (arr[i] != arr[len])
                            {
                                isPalindrome = false;
                                break;
                            }
                            len--;
                        }

                        Console.WriteLine($"{input} is {(isPalindrome ? "a palindrome string." : "not a palindrome string.")}");
                    }
                    else
                    {
                        Console.WriteLine("Invalid option!");
                    }
                    break;
                }

                case 6: // Sum of Digits
                {
                    Console.Write("Enter a number: ");
                    int num = int.Parse(Console.ReadLine() ?? "0");
                    int sum = 0;

                    while (num != 0)
                    {
                        sum += num % 10;
                        num /= 10;
                    }

                    Console.WriteLine($"Sum of digits: {sum}");
                    break;
                }

                case 7: // Fibonacci Series
                {
                    Console.Write("Enter the number of terms: ");
                    int terms = int.Parse(Console.ReadLine() ?? "0");
                    int a = 0, b = 1;

                    Console.Write("Fibonacci Series: ");
                    for (int i = 0; i < terms; i++)
                    {
                        Console.Write(a + " ");
                        int temp = a + b;
                        a = b;
                        b = temp;
                    }
                    Console.WriteLine();
                    break;
                }

                case 8: // Maximum of 3 Numbers
                {
                    Console.Write("Enter first number: ");
                    int num1 = int.Parse(Console.ReadLine() ?? "0");

                    Console.Write("Enter second number: ");
                    int num2 = int.Parse(Console.ReadLine() ?? "0");

                    Console.Write("Enter third number: ");
                    int num3 = int.Parse(Console.ReadLine() ?? "0");

                    int max = (num1 > num2) ? (num1 > num3 ? num1 : num3) : (num2 > num3 ? num2 : num3);
                    Console.WriteLine("The maximum number is: " + max);
                    break;
                }

                case 9: // Simple Interest  
                {
                    Console.Write("Enter principal amount: ");
                    double principal = double.Parse(Console.ReadLine() ?? "0");

                    Console.Write("Enter rate of interest: ");
                    double rate = double.Parse(Console.ReadLine() ?? "0");

                    Console.Write("Enter time period: ");
                    double time = double.Parse(Console.ReadLine() ?? "0");

                    double simpleInterest = (principal * rate * time) / 100;
                    Console.WriteLine($"Simple Interest: {simpleInterest}");
                    break;
                }

                case 10: // Unit Converter
                {
                    Console.WriteLine("1. Celsius to Fahrenheit");
                    Console.WriteLine("2. Fahrenheit to Celsius");
                    Console.Write("Enter your choice: ");
                    int unitChoice = int.Parse(Console.ReadLine() ?? "0");

                    switch (unitChoice)
                    {
                        case 1:
                        {
                            Console.Write("Enter temperature in Celsius: ");
                            double celsius = double.Parse(Console.ReadLine() ?? "0");
                            double fahrenheit = (celsius * 9 / 5) + 32;
                            Console.WriteLine($"Temperature in Fahrenheit: {fahrenheit}");
                            break;
                        }
                        case 2:
                        {
                            Console.Write("Enter temperature in Fahrenheit: ");
                            double fahrenheitInput = double.Parse(Console.ReadLine() ?? "0");
                            double celsiusOutput = (fahrenheitInput - 32) * 5 / 9;
                            Console.WriteLine($"Temperature in Celsius: {celsiusOutput}");
                            break;
                        }
                        default:
                        {
                            Console.WriteLine("Invalid choice!");
                            break;
                        }
                    }
                    break;
                }

                case 0: // Exit
                {
                    Console.WriteLine("Exiting the application. Goodbye!");
                    return;
                }

                default: 
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
                }
            }
        }
        while (true);
    }
}