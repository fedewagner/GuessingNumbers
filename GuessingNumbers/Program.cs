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
            const int MIN_FOR_RANDOM_FUNCTION = 1;
            const int MAX_FOR_RANDOM_FUNCTION = 101;
            int numberToGuess = random.Next(MIN_FOR_RANDOM_FUNCTION, MAX_FOR_RANDOM_FUNCTION);
            int userGuess;

            int guessesCounter = 0;

            int guessingDifference = 100; // If I don't initialize, then I get some error:(
            int guessesLeft;
            List<int> guessedNumbers = new List<int>();

            // Make comparison & Output if the guess is too high or too low or correct
            while (guessesCounter < MAX_GUESSES_ALLOWED)
            {
                // Read user text & Convert to ints
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(
                    $"So please enter a number between {MIN_FOR_RANDOM_FUNCTION} and {MAX_FOR_RANDOM_FUNCTION - 1}:");
                
                userGuess = Convert.ToInt32(Console.ReadLine());
                
                //Check if the value is already in the List
                //if is in the list then print a message and ask again for a number
                while (guessedNumbers.Contains(userGuess))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($"You already tried with the number {userGuess}, therefore it doesn't count");
                    Console.WriteLine(
                        $"So please enter a newnumber between {MIN_FOR_RANDOM_FUNCTION} and {MAX_FOR_RANDOM_FUNCTION - 1}:");
                    userGuess = Convert.ToInt32(Console.ReadLine());
                }
                //if is not in the list then add the number into the list and continue
                guessedNumbers.Add(userGuess);
                Console.ForegroundColor = ConsoleColor.White;
                // calculate the difference between guesses
                guessingDifference = int.Abs(numberToGuess - userGuess);
                //can I do this with Enumerable.Range???

                if (guessingDifference == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Your guess is correct!");
                    break;
                }
                else if (userGuess < numberToGuess)
                {
                    Console.WriteLine("Your guess is lower than the number!");
                }
                else
                {
                    Console.WriteLine("Your guess is higher than the number!");
                }

                ++guessesCounter;
                guessesLeft = MAX_GUESSES_ALLOWED - guessesCounter;
                if (guessingDifference <= MAX_GUESSES_ALLOWED && guessesLeft >= 1)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Your guess is very close! The guess is only 5 off or less");
                    Console.ForegroundColor = ConsoleColor.White;
                }

                if (guessesLeft > 0)
                {
                    Console.WriteLine($"You still have {guessesLeft} guesses left!");
                }
            }

            if (guessingDifference != 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("But, you run out of guesses :(");
                Console.WriteLine($"'The Number' was: {numberToGuess}");
                Console.WriteLine($"your guesses were:");
                Console.WriteLine("[{0}]", string.Join(", ", guessedNumbers));
                Console.WriteLine("Maybe next time!");
            }
        }
    }
}