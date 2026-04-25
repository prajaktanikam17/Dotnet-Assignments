using System;

public class Program
{
    public static void Main(String[] args)
    {
        do
        {
            Console.WriteLine("\n---- MENU DRIVEN CONSOLE APP ----");
            Console.WriteLine("1. Character Occurrence in a String");
            Console.WriteLine("2. Reverse Each Word in a Given String");
            Console.WriteLine("3. Remove Duplicate Characters From a String");
            Console.WriteLine("4. Remove Duplicate Elements from an Array");
            Console.WriteLine("5. Find All Substrings of a Given String");
            Console.WriteLine("6. Exit");
            Console.Write("Enter your choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    CharacterOccurrence();
                    break;
                case 2:
                    ReverseEachWord();
                    break;
                case 3:
                    RemoveDuplicateCharacters();
                    break;
                case 4:
                    RemoveDuplicateElements();
                    break;
                case 5:
                    FindAllSubstrings();
                    break;
                case 6:
                    Console.WriteLine("Exiting the program. Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

        } while (true);

        static void CharacterOccurrence()
        {
            Console.Write("Enter a string: ");
            string input = Console.ReadLine();

            Console.Write("Enter a character to find its occurrence: ");
            char character = Console.ReadLine()[0];

            int count = 0;

            foreach (char c in input)
            {
                if (char.ToLower(c) == char.ToLower(character))
                {
                    count++;
                }
            }

            Console.WriteLine($"The character '{character}' occurs {count} times in the string.");
        }

        static void ReverseEachWord()
        {
            Console.Write("Enter a string: ");
            string input = Console.ReadLine();
            string[] words = input.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                char[] charArray = words[i].ToCharArray();
                Array.Reverse(charArray);
                words[i] = new string(charArray);
            }
            string result = string.Join(" ", words);
            Console.WriteLine($"Reversed each word: {result}");
        }

        static void RemoveDuplicateCharacters()
        {
            Console.Write("Enter a string: ");
            string input = Console.ReadLine();

            string result = "";

            foreach (char c in input)
            {
                if (!result.ToLower().Contains(char.ToLower(c)))
                {
                    result += c;
                }
            }

            Console.WriteLine($"String after removing duplicate characters: {result}");
        }

        static void RemoveDuplicateElements()
        {
            Console.Write("Enter number of elements: ");
            int size = int.Parse(Console.ReadLine());

            int[] arr = new int[size];

            Console.WriteLine("Enter array elements:");
            for (int i = 0; i < size; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("Array after removing duplicate elements:");

            for (int i = 0; i < size; i++)
            {
                bool isDuplicate = false;

                for (int j = 0; j < i; j++)
                {
                    if (arr[i] == arr[j])
                    {
                        isDuplicate = true;
                        break;
                    }
                }

                if (!isDuplicate)
                {
                    Console.Write(arr[i] + " ");
                }
            }

            Console.WriteLine();
        }

        static void FindAllSubstrings()
        {
            Console.Write("Enter a string: ");
            string input = Console.ReadLine();
            Console.WriteLine("All substrings of the given string:");
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = i + 1; j <= input.Length; j++)
                {
                    Console.WriteLine(input.Substring(i, j - i));
                }
            }
        }
    }
}
