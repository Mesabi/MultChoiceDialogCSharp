using System;
using System.IO;
using System.Text;

namespace DialogTest
{
    public class DialogProject
    {
        public static void Main(string[] args)
        {
            Console .WriteLine("Hello World!");


            ConversationHandler conversationHandler = new ConversationHandler();
            //conversationHandler.seeFiles();
            conversationHandler.handleConsoleConversation();

        }
    }
}
