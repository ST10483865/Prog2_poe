using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog2_poe
{//start of namespace
    internal class Program
    {//start  of class
        static void Main(string[] args)
        {//start of method
            new voice_greeting { };

            display_helper display = new display_helper();
             
            chatbot_responses responds = new chatbot_responses();
            user_interaction interaction = new user_interaction();
           
        }//end of method
    }//end of class
}//end of namespace
