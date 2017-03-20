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
    //Class Droid Collection implements the IDroidCollection interface.
    //All methods declared in the Interface must be implemented in this class 
    class DroidCollection : IDroidCollection
    {
        public DroidCollection(){}

        //Private variable to hold the collection of droids
        private Droid[] droidCollection = new Droid[100];
        //Private variable to hold the length of the Collection
        private int lengthOfCollection;

        //Constructor that takes in the size of the collection.
        //It sets the size of the internal array that will be used.
        //It also sets the length of the collection to zero since nothing is added yet.
        public DroidCollection(int sizeOfCollection)
        {
            //Make new array for the collection
            droidCollection = new Droid[sizeOfCollection];
            //set length of collection to 0
            lengthOfCollection = 0;
        }

        //The Add method for a Protocol Droid. The parameters passed in match those needed for a protocol droid
        public bool Add(string Material, string Model, string Color, int NumberOfLanguages)
        {
            //If there is room to add the new droid
            if (lengthOfCollection < (droidCollection.Length - 1))
            {
                //Add the new droid. Note that the droidCollection is of type IDroid, but the droid being stored is
                //of type Protocol Droid. This is okay because of Polymorphism.
                droidCollection[lengthOfCollection] = new ProtocolDroid(Material, Model, Color, NumberOfLanguages);
                //Increase the length of the collection
                lengthOfCollection++;
                //return that it was successful
                return true;
            }
            //Else, there is no room for the droid
            else
            {
                //Return false
                return false;
            }
        }

        //The Add method for a Utility droid. Code is the same as the above method except for the type of droid being created.
        //The method can be redeclared as Add since it takes different parameters. This is called method overloading.
        public bool Add(string Material, string Model, string Color, bool HasToolBox, bool HasComputerConnection, bool HasArm)
        {
            if (lengthOfCollection < (droidCollection.Length - 1))
            {
                droidCollection[lengthOfCollection] = new UtilityDroid(Material, Model, Color, HasToolBox, HasComputerConnection, HasArm);
                lengthOfCollection++;
                return true;
            }
            else
            {
                return false;
            }
        }

        //The Add method for a Janitor droid. Code is the same as the above method except for the type of droid being created.
        public bool Add(string Material, string Model, string Color, bool HasToolBox, bool HasComputerConnection, bool HasArm, bool HasTrashCompactor, bool HasVaccum)
        {
            if (lengthOfCollection < (droidCollection.Length - 1))
            {
                droidCollection[lengthOfCollection] = new JanitorDroid(Material, Model, Color, HasToolBox, HasComputerConnection, HasArm, HasTrashCompactor, HasVaccum);
                lengthOfCollection++;
                return true;
            }
            else
            {
                return false;
            }
        }

        //The Add method for a Astromech droid. Code is the same as the above method except for the type of droid being created.
        public bool Add(string Material, string Model, string Color, bool HasToolBox, bool HasComputerConnection, bool HasArm, bool HasFireExtinguisher, int NumberOfShips)
        {
            if (lengthOfCollection < (droidCollection.Length - 1))
            {
                droidCollection[lengthOfCollection] = new AstromechDroid(Material, Model, Color, HasToolBox, HasComputerConnection, HasArm, HasFireExtinguisher, NumberOfShips);
                lengthOfCollection++;
                return true;
            }
            else
            {
                return false;
            }
        }

        //The last method that must be implemented due to implementing the interface.
        //This method iterates through the list of droids and creates a printable string that could
        //be either printed to the screen, or sent to a file.
        public string GetPrintString()
        {
            //Declare the return string
            string returnString = "";

            //For each droid in the droidCollection
            foreach (IDroid droid in droidCollection)
            {
                //If the droid is not null (It might be since the array may not be full)
                if (droid != null)
                {
                    //Calculate the total cost of the droid. Since we are using inheritance and Polymorphism
                    //the program will automatically know which version of CalculateTotalCost it needs to call based
                    //on which particular type it is looking at during the foreach loop.
                    droid.CalculateTotalCost();
                    //Create the string now that the total cost has been calculated
                    returnString += "******************************" + Environment.NewLine;
                    returnString += droid.ToString() + Environment.NewLine + Environment.NewLine;
                    returnString += "Total Cost: " + droid.TotalCost.ToString("C") + Environment.NewLine;
                    returnString += "******************************" + Environment.NewLine;
                    returnString += Environment.NewLine;
                }
            }

            //return the completed string
            return returnString;
        }

        // this method will count how many indexes there are in the array 
        // that have non-null values
        private static int nonNullIndexes(IDroid[] DroidCollection)
        {
            int index = 0;
            while (DroidCollection[index] != null)
            {
                index++;
            }
            return index;
        }

        // method to sort the droid by the type
        public void DroidSortByType()
        {
            Stack<AstromechDroid> AstromechStack = new Stack<AstromechDroid>(); // create a new stack for astromech
            Stack<JanitorDroid> JanitorStack = new Stack<JanitorDroid>();       // create a new stack for janitor
            Stack<UtilityDroid> UtilityStack = new Stack<UtilityDroid>();       // create a new stack for utility
            Stack<ProtocolDroid> ProtocolStack = new Stack<ProtocolDroid>();    // create a new stack for Protocol 

            Queue<Droid> DroidQueue = new Queue<Droid>();                       // initialize a new queue
            //For each droid in the droidCollection
            foreach (IDroid droid in droidCollection)
            {
                //If the droid is not null (It might be since the array may not be full)
                if (droid != null)
                { 
                    // is the droid type JanitorDroid?
                    if (droid is JanitorDroid)
                    {
                        JanitorStack.AddToFront((JanitorDroid)droid); // add the droid to the front of the stack
                    }
                    // is the droid of type Astromech?
                    else if (droid is AstromechDroid)
                    {
                        AstromechStack.AddToFront((AstromechDroid)droid);// add the droid to the front of the stack
                    }
                    // is the droid of type Utility?
                    else if (droid is UtilityDroid)
                    {
                        UtilityStack.AddToFront((UtilityDroid)droid);// add the droid to the front of the stack
                    }
                    // is the droid of type Protocol?
                    else if (droid is ProtocolDroid)
                    {
                        ProtocolStack.AddToFront((ProtocolDroid)droid);// add the droid to the front of the stack
                    }
                    
                }
            }

           // while the janitor stack is not empty then keep queueing them
            while(!JanitorStack.IsEmpty)
            {
                DroidQueue.AddToBack(JanitorStack.RemoveFromFront());
            }
            // while the astromech stack is not empty then keep queueing them
            while (!AstromechStack.IsEmpty)
            {
                DroidQueue.AddToBack(AstromechStack.RemoveFromFront());
            }
            // while the utility stack is not empty then keep queueing them
            while (!UtilityStack.IsEmpty)
            {
                DroidQueue.AddToBack(UtilityStack.RemoveFromFront());
            }
            // while the Protocol stack is not empty then keep queueing them
            while (!ProtocolStack.IsEmpty)
            {
                DroidQueue.AddToBack(ProtocolStack.RemoveFromFront());
            }

            //Dequeues Droids and places them back in the DroidInventory array
            int x = 0; //Index Variable
            while (!DroidQueue.IsEmpty)
            {
                droidCollection[x] = DroidQueue.RemoveFromFront(); // dequeue the droids until the queue is empty
                x++;
            }
        }
        // sort the droidarray by cost 
        public void DroidSortByCost()
        {
            Droid[] SortArray = new Droid[nonNullIndexes(droidCollection)];
            int i = 0;
            while(droidCollection[i] != null)
            {
                SortArray[i] = droidCollection[i];
                i++;
            }

            MergeSort<Droid>.Sort(SortArray);
            i = 0;
            foreach (Droid droid in SortArray)
            {
                droidCollection[i] = SortArray[i];
                i++;
            }
        }
    }
}
