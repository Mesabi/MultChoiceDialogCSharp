using System;
namespace DialogTest
{
    public class DialogNode
    {//Superclass for Dialog Single, and Dialog Choice
        public int myLocation;//integer representing the pointer in the conversation
        public string text;//text to output
        public string actor;//placed over text box as a title, can be used to embed other options. 

        public DialogNode(int myLocation, string text, string actor)
        {
            this.myLocation = myLocation;
            this.text = text;
            this.actor = actor;
        }
    }
}