using System;

class Program
{
    static void Main(string[] args)
    {
        bool playAgain = true;
        
        while (playAgain)
        {
            // Console.WriteLine("Hello Prep3 World!");
        // Console.Write("What is the magic number?: ");
        
        Random randomNumberGenerator = new Random();
        int magicNumber = randomNumberGenerator.Next(1, 101);

        int guess = -1;
        int numberOfGuesses = 0;

        while (guess != magicNumber)
        {
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());
            numberOfGuesses++;

            if (magicNumber > guess)
        {
            Console.WriteLine("Higher");
        }

        else if (magicNumber < guess)
        {
            Console.WriteLine("Lower");
        }

        else 
        {
            Console.WriteLine($"Great, you guessed it in {numberOfGuesses} guesses!");
            
            Console.Write("Do you want to play again? (yes/no): ");
            string playAgainResponse = Console.ReadLine().ToLower();

            if (playAgainResponse != "yes")
            {
                playAgain = false;
            }

            Console.WriteLine("Thanks for playing");
        }

        
        }
        }

        

    }
}