using System;
namespace DialogTest
{
    public class DialogOption
    {

        // ? | text | goto
        public string text;//text for the option
        public int GoTo;//integer to go to in conversation.

        //flags

        public DialogOption(string raw)
        {
            string[] option = raw.Split('|');
            text = option[1];
            GoTo = Int32.Parse(option[2]);
        }
    }
}
