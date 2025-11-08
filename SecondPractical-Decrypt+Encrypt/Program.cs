/* Practical 2
 * Information: Methods Demo (Decrypt+Encrypt)
 * Version 1
 * Author: Darren Smyth
 * Date: October 6th 2026
 */

using System;
using System.Runtime.CompilerServices;
using System.Text;

class Program
{
    public static void Main(string[] args)
    {
        //CountWords();
        int option = 0;
        bool exitBoolean = false;
        do
        {
            PrintEncryptDecryptMenu();
            option = InputOption(option);

            if (option == 0)
            {
                exitBoolean = true;
            }
            else if (option == 1)
            {
                Encrypt();
            }
            else
            {
                Decrypt();
            }
        } while (!exitBoolean);
        Environment.Exit(0);
    }

    private static void PrintEncryptDecryptMenu()
    {
        // Prints a menu which allows the user to see the below options
        Console.WriteLine("----------------------------------------");
        Console.WriteLine("Main Menu");
        Console.WriteLine("Select an option from below: ");
        Console.WriteLine("1 - Encrypt Text");
        Console.WriteLine("2 - Decrypt Text");
        Console.WriteLine("0 - End");
    }

    private static int InputOption(int methodOption)
    {
        try
        {
            // Stores the users choice as an integer variable and returns the integer value
            methodOption = Convert.ToInt32(Console.ReadLine());
        }
        catch (FormatException ex)
        {
            // Handles the case where the input is not valid
            Console.WriteLine("Please enter a valid number.");
        }
        return methodOption;
    }

    public static void CountWords()
    {
        Console.WriteLine("Enter a string while capitalizing the first letter of each word.");
        string userSentence = Console.ReadLine();
        // Splits string into array to allow for easy counting of number of words
        string[] splitUserSentence = userSentence.Split(' ');
        int numberOfWords = splitUserSentence.Length;

        Console.WriteLine($"The sentence you inputted is: {userSentence}");
        Console.WriteLine($"Number of words: {numberOfWords}.");
    }

    public static void Encrypt()
    {
        Console.WriteLine("Enter a string that you wish to encrypt.");
        string userSentence = Console.ReadLine();
        char[] splitUserSentence = userSentence.ToCharArray();

        Console.WriteLine("Enter the number of rotations you wish to encrypt by");
        int rotationAmount = Convert.ToInt32(Console.ReadLine());

        // ASCII alphabet used to simplify char rotations
        byte[] asciiBytes = Encoding.ASCII.GetBytes(userSentence);
        for (int i = 0; i < splitUserSentence.Length; i++)
        {
            // If ASCII code is not a SPACE, rotates forwards by 2. Done to stop all spaces becoming speechmarks
            if (asciiBytes[i] != 32)
            {
                asciiBytes[i] += (byte)rotationAmount;
                splitUserSentence[i] = (char)asciiBytes[i];
            }
        }
        string encryptedUserSentence = new string(splitUserSentence);

        Console.WriteLine($"The sentence you inputted is: {userSentence}");
        Console.WriteLine($"The encrypted sentence is now: {encryptedUserSentence}.");
    }

    public static void Decrypt()
    {
        Console.WriteLine("Enter a string that you wish to decrypt.");
        string userSentence = Console.ReadLine();
        char[] splitUserSentence = userSentence.ToCharArray();

        Console.WriteLine("Enter the number of rotations you wish to decrypt by");
        int rotationAmount = Convert.ToInt32(Console.ReadLine());

        // ASCII alphabet used to simplify char rotations
        byte[] asciiBytes = Encoding.ASCII.GetBytes(userSentence);
        for (int i = 0; i < splitUserSentence.Length; i++)
        {
            // If ASCII code is not a SPACE, rotates backwards by 2. Done to stop all spaces becoming speechmarks
            if (asciiBytes[i] != 32)
            {
                asciiBytes[i] -= (byte)rotationAmount;
                splitUserSentence[i] = (char)asciiBytes[i];
            }
        }
        string decryptedUserSentence = new string(splitUserSentence);

        Console.WriteLine($"The sentence you inputted is: {userSentence}");
        Console.WriteLine($"The decrypted sentence is now: {decryptedUserSentence}.");
    }
}