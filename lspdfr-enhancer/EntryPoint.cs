using Rage;
using Rage.Attributes;
using LSPDFR_Enhancer.Utilities;

[assembly: Plugin("LSPDFR Enhancer", Description = "Enhances LSPDFR", Author = "BlockBa5her")]
namespace LSPDFR_Enhancer
{
    public static class EntryPoint
    {
        /// <summary>
        /// Main code for LSPDE
        /// </summary>
        /// 
        public static void Main()
        {
            Config.GetConfig();

            //Successfully loaded stuff
            Logger.Log("LSPDE loaded successfully");
            Logger.Log("LSPDE version v2.0");
            Game.DisplayNotification("~b~LSP~r~DFR~w~ Enhancer ~g~successfully~w~ loaded");
            Game.DisplayNotification("~b~LSP~r~DFR~w~ Enhancer ~y~v2.0 STABLE");

            //Initializing the menu...
            GUI.GUIHandler.InitializeMenu();

            GameFiber.Hibernate();

        }

        //[ConsoleCommand("CleanUpLSPDE", Name = "LSPDECleanUp")]
        private static void Cleanup()
        {
            Logger.Log("Running LSPDE Cleanup");

            GUI.GUI.LSPDECleanUp();
        }
    }
}