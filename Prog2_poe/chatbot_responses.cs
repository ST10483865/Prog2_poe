using System.Collections;
using System.Collections.Generic;

namespace Prog2_poe
{//start of name space
    public class chatbot_responses
    {//start of class
        public string BotName { get; private set; }
        public int ResponseCount { get; private set; }

        // dictionary to store keyword-response pairs
        private Dictionary<string, string> response_dictionary;

        public chatbot_responses()
        { //start of constructor
            BotName = "CyberBot";
            ResponseCount = 0;
            response_dictionary = new Dictionary<string, string>();
            load_responses();
        }// end of constructor

        //method to load all responese into the dictionary
        private void load_responses()
        { //start of method 
            response_dictionary.Add("password",
               "PASSWORD SAFETY TIPS:\n" +
               "  * Use at least 12 characters - the longer the better.\n" +
               "  * Combine uppercase, lowercase, numbers and symbols (e.g. P@ssw0rd!).\n" +
               "  * Never reuse the same password across different websites or apps.\n" +
               "  * Use a trusted password manager like Bitwarden or LastPass.\n" +
               "  * Change your password immediately if you suspect a breach.\n" +
               "  * Never share your password with anyone, including IT support staff.");

            response_dictionary.Add("phishing",
                "PHISHING AWARENESS:\n" +
                "  * Phishing tricks you into revealing personal info via fake emails or websites.\n" +
                "  * Always verify the sender's email address - look for subtle misspellings.\n" +
                "  * Never click on suspicious or unexpected links in emails.\n" +
                "  * Legitimate organisations will NEVER ask for your password via email.\n" +
                "  * When in doubt, go directly to the official website instead of clicking links.\n" +
                "  * Report phishing emails to your IT department or email provider.");

            response_dictionary.Add("browsing",
                "SAFE BROWSING TIPS:\n" +
                "  * Always use HTTPS websites - look for the padlock icon in your browser.\n" +
                "  * Avoid downloading files from unknown or untrusted sources.\n" +
                "  * Keep your browser and all extensions updated regularly.\n" +
                "  * Use a reputable antivirus program and keep it updated.\n" +
                "  * Avoid public Wi-Fi for sensitive activities like online banking.\n" +
                "  * Clear your browser cookies and cache regularly for better privacy.");

            response_dictionary.Add("Two - factor authentication",
                "TWO-FACTOR AUTHENTICATION:\n" +
                "  * 2FA adds an extra layer of security beyond just a password.\n" +
                "  * Even if your password is stolen, attackers cannot access your account\n" +
                "    without the second factor such as a code sent to your phone.\n" +
                "  * Use an authenticator app like Google Authenticator or Microsoft Authenticator\n" +
                "    rather than SMS-based two-factor authentication where possible - it is more secure.\n" +
                "  * Enable two-factor authentication on all important accounts: email, banking and social media.\n" +
                "  * Never share your two-factor authentication codes with anyone.");

            response_dictionary.Add("malware",
                "MALWARE AWARENESS:\n" +
                "  * Malware includes viruses, ransomware, spyware, trojans and worms.\n" +
                "  * Never open email attachments from unknown or unexpected senders.\n" +
                "  * Keep your operating system and all software updated to patch vulnerabilities.\n" +
                "  * Install and regularly scan with a reputable antivirus program.\n" +
                "  * Regularly back up your important data - this is your best defence against ransomware.\n" +
                "  * Avoid pirated software as it often contains hidden malware.");

            response_dictionary.Add("social_engineering",
                "SOCIAL ENGINEERING AWARENESS:\n" +
                "  * Social engineering manipulates people into revealing confidential information.\n" +
                "  * Be suspicious of unsolicited calls, emails or messages asking for personal info.\n" +
                "  * Legitimate organisations will NEVER ask for your password over the phone.\n" +
                "  * Always verify the identity of anyone requesting sensitive information.\n" +
                "  * Be cautious of urgency tactics - attackers often create a false sense of emergency.\n" +
                "  * Common types include phishing, vishing (voice), smishing (SMS) and impersonation.");

            response_dictionary.Add("vpn",
                "VPN (Virtual Private Network):\n" +
                "  * A VPN encrypts your internet connection, protecting your data from eavesdroppers.\n" +
                "  * Always use a VPN when connected to public Wi-Fi at cafes, airports or hotels.\n" +
                "  * A VPN hides your IP address, improving your online privacy.\n" +
                "  * Choose a reputable VPN provider that has a strict no-logs policy.\n" +
                "  * Free VPNs can be risky as they may sell your data - consider a paid option.\n" +
                "  * Popular trusted VPNs include NordVPN, ExpressVPN and ProtonVPN.");

            response_dictionary.Add("privacy",
                "DATA PRIVACY TIPS:\n" +
                "  * Limit the personal information you share online.\n" +
                "  * Review app permissions and only grant access to what is truly necessary.\n" +
                "  * Regularly review and tighten your social media privacy settings.\n" +
                "  * Be cautious about what you post publicly as it can be permanent.\n" +
                "  * In South Africa, the POPIA Act protects your personal information rights.\n" +
                "  * Opt out of data collection and targeted advertising where possible.");
        }//end of response loding method

