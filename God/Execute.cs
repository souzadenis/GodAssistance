using System;

namespace God
{
    static class Execute
    {
        public static void MostraHorasHoje()
        {
            Sintetizador.Speak(DateTime.Now.ToShortTimeString());
        }

        public static void MostraDataHoje()
        {
            Sintetizador.Speak(DateTime.Now.ToShortDateString());
        }

    }
}
