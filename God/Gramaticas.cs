using Microsoft.Speech.Recognition;

namespace God
{
    static class Gramaticas
    {
        public static Grammar HoraAtual()
        {
            var opcoesInicio = new Choices();
            opcoesInicio.Add(new[] { "que", "qual", "tem" });

            var opcoesMeio = new Choices();
            opcoesMeio.Add(new[] { "hora", "horas" });

            var opcoesFim = new Choices();
            opcoesFim.Add(new[] { "são", "é" });

            var builder = new GrammarBuilder();
            builder.Append(opcoesInicio);
            builder.Append(opcoesMeio);
            builder.Append(opcoesFim, 0, 1);

            var grammar = new Grammar(builder)
            {
                Name = "HoraAtual"
            };

            return grammar;
        }

        public static Grammar DataAtual()
        {
            var opcoesInicio = new Choices();
            opcoesInicio.Add(new[] { "que", "qual", "tem" });

            var opcoesMeio = new Choices();
            opcoesMeio.Add(new[] { "hora", "horas" });

            var opcoesFim = new Choices();
            opcoesFim.Add(new[] { "são", "é" });

            var builder = new GrammarBuilder();
            builder.Append(opcoesInicio);
            builder.Append(opcoesMeio);
            builder.Append(opcoesFim, 0, 1);

            var grammar = new Grammar(builder)
            {
                Name = "HoraAtual"
            };

            return grammar;
        }
    }
}
