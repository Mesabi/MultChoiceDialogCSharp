using System;
namespace DialogTest
{
    public class DialogChoice : DialogNode
    {
        public DialogOption[] options;//a list of selectable options

        public DialogChoice(DialogOption[] options, int myLocation, string text, string actor)
            :base(myLocation, text, actor)
        {
            this.options = options;
            //add block for embed
        }
    }
}
