using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = 0;
            string input = "";
            bool isInputValid = false;
            bool shouldContinue = false;

            do
            {
                shouldContinue = false;

                do
                {
                    try
                    {
                        isInputValid = true;
                        Console.WriteLine("Welcome to our C# class! Which student would you like to learn more about? (enter a number 1-19:)");
                        input = Console.ReadLine();
                        num = int.Parse(input);//declared the students as a number to get information
                        Console.WriteLine("Student {0} is {1}. What would you like to know about {0}?(enter hometown, favorite food or favorite color)", num, names[num - 1]);
                    }
                    catch (ArgumentOutOfRangeException ex)//caught that the user input an invalid number
                    {
                        Console.WriteLine("That student does not exist, try again (1-19)");
                        isInputValid = false;//user has to type valid number
                    }
                } while (!isInputValid);//keep doing while invalid number

                do
                {
                    try
                    {
                        isInputValid = true;
                        input = Console.ReadLine();

                        if (!input.Equals("hometown", StringComparison.InvariantCultureIgnoreCase) && !input.Equals("favorite food", StringComparison.InvariantCultureIgnoreCase) && !input.Equals("favorite color", StringComparison.InvariantCultureIgnoreCase))
                        { //if the input doesn't equal to "hometown" or "favorite food" throw to FormatException
                            throw new FormatException("That data does not exist.  Try again (hometown, favorite food or favorite color)");
                        }
                    }
                    catch (FormatException ex)//FormatException reads the message above and shows as false/invalid
                    {
                        Console.WriteLine(ex.Message);
                        isInputValid = false;
                    }
                } while (!isInputValid);//user keep doing this until input is valid

                if (input.Equals("hometown", StringComparison.InvariantCultureIgnoreCase))
                { //if user inputs "hometown" display name and hometown
                    Console.WriteLine("{0}'s hometown is {1} ", names[num - 1], hometown[num - 1]);
                }
                else if (input.Equals("favorite food", StringComparison.InvariantCultureIgnoreCase))
                { //if user inputs "favorite food" display name and food
                    Console.WriteLine("{0}'s favorite food is {1} ", names[num - 1], food[num - 1]);
                }//People[num - 1,0]... displays row and columns of the students and their information\
                else
                {
                    Console.WriteLine("{0}'s favorite color is {1} ", names[num - 1], color[num - 1]);
                }

                Console.WriteLine("Would you like more info on students? If so write one of these. (student, add, exit)");
                input = Console.ReadLine();

                if (input.Equals("student", StringComparison.InvariantCultureIgnoreCase)) //if the input reads "yes" continue
                {
                    shouldContinue = true;
                }
                else if (input.Equals("add", StringComparison.InvariantCultureIgnoreCase))
                {
                    AddStudent();
                    shouldContinue = true;
                }
                else
                {
                    Console.WriteLine("Goodbye Buddy!");
                }
            } while (shouldContinue);
            Console.ReadKey();


        }

        static List<string> names = new List<string> { "Adriana", "Milton", "Marilyn", "Andrew", "John", "Johnny", "Keith", "Chaz", "Blake", "Richard", "Julia", "Bill", "Lous", "Zoey", "Francis", "Rochelle", "Nick", "Ellis", "Darrel" };
        static List<string> hometown = new List<string> { "New York", "Atlanta", "Balitmore", "Memphis", "Las Vegas", "AUstin", "Bismarck", "Los Angeles", "Detroit", "Boston", "El Pas", "San Antonio", "Buffalo", "Newark", "Seattle", "St. Louis", "San Fransico", "Kanas City", "Chicago" };
        static List<string> food = new List<string> { "French Toast", "Biscuts and Gravy", "Fish", "Grits", "Tacos", "T-Bone Steak", "Fries", "Salad", "Bratwurst", "Scallops", "Chicken Wings", "BBQ", "Tiramisu", "Spring Roll", "Quiche", "Chicken Nuggets", "Dulce De Leche", "Waffles", "Hot Dogs" };
        static List<string> color = new List<string> { "Green", "Purple", "Orange", "Blue", "Yellow", "Red", "Navy Blue", "Lime Green", "Gray", "Black", "White", "Brick Red", "Olive", "Dark Violet", "Pale Green", "Gold", "Cyan", "Maroon", "Magenta"};

        static string GetUserInput(string inputName)
        {
            string input;

            bool isValidInput = false;
            do
            {
                isValidInput = true;

                Console.WriteLine("Please enter {0}", inputName);
                input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))//check to see if user input is valid
                {//handle invalid input
                    Console.WriteLine("Please input valid info");
                    isValidInput = false;
                }
            } while (!isValidInput);
            return input;
        }
        static void AddStudent()
        {
            names.Add(GetUserInput("name"));
            hometown.Add(GetUserInput("hometown"));
            food.Add(GetUserInput("food"));
            color.Add(GetUserInput("color"));
        }
    }
}
