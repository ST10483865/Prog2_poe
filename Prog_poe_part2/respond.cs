using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog_poe_part2
{
    internal class respond
    {
        public respond(ArrayList reply, ArrayList ignore)
        {//start of constructor
            answers(reply);
            words(ignore);
        }//end of constructor
        private void words(ArrayList ignoring)
        {//start of method

            ignoring.Add("a");
            ignoring.Add("about");
            ignoring.Add("above");
            ignoring.Add("across");
            ignoring.Add("after");
            ignoring.Add("afterwards");
            ignoring.Add("again");
            ignoring.Add("against");
            ignoring.Add("all");
            ignoring.Add("almost");
            ignoring.Add("alone");
            ignoring.Add("along");
            ignoring.Add("already");
            ignoring.Add("also");
            ignoring.Add("although");
            ignoring.Add("always");
            ignoring.Add("am");
            ignoring.Add("among");
            ignoring.Add("amongst");
            ignoring.Add("amount");
            ignoring.Add("an");
            ignoring.Add("and");
            ignoring.Add("another");
            ignoring.Add("any");
            ignoring.Add("anyhow");
            ignoring.Add("anyone");
            ignoring.Add("anything");
            ignoring.Add("anyway");
            ignoring.Add("anywhere");
            ignoring.Add("are");
            ignoring.Add("around");
            ignoring.Add("as");
            ignoring.Add("at");
            ignoring.Add("back");
            ignoring.Add("be");
            ignoring.Add("became");
            ignoring.Add("because");
            ignoring.Add("become");
            ignoring.Add("becomes");
            ignoring.Add("becoming");
            ignoring.Add("been");
            ignoring.Add("before");
            ignoring.Add("beforehand");
            ignoring.Add("behind");
            ignoring.Add("being");
            ignoring.Add("below");
            ignoring.Add("beside");
            ignoring.Add("besides");
            ignoring.Add("between");
            ignoring.Add("beyond");
            ignoring.Add("both");
            ignoring.Add("but");
            ignoring.Add("by");
            ignoring.Add("can");
            ignoring.Add("cannot");
            ignoring.Add("could");
            ignoring.Add("did");
            ignoring.Add("do");
            ignoring.Add("does");
            ignoring.Add("doing");
            ignoring.Add("done");
            ignoring.Add("down");
            ignoring.Add("during");
            ignoring.Add("each");
            ignoring.Add("either");
            ignoring.Add("else");
            ignoring.Add("elsewhere");
            ignoring.Add("enough");
            ignoring.Add("etc");
            ignoring.Add("even");
            ignoring.Add("ever");
            ignoring.Add("every");
            ignoring.Add("everyone");
            ignoring.Add("everything");
            ignoring.Add("everywhere");
            ignoring.Add("except");
            ignoring.Add("few");
            ignoring.Add("first");
            ignoring.Add("for");
            ignoring.Add("former");
            ignoring.Add("formerly");
            ignoring.Add("from");
            ignoring.Add("further");
            ignoring.Add("had");
            ignoring.Add("has");
            ignoring.Add("have");
            ignoring.Add("having");
            ignoring.Add("he");
            ignoring.Add("hence");
            ignoring.Add("her");
            ignoring.Add("here");
            ignoring.Add("hereafter");
            ignoring.Add("hereby");
            ignoring.Add("herein");
            ignoring.Add("hereupon");
            ignoring.Add("hers");
            ignoring.Add("herself");
            ignoring.Add("him");
            ignoring.Add("himself");
            ignoring.Add("his");
            ignoring.Add("how");
            ignoring.Add("however");
            ignoring.Add("i");
            ignoring.Add("if");
            ignoring.Add("in");
            ignoring.Add("indeed");
            ignoring.Add("inside");
            ignoring.Add("instead");
            ignoring.Add("into");
            ignoring.Add("is");
            ignoring.Add("it");
            ignoring.Add("its");
            ignoring.Add("itself");
            ignoring.Add("last");
            ignoring.Add("later");
            ignoring.Add("latter");
            ignoring.Add("latterly");
            ignoring.Add("least");
            ignoring.Add("less");
            ignoring.Add("lot");
            ignoring.Add("many");
            ignoring.Add("may");
            ignoring.Add("me");
            ignoring.Add("meanwhile");
            ignoring.Add("might");
            ignoring.Add("more");
            ignoring.Add("moreover");
            ignoring.Add("most");
            ignoring.Add("mostly");
            ignoring.Add("much");
            ignoring.Add("must");
            ignoring.Add("my");
            ignoring.Add("myself");
            ignoring.Add("name");
            ignoring.Add("namely");
            ignoring.Add("neither");
            ignoring.Add("never");
            ignoring.Add("nevertheless");
            ignoring.Add("next");
            ignoring.Add("no");
            ignoring.Add("nobody");
            ignoring.Add("none");
            ignoring.Add("noone");
            ignoring.Add("nor");
            ignoring.Add("not");
            ignoring.Add("nothing");
            ignoring.Add("now");
            ignoring.Add("nowhere");
            ignoring.Add("of");
            ignoring.Add("off");
            ignoring.Add("often");
            ignoring.Add("on");
            ignoring.Add("once");
            ignoring.Add("one");
            ignoring.Add("only");
            ignoring.Add("or");
            ignoring.Add("other");
            ignoring.Add("others");
            ignoring.Add("otherwise");
            ignoring.Add("ought");
            ignoring.Add("our");
            ignoring.Add("ours");
            ignoring.Add("ourselves");
            ignoring.Add("out");
            ignoring.Add("outside");
            ignoring.Add("over");
            ignoring.Add("own");
            ignoring.Add("part");
            ignoring.Add("per");
            ignoring.Add("perhaps");
            ignoring.Add("please");
            ignoring.Add("put");
            ignoring.Add("rather");
            ignoring.Add("re");
            ignoring.Add("same");
            ignoring.Add("see");
            ignoring.Add("seem");
            ignoring.Add("seemed");
            ignoring.Add("seeming");
            ignoring.Add("seems");
            ignoring.Add("several");
            ignoring.Add("she");
            ignoring.Add("should");
            ignoring.Add("show");
            ignoring.Add("side");
            ignoring.Add("since");
            ignoring.Add("so");
            ignoring.Add("some");
            ignoring.Add("somehow");
            ignoring.Add("someone");
            ignoring.Add("something");
            ignoring.Add("sometime");
            ignoring.Add("sometimes");
            ignoring.Add("somewhere");
            ignoring.Add("still");
            ignoring.Add("such");
            ignoring.Add("take");
            ignoring.Add("than");
            ignoring.Add("that");
            ignoring.Add("the");
            ignoring.Add("their");
            ignoring.Add("theirs");
            ignoring.Add("them");
            ignoring.Add("themselves");
            ignoring.Add("then");
            ignoring.Add("thence");
            ignoring.Add("there");
            ignoring.Add("thereafter");
            ignoring.Add("thereby");
            ignoring.Add("therefore");
            ignoring.Add("therein");
            ignoring.Add("thereupon");
            ignoring.Add("these");
            ignoring.Add("they");
            ignoring.Add("this");
            ignoring.Add("those");
            ignoring.Add("though");
            ignoring.Add("through");
            ignoring.Add("throughout");
            ignoring.Add("thru");
            ignoring.Add("thus");
            ignoring.Add("to");
            ignoring.Add("together");
            ignoring.Add("too");
            ignoring.Add("toward");
            ignoring.Add("towards");
            ignoring.Add("under");
            ignoring.Add("unless");
            ignoring.Add("until");
            ignoring.Add("up");
            ignoring.Add("upon");
            ignoring.Add("us");
            ignoring.Add("used");
            ignoring.Add("very");
            ignoring.Add("via");
            ignoring.Add("was");
            ignoring.Add("we");
            ignoring.Add("well");
            ignoring.Add("were");
            ignoring.Add("what");
            ignoring.Add("whatever");
            ignoring.Add("when");
            ignoring.Add("whence");
            ignoring.Add("whenever");
            ignoring.Add("where");
            ignoring.Add("whereafter");
            ignoring.Add("whereas");
            ignoring.Add("whereby");
            ignoring.Add("wherein");
            ignoring.Add("whereupon");
            ignoring.Add("wherever");
            ignoring.Add("whether");
            ignoring.Add("which");
            ignoring.Add("while");
            ignoring.Add("whither");
            ignoring.Add("who");
            ignoring.Add("whoever");
            ignoring.Add("whole");
            ignoring.Add("whom");
            ignoring.Add("whose");
            ignoring.Add("why");
            ignoring.Add("will");
            ignoring.Add("with");
            ignoring.Add("within");
            ignoring.Add("without");
            ignoring.Add("would");
            ignoring.Add("yes");
            ignoring.Add("yet");
            ignoring.Add("hey");
            ignoring.Add("you");
            ignoring.Add("your");
            ignoring.Add("yours");
            ignoring.Add("yourself");
            ignoring.Add("yourselves");
            ignoring.Add("tell");
            ignoring.Add("give");
            ignoring.Add("get");
            ignoring.Add("tip");

        }//end of words method

        //method to load all answers in ArrayList
        public void answers(ArrayList add_answers)
        {//start of method
         //greetings
            add_answers.Add("greeting i'm doing well, thanks for asking! how are you doing today?");
            add_answers.Add("greeting i'm great today! how can i help you stay safe online?");
            add_answers.Add("greeting doing good! what cybersecurity topic can i help you with?");

            //purpose
            add_answers.Add("purpose my purpose is to educate you on how to stay safe online.");
            add_answers.Add("purpose i help users understand online safety and digital protection.");
            add_answers.Add("purpose i assist with cybersecurity awareness and safety guidance.");

            //cybersecurity
            add_answers.Add("cybersecurity cybersecurity is about protecting systems and networks from digital threats.");
            add_answers.Add("cybersecurity it involves protecting devices and online accounts from attacks.");
            add_answers.Add("cybersecurity it focuses on securing digital information and systems from unauthorised access.");

            //password - multiple responses for random selection
            add_answers.Add("password a strong password should be at least 12 characters long.");
            add_answers.Add("password use a mix of uppercase, lowercase, numbers and symbols in your password.");
            add_answers.Add("password never reuse the same password across different websites or apps.");
            add_answers.Add("password consider using a trusted password manager like Bitwarden or LastPass.");
            add_answers.Add("password never share your password with anyone, including IT support staff.");

            //phishing - multiple responses for random selection
            add_answers.Add("phishing phishing is a scam where attackers pretend to be trusted sources to steal information.");
            add_answers.Add("phishing always verify the sender's email address before clicking any links.");
            add_answers.Add("phishing legitimate organisations will never ask for your password via email.");
            add_answers.Add("phishing be cautious of urgent emails asking you to act immediately - this is a common phishing tactic.");
            add_answers.Add("phishing when in doubt, go directly to the official website instead of clicking email links.");

            //browsing - multiple responses for random selection
            add_answers.Add("browsing always look for HTTPS and the padlock icon before entering personal information on a website.");
            add_answers.Add("browsing avoid downloading software from unknown or untrusted websites.");
            add_answers.Add("browsing keep your browser and all extensions updated regularly to patch security vulnerabilities.");
            add_answers.Add("browsing use a reputable antivirus program and keep it updated for safe browsing.");
            add_answers.Add("browsing clear your browser cookies and cache regularly to protect your privacy.");

            //malware - multiple responses for random selection
            add_answers.Add("malware malware includes viruses, ransomware, spyware, trojans and worms.");
            add_answers.Add("malware never open email attachments from unknown or unexpected senders.");
            add_answers.Add("malware keep your operating system and all software updated to patch vulnerabilities.");
            add_answers.Add("malware regularly back up your important data - this is your best defence against ransomware.");
            add_answers.Add("malware avoid pirated software as it often contains hidden malware.");

            //vpn - multiple responses for random selection
            add_answers.Add("vpn a vpn encrypts your internet connection protecting your data from eavesdroppers.");
            add_answers.Add("vpn always use a vpn when connected to public wi-fi at cafes, airports or hotels.");
            add_answers.Add("vpn a vpn hides your ip address, improving your online privacy.");
            add_answers.Add("vpn choose a reputable vpn provider that has a strict no-logs policy.");
            add_answers.Add("vpn popular trusted vpns include nordvpn, expressvpn and protonvpn.");

            //privacy - multiple responses for random selection
            add_answers.Add("privacy limit the personal information you share online.");
            add_answers.Add("privacy review app permissions and only grant access to what is truly necessary.");
            add_answers.Add("privacy regularly review and tighten your social media privacy settings.");
            add_answers.Add("privacy in south africa, the popia act protects your personal information rights.");
            add_answers.Add("privacy be cautious about what you post publicly as it can be permanent.");

            //two factor authentication
            add_answers.Add("factor two-factor authentication adds an extra layer of security beyond just a password.");
            add_answers.Add("factor even if your password is stolen, attackers cannot access your account without the second factor.");
            add_answers.Add("factor use an authenticator app like google authenticator rather than sms-based 2fa.");
            add_answers.Add("factor enable 2fa on all important accounts including email, banking and social media.");

            //social engineering
            add_answers.Add("social social engineering manipulates people into revealing confidential information.");
            add_answers.Add("social be suspicious of unsolicited calls, emails or messages asking for personal info.");
            add_answers.Add("social legitimate organisations will never ask for your password over the phone.");

            //hacked
            add_answers.Add("hacked immediately secure your account and log out of all devices if you think you have been hacked.");
            add_answers.Add("hacked contact the platform's support team if your account has been compromised.");
            add_answers.Add("hacked enable two-factor authentication immediately after recovering a hacked account.");

            //fraud
            add_answers.Add("fraud contact your bank immediately if you suspect fraud on your account.");
            add_answers.Add("fraud report suspicious financial activity to the authorities.");
            add_answers.Add("fraud monitor your accounts regularly for any unusual activity.");

            //sentiment detection responses
            add_answers.Add("frustrated i understand you are frustrated. let's work through the issue step by step.");
            add_answers.Add("frustrated it's okay to feel frustrated when things aren't working. i am here to help.");
            add_answers.Add("frustrated take a breath, we will fix this together.");

            add_answers.Add("confused that's okay, confusion is normal. i will explain it clearly for you.");
            add_answers.Add("confused let me break it down step by step so it makes sense.");
            add_answers.Add("confused no worries, i will help you understand it better.");

            add_answers.Add("worried it's okay to feel worried. i am here to help you stay safe online.");
            add_answers.Add("worried don't panic, most cybersecurity issues can be fixed quickly.");
            add_answers.Add("worried i understand your concern. let's make sure your information is safe.");

            add_answers.Add("scared it is completely understandable to feel scared about cybersecurity threats.");
            add_answers.Add("scared don't worry, knowing about threats is the best way to protect yourself.");
            add_answers.Add("scared i am here to help you feel more confident about staying safe online.");

            add_answers.Add("happy that's great to hear! i am glad things are going well.");
            add_answers.Add("happy awesome! positivity is always good when learning about cybersecurity.");
            add_answers.Add("happy i am happy for you! let me know if you need any cybersecurity tips.");

            add_answers.Add("sad i am sorry you are feeling this way. i am here for you.");
            add_answers.Add("sad that sounds tough, take things one step at a time.");
            add_answers.Add("sad i hope things improve soon. you can talk to me anytime.");

            add_answers.Add("angry i understand you are angry. let's try to solve the issue together.");
            add_answers.Add("angry it's okay to feel angry, but i will help you fix the problem.");
            add_answers.Add("angry take your time, i am here to help you sort it out.");

            add_answers.Add("curious great curiosity! being eager to learn about cybersecurity is the first step to staying safe.");
            add_answers.Add("curious i love the curiosity! let me help you explore this topic further.");
            add_answers.Add("curious asking questions is the best way to learn. what would you like to know?");

            add_answers.Add("overwhelmed take it one step at a time. you do not need to learn everything at once.");
            add_answers.Add("overwhelmed start with password safety - it is the most important cybersecurity topic.");
            add_answers.Add("overwhelmed cybersecurity does not have to be complicated. i will explain things simply.");

        }//end of method

    }
}
