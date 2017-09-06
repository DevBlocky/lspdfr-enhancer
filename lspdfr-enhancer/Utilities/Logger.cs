using Rage;

namespace LSPDFR_Enhancer.Utilities
{
    internal class Logger
    {
        private const string PREFIX = "[LSPDFR Enhancer]";

        internal static string Log(string text)
        {
            string e = string.Format("{0}: {1}", PREFIX, text);

            Game.LogTrivial(e);

            return e;
        }

        internal static string Log(string errorText, int errorCode)
        {
            string e = string.Format("{0}: ERROR CODE {1} | Exception: {2}", PREFIX, errorCode, errorText);

            Game.LogTrivial(e);

            return e;
        }

        public override string ToString()
        {
            return null;
        }
    }
}
