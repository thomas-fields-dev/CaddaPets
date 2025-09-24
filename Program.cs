namespace CaddaPets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // the ourAnimals array will store the following: 
            string animalSpecies = "",
                animalID = "",
                animalAge = "",
                animalPhysicalDescription = "",
                animalPersonalityDescription = "",
                animalNickname = "",
                suggestedDonation = "";

            // variables that support data entry
            int maxPets = 8;
            string? readResult;
            int menuSelection = 0;
            int updatedAge;
            decimal decimalDonation = 0.00m;
            int recordsUpdated;
            int recordsToUpdate;

            // array used to store runtime data, there is no persisted data
            string[,] ourAnimals = new string[maxPets, 7];

            // create some initial ourAnimals array entries
            for (int i = 0; i < maxPets; i++)
            {
                switch (i)
                {
                    case 0:
                        animalSpecies = "dog";
                        animalID = "d1";
                        animalAge = "2";
                        animalPhysicalDescription = "medium sized cream colored female golden retriever weighing about 65 pounds. housebroken.";
                        animalPersonalityDescription = "loves to have her belly rubbed and likes to chase her tail. gives lots of kisses.";
                        animalNickname = "lola";
                        suggestedDonation = "85.00";
                        break;
                    case 1:
                        animalSpecies = "dog";
                        animalID = "d2";
                        animalAge = "9";
                        animalPhysicalDescription = "large reddish-brown male golden retriever weighing about 85 pounds. housebroken.";
                        animalPersonalityDescription = "loves to have his ears rubbed when he greets you at the door, or at any time! loves to lean-in and give doggy hugs.";
                        animalNickname = "gus";
                        suggestedDonation = "40.99";
                        break;
                    case 2:
                        animalSpecies = "cat";
                        animalID = "c3";
                        animalAge = "1";
                        animalPhysicalDescription = "small white female weighing about 8 pounds. litter box trained.";
                        animalPersonalityDescription = "friendly";
                        animalNickname = "Puss";
                        suggestedDonation = "40.00";
                        break;
                    case 3:
                        animalSpecies = "cat";
                        animalID = "c4";
                        animalAge = "?";
                        animalPhysicalDescription = "";
                        animalPersonalityDescription = "";
                        animalNickname = "";
                        suggestedDonation = "";
                        break;
                    default:
                        animalSpecies = "";
                        animalID = "";
                        animalAge = "";
                        animalPhysicalDescription = "";
                        animalPersonalityDescription = "";
                        animalNickname = "";
                        suggestedDonation = "";
                        break;
                }

                ourAnimals[i, 0] = "ID #: " + animalID;
                ourAnimals[i, 1] = "Species: " + animalSpecies;
                ourAnimals[i, 2] = "Age: " + animalAge;
                ourAnimals[i, 3] = "Nickname: " + animalNickname;
                ourAnimals[i, 4] = "Physical description: " + animalPhysicalDescription;
                ourAnimals[i, 5] = "Personality: " + animalPersonalityDescription;

                if (!decimal.TryParse(suggestedDonation, out decimalDonation))
                    decimalDonation = 45.00m;

                ourAnimals[i, 6] = $"Suggested donation: {decimalDonation:C2}";
            }

            // display the top-level menu options
            do
            {
                Console.Clear();

                Console.WriteLine("Welcome to the Contoso PetFriends app. Your main menu options are:");
                Console.WriteLine(" 1. List all of our current pet information");
                Console.WriteLine(" 2. Add a new animal friend to the ourAnimals array");
                Console.WriteLine(" 3. Ensure animal ages and physical descriptions are complete");
                Console.WriteLine(" 4. Ensure animal nicknames and personality descriptions are complete");
                Console.WriteLine(" 5. Edit an animal’s age");
                Console.WriteLine(" 6. Edit an animal’s personality description");
                Console.WriteLine(" 7. Display all cats with a specified characteristic");
                Console.WriteLine(" 8. Display all dogs with a specified characteristic");
                Console.WriteLine();
                Console.WriteLine("Enter your selection number (or type Exit to exit the program)");

                readResult = Console.ReadLine()?.Flatten();
                if (readResult != null)
                {
                    int.TryParse(readResult, out menuSelection);
                }

                Console.WriteLine($"You selected menu option {readResult}.");

                switch (menuSelection)
                {
                    case 1:
                        for (int i = 0; i < maxPets; i++)
                        {
                            if (ourAnimals[i, 0] != "ID #: ")
                            {
                                for (int j = 0; j < 7; j++)
                                {
                                    Console.WriteLine(ourAnimals[i, j]);
                                }
                                Console.WriteLine();
                            }
                        }
                        break;
                    case 2:
                        string? anotherPet = "y";
                        int petCount = 0;

                        while (anotherPet == "y")
                        {
                            int petsWithData = 0;

                            for (int i = 0; i < maxPets; i++)
                            {
                                if (ourAnimals[i, 0] != "ID #: ")
                                {
                                    petsWithData++;
                                }
                            }

                            Console.WriteLine($"{petsWithData} pet records have data.");

                            if (petsWithData < maxPets)
                            {
                                Console.WriteLine($"There are {petsWithData} pets with data, this is less than the max pet count of {maxPets}!");

                                Console.WriteLine("Enter Animal Species:");
                                bool validInput = false;
                                while (!validInput)
                                {
                                    readResult = Console.ReadLine();
                                    if (readResult != null)
                                    {
                                        animalSpecies = readResult.Flatten();
                                        if (animalSpecies != null && (animalSpecies == "dog" || animalSpecies == "cat"))
                                        {
                                            validInput = true;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Please dog or cat.");
                                        }
                                    }
                                }

                                animalID = animalSpecies?.Substring(0, 1) + (petsWithData + 1).ToString();
                                ourAnimals[petsWithData, 0] = "ID #: " + animalID;
                                ourAnimals[petsWithData, 1] = "Species: " + animalSpecies;

                                Console.WriteLine("Enter Animal Age:");
                                validInput = false;
                                while (!validInput)
                                {
                                    readResult = Console.ReadLine();
                                    if (readResult != null)
                                    {
                                        int age = 0;
                                        validInput = int.TryParse(readResult, out age);
                                        if (validInput)
                                        {
                                            if (age > 0)
                                            {
                                                ourAnimals[petsWithData, 2] = "Age: " + age;
                                            }
                                            else
                                            {
                                                validInput = false;
                                                Console.WriteLine("Please enter a non-negative number.");
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Please enter a non-negative number.");
                                        }
                                    }
                                }

                                validInput = false;
                                while (!validInput)
                                {
                                    Console.WriteLine("Enter Animal Nickname:");
                                    readResult = Console.ReadLine();
                                    if (readResult != null && readResult.Length > 3)
                                    {
                                        animalNickname = readResult.Flatten();
                                        ourAnimals[petsWithData, 3] = "Nickname: " + animalNickname;
                                        validInput = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Please enter Animal Nickname longer than three characters!");
                                    }
                                }

                                Console.WriteLine("Enter Animal Physical Description:");
                                validInput = false;
                                while (!validInput)
                                {
                                    readResult = Console.ReadLine();
                                    if (readResult != null && readResult.Length > 10)
                                    {
                                        animalPhysicalDescription = readResult.Flatten();
                                        ourAnimals[petsWithData, 4] = "Physical description: " + animalPhysicalDescription;
                                        validInput = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Please enter Animal Description longer than ten characters!");
                                    }
                                }

                                Console.WriteLine("Enter Animal Personality:");
                                validInput = false;
                                while (!validInput)
                                {
                                    readResult = Console.ReadLine();
                                    if (readResult != null && readResult.Length > 5)
                                    {
                                        animalPersonalityDescription = readResult.Flatten();
                                        ourAnimals[petsWithData, 5] = "Personality: " + animalPersonalityDescription;
                                        validInput = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Please enter Personality longer than 5 characters!");
                                    }
                                }

                                petCount++;

                                Console.WriteLine($"Pet Data Entered {petCount} have been entered so far, press any key to continue");
                                Console.ReadLine();
                            }
                            else
                            {
                                Console.WriteLine("Cannot add new pets, please remove some pets first!");
                                break;
                            }
                            Console.WriteLine("Would you like to enter another pet? Enter 'y' or 'n'");
                            anotherPet = Console.ReadLine();
                            anotherPet = anotherPet?.Flatten();
                        }
                        break;
                    // expected output is below. Pretty close but needs cleaned up!

                    // Enter 'dog' or 'cat' to begin a new entry
                    // dog
                    // Enter the pet's age or enter ? if unknown
                    // ?
                    // Enter a physical description of the pet(size, color, gender, weight, housebroken)
                    // Enter a description of the pet's personality (likes or dislikes, tricks, energy level)
                    // Enter a nickname for the pet
                    // Do you want to enter info for another pet (y / n)

                    case 3:
                        do
                        {
                            recordsUpdated = 0;
                            recordsToUpdate = 0;
                            for (int i = 0; i < maxPets; i++)
                            {
                                if (ourAnimals[i, 0] != "ID #: ")
                                {
                                    for (int j = 0; j < 6; j++)
                                    {
                                        string currentLine = ourAnimals[i, j];
                                        switch (currentLine)
                                        {
                                            case "Age: ?":
                                            case "Age: ":
                                                recordsToUpdate += 1;
                                                Console.WriteLine($"Please enter valid age for pet {ourAnimals[i, 0]}, current value is {ourAnimals[i, 2]}");
                                                readResult = Console.ReadLine();
                                                if (readResult != null)
                                                {
                                                    bool isValid = false;
                                                    isValid = int.TryParse(readResult, out updatedAge);
                                                    if (isValid && updatedAge > 0)
                                                    {
                                                        ourAnimals[i, 2] = $"Age: {updatedAge.ToString()}";
                                                        recordsUpdated += 1;
                                                    }
                                                }
                                                break;
                                            case "Physical description: ":
                                                recordsToUpdate += 1;
                                                Console.WriteLine($"Please enter valid physical description for pet {ourAnimals[i, 0]}, current value is {ourAnimals[i, 4]}");
                                                readResult = Console.ReadLine();
                                                if (readResult != null)
                                                {
                                                    animalPhysicalDescription = readResult.Flatten();
                                                    if (animalPhysicalDescription != "")
                                                    {
                                                        ourAnimals[i, 4] = $"Physical description: {animalPhysicalDescription}";
                                                        recordsUpdated += 1;
                                                    }
                                                }
                                                break;
                                            default:
                                                break;
                                        }
                                    }
                                }
                            }
                        } while (recordsToUpdate != recordsUpdated);
                        Console.WriteLine("All data requirements are met.\nPress 'Enter' key to Continue!");
                        Console.ReadLine();
                        break;
                    case 4:
                        do
                        {
                            recordsUpdated = 0;
                            recordsToUpdate = 0;
                            for (int i = 0; i < maxPets; i++)
                            {
                                if (ourAnimals[i, 0] != "ID #: ")
                                {
                                    for (int j = 0; j < 6; j++)
                                    {
                                        string currentLine = ourAnimals[i, j];
                                        switch (currentLine)
                                        {
                                            case "Nickname: ":
                                                recordsToUpdate += 1;
                                                Console.WriteLine($"Please enter valid Nickname for pet {ourAnimals[i, 0]}, current value is {ourAnimals[i, 3]}");
                                                readResult = Console.ReadLine();
                                                if (readResult != null)
                                                {
                                                    animalNickname = readResult.Flatten();
                                                    if (animalNickname != "")
                                                    {
                                                        ourAnimals[i, 3] = $"Nickname: {animalNickname}";
                                                        recordsUpdated += 1;
                                                    }
                                                }
                                                break;
                                            case "Personality: ":
                                                recordsToUpdate += 1;
                                                Console.WriteLine($"Please enter valid personality description for pet {ourAnimals[i, 0]}, current value is {ourAnimals[i, 5]}");
                                                readResult = Console.ReadLine();
                                                if (readResult != null)
                                                {
                                                    animalPersonalityDescription = readResult.Flatten();
                                                    if (animalPersonalityDescription != "")
                                                    {
                                                        ourAnimals[i, 5] = $"Personality: {animalPersonalityDescription}";
                                                        recordsUpdated += 1;
                                                    }
                                                }
                                                break;
                                            default:
                                                break;
                                        }
                                    }
                                }
                            }
                        } while (recordsToUpdate != recordsUpdated);
                        Console.WriteLine("All data requirements are met, press 'Enter' key to Continue!");
                        Console.ReadLine();
                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                    case 7:
                        break;
                    case 8:
                        int matchesFound = 0;
                        string searchTerms = "";
                        string combinedDescription = "";
                        while (searchTerms == "")
                        {
                            var matches = "";
                            string[] progressIndicator = ["| ", "/ ", "—-", "* "];
                            Console.WriteLine("Provide pet characteristic (can enter multiple values with ','):");
                            readResult = Console.ReadLine();
                            if (readResult != null)
                            {
                                searchTerms = readResult.Flatten();
                            }

                            if (searchTerms != "")
                            {
                                for (int i = 0; i < maxPets; i++)
                                {
                                    if (ourAnimals[i, 0] != "ID #: " && ourAnimals[i, 1].Contains("dog"))
                                    {
                                        combinedDescription = ourAnimals[i, 4] + "\n" + ourAnimals[i, 5];
                                        string[] terms = searchTerms.Split(",");
                                        Array.Sort(terms);
                                        string match = "";
                                        for (int j = 0; j < terms.Length; j++)
                                        {
                                            var delay = Task.Delay(1000);
                                            Console.CursorLeft = 0;
                                            Console.Write($"searching...{terms[j]}  {progressIndicator[0]} 3");
                                            Task.WaitAll(delay);

                                            if (combinedDescription.Contains(terms[j].Flatten()))
                                            {
                                                Console.CursorLeft = 0;
                                                Console.Write($"searching...{terms[j]}  {progressIndicator[1]} 2");
                                                delay = Task.Delay(1000);
                                                Task.WaitAll(delay);
                                                if (i != maxPets)
                                                {
                                                    Console.CursorLeft = 0;
                                                    Console.Write($"searching...{terms[j]}  {progressIndicator[2]} 1");
                                                    delay = Task.Delay(1000);
                                                    Task.WaitAll(delay);
                                                    if (!matches.Contains(ourAnimals[i, 0]))
                                                    {
                                                        Console.CursorLeft = 0;
                                                        Console.Write($"searching...{terms[j]}  {progressIndicator[3]} 0");
                                                        delay = Task.Delay(1000);
                                                        Task.WaitAll(delay);

                                                        string petName = ourAnimals[i, 3].Replace("Nickname:", "").Trim();
                                                        Console.CursorLeft = 0;
                                                        Console.WriteLine($"Our dog {petName} is a match for your search for {terms[j].Trim()}!");

                                                        animalNickname = ourAnimals[i, 3];
                                                        match = combinedDescription;
                                                        matchesFound++;
                                                    }
                                                }
                                                continue;
                                            }
                                            else
                                            {
                                                Console.CursorLeft = 0;
                                                Console.Write($"searching...{terms[j]}  {progressIndicator[1]} 2");
                                                delay = Task.Delay(1000);
                                                Task.WaitAll(delay);

                                                Console.CursorLeft = 0;
                                                Console.Write($"searching...{terms[j]}  {progressIndicator[2]} 1");
                                                delay = Task.Delay(1000);
                                                Task.WaitAll(delay);

                                                Console.CursorLeft = 0;
                                                Console.Write($"searching...{terms[j]}  {progressIndicator[3]} 0");
                                                delay = Task.Delay(1000);
                                                Task.WaitAll(delay);
                                            }
                                                Console.CursorLeft = 0;
                                            Console.Write(new string(' ', Console.BufferWidth));
                                        }
                                        Console.CursorLeft = 0;
                                        if (matchesFound > 0)
                                        {
                                            Console.WriteLine("");
                                            Console.WriteLine(animalNickname);
                                            Console.WriteLine(match);
                                            Console.WriteLine();
                                        }
                                    }
                                }
                                if (matchesFound == 0)
                                {
                                    Console.CursorLeft = 0;
                                    Console.WriteLine($"None of our dogs are a match for: {searchTerms}");
                                }
                            }
                        }
                        break;
                    default:
                        break;
                }
                Console.WriteLine("Press the Enter key to continue");
                readResult = Console.ReadLine();
            }
            while (readResult != "exit");
        }
    }
}

internal static class Helpers
{
    public static string Flatten(this string s)
    {
        return s.ToLower().Trim();
    }

}

