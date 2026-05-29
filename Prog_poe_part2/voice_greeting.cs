using System;
using System.Drawing;
using System.IO;
using System.Media;
using System.Text;

namespace Prog_poe_part2
{//start of namespace
    public class voice_greeting
    {//start of class

        //Auto get the path directory
        private string full_path = AppDomain.CurrentDomain.BaseDirectory;
        public voice_greeting() 
        { //start of constructor
            
        }//end of constructor
        
        //method to play the sound
        public void greet() 
        { //start of the method
            try
            {
                string correct_path = full_path.Replace(@"bin\Debug\", @"\sound.wav");
                SoundPlayer sound = new SoundPlayer(correct_path);
                sound.Play();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Could not play sound: " + ex.Message);
            }
        }//end of the method

        //method to convert the logo to ascii art
        //return the ascii art as a string for the GUI display
        public string get_ascii_art()
        {
            try
            {
                string path = full_path.Replace(@"bin\Debug\", @"\logo_art.jpg");

                Bitmap image = new Bitmap(path);

                // Resize for better console fit
                int width = 150;
                int height = 70;
                Bitmap resized = new Bitmap(image, new Size(width, height));

                string asciiChars = "@#S%?*+;:,. ";
                StringBuilder ascii_art = new StringBuilder(); 


                for (int y = 0; y < resized.Height; y++)
                {
                    //then width
                    for (int x = 0; x < resized.Width; x++)
                    {
                        //color the pixel on x and y
                        Color pixel = resized.GetPixel(x, y);

                        // Convert to grayscale
                        int gray = (pixel.R + pixel.G + pixel.B) / 3;

                        // Map grayscale to ASCII
                        int index = (gray * (asciiChars.Length - 1)) / 255;

                        ascii_art.Append(asciiChars[index]);
                    }
                    ascii_art.AppendLine();
                }
                return ascii_art.ToString();
            }
            catch(Exception ex)
            {
                return "[CYBERSECURITY AWARENESS BOT]";
            }
        }//end of method
    

    }//end of class


}//end of namespace

