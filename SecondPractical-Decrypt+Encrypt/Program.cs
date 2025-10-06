/* Practical 2
 * Information: Methods Demo (Decrypt+Encrypt)
 * Version 1
 * Author: Darren Smyth
 * Date: October 6th 2026
 */

class Program
{
    public static void Main(string[] args)
    {
        CountWords();
    }

    public static void CountWords()
    {
        Console.WriteLine("Please enter a sentence while capitalizing each first letter of each word.");
        string userSentence = Console.ReadLine();
        string[] splitUserSentence = userSentence.Split(' ');
        int numberOfWords = splitUserSentence.Length;

        Console.WriteLine($"The sentence you inputted is: {userSentence}");
        Console.WriteLine($"Number of words: {numberOfWords}.");
    }
}