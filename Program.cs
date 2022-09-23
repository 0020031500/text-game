using System;

string[] askedYesQuestions = { };
string[] askedNoQuestions = { };


static void getRandomQuestion()
{
    string[] mustAnswerYes = { "You wander into the depths of a cave. Do you fight?", "You're surrounded! Want to fight?", "A Wizard has arrived! Are you going to fight them?", "An evil spirit has summoned you! Are you going to go to them?"  };
    string[] mustAnswerNo = { "You're close to dying! Are you going to risk it and fight?", "A dragon has arrived and the flame from his breath is circling you! Are you going to run?", "Looks like there's a trap! Are you going to risk standing on it?", "That looks a lot like a booby trap! Are you going to attempt to trigger it?" };
    string[] mustAnswerEither = { "There is a possibility of escaping! Are you going to take it?", "Look, an open door! Wanna risk going through it?", "Possible danger ahead - there might be a chance at escaping if you jump into the water! Are you going to take the risk, even if it costs you the mission?", "Possible escape time! Are you going to take the leap of faith, even if it costs the mission?" };
    
    string[] possible = { "yes", "no", "either" };
    Random random = new Random();
    string choice = possible[random.Next(0, possible.Length)];

    if (choice == "yes") Console.WriteLine(mustAnswerYes[random.Next(0, mustAnswerYes.Length)]);
    
    else if (choice == "no") Console.WriteLine(mustAnswerNo[random.Next(0, mustAnswerNo.Length)]);
    
    else if (choice == "either") Console.WriteLine(mustAnswerEither[random.Next(0, mustAnswerEither.Length)]);

    
    Console.WriteLine("Yes or No?");

    string response = getResponse();
    
    
    if (response != choice)
    {
        if (choice == "either") correctChoice(choice, response);
        else incorrectChoice(choice, response);
    }
    else correctChoice(choice, response);
}

static string getResponse()
{
    string response = Console.ReadLine();

    Console.WriteLine(response != "yes" && response != "no");

    bool isIncorrect = response != "yes" && response != "no";
    
    if (isIncorrect)
    {
        Console.WriteLine("Invalid Answer! Try again:");
        getResponse();
    }

    return response;
}

static void incorrectChoice(string choice, string response)
{
    Globals.roundsLasted++;
    Console.Clear();
    string ltr = Globals.roundsLasted > 1 ? "s" : "";
    Console.WriteLine($"Game Over! Looks like you're dead.\n\nYou lasted for {Globals.roundsLasted} round{ltr}!");
}

static void correctChoice(string choice, string response)
{
    if (Globals.roundsLasted < 10)
    {
        Console.Clear();

        string[] possibleSuccessMessages = { "Wow, you're still here? Congrats!", "Phew, you made it out alive!", "Hurray, you're still alive!", "Woah, you made it out alive?!?!", "Wow, you handled that well!", "Huray, you got the right answer!" };

        Random random = new Random();
        Console.WriteLine(choice == "either" ? possibleSuccessMessages[random.Next(0, possibleSuccessMessages.Length)] : $"That's ok - you still got the right answer!");
        Console.WriteLine("Onto the next question!");

        Globals.roundsLasted++;

        getRandomQuestion();
    }
    else {
        Console.Clear();
        Console.WriteLine("Congratulations, you've beaten the game!");
    }
}

getRandomQuestion();



public static class Globals
{
    public static int roundsLasted = 0;
}
