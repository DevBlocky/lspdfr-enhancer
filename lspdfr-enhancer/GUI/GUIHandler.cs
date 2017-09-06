using Rage;
using LSPDFR_Enhancer.Utilities;

namespace LSPDFR_Enhancer.GUI
{
    /// <summary>
    /// Class is responsible for player interacting with menu.
    /// </summary>
    public static class GUIHandler
    {
        private static GUI gui;
        private static Config c = Config.GetConfig();
        private static GUIList l;

        public static void InitializeMenu()
        {
            Logger.Log("Initializing menu");

            Logger.Log("Initializing GUI");
            gui = new GUI(l = new GUIList
            {
                PlayerModels = c.CharacterModelsList(),
                PlayerModelNames = c.CharacterModelNamesList(),
                VehicleModels = c.CarModelsList(),
                VehicleModelNames = c.CarModelsNameList(),
                WeaponModels = c.WeaponModelsList(),
                WeaponNames = c.WeaponModelNamesList(),
                WeatherType = c.WeatherTypesList(),
                WeatherName = c.WeatherNamesList(),
                TimeInt = c.TimesList(),
                Time = c.TimeNamesList()
            });

            Logger.Log("Creating GUI");
            gui.Create();

            Logger.Log("Running GUI");
            gui.Run();

            new GameFiber(IsCheckboxChecked, "LSPDE Thread").Start();

            Logger.Log("Loaded GUIHandler");

            OpenCloseMenu();
        }

        /// <summary>
        /// Mainlogic to the program (keys and isdead stuff)
        /// </summary>
        private static void OpenCloseMenu()
        {
            GameFiber.StartNew(delegate
            {
                while (true)
                {
                    GameFiber.Yield();

                    //Detecting if the player has pressed openMenu Key
                    if (Game.IsKeyDown(c.GetKeyBinding()))
                    {
                        //Changes menu visability state from opposite of what it was
                        gui.MainMenu.Visible = !gui.MainMenu.Visible;
                    }
                    //Making sure if player is dead than the menu is un-openable
                    if (Game.LocalPlayer.Character.IsDead)
                    {
                        gui.MainMenu.Visible = false;
                    }
                    //Closes the StopWeaponDeliveryMenu when open
                    if (gui.StopWeaponDeliveryMenu.Visible)
                    {
                        gui.StopWeaponDeliveryMenu.Visible = false;
                    }
                    //Closes the StopVehicleDeliveryMenu when open
                    if (gui.StopVehicleDeliveryMenu.Visible)
                    {
                        gui.StopVehicleDeliveryMenu.Visible = false;
                    }
                    gui._MenuPool.ProcessMenus();
                }
            });
        }

        /// <summary>
        /// Checkbox functions in a thread go here
        /// </summary>
        internal static void IsCheckboxChecked()
        {
            while (true)
            {
                GameFiber.Yield();

                gui.CheckCheckboxes();
            }
        }
    }
}