using System;
using System.Speech.Synthesis;

namespace God
{
    static class Sintetizador
    {
        private static SpeechSynthesizer synthesizer = new SpeechSynthesizer();

        public static void Speak(string text)
        {
            if (synthesizer.State == SynthesizerState.Speaking)
                synthesizer.SpeakAsyncCancelAll();

            synthesizer.SpeakAsync(text);
        }

        public static void Speak(string[] text)
        {
            Speak(text[new Random().Next(0, text.Length - 1)]);
        }
    }
}
