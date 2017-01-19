using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rage;
using RAGENativeUI;
using System.Windows.Forms;
using RAGENativeUI.Elements;

[assembly: Rage.Attributes.Plugin("LSPDFR Enhancer", Description = "Enhances LSPDFR", Author = "BlockBa5her", SupportUrl = "Coming soon")]
namespace LSPDFR_Enhancer
{
    public static class EntryPoint
    {
        /// <summary>
        /// Setup ini file for LSPDE
        /// </summary>
        /// <returns></returns>
        public static InitializationFile initialiseFile()
        {
            InitializationFile ini = new InitializationFile("Plugins/LSPDFR Enhancer.ini");
            ini.Create();
            return ini;
        }

        /// <summary>
        /// Reading the INI for keyBinding
        /// </summary>
        /// <returns></returns>
        public static string getKeyBinding()
        {
            InitializationFile ini = initialiseFile();

            string keyBinding = ini.ReadString("GENERAL", "OpenMenuKey");
            return keyBinding;
        }


        //Menus
        private static MenuPool _menuPool;
        private static UIMenu mainMenu;
        private static UIMenu playerMenu;
        private static UIMenu vehicleMenu;
        private static UIMenu weaponMenu;
        private static UIMenu environmentMenu;

        //Main Menu buttons
        private static UIMenuItem btnPlayer;
        private static UIMenuItem btnVehicles;
        private static UIMenuItem btnWeapons;
        private static UIMenuItem btnEnvironment;
        private static UIMenuItem btnExit;

        //Player Menu Buttons
        private static UIMenuItem btnPlayerHeal;
        private static UIMenuCheckboxItem cbPlayerInvincible;
        private static UIMenuCheckboxItem cbNeverWanted;
        private static UIMenuListItem wantedLevelList;
        private static UIMenuItem btnCopModel;
        private static UIMenuItem btnSuicide;

        //Vehicles Menu Buttons
        private static UIMenuListItem modelList;
        private static UIMenuCheckboxItem cbWarp;
        private static UIMenuCheckboxItem cbInvincible;
        private static UIMenuListItem directionList;
        private static UIMenuItem btnSpawnVehicle;

        //Weapons Menu Buttons
        private static UIMenuListItem weaponsList;
        private static UIMenuItem btnSpawnWeapon;
        private static UIMenuItem btnOfficerLoadout;
        private static UIMenuItem btnRefillAmmo;
        private static UIMenuCheckboxItem cbUnlimitedAmmo;

        //Environment Menu Buttons
        private static UIMenuListItem weatherList;
        private static UIMenuListItem timeList;
        private static UIMenuItem btnTimeWeatherSet;


