using System;
using System.Threading;

namespace Prog2_poe
{
    public class display_helper
    {// start of class
        //Automatc properties to display settings
        public int DividerLength { get; set; }
        public char DefaultSymbol { get; set; }

        public display_helper()
        {//start of constructor
            DividerLength = 60;
            DefaultSymbol = '-';
        }//end of constructor

        public void type_text(string message, ConsoleColor color)
        {//start of method
            try
            {
                Console.ForegroundColor = color;
                foreach (char c in message)
                {
                    Console.Write(c);
                    Thread.Sleep(50);
                }
                Console.WriteLine();
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"  ! Display error: {ex.Message}");

            }
        }// end of method

        public void print_divider(char symbol, int length, ConsoleColor color)
        { //start of method
            Console.ForegroundColor = color;
            Console.WriteLine(new string(symbol, length));
            Console.ResetColor();
        }// end of method
        public void display_welcome_banner()
        { //start of method
            Console.WriteLine();
            print_divider('=', DividerLength, ConsoleColor.Cyan);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"  ----      --              ----        --");
            Console.WriteLine(@" / __/_  __/ /_  ___  _____/ __ )____  / /_");
            Console.WriteLine(@"/ /_/ / / / __ \/ _ \/ ___/ __  / __ \/ __/");
            Console.WriteLine(@" / __/ /_/ / /_/ /  __/ /  / /_/ / /_/ / /_");
            Console.WriteLine(@"/_/  \__, /_.___/\___/_/  /_____/\____/\__/");
            Console.WriteLine(@"    /____/                                 ");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("/n Welcome to CYBERSECURITY AWARENESS BOT");
            Console.ResetColor();

            print_divider('=', DividerLength, ConsoleColor.Cyan);
            type_text("    Keeping you safe in the digital world!", ConsoleColor.Green);
            print_divider(DefaultSymbol, DividerLength, ConsoleColor.DarkCyan);

        } //end of display_welcome_banner method
        //method to display topic menu
        public void display_topics_menu()
        {//start of method
            Console.WriteLine();
            print_divider('~', DividerLength, ConsoleColor.DarkYellow);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("  TOPICS YOU CAN ASK ME ABOUT:");
            Console.ResetColor();

            print_divider('~', DividerLength, ConsoleColor.DarkYellow);

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("   [1]  How are you?");
            Console.WriteLine("   [2]  What is your purpose?");
            Console.WriteLine("   [3]  Password safety");
            Console.WriteLine("   [4]  Phishing");
            Console.WriteLine("   [5]  Safe browsing");
            Console.WriteLine("   [6]  Two-factor authentication ");
            Console.WriteLine("   [7]  Malware");
            Console.WriteLine("   [8]  Social engineering");
            Console.WriteLine("   [9]  VPN");
            Console.WriteLine("   [10] Data privacy");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n   Type 'exit' to quit the chatbot.");
            Console.ResetColor();

            print_divider('~', DividerLength, ConsoleColor.DarkYellow);
        }//end of display_topic_menu method

        //method to display chatbot responses
        public void display_bot_response(string response)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("  Bot: ");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(response);
            Console.ResetColor();
            print_divider(DefaultSymbol, DividerLength, ConsoleColor.DarkCyan);
        }

        //method to display warning messages
        public void display_warning(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n  ! {message}");
            Console.ResetColor();
        }//end of display_warning_method

        //method to display goodbye message
        public void display_goodbye(string user_name) 
        {
            Console.WriteLine();
            print_divider('=', DividerLength, ConsoleColor.Cyan);
            type_text($"  Goodbye, {user_name}! Stay safe online!", ConsoleColor.Cyan);
            type_text("  Remember: Think before you click!", ConsoleColor.Yellow);
            type_text("  Stay vigilant. Stay secure.", ConsoleColor.Green);
            print_divider('=', DividerLength, ConsoleColor.Cyan);
            Console.WriteLine();
        }

    }//end of class

}//end of namespace