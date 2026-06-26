using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog_poe_part2
{//start of namespace
    public class quiz_question
    {
        //start of properties
        public string Question { get; set; }
        public List<string> Options { set; get; }
        public int CorrectIndex { get; set; } 
        public string Explanation { get; set; }
        // end of properties
    }

    public class quiz_manager
    {
        private List<quiz_question> questions;
        private int current_index;
        private int score;

        public quiz_manager()
        {//start of constructor
            //initialize quiz with 15 cybersecurity questions
            score = 0;
            current_index = 0;
            load_questions();
        }//end of constructuctor

        private void load_questions()
        {
            questions = new List<quiz_question>
            {
                new quiz_question {Question ="What does phising mean?",Options = new List<string>{"Hacking a server"," Tricking someone into personal info", "Installing antivirus","Encrypting files" }, CorrectIndex = 1, Explanation= "Phishing tricks users into revealing password or personal info via fake emai or website." },
                new quiz_question {Question = "What is a strong password?",Options = new List<string>{"password123","john1990","P@sswOrd!2024","abc" }, CorrectIndex = 2, Explanation ="A strong passwprd uses uppercase, lowercase,numbers and special  characters." },
                new quiz_question { Question = "What does VPN stand for?", Options = new List<string> { "Virtual Private Network", "Virus Protection Node", "Very Private Network", "Visual Processing Node" }, CorrectIndex = 0, Explanation = "VPN stands for Virtual Private Network and encrypts your internet connection." },
                new quiz_question { Question = "True or False: Public Wi-Fi is always safe to use.", Options = new List<string> { "True", "False" }, CorrectIndex = 1, Explanation = "Public Wi-Fi is often unsecured and attackers can intercept your data." },
                new quiz_question { Question = "What is two-factor authentication (2FA)?", Options = new List<string> { "Using two passwords", "A second verification step after password", "Logging in twice", "Having two accounts" }, CorrectIndex = 1, Explanation = "2FA adds a second layer of verification (like an SMS code) beyond just your password." },
                new quiz_question { Question = "What is malware?", Options = new List<string> { "A type of hardware", "Software designed to harm your system", "A security tool", "A strong firewall" }, CorrectIndex = 1, Explanation = "Malware is malicious software designed to damage, disrupt or gain unauthorised access to a system." },
                new quiz_question { Question = "True or False: Clicking unknown email links is safe if the email looks official.", Options = new List<string> { "True", "False" }, CorrectIndex = 1, Explanation = "Attackers often spoof official-looking emails. Always verify before clicking any link." },
                new quiz_question { Question = "What does HTTPS mean in a URL?", Options = new List<string> { "The site is fast", "The connection is encrypted and secure", "The site is government-owned", "The site has no ads" }, CorrectIndex = 1, Explanation = "HTTPS means the site uses SSL/TLS encryption to protect data in transit." },
                new quiz_question { Question = "What is ransomware?", Options = new List<string> { "Software that speeds up your PC", "Malware that locks your files and demands payment", "An antivirus tool", "A backup service" }, CorrectIndex = 1, Explanation = "Ransomware encrypts your files and demands a ransom payment to restore access." },
                new quiz_question { Question = "How often should you update your passwords?", Options = new List<string> { "Never", "Every 5 years", "Every 3-6 months or after a breach", "Only when forced" }, CorrectIndex = 2, Explanation = "Regularly updating passwords reduces the risk from data breaches and credential theft." },
                new quiz_question { Question = "True or False: Antivirus software alone is enough to protect your device.", Options = new List<string> { "True", "False" }, CorrectIndex = 1, Explanation = "Antivirus is one layer. You also need updates, strong passwords, 2FA, and safe browsing habits." },
                new quiz_question { Question = "What is a firewall?", Options = new List<string> { "A physical wall in a server room", "Software or hardware that monitors and controls network traffic", "A type of antivirus", "A VPN service" }, CorrectIndex = 1, Explanation = "A firewall filters incoming and outgoing network traffic based on security rules." },
                new quiz_question { Question = "What should you do if you receive a suspicious email?", Options = new List<string> { "Open all attachments", "Reply with your details", "Delete it and report it", "Forward it to friends" }, CorrectIndex = 2, Explanation = "Suspicious emails should be deleted and reported to prevent phishing attacks." },
                new quiz_question { Question = "True or False: Using the same password for all accounts is safe.", Options = new List<string> { "True", "False" }, CorrectIndex = 1, Explanation = "If one account is breached, all your accounts become vulnerable. Use unique passwords." },
                new quiz_question { Question = "What is social engineering in cybersecurity?", Options = new List<string> { "Building social media apps", "Manipulating people into revealing confidential info", "Engineering social networks", "Designing user interfaces" }, CorrectIndex = 1, Explanation = "Social engineering exploits human psychology rather than technical vulnerabilities to gain access." }
            };
             
        }//end of question method

        //start of method
        public quiz_question get_current_question()
        {
            if (current_index < questions.Count)
                return questions[current_index];
            return null;
        }//end of method

        //start of method 
        public bool submit_answer(int selected_index)
        {
            quiz_question q = get_current_question();
            if (q == null) return false;
            bool correct = selected_index == q.CorrectIndex;
            if (correct) score++;
            current_index++;
            return correct;
        }//end of method
        public int get_score() { return score;}
        public int get_total() { return questions.Count(); }
        public bool is_finished() { return current_index >= questions.Count(); }

        public void reset_quiz()
        {
            score = 0;
            current_index = 0;
        }
    }
}//end of namespace
