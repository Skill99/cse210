using System;
using System.Collections.Generic;

/*Shows creativity and exceeds core requirements 
- I created a variable called "saved" that will be checked if it is true, if it is false, 
the program will ask the users if he is sure that he want to quit without saving, 
if yes the program will quit, if not, he will back to the main menu. 
each time the user write and try to quit it will be prompt.(load and display will not trigger it) */


public class Program
{
    public static void Main(string[] args)
    {
        bool quit = false;
        bool saved = false;

        string filename;
        string saveAnswer;

        Journal journal = new Journal();
        PromptGenerator prompt = new PromptGenerator();
        Entry entry = new Entry();

        prompt.LoadPrompts(prompt._prompts);
        
        
        Console.WriteLine("Welcome to the Journal Program!");

        do
        {
            Console.WriteLine("1-Write \n2-Display\n3-Load\n4-Save\n5-Quit");
            string userChoice = Console.ReadLine();
            switch(userChoice)
            {
                case "1":
                    prompt.GeneratePrompt();
                    entry._answer = entry.GetEntry();
                    journal._answers.Add(entry._answer);
                    saved = false;
                    break;
               
                case "2":
                    journal.DisplayEntries(journal._answers);
                   
                    break;
            
                case "3":
                    journal._answers.Clear();
                    Console.Write("Please, Choose a file name:");
                    filename = Console.ReadLine();
                    journal.LoadJournal(journal._answers, filename);
                    saved = true;
                    break;
            
                case "4":
                    Console.Write("Please, Choose a file name:");
                    filename = Console.ReadLine();
                    journal.SaveJournal(journal._answers, filename);
                    saved = true;
                    break;
            
                case "5":
                
                    if (saved == false)
                    {
                        Console.WriteLine("Are you sure you want exit without saving?(Y/N)");
                        saveAnswer = Console.ReadLine();
                        if (saveAnswer.ToLower() == "n")
                        {
                            break;
                        }
                        else if (saveAnswer.ToLower() == "y")
                        {
                            quit = true;
                        }
                        else 
                        {
                            Console.WriteLine("You don't typped Y or N, returning to menu..");
                        }
                    }
                    
                    
                    Console.WriteLine("Good Bye");
                    quit = true;
                    break;
            
            }
        }while(!quit);
 
    }
}