        /// <summary>
        /// Main code for LSPDE
        /// </summary>
        public static void Main()
        {
            //Successfully loaded stuff
            Game.LogTrivial("LSPDE loaded successfully");
            Game.LogTrivial("LSPDE version 0.1");
            Game.DisplayNotification("LSPDFR Enhancer successfully loaded");
            Game.DisplayNotification("LSPDFR Enhancer v0.1 BETA");


            //ini Read keybinding to Windows.Forms
            KeysConverter kc = new KeysConverter(); //Converts strings to keys

            Keys openMenuKey; //Create new key for use in Windows Forms

            try //Using try/catch to convert keys
            {
                openMenuKey = (Keys)kc.ConvertFromString(getKeyBinding());
            }
            catch
            {
                openMenuKey = Keys.Pause;
                Game.DisplayNotification("LSPDFR Enhancer had an error reading the INI, reverting to defaults");
            }

            List<dynamic> models = new List<dynamic>
            {
                "POLICE", "POLICE2", "POLICE3", "POLICE4", "SHERIFF", "SHERIFF2", "FBI", "FBI2", "POLICEB", "POLICET", "RIOT"
            };
            List<dynamic> directions = new List<dynamic>
            {
                "Front", "Back"
            };
            List<dynamic> weaponNames = new List<dynamic>
            {
                "Pistol", "Combat Pistol", "Carbine Assault Rifle", "Shotgun", "Tazer", "Flashlight", "Baton"
            };
            List<dynamic> weather = new List<dynamic>
            {
                "Extra Sunny", "Sunny", "Clearing", "Raining", "Thunder", "Foggy", "Smoggy"
            };
            List<dynamic> time = new List<dynamic>
            {
                "Morning", "Afternoon", "Evening", "Midnight", "Early Morning"
            };
            List<dynamic> wantedLevel = new List<dynamic>
            {
                "0", "1", "2", "3", "4", "5"
            };

            //Declaring menus
            _menuPool = new MenuPool();
            mainMenu = new UIMenu("Main Menu", "LPSDFR Enhancer");
            playerMenu = new UIMenu("Player", "LSPDFR Enhancer");
            vehicleMenu = new UIMenu("Vehicles", "LSPDFR Enhancer");
            weaponMenu = new UIMenu("Weapons", "LSPDFR Enhancer");
            environmentMenu = new UIMenu("Environment", "LSPDFR Enhancer");

            //Main Menu declaring items
            btnPlayer = new UIMenuItem("Player Menu");
            btnVehicles = new UIMenuItem("Vehicles Menu");
            btnWeapons = new UIMenuItem("Weapons Menu");
            btnEnvironment = new UIMenuItem("Environment Menu");
            btnExit = new UIMenuItem("Exit");

            //Player Menu declaring items
            btnPlayerHeal = new UIMenuItem("Heal Player");
            cbPlayerInvincible = new UIMenuCheckboxItem("Invincible", false);
            btnCopModel = new UIMenuItem("Set model as cop");
            btnSuicide = new UIMenuItem("Commit Suicide");
            wantedLevelList = new UIMenuListItem("Clear Wanted Level", wantedLevel, 0);
            cbNeverWanted = new UIMenuCheckboxItem("Never Wanted", false);

            //Vehicles Menu declaring items
            modelList = new UIMenuListItem("Model", models, 0);
            cbWarp = new UIMenuCheckboxItem("Warp Into Vehicle", true);
            cbInvincible = new UIMenuCheckboxItem("Invincible", false);
            directionList = new UIMenuListItem("Direction", directions, 0);
            btnSpawnVehicle = new UIMenuItem("Spawn");

            //Weapons menu declaring items
            weaponsList = new UIMenuListItem("Weapons", weaponNames, 0);
            btnSpawnWeapon = new UIMenuItem("Spawn Weapon");
            btnOfficerLoadout = new UIMenuItem("Give Officer Loadout");
            btnRefillAmmo = new UIMenuItem("Refill Equiped Weapon Ammo");
            cbUnlimitedAmmo = new UIMenuCheckboxItem("Unlimited Ammo", false);

            //Environment menu declaring items
            weatherList = new UIMenuListItem("Weather", weather, 0);
            timeList = new UIMenuListItem("Time", time, 0);
            btnTimeWeatherSet = new UIMenuItem("Set Time and Weather");

            //Adding stuff to menuPool
            _menuPool.Add(mainMenu);
            _menuPool.Add(playerMenu);
            _menuPool.Add(vehicleMenu);
            _menuPool.Add(weaponMenu);
            _menuPool.Add(environmentMenu);

            //Adding stuff to mainMenu
            mainMenu.AddItem(btnPlayer);
            mainMenu.AddItem(btnVehicles);
            mainMenu.AddItem(btnWeapons);
            mainMenu.AddItem(btnEnvironment);
            mainMenu.AddItem(btnExit);

            //Binding stuff to mainMenu
            mainMenu.BindMenuToItem(playerMenu, btnPlayer);
            mainMenu.BindMenuToItem(vehicleMenu, btnVehicles);
            mainMenu.BindMenuToItem(weaponMenu, btnWeapons);
            mainMenu.BindMenuToItem(environmentMenu, btnEnvironment);
            playerMenu.ParentMenu = mainMenu;
            vehicleMenu.ParentMenu = mainMenu;
            weaponMenu.ParentMenu = mainMenu;
            environmentMenu.ParentMenu = mainMenu;

            //Adding and binding stuff to playerMenu
            playerMenu.AddItem(btnPlayerHeal);
            playerMenu.AddItem(cbPlayerInvincible);
            playerMenu.AddItem(cbNeverWanted);
            playerMenu.AddItem(wantedLevelList);
            playerMenu.AddItem(btnCopModel);
            playerMenu.AddItem(btnSuicide);

            //Adding stuff to vehicleMenu
            vehicleMenu.AddItem(modelList);
            vehicleMenu.AddItem(cbWarp);
            vehicleMenu.AddItem(cbInvincible);
            vehicleMenu.AddItem(directionList);
            vehicleMenu.AddItem(btnSpawnVehicle);

            //Adding stuff to weaponMenu
            weaponMenu.AddItem(weaponsList);
            weaponMenu.AddItem(btnSpawnWeapon);
            weaponMenu.AddItem(btnOfficerLoadout);
            weaponMenu.AddItem(btnRefillAmmo);
            weaponMenu.AddItem(cbUnlimitedAmmo);

            //Adding stuff to environmentMenu
            environmentMenu.AddItem(weatherList);
            environmentMenu.AddItem(timeList);
            environmentMenu.AddItem(btnTimeWeatherSet);


            //Main logic for entire menu

            //Refresh index
            mainMenu.RefreshIndex();
            playerMenu.RefreshIndex();
            vehicleMenu.RefreshIndex();
            weaponMenu.RefreshIndex();
            environmentMenu.RefreshIndex();

            //On button select
            mainMenu.OnItemSelect += OnItemSelect;
            playerMenu.OnItemSelect += OnItemSelect;
            vehicleMenu.OnItemSelect += OnItemSelect;
            weaponMenu.OnItemSelect += OnItemSelect;
            environmentMenu.OnItemSelect += OnItemSelect;

            //Tells the game that you can use mouse to control camera when in menu
            mainMenu.MouseControlsEnabled = false;
            mainMenu.AllowCameraMovement = true;
            playerMenu.MouseControlsEnabled = false;
            playerMenu.AllowCameraMovement = true;
            vehicleMenu.MouseControlsEnabled = false;
            vehicleMenu.AllowCameraMovement = true;
            weaponMenu.MouseControlsEnabled = false;
            weaponMenu.AllowCameraMovement = true;
            environmentMenu.MouseControlsEnabled = false;
            environmentMenu.AllowCameraMovement = true;

            //This is the Main Logic
            GameFiber.StartNew(delegate
            {
                while (true)
                {
                    GameFiber.Yield();

                    //Detecting if the player has pressed openMenu Key
                    if (Game.IsKeyDown(openMenuKey))
                    {
                        //Changes menu visability state from opposite of what it was
                        mainMenu.Visible = !mainMenu.Visible;
                    }
                    _menuPool.ProcessMenus();

                    //Making sure if player is dead than the menu is un-openable
                    if (Game.LocalPlayer.Character.IsDead)
                    {
                        mainMenu.Visible = false;
                    }
                    
                    //Making player invincible
                    if (cbPlayerInvincible.Checked == true)
                    {
                        Game.LocalPlayer.IsInvincible = true;
                    }

                    else
                    {
                        Game.LocalPlayer.IsInvincible = false;
                    }

                    //If cbNeverWanted checked then always set the wanted level to 0
                    if (cbNeverWanted.Checked == true)
                    {
                        Game.LocalPlayer.WantedLevel = 0;
                    }

                    if (cbUnlimitedAmmo.Checked == true)
                    {
                        WeaponDescriptor equipWeapon = Game.LocalPlayer.Character.Inventory.EquippedWeapon;
                        equipWeapon.Ammo = 9999;
                    }
                }
            });
            GameFiber.Hibernate();
        }
        public static void OnItemSelect(UIMenu sender, UIMenuItem selectedItem, int index)
        {
            //If button pressed on mainMenu
            if (sender == mainMenu)
            {
                //If Exit button is pressed, then exit make the menu no longer visible
                if (selectedItem == btnExit)
                {
                    mainMenu.Visible = false;
                }

                //If Weapons button is pressed, gives notification that it is still in the works
                if (selectedItem == btnWeapons)
                {
                    Game.DisplayNotification("This feature is still in the works hotshot, this is only a beta");
                }

                //If Environment button is pressed, gives notification that it is still in the works
                if (selectedItem == btnEnvironment)
                {
                    Game.DisplayNotification("This feature is still in the works hotshot, this is only a beta");
                }
            }

            //If button pressed on playerMenu
            if (sender == playerMenu)
            {
                //If player pressed Player Heal then heal the player to 100%
                if (selectedItem == btnPlayerHeal)
                {
                    Game.LocalPlayer.Character.Health = 10000;
                }

                //If player selected Clear Level then set wanted level designated wanted level
                if (selectedItem == wantedLevelList)
                {
                    //Creating new string to store the index of wantedLevelList
                    string igWantedLevel = wantedLevelList.IndexToItem(wantedLevelList.Index);
                    //Converting string to integer
                    int igWantedLevelInt = Convert.ToInt32(igWantedLevel);

                    //Setting in game wanted level
                    Game.LocalPlayer.WantedLevel = igWantedLevelInt;
                }

                //If player selected Cop Model, then change to cop ped
                if (selectedItem == btnCopModel)
                {
                    Game.LocalPlayer.Model = "s_m_y_cop_01";
                }

                //If player selects Suicide, change Kill player
                if (selectedItem == btnSuicide)
                {
                    Game.LocalPlayer.Character.Kill();
                }
            }
            
            //If button pressed on vehicleMenu
            if (sender == vehicleMenu)
            {
                if (selectedItem == btnSpawnVehicle)
                {
                    //Telling the game what model car you want
                    string modelName = modelList.IndexToItem(modelList.Index);
                    Model vehicleModel = new Model(modelName);

                    //Checking if you want your vehicle invincible or you to spawn in vehicle
                    bool warpToVehicle = cbWarp.Checked;
                    bool invincible = cbInvincible.Checked;

                    //Setting the right position for your car to be spawned at
                    string directionName = directionList.IndexToItem(directionList.Index);
                    Vector3 position;
                    if (directionName == "Front")
                    {
                        position = Game.LocalPlayer.Character.GetOffsetPositionFront(5);
                    }
                    else
                    {
                        position = Game.LocalPlayer.Character.GetOffsetPositionFront(-5);
                    }

                    //Creating vehicle in Game world
                    Vehicle spawnedVehicle = new Vehicle(vehicleModel, position, 0);

                    //Making vehicle invincible if you selected the box
                    spawnedVehicle.IsInvincible = invincible;

                    //Warping you into vehicle if you selected box
                    if (warpToVehicle == true)
                    {
                        Game.LocalPlayer.Character.WarpIntoVehicle(spawnedVehicle, -1);
                    }
                }
            }

            //If button pressed on weaponsMenu
            if (sender == weaponMenu)
            {
                if (selectedItem == btnSpawnWeapon)
                {
                    string wpnName = weaponsList.IndexToItem(weaponsList.Index);

                    if (wpnName == "Pistol") { Game.LocalPlayer.Character.Inventory.GiveNewWeapon(WeaponHash.Pistol, 9999, false); }
                    if (wpnName == "Combat Pistol") { Game.LocalPlayer.Character.Inventory.GiveNewWeapon(WeaponHash.CombatPistol, 9999, false); }
                    if (wpnName == "Carbine Assault Rifle") { Game.LocalPlayer.Character.Inventory.GiveNewWeapon(WeaponHash.CarbineRifle, 9999, false); }
                    if (wpnName == "Shotgun") { Game.LocalPlayer.Character.Inventory.GiveNewWeapon(WeaponHash.PumpShotgun, 9999, false); }
                    if (wpnName == "Tazer") { Game.LocalPlayer.Character.Inventory.GiveNewWeapon(WeaponHash.StunGun, 9999, false); }
                    if (wpnName == "Flashlight") { Game.LocalPlayer.Character.Inventory.GiveNewWeapon(WeaponHash.Flashlight, 9999, false); }
                    if (wpnName == "Baton") { Game.LocalPlayer.Character.Inventory.GiveNewWeapon(WeaponHash.Nightstick, 9999, false); }
                }
                if (selectedItem == btnRefillAmmo)
                {
                    WeaponDescriptor weapon = Game.LocalPlayer.Character.Inventory.EquippedWeapon;
                    weapon.Ammo = 9999;
                }
                if (selectedItem == btnOfficerLoadout)
                {
                    if (true) { Game.LocalPlayer.Character.Inventory.GiveNewWeapon(WeaponHash.Pistol, 9999, false); }
                    if (true) { Game.LocalPlayer.Character.Inventory.GiveNewWeapon(WeaponHash.CombatPistol, 9999, false); }
                    if (true) { Game.LocalPlayer.Character.Inventory.GiveNewWeapon(WeaponHash.CarbineRifle, 9999, false); }
                    if (true) { Game.LocalPlayer.Character.Inventory.GiveNewWeapon(WeaponHash.PumpShotgun, 9999, false); }
                    if (true) { Game.LocalPlayer.Character.Inventory.GiveNewWeapon(WeaponHash.StunGun, 9999, false); }
                    if (true) { Game.LocalPlayer.Character.Inventory.GiveNewWeapon(WeaponHash.Flashlight, 9999, false); }
                    if (true) { Game.LocalPlayer.Character.Inventory.GiveNewWeapon(WeaponHash.Nightstick, 9999, false); }
                }
            }

            //If button pressed on environmentMenu
            if (sender == environmentMenu)
            {
                //This feature is still being developed
                Game.DisplayNotification("This feature is still in the works");
            }
        }
    }
}