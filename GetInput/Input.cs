using System;
using System.Drawing;
using System.Globalization;
using Colorful;
using Console = Colorful.Console;

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
                Console.WriteLine("Please, type a valid number.", Color.Red);
            }
            catch (OverflowException)
            {
                Console.WriteLine("Provided number is too large or too small.", Color.Red);
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong. Please try typing your input again!", Color.Red);
            }
        }
    }
    
    public static double GetDouble(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);

            // Get number from user and replace separator for easier parse to double
            string number = Console.ReadLine().Replace(',', '.');
            
            try
            {
                return double.Parse(number, CultureInfo.InvariantCulture);
            }
            catch (FormatException)
            {
                Console.WriteLine("Please, type a valid number.", Color.Red);
            }
            catch (OverflowException)
            {
                Console.WriteLine("Provided number is too large or too small.", Color.Red);
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong. Please try typing your input again!", Color.Red);
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
                    Console.WriteLine($"Please, type a number in range {lowerBound}-{upperBound}.", Color.Red);
                }
                    
            }
            catch (FormatException)
            {
                Console.WriteLine("Please, type a valid number.", Color.Red);
            }
            catch (OverflowException)
            {
                Console.WriteLine($"Provided number is too large or too small. Please, type a number in range {lowerBound}-{upperBound}.", Color.Red);
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong. Please try typing your input again!", Color.Red);
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
                Console.WriteLine("Provided string is empty, please type it again!", Color.Red);
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
                Console.WriteLine("Provided path to the file is incorrect. Please, try again!", Color.Red);
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
                Console.WriteLine("The provided folder doesn't exist. Please provide the correct path to your folder!", Color.Red);
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
                Console.WriteLine("Provided input is incorrect. Please type \"y\" or \"n\"!", Color.Red);
            }
                
        }
    }

    /* get current date in specified format e.g "yyyy-MM-dd", "M/d/yyyy" or "yyyy-MM-dd hh:mm:ss"*/
    public static string GetCurrentFormatedDate(string dateFormat)
    {
        try
        {
            return DateTime.Now.ToString(dateFormat);
        }
        catch (FormatException)
        {
            throw new ArgumentException("Invalid date format provided.");
        }   
    }
}
