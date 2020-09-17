using System;
using System.Windows.Forms;
using System.Globalization;
using Microsoft.Speech.Recognition;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

namespace God
{
    public partial class App : Form
    {
        const string culture = "pt-BR";

        private SpeechRecognitionEngine SpeechRecognitionEngine;

        public App()
        {
            SpeechRecognitionEngine = new SpeechRecognitionEngine(new CultureInfo(culture));
            InitializeComponent();
        }



        private void Start(object sender, EventArgs e)
        {
            try
            {
                SpeechRecognition_Init();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Start error");
            }
        }

        private void SpeechRecognition_Init()
        {
            // Pega o recurso de audio padrão do sistema
            SpeechRecognitionEngine.SetInputToDefaultAudioDevice();

            // Eventos
            // Quando o audio for reconhecido
            SpeechRecognitionEngine.SpeechRecognized += SpeechRecognitionEngine_SpeechRecognized;
            // Quando capta algum audio
            SpeechRecognitionEngine.AudioLevelUpdated += SpeechRecognitionEngine_AudioLevelUpdated;
            // Quando não reconhecer o audio
            SpeechRecognitionEngine.SpeechRecognitionRejected += SpeechRecognitionEngine_SpeechRecognitionRejected;
            // Quando finaliza um reconhecimento
            SpeechRecognitionEngine.RecognizeCompleted += SpeechRecognitionEngine_RecognizeCompleted;

            SpeechRecognitionEngine.LoadGrammar(Gramaticas.HoraAtual());
            SpeechRecognitionEngine.LoadGrammar(CriaGramaticaData());

            // Inicia o reconhecimento
            SpeechRecognitionEngine.RecognizeAsync(RecognizeMode.Multiple);
        }

        private Grammar CriaGramaticaData()
        {
            // Escolhas
            var commandos = new Choices();
            commandos.Add(Gramaticas.Data.ToArray());
            
            var builder = new GrammarBuilder(commandos);

            var grammar = new Grammar(builder)
            {
                Name = "Gram_Data"
            };

            return grammar;
        }


        private void SpeechRecognitionEngine_RecognizeCompleted(object sender, RecognizeCompletedEventArgs e)
        {
            Console.WriteLine("RecognizeCompleted");
        }

        private void SpeechRecognitionEngine_SpeechRecognitionRejected(object sender, SpeechRecognitionRejectedEventArgs e)
        {
            Console.WriteLine("Rejected text: " + e.Result.Text);
        }

        private void SpeechRecognitionEngine_AudioLevelUpdated(object sender, AudioLevelUpdatedEventArgs e)
        {
            barraAudio.Value = e.AudioLevel;
        }

        private void SpeechRecognitionEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            var frase = e.Result.Text;

            Console.WriteLine("Recognized text: " + frase);

            if (e.Result.Grammar.Name == Gramaticas.NomeGramatica)
            {
                if (Gramaticas.Hora.Any(i => i == frase))
                    Execute.MostraHorasHoje();
                else if (Gramaticas.Data.Any(i => i == frase))
                    Execute.MostraDataHoje();
            }
        }

    }
}
