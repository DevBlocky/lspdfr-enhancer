using Rage;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using System;

namespace LSPDFR_Enhancer
{
    internal class Config
    {
        #region Singleton
        private Config()
        {

        }

        private static Config s;
        private static readonly object syncLock = new object();

        internal static Config GetConfig()
        {
            if (s == null)
            {
                lock(syncLock)
                {
                    if (s == null)
                    {
                        s = new Config();
                    }
                }
            }

            return s;
        }
        #endregion

        /// <summary>
        /// Setup ini file for LSPDE
        /// </summary>
        /// <returns></returns>
        private InitializationFile InitialiseFile()
        {
            InitializationFile ini = new InitializationFile("Plugins/LSPDFR Enhancer Config/LSPDFREnhancer.ini");
            ini.Create();
            return ini;
        }

        /// <summary>
        /// Reading the INI for keyBinding
        /// </summary>
        /// <returns></returns>
        internal Keys GetKeyBinding()
        {
            InitializationFile ini = InitialiseFile();

            string keyBindingString = ini.ReadString("GENERAL", "OpenMenuKey");

            KeysConverter kc = new KeysConverter();
            try
            {
                Keys keyBinding = (Keys)kc.ConvertFromString(keyBindingString);
                return keyBinding;
            }
            catch (Exception exception)
            {
                Game.DisplayNotification("LSPDFR Enhancer had a problem reading the key in the INI, defaulting the Key");
                Game.LogTrivial(exception.ToString());

                return Keys.Pause;
            }
        }

        internal bool IsRealisticCarOptionEnabled()
        {
            InitializationFile ini = InitialiseFile();

            try
            {
                bool realisticCarOption = ini.ReadBoolean("GENERAL", "RealisticCarDelivery", true);
                return realisticCarOption;
            }
            catch (Exception exception)
            {
                Game.DisplayNotification("LSPDFR Enhancer had a problem reading the Realistic Car Option in the INI, defaulting the boolean");
                Game.LogTrivial(exception.ToString());

                return true;
            }
        }

        internal bool IsRealisticWeaponOptionEnabled()
        {
            InitializationFile ini = InitialiseFile();

            try
            {
                return ini.ReadBoolean("GENERAL", "RealisticWeaponDelivery");
            }
            catch (Exception exception)
            {
                Game.DisplayNotification("LSPDFR Enhancer had a problem reading the Realistic Weapon Option in the INI, defaulting the boolean");
                Game.LogTrivial(exception.ToString());

                return true;
            }
        }

        #region ListItems
        internal List<string> CharacterModelsList()
        {
            List<string> e = new List<string>();

            try
            {
                File.ReadAllLines(@"Plugins/LSPDFR Enhancer Config/Lists/1 Player/CharacterModels.txt").ToList().ForEach(x => e.Add(x));
            }
            catch (Exception exception)
            {
                Game.DisplayNotification("LSPDFR Enhancer had a problem reading the CharacterModels.txt, defaulting the list");
                Game.LogTrivial(exception.ToString());
            }

            return e;
        }

        internal List<dynamic> CharacterModelNamesList()
        {
            List<dynamic> e = new List<dynamic>();

            try
            {
                File.ReadAllLines(@"Plugins/LSPDFR Enhancer Config/Lists/1 Player/CharacterModelNames.txt").ToList().ForEach(x => e.Add(x));
            }
            catch (Exception exception)
            {
                Game.DisplayNotification("LSPDFR Enhancer had a problem reading the CharacterModelNames.txt, defaulting the list");
                Game.LogTrivial(exception.ToString());
            }

            return e;
        }

        internal List<string> CarModelsList()
        {
            List<string> e = new List<string>();

            try
            {
                File.ReadAllLines(@"Plugins/LSPDFR Enhancer Config/Lists/2 Vehicle/CarModels.txt").ToList().ForEach(x => e.Add(x));
            }
            catch (Exception exception)
            {
                Game.DisplayNotification("LSPDFR Enhancer had a problem reading the CarModels.txt, defaulting the list");

                Game.LogTrivial(exception.ToString());
            }

            return e;
        }

