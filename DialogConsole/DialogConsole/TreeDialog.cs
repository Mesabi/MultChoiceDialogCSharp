using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DialogTest
{
    internal class TreeDialog
    {
        public List<DialogNode> tree = new List<DialogNode>();//nodes of conversation. 
        public string treeName;//name of conversation

        string errorMessagereturn = "Unkown Error";


        public TreeDialog(string treeName)
        {
         
            buildTree(treeName);//
        }

        public DialogNode returnThisNode(int thisNode)
        {
            try
            {
                foreach (DialogNode node in tree)
                {
                    if (node.myLocation==thisNode)
                    {
                        return node;
                    }
                }
                return new DialogSingle(-1, "System unable to find node", "System", -1);
            }
            catch (Exception e)
            {
                return new DialogSingle(-1,"System unable to find node and crashed","System",-1);
            }
        }

        private void buildTree(string fileName)
        {
            //fileName = "@" + fileName;
            Console.WriteLine(fileName);
            StreamReader sr = new StreamReader(Path.Combine(Directory.GetCurrentDirectory(),fileName));
            string raw = sr.ReadToEnd();
            string[] lines = raw.Split('\n');//arbitrary size
            DialogNode[] rawTree = new DialogNode[lines.Length];
            //int count = 0;
            for (int j = 0; j < lines.Length-1; j++)
            {
                errorMessagereturn = "Unkown Error";
                try
                {
                    errorMessagereturn = "Line Did Not Split Properly";
                    string[] splitLine = lines[j].Split('|');
                    // # | text | Actor | goto / ?
                    // 0  |  1   |  2 |  3 
                    if (splitLine[0].Contains("END"))
                    {// if end of file, end tree. 
                        break;
                    }
                    else if (splitLine[0].Contains("?"))
                    {
                        //do nothing since it's an option.
                        ////options are handled in the next block. 
                    }
                    else if (splitLine[3].Contains("?"))
                    {//code to add choice node.
                        string[] choices = new string[8];//arbitrary number, 8 choices is max so far;
                        int optionsCount = 0;
                        errorMessagereturn = "DialogChoice not created properly";
                        for (int k = j + 1; k < lines.Length; k++)//this will crash if the dialog conversation isn't set up properly. 
                                                                  //iterates through the remainder of the file if necessary. (It shouldn't be!)
                        {
                            if (lines[k].Split('|')[0].Contains("?"))
                            {//constructs options, adds to array
                                choices[optionsCount] = lines[k];
                                optionsCount++;
                            }
                            else
                            {
                                break;
                            }
                        }
                        DialogOption[] dialogOptions = new DialogOption[optionsCount];
                        //turns the strings into options
                        for (int l = 0; l < dialogOptions.Length; l++)
                        {
                            dialogOptions[l] = new DialogOption(choices[l]);
                        }
                        tree.Add(new DialogChoice(dialogOptions, Int32.Parse(splitLine[0]), splitLine[1], splitLine[2]));
                        //construct choicenode
                        //add to tree
                    }
                    else
                    {//adds a singular node to the tree.
                        errorMessagereturn = "DialogSingle did not create properly!";
                        tree.Add(new DialogSingle(Int32.Parse(splitLine[0]), splitLine[1], splitLine[2], Int32.Parse(splitLine[3])));
                    }
                }catch (Exception ex)
                {
                    int h = j ++;
                    Console.WriteLine("Error at Line " + h+" : "+errorMessagereturn);
                }
            }

        }
    }
}






