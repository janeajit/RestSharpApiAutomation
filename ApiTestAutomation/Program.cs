// See https://aka.ms/new-console-template for more information
using System.Text;

Console.WriteLine("Hello, World!");
///Reverse a string

string str = "Automation";
try
{
    string newString = new string(str.Reverse().ToArray());
    Console.WriteLine(newString);
}
catch(Exception e)
{
    Console.WriteLine(e);
}

////Palindrome Check

string word = "Madam";
for(int i = 0; i<word.Length;i++ )
{
    if (word[i] == word[word.Length-1])
    { }
}

