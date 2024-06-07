using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string text = "abcdf abc abcde abcd ab a bcd ef ghijk abcde abcd abc a a";

        // Заміна послідовностей букв
        string replacedText = ReplaceAlphabetSequences(text);
        Console.WriteLine("Замінений текст:");
        Console.WriteLine(replacedText);

        // Пошук слів, які зустрічаються лише один раз
        List<string> uniqueWords = FindUniqueWords(text);
        Console.WriteLine("\nСлова, які зустрічаються лише один раз:");
        foreach (string word in uniqueWords)
        {
            Console.WriteLine(word);
        }
    }

    static string ReplaceAlphabetSequences(string text)
    {
        return Regex.Replace(text, @"(?<=\w)(?=(\w)(?<!\1\1\1)\1\1\1)", "-");
    }

    static List<string> FindUniqueWords(string text)
    {
        string[] words = text.Split(new char[] { ' ', ',', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
        Dictionary<string, int> wordCounts = new Dictionary<string, int>();

        foreach (string word in words)
        {
            if (wordCounts.ContainsKey(word))
            {
                wordCounts[word]++;
            }
            else
            {
                wordCounts[word] = 1;
            }
        }

        List<string> uniqueWords = new List<string>();
        foreach (var pair in wordCounts)
        {
            if (pair.Value == 1)
            {
                uniqueWords.Add(pair.Key);
            }
        }

        return uniqueWords;
    }
}