        //method to get a response based on user input
        public string get_response(string input, string user_name)
        {//start of method

            //increment the response count property
            ResponseCount++;

            //exit commands
            if (input.Contains("exit") || input.Contains("quit") ||
                input.Contains("bye") || input.Contains("goodbye"))
                return "EXIT";

            //greetings
            if (input.Contains("hello") || input.Contains("hi") ||
                input.Contains("hey") || input.Contains("greetings"))
                return $"Hello again, {user_name}! How can I help you with cybersecurity today?";

            //how are you
            if (input.Contains("how are you") || input.Contains("how r u") ||
                input.Contains("how do you do") || input.Contains("you doing"))
                return $"I am running smoothly and staying vigilant against cyber threats!\n" +
                       $"  Thanks for asking, {user_name}. How can I help you today?";

            //purpose
            if (input.Contains("purpose") || input.Contains("what do you do") ||
                input.Contains("what are you") || input.Contains("who are you") ||
                input.Contains("your role"))
                return "My purpose is to educate and assist you with cybersecurity awareness.\n" +
                       "  I help you understand threats like phishing, weak passwords,\n" +
                       "  malware, social engineering and unsafe browsing habits.\n" +
                       "  Think of me as your personal cybersecurity guide!";

            //help / topics / menu
            if (input.Contains("help") || input.Contains("topics") ||
                input.Contains("what can i ask") || input.Contains("menu") ||
                input.Contains("options"))
                return "Here are all the topics you can ask me about:\n" +
                       "  -> Password safety\n" +
                       "  -> Phishing\n" +
                       "  -> Safe browsing\n" +
                       "  -> Two-factor authentication (2FA)\n" +
                       "  -> Malware\n" +
                       "  -> Social engineering\n" +
                       "  -> VPN\n" +
                       "  -> Data privacy\n" +
                       "  Just type any of these topics and I will help you!";

            //thank you
            if (input.Contains("thank") || input.Contains("thanks") ||
                input.Contains("appreciate"))
                return $"You are welcome, {user_name}!\n" +
                       "  Staying informed is the first step to staying secure online.\n" +
                       "  Feel free to ask me anything else!";

            //check the dictionary for keyword matches
            foreach (KeyValuePair<string, string> entry in response_dictionary)
            {
                if (input.Contains(entry.Key))
                {
                    return entry.Value;
                }
            }

            //extra keyword aliases that map to dictionary entries
            if (input.Contains("passphrase") || input.Contains("credentials"))
                return response_dictionary["password"];

            if (input.Contains("phish") || input.Contains("fake email") ||
                input.Contains("email scam"))
                return response_dictionary["phishing"];

            if (input.Contains("browse") || input.Contains("internet safety") ||
                input.Contains("online safety"))
                return response_dictionary["browsing"];

            if (input.Contains("two factor") || input.Contains("two-factor") ||
                input.Contains("authentication") || input.Contains("mfa") ||
                input.Contains("verification"))
                return response_dictionary["2fa"];

            if (input.Contains("virus") || input.Contains("ransomware") ||
                input.Contains("spyware") || input.Contains("trojan") ||
                input.Contains("worm"))
                return response_dictionary["malware"];

            if (input.Contains("scam") || input.Contains("fraud") ||
                input.Contains("manipulation"))
                return response_dictionary["social engineering"];

            if (input.Contains("virtual private network") || input.Contains("encrypt") ||
                input.Contains("public wifi"))
                return response_dictionary["vpn"];

            if (input.Contains("personal data") || input.Contains("personal information") ||
                input.Contains("data protection") || input.Contains("popia") ||
                input.Contains("gdpr"))
                return response_dictionary["privacy"];

            //Task 5: default response for unrecognised or invalid input
            return "I did not quite understand that. Could you rephrase?\n" +
                   "  Try asking about 'password safety', 'phishing', 'safe browsing',\n" +
                   "  'malware', 'VPN' or type 'help' to see all available topics.";

        }//end of get_response method


    }//end of class
}//end of namespace