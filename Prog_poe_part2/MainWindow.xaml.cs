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

        //part 3 instances

        database_helper db = new database_helper();
        quiz_manager quiz = new quiz_manager();
        activity_log log = new activity_log();
        nlp_manager nlp = new nlp_manager();

        //variables
        string username = string.Empty;
        int counting = 0;
        int selected_quiz_option = -1;

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
            log.log("User asked:" + rawQuestion);

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

        //  PART 3 NAVIGATION 

        //start of method
        private void btn_nav_chat_Click(object sender, RoutedEventArgs e)
        {
            show_panel("chat");
            log.log("Navigated to Chat");
        }
        //end of method

        //start of method
        private void btn_nav_tasks_Click(object sender, RoutedEventArgs e)
        {
            show_panel("tasks");
            load_tasks();
            log.log("Navigated to Tasks");
        }
        //end of method

        //start of method
        private void btn_nav_quiz_Click(object sender, RoutedEventArgs e)
        {
            show_panel("quiz");
            log.log("Navigated to Quiz");
        }
        //end of method

        //start of method
        private void btn_nav_log_Click(object sender, RoutedEventArgs e)
        {
            show_panel("log");
            refresh_log_panel();
            log.log("Navigated to Activity Log");
        }
        //end of method

        //start of method
        private void show_panel(string panel)
        {
            chat_panel.Visibility = Visibility.Collapsed;
            tasks_panel.Visibility = Visibility.Collapsed;
            quiz_panel.Visibility = Visibility.Collapsed;
            log_panel.Visibility = Visibility.Collapsed;

            switch (panel)
            {
                case "chat": chat_panel.Visibility = Visibility.Visible; break;
                case "tasks": tasks_panel.Visibility = Visibility.Visible; break;
                case "quiz": quiz_panel.Visibility = Visibility.Visible; break;
                case "log": log_panel.Visibility = Visibility.Visible; break;
            }
        }
        //end of method

        //  TASKS

        //start of method
        private void btn_add_task_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string title = txt_task_title.Text.Trim();
                string desc = txt_task_desc.Text.Trim();

                if (string.IsNullOrEmpty(title))
                {
                    MessageBox.Show("Please enter a task title.");
                    return;
                }

                bool success = db.add_task(title, desc);
                if (success)
                {
                    txt_task_title.Clear();
                    txt_task_desc.Clear();
                    log.log("Task added: " + title);
                    load_tasks();
                }
                else
                {
                    MessageBox.Show("Could not add task. Check your MySQL connection.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        //end of method

        //start of method
        private void load_tasks()
        {
            try
            {
                tasks_stack.Children.Clear();
                List<task_item> tasks = db.get_all_tasks();

                if (tasks.Count == 0)
                {
                    tasks_stack.Children.Add(new TextBlock
                    {
                        Text = "No tasks yet. Add one above.",
                        Foreground = new SolidColorBrush(Colors.Gray),
                        FontSize = 14,
                        Margin = new Thickness(0, 10, 0, 0)
                    });
                    return;
                }

                foreach (task_item task in tasks)
                {
                    Border card = new Border
                    {
                        Background = new SolidColorBrush(Color.FromRgb(240, 240, 240)),
                        CornerRadius = new CornerRadius(6),
                        Padding = new Thickness(10),
                        Margin = new Thickness(0, 0, 0, 6),
                        BorderBrush = task.IsCompleted ?
                            new SolidColorBrush(Colors.Green) :
                            new SolidColorBrush(Colors.LightBlue),
                        BorderThickness = new Thickness(1)
                    };

                    Grid card_grid = new Grid();
                    card_grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                    card_grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });

                    StackPanel info = new StackPanel();
                    info.Children.Add(new TextBlock
                    {
                        Text = (task.IsCompleted ? "✅ " : "⏳ ") + task.Title,
                        FontSize = 14,
                        FontWeight = FontWeights.SemiBold
                    });
                    if (!string.IsNullOrEmpty(task.Description))
                    {
                        info.Children.Add(new TextBlock
                        {
                            Text = task.Description,
                            Foreground = new SolidColorBrush(Colors.Gray),
                            FontSize = 12,
                            Margin = new Thickness(0, 2, 0, 0)
                        });
                    }
                    info.Children.Add(new TextBlock
                    {
                        Text = "Added: " + task.CreatedAt.ToString("dd MMM yyyy HH:mm"),
                        Foreground = new SolidColorBrush(Colors.Gray),
                        FontSize = 11,
                        Margin = new Thickness(0, 2, 0, 0)
                    });

                    Grid.SetColumn(info, 0);
                    card_grid.Children.Add(info);

                    StackPanel btns = new StackPanel
                    {
                        Orientation = Orientation.Horizontal,
                        VerticalAlignment = VerticalAlignment.Center
                    };

                    if (!task.IsCompleted)
                    {
                        Button btn_complete = new Button
                        {
                            Content = "Complete",
                            Width = 75,
                            Height = 28,
                            Margin = new Thickness(5, 0, 5, 0),
                            Background = new SolidColorBrush(Colors.Green),
                            Foreground = Brushes.White,
                            BorderThickness = new Thickness(0),
                            Cursor = Cursors.Hand,
                            Tag = task.Id
                        };
                        btn_complete.Click += btn_complete_task_Click;
                        btns.Children.Add(btn_complete);
                    }

                    Button btn_del = new Button
                    {
                        Content = "Delete",
                        Width = 65,
                        Height = 28,
                        Background = new SolidColorBrush(Color.FromRgb(220, 50, 50)),
                        Foreground = Brushes.White,
                        BorderThickness = new Thickness(0),
                        Cursor = Cursors.Hand,
                        Tag = task.Id
                    };
                    btn_del.Click += btn_delete_task_Click;
                    btns.Children.Add(btn_del);

                    Grid.SetColumn(btns, 1);
                    card_grid.Children.Add(btns);

                    card.Child = card_grid;
                    tasks_stack.Children.Add(card);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading tasks: " + ex.Message);
            }
        }
        //end of method

        //start of method
        private void btn_complete_task_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button btn = sender as Button;
                int id = (int)btn.Tag;
                db.complete_task(id);
                log.log("Task completed (id: " + id + ")");
                load_tasks();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        //end of method

        //start of method
        private void btn_delete_task_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button btn = sender as Button;
                int id = (int)btn.Tag;
                db.delete_task(id);
                log.log("Task deleted (id: " + id + ")");
                load_tasks();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        //end of method

        //  QUIZ

        //start of method
        private void btn_quiz_start_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                quiz.reset_quiz();
                selected_quiz_option = -1;
                btn_quiz_start.Visibility = Visibility.Collapsed;
                btn_quiz_submit.Visibility = Visibility.Visible;
                log.log("Quiz started");
                show_quiz_question();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        //end of method

        //start of method
        private void show_quiz_question()
        {
            try
            {
                quiz_stack.Children.Clear();
                selected_quiz_option = -1;

                quiz_question q = quiz.get_current_question();
                if (q == null) return;

                txt_quiz_progress.Text = "Question " + (quiz.get_score() + 1) + " of " + quiz.get_total();

                quiz_stack.Children.Add(new TextBlock
                {
                    Text = q.Question,
                    FontSize = 16,
                    FontWeight = FontWeights.SemiBold,
                    TextWrapping = TextWrapping.Wrap,
                    Margin = new Thickness(0, 0, 0, 15)
                });

                for (int i = 0; i < q.Options.Count; i++)
                {
                    int index = i;
                    Border opt = new Border
                    {
                        Background = new SolidColorBrush(Color.FromRgb(240, 240, 240)),
                        CornerRadius = new CornerRadius(6),
                        BorderBrush = new SolidColorBrush(Colors.LightBlue),
                        BorderThickness = new Thickness(2),
                        Padding = new Thickness(12, 8, 12, 8),
                        Margin = new Thickness(0, 0, 0, 8),
                        Cursor = Cursors.Hand,
                        Tag = index
                    };
                    opt.Child = new TextBlock
                    {
                        Text = q.Options[i],
                        FontSize = 14,
                        TextWrapping = TextWrapping.Wrap
                    };
                    opt.MouseLeftButtonDown += (s, ev) =>
                    {
                        foreach (var child in quiz_stack.Children)
                        {
                            if (child is Border b && b.Tag is int)
                                b.BorderBrush = new SolidColorBrush(Colors.LightBlue);
                        }
                        ((Border)s).BorderBrush = new SolidColorBrush(Color.FromRgb(219, 112, 147));
                        selected_quiz_option = index;
                    };
                    quiz_stack.Children.Add(opt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        //end of method

        //start of method
        private void btn_quiz_submit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (selected_quiz_option == -1)
                {
                    MessageBox.Show("Please select an answer.");
                    return;
                }

                quiz_question current = quiz.get_current_question();
                bool correct = quiz.submit_answer(selected_quiz_option);

                quiz_stack.Children.Clear();
                quiz_stack.Children.Add(new TextBlock
                {
                    Text = correct ? "✅ Correct!" : "❌ Incorrect!",
                    Foreground = correct ? new SolidColorBrush(Colors.Green) : new SolidColorBrush(Colors.Red),
                    FontSize = 16,
                    FontWeight = FontWeights.Bold,
                    Margin = new Thickness(0, 0, 0, 8)
                });
                quiz_stack.Children.Add(new TextBlock
                {
                    Text = current.Explanation,
                    FontSize = 13,
                    TextWrapping = TextWrapping.Wrap,
                    Margin = new Thickness(0, 0, 0, 15)
                });

                log.log("Quiz answer submitted — " + (correct ? "Correct" : "Incorrect"));

                if (quiz.is_finished())
                {
                    int score = quiz.get_score();
                    int total = quiz.get_total();
                    quiz_stack.Children.Add(new TextBlock
                    {
                        Text = "🎉 Quiz complete! You scored " + score + " out of " + total + ".",
                        FontSize = 15,
                        FontWeight = FontWeights.Bold,
                        TextWrapping = TextWrapping.Wrap
                    });
                    btn_quiz_submit.Visibility = Visibility.Collapsed;
                    btn_quiz_start.Content = "Restart Quiz";
                    btn_quiz_start.Visibility = Visibility.Visible;
                    txt_quiz_progress.Text = "Finished — Score: " + score + "/" + total;
                    log.log("Quiz finished — Score: " + score + "/" + total);
                }
                else
                {
                    Button btn_next = new Button
                    {
                        Content = "Next Question",
                        Width = 130,
                        Height = 36,
                        Margin = new Thickness(0, 10, 0, 0)
                    };
                    btn_next.Click += (s, ev) => show_quiz_question();
                    quiz_stack.Children.Add(btn_next);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        //end of method

        //  ACTIVITY LOG 

        //start of method
        private void refresh_log_panel()
        {
            try
            {
                log_stack.Children.Clear();
                List<log_entry> entries = log.get_recent(10);

                if (entries.Count == 0)
                {
                    log_stack.Children.Add(new TextBlock
                    {
                        Text = "No activity yet.",
                        Foreground = new SolidColorBrush(Colors.Gray),
                        FontSize = 14
                    });
                    return;
                }

                foreach (log_entry entry in entries)
                {
                    Border card = new Border
                    {
                        Background = new SolidColorBrush(Color.FromRgb(240, 240, 240)),
                        CornerRadius = new CornerRadius(6),
                        Padding = new Thickness(10, 6, 10, 6),
                        Margin = new Thickness(0, 0, 0, 5)
                    };
                    StackPanel sp = new StackPanel();
                    sp.Children.Add(new TextBlock
                    {
                        Text = entry.Message,
                        FontSize = 13
                    });
                    sp.Children.Add(new TextBlock
                    {
                        Text = entry.Timestamp.ToString("dd MMM yyyy HH:mm:ss"),
                        Foreground = new SolidColorBrush(Colors.Gray),
                        FontSize = 11
                    });
                    card.Child = sp;
                    log_stack.Children.Add(card);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        //end of method

        //start of method
        private void btn_clear_log_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                log.clear_log();
                refresh_log_panel();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        //end of method

    }//end of class

}//end of namespace

