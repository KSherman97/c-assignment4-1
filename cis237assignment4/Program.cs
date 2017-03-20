// Kyle Sherman
// Assignment 4
// Due 3/20/17

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment4
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create a new droid collection and set the size of it to 100.
            DroidCollection droidCollection = new DroidCollection(100);

            //Create a user interface and pass the droidCollection into it as a dependency
            UserInterface userInterface = new UserInterface(droidCollection);

            // add some test droids 
            droidCollection.Add("Agrinium", "Janitorial", "Red", false, true, true, false, true);

            droidCollection.Add("Durasteel", "Astromech", "Blue", true, true, true, true, 50);

            droidCollection.Add("Inoxinum", "Protocol", "Orange", 15);

            droidCollection.Add("Neuranium", "Protocol", "Silver", 60);

            droidCollection.Add("Neuranium", "Astromech", "Red", true, true, false, true, 10);

            droidCollection.Add("Lamanium", "Utility", "Silver", true, true, true);

            droidCollection.Add("Agrinium", "Protocol", "Gold", 1);

            droidCollection.Add("Inoxium", "Janitorial", "Orange", true, false, true, true, true);

            //Display the main greeting for the program
            userInterface.DisplayGreeting();

            //Display the main menu for the program
            userInterface.DisplayMainMenu();

            //Get the choice that the user makes
            int choice = userInterface.GetMenuChoice();

            //While the choice is not equal to 3, continue to do work with the program
            while (choice != 5)
            {
                //Test which choice was made
                switch (choice)
                {
                    //Choose to create a droid
                    case 1:
                        userInterface.CreateDroid();
                        break;

                    //Choose to Print the droid
                    case 2:
                        userInterface.PrintDroidList();
                        break;
                    
                    case 3:
                        droidCollection.DroidSortByType(); // sort the droids by model type
                        userInterface.PrintDroidList();
                        break;
                    case 4:
                        droidCollection.DroidSortByCost(); // sort the droids by cost
                        userInterface.PrintDroidList();
                        break;

                }
                //Re-display the menu, and re-prompt for the choice
                userInterface.DisplayMainMenu();
                choice = userInterface.GetMenuChoice();
            }


        }
    }
}
