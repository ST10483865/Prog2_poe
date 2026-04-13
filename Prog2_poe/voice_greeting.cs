using System;
using System.Drawing;
using System.IO;
using System.Media;

namespace Prog2_poe
{//start of namespace
    public class voice_greeting
    {//start of class

        //Auto get the path directory
        private string full_path = AppDomain.CurrentDomain.BaseDirectory;
        public voice_greeting() 
        { //start of constructor
            PlayWelcomeMessage();
            logo_to_ascii();
        }//end of constructor
        
        //method to play the sound
        public void PlayWelcomeMessage() 
        { //start of the method
            Console.WriteLine(full_path);// check if the path way is auto collected
            string correct_path = full_path.Replace(@"bin\Debug\", @"\sound.wav");
            Console.WriteLine(correct_path);

            SoundPlayer sound = new SoundPlayer(correct_path);
            sound.PlaySync();
        }//end of the playwelcomeMessage method

        //method to convert the logo to ascii art
        public void logo_to_ascii()
        {
            string path = full_path.Replace(@"bin\Debug\", @"\logo_art.jpg");

            Bitmap image = new Bitmap(path);

            // Resize for better console fit
            int width = 150;
            int height = 70; 
            Bitmap resized = new Bitmap(image, new Size(width, height));

            string asciiChars = "@#S%?*+;:,. ";

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

                    Console.Write(asciiChars[index]);
                }
                Console.WriteLine();
            }
        }
    

    }//end of class


}//end of namespace

