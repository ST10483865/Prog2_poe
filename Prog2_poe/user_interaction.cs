using System;

namespace Prog2_poe
{//start of namespacee
    public class user_interaction
    {//start of class
        // automatic properties
        public string UserName { get; private set; }
        public bool IsRunning { get; private set; }

        //references to the other classes
        private display_helper display = new display_helper();
        private chatbot_responses responses = new chatbot_responses();

        public user_interaction() 
        {
            display.display_welcome_banner();
            UserName = get_user_name();
            display_personalised_greeting(UserName);
            IsRunning = true;
            start_chat_loop(UserName);
        }
        //method to ask for user_name
        public string get_user_name()
        {
            display.type_text("\n  Bot: Hello! Welcome to the Cybersecurity Awareness Bot.", ConsoleColor.Cyan);
            display.type_text("  Bot: Before we begin, may I ask for your name?", ConsoleColor.Cyan);

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("\n  You: ");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.White;
            string user_name = Console.ReadLine();
            Console.ResetColor();

            //Task 5: input validation - keep asking until a valid name is entered
            while (string.IsNullOrWhiteSpace(user_name))
            {
                display.display_warning("Please enter a valid name to continue.");
                display.type_text("  Bot: I did not quite catch that. What is your name?", ConsoleColor.Yellow);

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("\n  You: ");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.White;
                user_name = Console.ReadLine();
                Console.ResetColor();
            }
            return user_name;
        }//end of user_name method

        //method to display personalised greeting
        public void display_personalised_greeting(string user_name)
        {
            Console.WriteLine();
            display.print_divider('*', 60, ConsoleColor.Yellow);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\n  Welcome, {user_name.ToUpper()}!");
            Console.ResetColor();

            display.type_text($"\n  Bot: Great to meet you, {user_name}!", ConsoleColor.Cyan);
            display.type_text("  Bot: I am your personal Cybersecurity Awareness Bot.", ConsoleColor.Cyan);
            display.type_text("  Bot: I am here to help you stay safe and informed online.", ConsoleColor.Cyan);

            display.print_divider('*', 60, ConsoleColor.Yellow);

        }// end of personalised greeting method

        //method to run the main chat loop
        public void start_chat_loop(string user_name)
        {
            //show the topics menu when the chat starts
            display.display_topics_menu();

            while (IsRunning)
            {//start of while loop

                try
                {
                    //get user input
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write($"\n  {user_name}: ");
                    Console.ResetColor();

                    Console.ForegroundColor = ConsoleColor.White;
                    string input = Console.ReadLine();
                    Console.ResetColor();

                    // validate empty or whitespace input
                    if (string.IsNullOrWhiteSpace(input))
                    {
                        display.display_warning("Input cannot be empty.");
                        display.type_text("  Bot: I did not quite understand that. Could you rephrase?", ConsoleColor.Yellow);
                        display.print_divider('-', 60, ConsoleColor.DarkCyan);
                        continue;
                    }

                    //get the appropriate response based on input
                    string response = responses.get_response(input.ToLower().Trim(), user_name);

                    //check if user wants to exit
                    if (response == "EXIT")
                    {
                        display.display_goodbye(user_name);
                        IsRunning = false;
                    }
                    else
                    {
                        //display the formatted bot response
                        display.display_bot_response(response);
                    }
                }
                catch (Exception ex)
                {
                    display.display_warning($"An unexpected error occurred: {ex.Message}");
                }
            }//end of while loop
        }//end of chat loop method
    }//end of class
}//end of namespace