using System;
namespace DialogTest
{
    public class DialogSingle : DialogNode
    {
        public int GoTo { get; set; }//this is will send the conversation to the next DialogNode

        public DialogSingle(int myLocation, string text, string actor, int GoTo)
            : base(myLocation, text, actor)
        {
            this.GoTo = GoTo;
            //add block for embed. 

        }
    }
}
