using System;
namespace GetUserInput;

public class Input
{
    /* Get a number from user and handle all possible exceptions */
    public static int GetInt(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            
            try
            {
                return Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("\u001b[31mPlease, type a valid number.\u001b[0m");
            }
            catch (OverflowException)
            {
                Console.WriteLine($"\u001b[31mProvided number is too large or to small.\u001b[0m");
            }
            catch (Exception e)
            {
                Console.WriteLine("\u001b[31mSomething went wrong. Please try typing your input again!\u001b[0m");
            }
        }
    }
    
    public static double GetDouble(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            
            try
            {
                return Convert.ToDouble(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("\u001b[31mPlease, type a valid number.\u001b[0m");
            }
            catch (OverflowException)
            {
                Console.WriteLine($"\u001b[31mProvided number is too large or to small.\u001b[0m");
            }
            catch (Exception e)
            {
                Console.WriteLine("\u001b[31mSomething went wrong. Please try typing your input again!\u001b[0m");
            }
        }
    }

   

    public static int GetInRangeInt(int lowerBound, int upperBound, string prompt)
    {
        while (true)
        {
            Console.Write(prompt);

            try
            {
                int result = Convert.ToInt32(Console.ReadLine());

                if (result >= lowerBound && result <= upperBound)
                {
                    Console.Clear();
                    return result;
                }
                else
                {
                    Console.WriteLine($"\u001b[31mPlease, type a number in range {lowerBound}-{upperBound}.\u001b[0m");
                }
                    
            }
            catch (FormatException)
            {
                Console.WriteLine("\u001b[31mPlease, type a valid number.\u001b[0m");
            }
            catch (OverflowException)
            {
                Console.WriteLine($"\u001b[31mProvided number is too large or to small. Please, type a number in range {lowerBound}-{upperBound}.\u001b[0m");
            }
            catch (Exception e)
            {
                Console.WriteLine("\u001b[31mSomething went wrong. Please try typing your input again!\u001b[0m");
            }
        }
    }
    
    /* Get string */

    public static string GetString(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string userInput = Console.ReadLine();
            
            if(!string.IsNullOrWhiteSpace(userInput))
            {
                return userInput;
            }
            else
            {
                Console.WriteLine("\u001b[31mProvided string is empty, please type it again!\u001b[0m");
            }
        }
    }
    
    /* Get char */
    
    public static char GetChar(string prompt)
    {
        Console.Write(prompt);

        return Console.ReadLine()[0];
    }
    
    /* Get the path to a file or a directory and check if it exists */

    public static string GetFilePath(string prompt)
    {
        while (true)
        {
            string path = GetString(prompt);
            
            if (File.Exists(path))
            {
                return path;
            }
            else
            {
                Console.WriteLine("\u001b[31m Provided path to the file is incorrect. Please, try again!\u001b[0m");
            }
        }
    }

    public static string GetDirectory(string prompt)
    {
        while (true)
        {
            string path = GetString(prompt);
            
            if (Directory.Exists(path))
            {
                return path;
            }
            else
            {
                Console.WriteLine("\u001b[31mThe provided folder doesn't exist. Please provide the correct path to your folder!\u001b[0m");
            }
        }
    }
    
    /* Get agreement (yes or no) from the user */
    public static bool GetAgreement(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);

            // get input from user, force it lowercase and delete whitespaces
            string choice = Console.ReadLine().Trim().ToLower();

            if (choice == "y")
            {
                return true;
            }
            else if(choice == "n")
            {
                return false;
            }
            else
            {
                Console.WriteLine("\u001b[31mProvided input is incorrect. Please type \"y\" or \"n\"! \u001b[0m");
            }
                
        }
    }
}