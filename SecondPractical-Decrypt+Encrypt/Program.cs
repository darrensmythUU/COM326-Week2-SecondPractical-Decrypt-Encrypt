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

        // Iterates throughout the char array version of userSentence to figure out how many blank spaces there are to figure out how many words there are
        char[] splitUserSentence = userSentence.ToCharArray();
        int numberOfWords = 0;
        for (int i = 0; i < splitUserSentence.Length; i++)
        {
            if (splitUserSentence[i] == ' ')
            {
                numberOfWords++;
            }
        }

        Console.WriteLine($"The sentence you inputted is: {userSentence}");
        Console.WriteLine($"Number of words: {numberOfWords}.");
    }
}