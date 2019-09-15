using System;
using System.Speech.Recognition;
namespace SpeechApp
{
    class Program
    {
        private static SpeechRecognitionEngine engine;

        static void Main(string[] args)
        {
            // Pre-requisite: Speech SDK 5.1 must be installed in your Windows OS
            // Note: Windows 10 comes with it pre-installed

            engine = new SpeechRecognitionEngine(); // Creating a new instance of the Recognizer 8.0 (maybe)
            engine.SetInputToDefaultAudioDevice(); // Defines the input
            engine.LoadGrammar(new DictationGrammar()); // loads grammer

            Console.WriteLine("Listening");
            engine.SpeechRecognized += rec;
            engine.RecognizeAsync(RecognizeMode.Multiple); // Listen
            engine.SpeechDetected += Engine_SpeechDetected;
            engine.RecognizeCompleted += Engine_RecognizeCompleted;


            Console.WriteLine("Press any key to exit...");

            Console.ReadKey();
        }

        private static void Engine_RecognizeCompleted(object sender, RecognizeCompletedEventArgs e)
        {
            Console.WriteLine("Recognized Complete");
        }

        private static void Engine_SpeechDetected(object sender, SpeechDetectedEventArgs e)
        {
            Console.WriteLine("Speech detected");
        }

        private static void rec(object sender, SpeechRecognizedEventArgs result)
        {
            Console.WriteLine("You said: {0}  Conf: {1}", result.Result.Text, result.Result.Confidence);
        }
    }
}