        internal List<dynamic> CarModelsNameList()
        {
            List<dynamic> e = new List<dynamic>();

            try
            {
                File.ReadAllLines(@"Plugins/LSPDFR Enhancer Config/Lists/2 Vehicle/CarModelNames.txt").ToList().ForEach(x => e.Add(x));
            }
            catch (Exception exception)
            {
                Game.DisplayNotification("LSPDFR Enhancer had a problem reading the CarModelNames.txt, defaulting the list");

                Game.LogTrivial(exception.ToString());
            }

            return e;
        }

        internal List<uint> WeaponModelsList()
        {
            List<uint> e = new List<uint>();

            try
            {
                File.ReadAllLines(@"Plugins/LSPDFR Enhancer Config/Lists/3 Weapon/WeaponModels.txt").ToList().ForEach(x => e.Add(Convert.ToUInt32(x)));
            }
            catch (Exception exception)
            {
                Game.DisplayNotification("LSPDFR Enhancer had a problem reading the WeaponModels.txt, defaulting the list");

                Game.LogTrivial(exception.ToString());
            }

            return e;
        }

        internal List<dynamic> WeaponModelNamesList()
        {
            List<dynamic> e = new List<dynamic>();

            try
            {
                File.ReadAllLines(@"Plugins/LSPDFR Enhancer Config/Lists/3 Weapon/WeaponModelNames.txt").ToList().ForEach(x => e.Add(x));
            }
            catch (Exception exception)
            {
                Game.DisplayNotification("LSPDFR Enhancer had a problem reading the WeaponModelNames.txt, defaulting the list");

                Game.LogTrivial(exception.ToString());
            }

            return e;
        }

        internal List<int> TimesList()
        {
            List<int> e = new List<int>();

            try
            {
                File.ReadAllLines(@"Plugins/LSPDFR Enhancer Config/Lists/4 Environment/Times.txt").ToList().ForEach(x => e.Add(Convert.ToInt32(x)));
            }
            catch (Exception exception)
            {
                Game.DisplayNotification("LSPDFR Enhancer had a problem reading the Times.txt, defaulting the list");
                Game.LogTrivial(exception.ToString());
            }

            return e;
        }

        internal List<dynamic> TimeNamesList()
        {
            List<dynamic> e = new List<dynamic>();

            try
            {
                File.ReadAllLines(@"Plugins/LSPDFR Enhancer Config/Lists/4 Environment/TimeNames.txt").ToList().ForEach(x => e.Add(x));
            }
            catch (Exception exception)
            {
                Game.DisplayNotification("LSPDFR Enhancer had a problem reading the TimeNames.txt, defaulting the list");
                Game.LogTrivial(exception.ToString());
            }

            return e;
        }

        internal List<string> WeatherTypesList()
        {
            List<string> e = new List<string>();

            try
            {
                File.ReadAllLines(@"Plugins/LSPDFR Enhancer Config/Lists/4 Environment/WeatherTypes.txt").ToList().ForEach(x => e.Add(x));
            }
            catch (Exception exception)
            {
                Game.DisplayNotification("LSPDFR Enhancer had a problem reading the WeatherTypes.txt, defaulting the list");
                Game.LogTrivial(exception.ToString());
            }

            return e;
        }

        internal List<dynamic> WeatherNamesList()
        {
            List<dynamic> e = new List<dynamic>();

            try
            {
                File.ReadAllLines(@"Plugins/LSPDFR Enhancer Config/Lists/4 Environment/WeatherNames.txt").ToList().ForEach(x => e.Add(x));
            }
            catch (Exception exception)
            {
                Game.DisplayNotification("LSPDFR Enhancer had a problem reading the WeatherNames.txt, defaulting the list");
                Game.LogTrivial(exception.ToString());
            }

            return e;
        }
        #endregion
    }
}