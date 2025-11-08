/* Practical 2
 * Information: Methods Demo (Decrypt+Encrypt)
 * Version 1
 * Author: Darren Smyth
 * Date: October 6th 2025
 */

using System;
using System.Runtime.CompilerServices;
using System.Text;

class Program
{
    public static void Main(string[] args)
    {
        //CountWords();
        int option = 5; // 5 is chosen instead of 0 to stop environment from auto-exiting if user inputs invalid value
        bool exitBoolean = false;
        do
        {
            PrintEncryptDecryptMenu();
            option = InputOption(option);

            if (option == 0)
            {
                Environment.Exit(0);
            }
            else if (option == 1)
            {
                Encrypt();
            }
            else if (option == 2)
            {
                Decrypt();
            }
            option = 5;
        } while (!exitBoolean);
    }

    private static void PrintEncryptDecryptMenu()
    {
        // Prints a menu which allows the user to see the below options
        Console.WriteLine("----------------------------------------");
        Console.WriteLine("Main Menu");
        Console.WriteLine("Please select an option from below: ");
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
            Console.WriteLine("Please enter a valid number (0 - 2).");
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
        Console.WriteLine("Enter the desired string that you wish to encrypt.");
        string userSentence = Console.ReadLine();
        char[] splitUserSentence = userSentence.ToCharArray();

        int rotationAmount = NumberOfRotationsAcquirer(0) % 25;
        // Done so that rotationAmount can be reset at the start of each for loop at line 95

        // ASCII alphabet used to simplify char rotations
        byte[] asciiBytes = Encoding.ASCII.GetBytes(userSentence);
        bool isUpper = true;
        for (int i = 0; i < splitUserSentence.Length; i++)
        {
            // Only rotates forwards if the given ASCII value is a letter. Done to allow only letters to be encrypted
            if ((asciiBytes[i] >= 65 && asciiBytes[i] <= 90) || (asciiBytes[i] >= 97 && asciiBytes[i] <= 122))
            {
                isUpper = char.IsUpper(splitUserSentence[i]);
                // Checks if rotation amount would cause asciiBytes to loop over the alphabet
                if ((asciiBytes[i] + rotationAmount) > 90 && isUpper == true)
                {
                    asciiBytes[i] = 64;
                }
                else if ((asciiBytes[i] + rotationAmount) > 122 && isUpper == false)
                {
                    asciiBytes[i] = 96;
                }
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
        Console.WriteLine("Enter the desired string that you wish to decrypt.");
        string userSentence = Console.ReadLine();
        char[] splitUserSentence = userSentence.ToCharArray();

        int rotationAmount = NumberOfRotationsAcquirer(0) % 25;

        // ASCII alphabet used to simplify char rotations
        byte[] asciiBytes = Encoding.ASCII.GetBytes(userSentence);
        bool isUpper = true;
        for (int i = 0; i < splitUserSentence.Length; i++)
        {
            // Only rotates backwards if the given ASCII value is a letter. Done to allow only letters to be encrypted
            if ((asciiBytes[i] >= 65 && asciiBytes[i] <= 90) || (asciiBytes[i] >= 97 && asciiBytes[i] <= 122))
            {
                isUpper = char.IsUpper(splitUserSentence[i]);
                // Checks if rotation amount would cause asciiBytes to loop backwards over the alphabet
                if ((asciiBytes[i] - rotationAmount) < 65 && isUpper == true)
                {
                    asciiBytes[i] = 91;
                }
                else if ((asciiBytes[i] - rotationAmount) < 97 && isUpper == false)
                {
                    asciiBytes[i] = 123;
                }
                asciiBytes[i] -= (byte)rotationAmount;
                splitUserSentence[i] = (char)asciiBytes[i];
            }
        }
        string decryptedUserSentence = new string(splitUserSentence);

        Console.WriteLine($"The sentence you inputted is: {userSentence}");
        Console.WriteLine($"The decrypted sentence is now: {decryptedUserSentence}.");
    }

    public static int NumberOfRotationsAcquirer (int methodRotationAmount)
    {
        bool exitBoolean = false;
        do
        {
            try
            {
                methodRotationAmount = 0;
                Console.Write("Enter the desired number of rotations (0-100): ");
                methodRotationAmount = Convert.ToInt32(Console.ReadLine());

                if (methodRotationAmount < 0 || methodRotationAmount > 100)
                {
                    Console.WriteLine("You cannot enter a number less than 0 times or greater than 100. Please enter a valid number.");
                }
                else
                {
                    exitBoolean = true;
                }
            }
            catch (FormatException ex)
            {
                // Handles the case where the input is not valid
                Console.WriteLine("Please enter a valid number.");
            }
        } while (exitBoolean == false);

        return methodRotationAmount;
    }
}