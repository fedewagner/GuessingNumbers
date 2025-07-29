// See https://aka.ms/new-console-template for more information

namespace GuessingNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int MAX_GUESSES_ALLOWED = 5;

            // Print some introduction text
            Console.WriteLine(
                $"In this game you have to guess a number between 1 and 100. You have {MAX_GUESSES_ALLOWED} allowed guesses!");

            // Find out how to generate random numbers in C#
            Random random = new Random();
            int the_number = random.Next(1, 101);
            int user_guess;
            bool is_there_already_correct_guess = false;
            int guesses_counter = 0;
            int guessing_difference = 100;
            int guesses_left;
            List<int> guessed_numbers = new List<int>();

            // Make comparison & Output if the guess is too high or too low or correct
            while (is_there_already_correct_guess == false && guesses_counter < MAX_GUESSES_ALLOWED)
            {
                // Read user text & Convert to ints
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("So please enter a number between 1 and 100:");
                Console.ForegroundColor = ConsoleColor.White;
                user_guess = Convert.ToInt32(Console.ReadLine());
                guessed_numbers.Add(user_guess);
                // calculate the difference between guesses
                guessing_difference = int.Abs(the_number - user_guess);
                // calculate the guesses left for the user

                if (guessing_difference == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Your guess is correct!");
                    break;
                }
                else if (user_guess < the_number)
                {
                    Console.WriteLine("Your guess is lower than the number!");
                    ++guesses_counter;
                    guesses_left = MAX_GUESSES_ALLOWED - guesses_counter;
                    if (guessing_difference <= 5 && guesses_left >= 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Your guess is very close! The guess is only 5 off or less");
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    if (guesses_left > 0)
                    {
                        Console.WriteLine($"You still have {guesses_left} guesses left!");
                    }
                }
                else
                {
                    Console.WriteLine("Your guess is higher than the number!");
                    ++guesses_counter;
                    guesses_left = MAX_GUESSES_ALLOWED - guesses_counter;
                    if (guessing_difference <= 5 && guesses_left >= 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Your guess is very close! The guess is only 5 off or less");
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    if (guesses_left > 0)
                    {
                        Console.WriteLine($"You still have {guesses_left} guesses left!");
                    }
                }
            }

            if (guessing_difference != 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("But, you run out of guesses :(");
                Console.WriteLine($"'The Number' was: {the_number}");
                Console.WriteLine($"your guesses were:");
                Console.WriteLine("[{0}]", string.Join(", ", guessed_numbers));
                Console.WriteLine("Maybe next time!");
            }
        }
    }
}