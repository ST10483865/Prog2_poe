using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Prog_poe_part2
{//Start of namespace
    
    public partial class MainWindow : Window
    {//start of class

        //creating instances for the ArrayList class
        ArrayList reply = new ArrayList();
        ArrayList ignore = new ArrayList();

        //creating instances for the other classes
        user_name check_name = new user_name();
        voice_greeting greet = new voice_greeting();
        display_helper display = new display_helper();
        chatbot_responses responses = new chatbot_responses();

        //variables
        string username = string.Empty;
        int counting = 0;

        public MainWindow()
        {//start of constructor

            InitializeComponent();

            //load responses and ignored words into the ArrayLists
            new respond(reply, ignore) { };

            //call the voice greeting method
            greet.greet();

            //display the ascii art on the home grid
            ascii_art_display.Text = greet.get_ascii_art();

        }//end of constructor

        // proceed event handler       
        private void proceed(object sender, RoutedEventArgs e)
        {//start of method

            home_grid.Visibility = Visibility.Collapsed;
            username_grid.Visibility = Visibility.Visible;
            usernames_input.Focus();

        }//end of method

        // allow pressing enter in username textbox to submit
        private void usernames_input_key_down(object sender, KeyEventArgs e)
        {//start of method
            if (e.Key == Key.Enter)
            {
                submit_name(sender, e);
            }
        }//end of method

        // allow pressing enter in question textbox to send

        private void question_key_down(object sender, KeyEventArgs e)
        {//start of method
            if (e.Key == Key.Enter)
            {
                send(sender, e);
            }
        }//end of method

        // submit name event handler
        private void submit_name(object sender, RoutedEventArgs e)
        {//start of method

            if (string.IsNullOrWhiteSpace(usernames_input.Text))
            {
                name_error_label.Visibility = Visibility.Visible;
                error_method("ChatBot", "Please enter your name to continue.", false);
                return;
            }

            name_error_label.Visibility = Visibility.Collapsed;
            username = check_name.submit_name(usernames_input, chats);
            username_grid.Visibility = Visibility.Collapsed;
            chat_grid.Visibility = Visibility.Visible;
            question.Focus();

        }//end of method

        // topic button click event handler
        private void topic_button_click(object sender, RoutedEventArgs e)
        {//start of method

            Button button = (Button)sender;
            question.Text = button.Tag.ToString();
            send(sender, e);

        }//end of method


        // send event handler
        private void send(object sender, RoutedEventArgs e)
        {//start of method

            string rawQuestion = question.Text.ToString().Trim();

            if (string.IsNullOrWhiteSpace(rawQuestion))
            {
                error_method("ChatBot", "Please enter a question.", false);
                return;
            }

            string questions = remove_special_characters(rawQuestion);

            //show user message in pink
            error_method(username, rawQuestion, true);

            auto_show_interest();
            ai_check(questions);

        }//end of method

        private void ai_check(string questions)
        {//start of method

            if (string.IsNullOrWhiteSpace(questions))
            {
                error_method("ChatBot", "Please enter a valid question.", false);
                question.Clear();
                return;
            }

            string[] words = questions.ToLower().Split(
                new char[] { ' ', ',', '.', '?', '!', ';', ':' },
                StringSplitOptions.RemoveEmptyEntries);

            bool found = false;
            string message = string.Empty;
            Random indexer = new Random();
            List<string> per_word = new List<string>();
            List<string> answers_found = new List<string>();

            foreach (string word in words)
            {//start of foreach

                if (word.Length < 3 || ignore.Contains(word.ToLower()))
                    continue;

                per_word.Clear();

                // memory recall to store interests
                if (word.Contains("interested"))
                {//start of interested block

                    string store_interests = string.Empty;
                    bool found_interest = false;
                    HashSet<string> currentInterests = new HashSet<string>();

                    foreach (string interest in words)
                    {//start of inner foreach
                        string clean = interest.ToLower().Trim();
                        clean = Regex.Replace(clean, @"[^a-zA-Z0-9\s]", "");

                        if (!ignore.Contains(clean) && clean != "interested" &&
                            clean != "and" && clean != "in" && clean.Length >= 3)
                        {
                            found_interest = true;
                            currentInterests.Add(clean);
                        }
                    }//end of inner foreach

                    store_interests = string.Join(", ", currentInterests);

                    if (found_interest && !string.IsNullOrWhiteSpace(store_interests))
                    {//start of if
                        string filename = "interested_topic.txt";
                        bool userFound = false;

                        if (File.Exists(filename))
                        {//start of file exists check
                            string[] lines = File.ReadAllLines(filename);

                            for (int i = 0; i < lines.Length; i++)
                            {//start of for loop
                                if (lines[i].StartsWith(username))
                                {//start of username check
                                    userFound = true;

                                    string existing = lines[i]
                                        .Replace(username + " interested in:", "")
                                        .ToLower();

                                    HashSet<string> existingSet = new HashSet<string>(
                                        existing.Split(',')
                                        .Select(x => x.Trim())
                                        .Where(x => x != "")
                                    );

                                    foreach (string item in currentInterests)
                                    {
                                        existingSet.Add(item);
                                    }

                                    string finalList = string.Join(", ", existingSet);
                                    lines[i] = username + " interested in: " + finalList;
                                    File.WriteAllLines(filename, lines);

                                    message += "great, i added " + store_interests + " to your interests and ";
                                    break;
                                }//end of username check
                            }//end of for loop
                        }//end of file exists check

                        if (!userFound)
                        {//start of if not found
                            File.AppendAllText(
                                filename,
                                username + " interested in: " + store_interests + "\n"
                            );
                            message += "great, i will remember that you are interested in " + store_interests + " and ";
                        }//end of if not found

                    }//end of if
                    else
                    {
                        message += "Please specify what you are interested in. For example: 'I am interested in cybersecurity'";
                    }

                }//end of interested block

                if (questions.ToLower().Contains("tell me more") ||
                    questions.ToLower().Contains("explain more") ||
                    questions.ToLower().Contains("give me another tip") ||
                    questions.ToLower().Contains("more details"))
                {//start of conversation flow block

                    string filename = "interested_topic.txt";

                    if (File.Exists(filename))
                    {//start of file check
                        string[] lines = File.ReadAllLines(filename);

                        foreach (string line in lines)
                        {//start of foreach
                            if (line.StartsWith(username))
                            {//start of username check
                                int colonIndex = line.IndexOf("interested in:");
                                if (colonIndex >= 0)
                                {
                                    string interests = line.Substring(colonIndex + 14).Trim();
                                    message += "Based on your interests in " + interests + ", here is more information: and ";
                                    ai_check(interests);
                                    question.Clear();
                                    return;
                                }
                            }//end of username check
                        }//end of foreach
                    }//end of file check

                }//end of conversation flow block

                //search for matching answers in the reply ArrayList
                bool wordFound = false;
                foreach (string answer in reply)
                {//start of foreach
                    if (answer.ToLower().Contains(word))
                    {
                        wordFound = true;
                        per_word.Add(answer);
                    }
                }//end of foreach

                if (wordFound && per_word.Count > 0)
                {
                    found = true;
                    int indexing = indexer.Next(0, per_word.Count);
                    answers_found.Add(per_word[indexing]);
                }

            }//end of foreach

            if (found && answers_found.Count > 0)
            {//start of if found
                answers_found = answers_found.Distinct().ToList();

                foreach (string per_answer in answers_found)
                {
                    message += per_answer + "\n";
                }

                error_method("ChatBot", message.TrimEnd('\n'), false);
                chats.ScrollIntoView(chats.Items[chats.Items.Count - 1]);
            }//end of if found
            else
            {//start of else
                string[] fallbackMessages = {
                "I am sorry, i don't understand that. Could you rephrase your question?",
                "I didn't quite get that. Try asking about cybersecurity topics.",
                "Hmm, i am not sure how to respond to that. Can you ask something else?",
                "I couldn't find an answer for that. Please ask about password safety, phishing, malware or vpn.",
                "My apologies, i don't have information on that topic yet."
            };

                Random random = new Random();
                string fallbackMessage = fallbackMessages[random.Next(fallbackMessages.Length)];
                error_method("ChatBot", fallbackMessage, false);
            }//end of else

            question.Clear();

        }//end of ai_check method

        private string remove_special_characters(string input)
        {//start of method

            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

            StringBuilder sanitized = new StringBuilder();

            foreach (char c in input)
            {
                if (char.IsLetterOrDigit(c) || char.IsWhiteSpace(c) || c == '\'' || c == '-')
                {
                    sanitized.Append(c);
                }
                else
                {
                    sanitized.Append(' ');
                }
            }

            string result = sanitized.ToString();
            result = Regex.Replace(result, @"\s+", " ").Trim();

            return result;

        }//end of method

        private void auto_show_interest()
        {//start of method

            if (counting == 3)
            {//start of if
                string filename = "interested_topic.txt";

                if (File.Exists(filename))
                {//start of file check
                    string[] lines = File.ReadAllLines(filename);

                    foreach (string line in lines)
                    {//start of foreach
                        if (line.StartsWith(username))
                        {//start of username check
                            int colonIndex = line.IndexOf("interested in:");
                            if (colonIndex >= 0)
                            {
                                string interests = line.Substring(colonIndex + 14).Trim();
                                error_method("ChatBot", "Just a reminder, you are interested in " + interests + " and ", false);
                                ai_check(interests);
                                break;
                            }
                        }//end of username check
                    }//end of foreach
                }//end of file check

                counting = 0;
            }//end of if
            else
            {
                counting += 1;
            }

        }//end of method

        private void error_method(string name, string message, bool isUser)
        {//start of method

            Border messageBorder = new Border
            {
                Margin = new Thickness(0, 2, 0, 2),
                Padding = new Thickness(8, 5, 8, 5),
                CornerRadius = new CornerRadius(8),
                BorderThickness = new Thickness(1)
            };

            if (isUser)
            {//start of if - pink for user
             //pink background with darker pink border
                messageBorder.Background = new SolidColorBrush(Color.FromRgb(255, 182, 193));
                messageBorder.BorderBrush = new SolidColorBrush(Color.FromRgb(219, 112, 147));
            }//end of if
            else
            {//start of else - light blue for bot
             //light blue background with steel blue border
                messageBorder.Background = new SolidColorBrush(Color.FromRgb(173, 216, 230));
                messageBorder.BorderBrush = new SolidColorBrush(Color.FromRgb(70, 130, 180));
            }//end of else

            TextBlock messageText = new TextBlock
            {
                TextWrapping = TextWrapping.Wrap,
                Margin = new Thickness(2)
            };

            //name color
            Brush nameColor = isUser ?
                new SolidColorBrush(Color.FromRgb(139, 0, 70)) :  //dark pink for user name
                new SolidColorBrush(Color.FromRgb(0, 0, 139));    //dark blue for bot name

            messageText.Inlines.Add(new Run
            {
                Text = name + ": ",
                Foreground = nameColor,
                FontWeight = FontWeights.Bold
            });

            messageText.Inlines.Add(new Run
            {
                Text = message,
                Foreground = Brushes.Black
            });

            messageBorder.Child = messageText;
            chats.Items.Add(messageBorder);

            chats.ScrollIntoView(chats.Items[chats.Items.Count - 1]);

        }//end of method

    }//end of class

}//end of namespace

