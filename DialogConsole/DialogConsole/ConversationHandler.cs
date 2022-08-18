using System;
namespace DialogTest
{
    public class ConversationHandler
    {
        string fileName = "SimpleConvoTest.txt";
        TreeDialog tree;
        private int goNextNode = 0;
        private DialogNode thisNode;

        public ConversationHandler()
        {
            seeFiles();//this sets the fileName
            Console.WriteLine(fileName);
            tree = new TreeDialog(fileName);
            thisNode = tree.returnThisNode(goNextNode);
        }

        public void seeFiles()
        {//views all files, and then allows the user to select. 
            Console.WriteLine("Please Select a File:");
            string[] fileEntries = Directory.GetFiles("Dialog");//something with this returns the wrong length
            string[] fixesFileMistakes = new string[fileEntries.Length + 1];//this fixes it. 
            int i = 1;
            foreach (string fileEntry in fileEntries)
            {
                fixesFileMistakes[i] = fileEntry;
                Console.WriteLine(i + ". " + fileEntry);
                i++;
            }
            while (true)
            {
                try
                {
                    int tempGoTo = Int32.Parse(Console.ReadLine());
                    fileName = fixesFileMistakes[tempGoTo];
                    Console.WriteLine(fileName + " Was Selected!");
                    return;
                }
                catch (Exception)
                {
                    Console.WriteLine("Please Try Again!");
                }
            }
        }
        public void handleConsoleConversation()
        {//works by moving the node forward. It does return the dialog again on bad input
            while (true)
            {
                displayNodeInConsole();
                if (goNextNode == -1)//-1 automatically ends conversation.
                {
                    Console.WriteLine("Conversation Ended!");
                    return;
                }
                else
                {
                    if (thisNode is DialogChoice)
                    {               
                        Console.WriteLine("Please Select an Option");
                        moveForwardChoiceConsole();
                        thisNode = tree.returnThisNode(goNextNode);
                    }
                    else if(thisNode is DialogSingle)//this fixes a casting issue below. 
                    {
                        Console.WriteLine("Press Enter!");
                        string line = Console.ReadLine();
                        goNextNode = ((DialogSingle)thisNode).GoTo;
                        thisNode = tree.returnThisNode(goNextNode);
                    }
                }
            }
        }
        private void moveForwardChoiceConsole()
        {//selects a option from the list of options.
                string line = Console.ReadLine();
                try
                {
                Console.WriteLine(line);
                    DialogOption[] tempEvaluate = ((DialogChoice)thisNode).options;
                    int tempGoTo = Int32.Parse(line); 
                    try
                    {
                        goNextNode = tempEvaluate[Int32.Parse(line)].GoTo;
                    }
                    catch(Exception f)
                    {
                        Console.WriteLine("Please Select a valid Option");
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine("Please Select a valid Option!");
                }
        }
        public void displayNodeInConsole()
        {//displays the Node as a nice formated console line.
            Console.WriteLine("====================================");
            Console.WriteLine(thisNode.actor);
            Console.WriteLine("====================================");
            Console.WriteLine(thisNode.text);
            if (thisNode is DialogChoice)
            {
                DialogChoice output = (DialogChoice)thisNode;//theoretically this line should be unneccessary
                for (int i = 0; i < output.options.Length; i++)
                {
                    Console.WriteLine(i + ". " + output.options[i].text);
                }
            }
        }
    }
}
