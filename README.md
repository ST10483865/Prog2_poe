# Prog2_poe
Cybersecurity Awareness Chatbot
PROG6221 – Part 1 POE
A C# console application that acts as a Cybersecurity Awareness Chatbot. The chatbot plays a voice greeting on launch, displays an ASCII art logo, and then guides the user through cybersecurity topics in a conversational interface.

Features
Voice Greeting – Plays a recorded WAV welcome message when the application starts
ASCII Art Logo – Converts a JPG image into ASCII art and displays it as a header
Personalised Greeting – Asks the user for their name and welcomes them personally
Cybersecurity Responses – Provides detailed tips on 10 cybersecurity topics
Input Validation – Handles empty inputs and unrecognised queries gracefully
Enhanced Console UI – Coloured text, typing effect, dividers, and decorative borders

8 Cybersecurity topics
1.Password safety
2.Phishing
3.Safe browsing
4.Two-factor authentication (2FA)
5.Malware
6.Social engineering
7.VPN
8.Data privacy

Project structure
.program.cs
.greeting_voice.cs
.user_interaction.cs
.display_helper.cs
.chatbot_responses.cs

# PART2
AWARENESS CHAT BOT GUI

Description
An expanded version of the chatbot with a Graphical User Interface built using WPF. The responses are more dynamic with keyword recognition, random responses, conversation flow, memory and recall, and sentiment detection.
Features

# GUI interface with three pages — home, username entry, and chat
Voice greeting and ASCII art displayed in the GUI
Keyword recognition for cybersecurity topics
Random responses for phishing and browsing topics
Conversation flow — type "tell me more" for follow up information
Memory and recall — stores user interests and recalls them every 3 messages
Sentiment detection — detects worried, curious, frustrated, overwhelmed, happy and sad
Input validation and error handling
Topic buttons for quick access to cybersecurity topics
Pink chat bubbles for user messages and blue for bot messages

# Project Structure
FilMainWindow.xaml -GUI design and layout
MainWindow.xaml.cs - GUI logic and event handlers 
voice_greeting.cs -Voice greeting and ASCII art 
respond.cs  -Loads all responses and ignored words 
user_name.cs  -Memory recall and returning user detection
display_helper.cs - Console formatting helpers 
chatbot_responses.cs -Response dictionary

## Part 3 — Enhanced WPF Application (Prog_poe_part2)

### New Features Added
- **Task Assistant** — Add, view, complete and delete cybersecurity tasks stored in SQL Server LocalDB
- **Cybersecurity Quiz** — 15 questions with multiple choice and true/false, score tracking and explanations
- **NLP Simulation** — Intent detection and keyword recognition for 10 cybersecurity topics
- **Activity Log** — Tracks all user actions with timestamps, shows last 10 activities

### Database
- Uses SQL Server LocalDB built into Visual Studio
- No external database setup required
- Database and table created automatically when app starts

### How to Run
1. Open `Prog_poe_part2` project in Visual Studio
2. Set as startup project
3. Press F5 to run
4. Database is created automatically

### Project Structure
| File | Description |
|---|---|
| `MainWindow.xaml` | WPF layout with all panels |
| `MainWindow.xaml.cs` | Main logic for all features |
| `chatbot_responses.cs` | Cybersecurity response dictionary |
| `respond.cs` | ArrayList responses and ignored words |
| `database_helper.cs` | SQL Server CRUD operations for tasks |
| `quiz_manager.cs` | 15-question cybersecurity quiz |
| `activity_log.cs` | Activity tracking with timestamps |
| `nlp_manager.cs` | Intent detection and keyword matching |
| `user_name.cs` | Username memory recall |
| `voice_greeting.cs` | Voice greeting and ASCII art |
| `display_helper.cs` | Display formatting helper |





