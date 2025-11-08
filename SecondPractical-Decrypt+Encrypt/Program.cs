/* Practical 2
 * Information: Methods Demo (Decrypt+Encrypt)
 * Version 1
 * Author: Darren Smyth
 * Date: October 6th 2026
 */

using System.Text;

class Program
{
    public static void Main(string[] args)
    {
        CountWords();
        //Encrypt();
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

        // ASCII alphabet used to simply char rotations
        byte[] asciiBytes = Encoding.ASCII.GetBytes(userSentence);
        for (int i = 0; i < splitUserSentence.Length; i++)
        {
            // If ASCII code not a SPACE, rotates by 2. Done to stop all spaces becoming speechmarks
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
}