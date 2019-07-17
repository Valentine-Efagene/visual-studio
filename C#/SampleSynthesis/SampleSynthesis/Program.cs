using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;

namespace SampleSynthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize a new instance of the speech synthesizer
            SpeechSynthesizer synth = new SpeechSynthesizer();

            synth.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Adult);

            // Configure the audio output
            synth.SetOutputToDefaultAudioDevice();

            // Speak a string
            synth.Speak("This example demonstrates a basic use of speech synthesizer");

            Console.WriteLine();
            Console.WriteLine("Press any key to exit . . . ");
            Console.ReadKey();
        }
    }
}
