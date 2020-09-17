using System;
using System.Windows.Forms;
using System.Globalization;
using Microsoft.Speech.Recognition;

namespace God
{
    public partial class App : Form
    {
        const string culture = "pt-BR";

        public App()
        {
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
            var SpeechRecognitionEngine = new SpeechRecognitionEngine(new CultureInfo(culture));

            // Pega o recurso de audio padrão do sistema
            SpeechRecognitionEngine.SetInputToDefaultAudioDevice();

            // Eventos
            // Quando o audio for reconhecido
            SpeechRecognitionEngine.SpeechRecognized += SpeechRecognitionEngine_SpeechRecognized;
            // Quando capta algum audio
            SpeechRecognitionEngine.AudioLevelUpdated += SpeechRecognitionEngine_AudioLevelUpdated;
            // Quando não reconhecer o audio
            SpeechRecognitionEngine.SpeechRecognitionRejected += SpeechRecognitionEngine_SpeechRecognitionRejected;

            // Carrega gramatica
            var choices = new Choices();
            choices.Add(Gramaticas.HoraAtual.ToArray());
            choices.Add(Gramaticas.DataAtual.ToArray());

            var builder = new GrammarBuilder();
            builder.Append(choices);

            var grammar = new Grammar(builder);
            grammar.Name = "System";

            SpeechRecognitionEngine.LoadGrammar(grammar);

            // Inicia o reconhecimento
            SpeechRecognitionEngine.RecognizeAsync(RecognizeMode.Multiple);
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
            var nomeGramatica = e.Result.Grammar.Name;
            var frase = e.Result.Text;

            Console.WriteLine(string.Format("Fala reconhecida: {0}/{1}", frase, nomeGramatica));

            switch (nomeGramatica)
            {
                case "System":
                    if (Gramaticas.HoraAtual.Contains(frase))
                    {
                        Execute.MostraHorasHoje();
                    }
                    else if (Gramaticas.DataAtual.Contains(frase))
                    {
                        Execute.MostraDataHoje();
                    }
                    break;
            }
        }

    }
}
