using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Recognition;

namespace SpeechRecognizerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an in-process speech recognizer for the en-US locale
            using (
                SpeechRecognitionEngine recognizer = 
                    new SpeechRecognitionEngine(
                        new System.Globalization.CultureInfo("en-US")))
            {
                // Create and load a dictation grammar
                recognizer.LoadGrammar(new DictationGrammar());

                // Add a handler for the speech recognized event
                recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(recognizer_SpeechRecognized);

                // Configure input to the speech recognizer
                recognizer.SetInputToDefaultAudioDevice();

                // Start asynchronous, continuous speech recognition
                recognizer.RecognizeAsync(RecognizeMode.Multiple);

                // Keep the console window open
                while(true)
                {
                    Console.ReadLine();
                }
            }
        }

        private static void recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            Console.WriteLine("Recognized text: " + e.Result.Text);
        }

        // Handle the SpeechRecognized event

    }
}
