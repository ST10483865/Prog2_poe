using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace Prog_poe_part2
{//start of namespace
    internal class user_name
    {//start of class 

        //method to store and submit username
        public string submit_name(TextBox user_input, ListView chats)
        {//start of submit method

            string filename = "user_names.txt";

            //check if the file exists, then auto create it
            if (!File.Exists(filename))
            {//start of if
                File.AppendAllText(filename, "auto_create\n");
            }//end of if

            string name = user_input.Text.ToString().Trim();

            //check if the user has visited before
            bool found = check_name(name);

            if (found)
            {//start of if statement
                File.AppendAllText(filename, name + "\n");
                //welcome the new user
                error_method("ChatBot", "Hey " + name + ", welcome to the Cybersecurity Awareness Bot! I am here to help you stay safe online.", chats);
            }//end of if statement
            else
            {//start of else statement
             //welcome the returning user back
                error_method("ChatBot", "Hey " + name + ", welcome back! Great to see you again. How can I help you today?", chats);
            }//end of else statement

            return name;


        }//end of submit method

        internal string submit_name(TextBlock usernames_input, ListView chats)
        {
            throw new NotImplementedException();
        }

        private bool check_name(string name)
        {//start of method

            string filename = "user_names.txt";
            bool found_name = false;
            string[] names = File.ReadAllLines(filename);

            //for each to search for the username
            foreach (string name_found in names)
            {
                if (name_found.ToLower() == name.ToLower())
                {
                    found_name = true;
                }

            }
            //return weather name was found or not
            return found_name;

        }//end of method

        private void error_method(string name, string message, ListView chats)
        {
            Border messageBoader = new Border
            {
                Margin = new Thickness(0, 2, 0, 2),
                Padding = new Thickness(5, 3, 5, 3),
                CornerRadius = new CornerRadius(5)
            };

            if (name.ToLower().Contains("Chatbot") || name.ToLower().Contains("chats"))
            {//start if
             //the color for the chatbot is light blue
                messageBoader.Background = new SolidColorBrush(Color.FromRgb(240, 248, 255));
                messageBoader.BorderBrush = new SolidColorBrush(Color.FromRgb(178, 216, 230));
            }
            else
            {// color pink for the user
                messageBoader.Background = new SolidColorBrush(Color.FromRgb(255, 182, 193));
                messageBoader.BorderBrush = new SolidColorBrush(Color.FromRgb(255, 105, 180));

            }
            messageBoader.BorderThickness = new Thickness(1);

            TextBlock messageText = new TextBlock
            {
                TextWrapping = TextWrapping.Wrap,
                Margin = new Thickness(2)
            };

            //set color based on sender
            Brush nameColor = (name.ToLower().Contains("chatbot") || name.ToLower().Contains("chats")) ?
                Brushes.DarkBlue : Brushes.DarkGreen;

            messageText.Inlines.Add(new Run
            {
                Text = name + ":",
                Foreground = nameColor,
                FontWeight = FontWeights.Bold

            });

            messageText.Inlines.Add(new Run
            {
                Text = message,
                Foreground = Brushes.Black
            });

            messageBoader.Child = messageText;
            chats.Items.Add(messageBoader);

        }


    }//end of class


}