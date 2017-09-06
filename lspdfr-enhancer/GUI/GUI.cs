using System;
using Rage;
using Rage.Native;
using System.Threading;
using RAGENativeUI;
using RAGENativeUI.Elements;
using System.Collections.Generic;

namespace LSPDFR_Enhancer.GUI
{
    /// <summary>
    /// All the functions to the OnItemSelect in voids
    /// </summary>
    public class GUI
    {
        private Player player => Game.LocalPlayer;
        private Ped character => player.Character;
        private PedInventory inventory => character.Inventory;

        private Config c => Config.GetConfig();
        private GUIList l;

        #region UI items
        //Menus
        internal MenuPool _MenuPool { get; private set; }
        internal UIMenu MainMenu { get; private set; }
        private UIMenu playerMenu;
        private UIMenu quickSetupMenu;
        private UIMenu vehicleMenu;
        private UIMenu weaponMenu;
        private UIMenu environmentMenu;
        internal UIMenu StopVehicleDeliveryMenu { get; private set; }
        internal UIMenu StopWeaponDeliveryMenu { get; private set; }

        //Main Menu buttons
        private UIMenuItem btnPlayer;
        private UIMenuItem btnQuickSetup;
        private UIMenuItem btnVehicles;
        private UIMenuItem btnWeapons;
        private UIMenuItem btnEnvironment;
        private UIMenuItem btnExit;

        //Player Menu Buttons
        private UIMenuItem btnPlayerHeal;
        private UIMenuCheckboxItem cbPlayerInvincible;
        private UIMenuCheckboxItem cbNoRagdoll;
        private UIMenuCheckboxItem cbNeverWanted;
        private UIMenuListItem wantedLevelList;
        private UIMenuListItem playerModelList;
        private UIMenuItem btnSuicide;

        //Quick Setup Menu Buttons
        //vehicleList
        //playerModelList
        private UIMenuCheckboxItem cbSpawnWithWeapons;
        private UIMenuItem btnStartQuickSetup;

        //Vehicles Menu Buttons
        private UIMenuListItem vehicleModelList;
        private UIMenuCheckboxItem cbWarpIntoVehicle;
        private UIMenuCheckboxItem cbVehicleInvincible;
        private UIMenuListItem vehicleDirectionList;
        private UIMenuItem btnSpawnVehicle;
        private UIMenuItem btnDeliverVehicle;
        private UIMenuItem btnRemoveWindowTint;
        private UIMenuItem btnFixEngine;
        private UIMenuItem btnFixVehicle;

        //Weapons Menu Buttons
        private UIMenuListItem weaponsList;
        private UIMenuItem btnAddToQueue;
        private UIMenuCheckboxItem cbSpawnWithAttachments;
        private UIMenuItem btnSpawnWeapon;
        private UIMenuItem btnDeliverWeapon;
        private UIMenuItem btnGiveOfficerLoadout;
        private UIMenuItem btnDeliverOfficerLoadout;
        private UIMenuItem btnRefillAmmo;
        private UIMenuItem btnRemoveWeapons;
        private UIMenuCheckboxItem cbUnlimitedAmmo;

        //Environment Menu Buttons
        private UIMenuListItem weatherList;
        private UIMenuItem btnWeatherSet;
        private UIMenuListItem timeList;
        private UIMenuItem btnTimeSet;
        private UIMenuCheckboxItem cbFreezeTime;
        private UIMenuCheckboxItem cbFreezeWeather;

        //Stop Vehicle Delivery Menu Buttons
        private UIMenuItem btnCancelVehicleDelivery;

        //Stop Weapon Delivery Menu Buttons
        private UIMenuItem btnCancelWeaponDelivery;
        #endregion

        public GUI(GUIList l)
        {
            this.l = l;
        }

        public void Create()
        {
            #region NativeUI Contructers
            //Declaring menus
            _MenuPool = new MenuPool();
            MainMenu = new UIMenu("Main Menu", "LSPDFR Enhancer");
            playerMenu = new UIMenu("Player", "LSPDFR Enhancer");
            quickSetupMenu = new UIMenu("Quick Setup Menu", "LSPDFR Enhancer");
            vehicleMenu = new UIMenu("Vehicles", "LSPDFR Enhancer");
            weaponMenu = new UIMenu("Weapons", "LSPDFR Enhancer");
            environmentMenu = new UIMenu("Environment", "LSPDFR Enhancer");
            StopVehicleDeliveryMenu = new UIMenu("Vehicle Menu", "LSPDFR Enhancer");
            StopWeaponDeliveryMenu = new UIMenu("Weapon Menu", "LSPDFR Enhancer");

            //Main Menu declaring items
            btnPlayer = new UIMenuItem("Player Menu");
            btnQuickSetup = new UIMenuItem("Quick Setup Menu");
            btnVehicles = new UIMenuItem("Vehicles Menu");
            btnWeapons = new UIMenuItem("Weapons Menu");
            btnEnvironment = new UIMenuItem("Environment Menu");
            btnExit = new UIMenuItem("Exit");

            //Player Menu declaring items
            btnPlayerHeal = new UIMenuItem("Heal Player");
            cbPlayerInvincible = new UIMenuCheckboxItem("Invincible", false);
            cbNoRagdoll = new UIMenuCheckboxItem("No Ragdoll", false);
            cbNeverWanted = new UIMenuCheckboxItem("Never Wanted", false);
            wantedLevelList = new UIMenuListItem("Wanted Level", l.WantedLevel, 0);
            playerModelList = new UIMenuListItem("Player Model", l.PlayerModelNames, 0);
            btnSuicide = new UIMenuItem("Commit Suicide");

            //Quick Setup Menu declaring items
            //Vehicle Menu
            //Player Menu
            cbSpawnWithWeapons = new UIMenuCheckboxItem("Spawn with weapons", true);
            btnStartQuickSetup = new UIMenuItem("Start Quick Setup");

            //Vehicles Menu declaring items
            vehicleModelList = new UIMenuListItem("Vehicle Model", l.VehicleModelNames, 0);
            cbWarpIntoVehicle = new UIMenuCheckboxItem("Warp Into Vehicle", true);
            cbVehicleInvincible = new UIMenuCheckboxItem("Invincible", false);
            vehicleDirectionList = new UIMenuListItem("Direction", l.VehicleDirections, 0);
            btnSpawnVehicle = new UIMenuItem("Spawn");
            btnDeliverVehicle = new UIMenuItem("Deliver");
            btnRemoveWindowTint = new UIMenuItem("Remove Window Tint");
            btnFixEngine = new UIMenuItem("Fix Engine");
            btnFixVehicle = new UIMenuItem("Fix Vehicle");

            //Weapons menu declaring items
            weaponsList = new UIMenuListItem("Weapons", l.WeaponNames, 0);
            btnAddToQueue = new UIMenuItem("Add to Weapon Queue");
            if (c.IsRealisticWeaponOptionEnabled()) cbSpawnWithAttachments = new UIMenuCheckboxItem("Deliver weapons with attachments", true);
            else cbSpawnWithAttachments = new UIMenuCheckboxItem("Spawn weapons with attachments", true);
            btnSpawnWeapon = new UIMenuItem("Spawn Weapon");
            btnDeliverWeapon = new UIMenuItem("Deliver Weapon(s)");
            btnGiveOfficerLoadout = new UIMenuItem("Give Officer Loadout");
            btnDeliverOfficerLoadout = new UIMenuItem("Deliver Officer Loadout");
            btnRefillAmmo = new UIMenuItem("Refill Equiped Weapon Ammo");
            btnRemoveWeapons = new UIMenuItem("Remove All Weapons");
            cbUnlimitedAmmo = new UIMenuCheckboxItem("Unlimited Ammo", false);

            //Environment menu declaring items
            weatherList = new UIMenuListItem("Weather", l.WeatherName, 0);
            btnWeatherSet = new UIMenuItem("Set Weather");
            timeList = new UIMenuListItem("Time", l.Time, 0);
            btnTimeSet = new UIMenuItem("Set Time");
            cbFreezeTime = new UIMenuCheckboxItem("Freeze Time", false);
            cbFreezeWeather = new UIMenuCheckboxItem("Freeze Weather", false);

            //Stop Vehicle Delivery Menu declaring items
            btnCancelVehicleDelivery = new UIMenuItem("Cancel Vehicle Delivery");

            //Stop Weapon Delivery Menu declaring items
            btnCancelWeaponDelivery = new UIMenuItem("Cancel Weapon Delivery");
            #endregion
        }
        public void Run()
        {
            #region Adding NativeUI
            //Adding stuff to menuPool
            _MenuPool.Add(MainMenu);
            _MenuPool.Add(playerMenu);
            _MenuPool.Add(quickSetupMenu);
            _MenuPool.Add(vehicleMenu);
            _MenuPool.Add(weaponMenu);
            _MenuPool.Add(environmentMenu);
            _MenuPool.Add(StopVehicleDeliveryMenu);
            _MenuPool.Add(StopWeaponDeliveryMenu);

            //Adding stuff to mainMenu
            MainMenu.AddItem(btnPlayer);
            MainMenu.AddItem(btnVehicles);
            MainMenu.AddItem(btnQuickSetup);
            MainMenu.AddItem(btnWeapons);
            MainMenu.AddItem(btnEnvironment);
            MainMenu.AddItem(btnExit);

            //Binding stuff to mainMenu
            MainMenu.BindMenuToItem(playerMenu, btnPlayer);
            MainMenu.BindMenuToItem(vehicleMenu, btnVehicles);
            MainMenu.BindMenuToItem(quickSetupMenu, btnQuickSetup);
            MainMenu.BindMenuToItem(weaponMenu, btnWeapons);
            MainMenu.BindMenuToItem(environmentMenu, btnEnvironment);
            playerMenu.ParentMenu = MainMenu;
            vehicleMenu.ParentMenu = MainMenu;
            quickSetupMenu.ParentMenu = MainMenu;
            weaponMenu.ParentMenu = MainMenu;
            environmentMenu.ParentMenu = MainMenu;

            //Adding stuff to playerMenu
            playerMenu.AddItem(btnPlayerHeal);
            playerMenu.AddItem(cbPlayerInvincible);
            playerMenu.AddItem(cbNoRagdoll);
            playerMenu.AddItem(cbNeverWanted);
            playerMenu.AddItem(wantedLevelList);
            playerMenu.AddItem(playerModelList);
            playerMenu.AddItem(btnSuicide);

            //Adding stuff to quickSetupMenu
            quickSetupMenu.AddItem(vehicleModelList);
            quickSetupMenu.AddItem(playerModelList);
            quickSetupMenu.AddItem(cbSpawnWithWeapons);
            quickSetupMenu.AddItem(btnStartQuickSetup);

            //Adding stuff to vehicleMenu
            vehicleMenu.AddItem(vehicleModelList);
            if (!c.IsRealisticCarOptionEnabled()) vehicleMenu.AddItem(cbWarpIntoVehicle);
            vehicleMenu.AddItem(cbVehicleInvincible);
            if (!c.IsRealisticCarOptionEnabled()) vehicleMenu.AddItem(vehicleDirectionList);
            if (!c.IsRealisticCarOptionEnabled()) vehicleMenu.AddItem(btnSpawnVehicle);
            if (c.IsRealisticCarOptionEnabled()) vehicleMenu.AddItem(btnDeliverVehicle);
            //VehicleMenu.AddItem(BtnRemoveWindowTint); TODO: Fix this so that it will be released next version
            vehicleMenu.AddItem(btnFixEngine);
            vehicleMenu.AddItem(btnFixVehicle);

            //Adding stuff to weaponMenu
            weaponMenu.AddItem(weaponsList);
            if (c.IsRealisticWeaponOptionEnabled()) weaponMenu.AddItem(btnAddToQueue);
            weaponMenu.AddItem(cbSpawnWithAttachments);
            if (!c.IsRealisticWeaponOptionEnabled()) weaponMenu.AddItem(btnSpawnWeapon);
            if (c.IsRealisticWeaponOptionEnabled()) weaponMenu.AddItem(btnDeliverWeapon);
            if (!c.IsRealisticWeaponOptionEnabled()) weaponMenu.AddItem(btnGiveOfficerLoadout);
            if (c.IsRealisticWeaponOptionEnabled()) weaponMenu.AddItem(btnDeliverOfficerLoadout);
            weaponMenu.AddItem(btnRefillAmmo);
            weaponMenu.AddItem(btnRemoveWeapons);
            weaponMenu.AddItem(cbUnlimitedAmmo);

            //Adding stuff to environmentMenu
            environmentMenu.AddItem(weatherList);
            environmentMenu.AddItem(btnWeatherSet);
            environmentMenu.AddItem(timeList);
            environmentMenu.AddItem(btnTimeSet);
            environmentMenu.AddItem(cbFreezeTime);
            environmentMenu.AddItem(cbFreezeWeather);

            //Adding stuff to stopVehicleDeliveryMenu
            StopVehicleDeliveryMenu.AddItem(btnCancelVehicleDelivery);

            //Adding stuff to stopWeaponDeliveryMenu   
            StopWeaponDeliveryMenu.AddItem(btnCancelWeaponDelivery);
            #endregion

            #region Setting up Menus
            //Refresh index
            MainMenu.RefreshIndex();
            playerMenu.RefreshIndex();
            quickSetupMenu.RefreshIndex();
            vehicleMenu.RefreshIndex();
            weaponMenu.RefreshIndex();
            environmentMenu.RefreshIndex();
            StopVehicleDeliveryMenu.RefreshIndex();
            StopWeaponDeliveryMenu.RefreshIndex();

            //On button select
            MainMenu.OnItemSelect += OnItemSelect;
            playerMenu.OnItemSelect += OnItemSelect;
            quickSetupMenu.OnItemSelect += OnItemSelect;
            vehicleMenu.OnItemSelect += OnItemSelect;
            weaponMenu.OnItemSelect += OnItemSelect;
            environmentMenu.OnItemSelect += OnItemSelect;
            StopVehicleDeliveryMenu.OnItemSelect += OnItemSelect;
            StopWeaponDeliveryMenu.OnItemSelect += OnItemSelect;

            //Tells the game that you can use mouse to control camera when in menu
            MainMenu.MouseControlsEnabled = false;
            MainMenu.AllowCameraMovement = true;
            playerMenu.MouseControlsEnabled = false;
            playerMenu.AllowCameraMovement = true;
            quickSetupMenu.MouseControlsEnabled = false;
            quickSetupMenu.AllowCameraMovement = true;
            vehicleMenu.MouseControlsEnabled = false;
            vehicleMenu.AllowCameraMovement = true;
            weaponMenu.MouseControlsEnabled = false;
            weaponMenu.AllowCameraMovement = true;
            environmentMenu.MouseControlsEnabled = false;
            environmentMenu.AllowCameraMovement = true;
            StopVehicleDeliveryMenu.MouseControlsEnabled = false;
            StopVehicleDeliveryMenu.AllowCameraMovement = true;
            StopWeaponDeliveryMenu.MouseControlsEnabled = false;
            StopWeaponDeliveryMenu.AllowCameraMovement = true;
            #endregion
        }

        private void OnItemSelect(UIMenu sender, UIMenuItem selectedItem, int index)
        {
            #region mainMenu
            //If button pressed on mainMenu
            if (sender == MainMenu && selectedItem == btnExit)
            {
                ExitMenu();
            }
            #endregion

            #region playerMenu
            //If button pressed on playerMenu
            if (sender == playerMenu)
            {
                //If player pressed Player Heal then heal the player to 100%
                if (selectedItem == btnPlayerHeal)
                {
                    HealPlayer();
                }

                //If player selected Clear Level then set wanted level designated wanted level
                if (selectedItem == wantedLevelList)
                {
                    SetWantedLevel();
                }

                //If player selected Cop Model, then change to cop ped
                if (selectedItem == playerModelList)
                {
                    SetPlayerModel();
                }

                //If player selects Suicide, change Kill player
                if (selectedItem == btnSuicide)
                {
                    PlayerSuicide();
                }
            }
            #endregion

            #region quickSetupMenu
            if (sender == quickSetupMenu && selectedItem == btnStartQuickSetup)
            {
                StartQuickSetup();
            }
            #endregion

            #region vehicleMenu
            //If button pressed on vehicleMenu
            if (sender == vehicleMenu)
            {
                if (selectedItem == btnSpawnVehicle)
                {
                    SpawnVehicle();
                }

                if (selectedItem == btnDeliverVehicle)
                {
                    DeliverVehicle();
                }

                if (selectedItem == btnRemoveWindowTint)
                {
                    RemoveWindowTint();
                }

                if (selectedItem == btnFixEngine)
                {
                    FixVehicle(FixType.Engine);
                }

                if (selectedItem == btnFixVehicle)
                {
                    FixVehicle(FixType.Vehicle);
                }
            }
            #endregion

            #region weaponMenu
            //If button pressed on weaponsMenu
            if (sender == weaponMenu)
            {
                if (selectedItem == btnAddToQueue)
                {
                    AddWeaponToQueue();
                }
                if (selectedItem == btnSpawnWeapon)
                {
                    SpawnWeapon();
                }
                if (selectedItem == btnDeliverWeapon)
                {
                    DeliverWeapons();
                }
                if (selectedItem == btnRefillAmmo)
                {
                    RefillAmmo();
                }
                if (selectedItem == btnGiveOfficerLoadout)
                {
                    GiveOfficerLoadout();
                }
                if (selectedItem == btnDeliverOfficerLoadout)
                {
                    DeliverOfficerLoadout();
                }
                if (selectedItem == btnRemoveWeapons)
                {
                    RemoveWeapons();
                }
            }
            #endregion

            #region environmentMenu
            //If button pressed on environmentMenu
            if (sender == environmentMenu)
            {
                if (selectedItem == btnWeatherSet)
                {
                    int i = weatherList.Index;

                    SetEnvironment(l.WeatherType[i]);
                }

                if (selectedItem == btnTimeSet)
                {
                    int i = timeList.Index;

                    SetEnvironment(l.TimeInt[i]);
                }
            }
            #endregion

            #region stopVehicleDeliveryMenu
            if (sender == StopVehicleDeliveryMenu && selectedItem == btnCancelVehicleDelivery && IsCarDeliveryInProcess)
            {
                CancelDelivery(CancelType.VehicleDelivery);
            }
            else if (sender == StopVehicleDeliveryMenu && selectedItem == btnCancelVehicleDelivery)
            {
                Game.DisplayNotification("HEY! Why did you try to do that when the vehicle was delivered?");

                StopVehicleDeliveryMenu.Visible = false;
                _MenuPool.ProcessMenus();
            }
            #endregion

            #region stopWeaponDeliveryMenu
            if (sender == StopWeaponDeliveryMenu && selectedItem == btnCancelWeaponDelivery && IsWeaponDeliveryInProcess)
            {
                CancelDelivery(CancelType.WeaponDelivery);
            }
            else if (sender == StopWeaponDeliveryMenu && selectedItem == btnCancelWeaponDelivery)
            {
                Game.DisplayNotification("HEY! Why did you try to do that when the weapons were delivered?");

                StopWeaponDeliveryMenu.Visible = false;
                _MenuPool.ProcessMenus();
            }
            #endregion
        }

        #region mainMenu
        private void ExitMenu()
        {
            MainMenu.Visible = false;
        }
        #endregion

        #region playerMenu
        private void HealPlayer()
        {
            character.Health = 10000;
        }

        private void SetWantedLevel()
        {
            int index = wantedLevelList.Index;

            player.WantedLevel = l.WantedLevelInt[index];
        }

        private void SetPlayerModel()
        {
            int index = playerModelList.Index;

            player.Model = l.PlayerModels[index];
        }

        private void PlayerSuicide()
        {
            character.Kill();
        }
        #endregion

        #region vehicleMenu
        private void SpawnVehicle()
        {
            //Telling the game what model car you want
            int modelIndex = vehicleModelList.Index;
            Model vehicleModel = new Model(l.VehicleModels[modelIndex]);

            //Checking if you want your vehicle invincible or you to spawn in vehicle
            bool warpToVehicle = cbWarpIntoVehicle.Checked;
            bool invincible = cbVehicleInvincible.Checked;

            //Setting the right position for your car to be spawned at
            string directionName = vehicleDirectionList.IndexToItem(vehicleDirectionList.Index);
            Vector3 position;
            if (directionName == "Front")
            {
                position = character.GetOffsetPositionFront(5);
            }
            else
            {
                position = character.GetOffsetPositionFront(-5);
            }

            //Creating vehicle in Game world
            Vehicle spawnedVehicle = new Vehicle(vehicleModel, position, 0);

            //Making vehicle invincible if you selected the box
            spawnedVehicle.IsInvincible = invincible;

            //Warping you into vehicle if you selected box
            if (warpToVehicle == true)
            {
                character.WarpIntoVehicle(spawnedVehicle, -1);
            }
        }

        private static Vehicle spawnedVehicle;
        private static Ped driver;
        private static Blip vehicleBlip;
        private static Blip vehicleDeliveryBlip;
        private bool IsCarDeliveryInProcess { get; set; } = false;
        private void DeliverVehicle()
        {
            int modelIndex = vehicleModelList.Index;
            Model vehicleModel = new Model(l.VehicleModels[modelIndex]);
            bool invincible = cbVehicleInvincible.Checked;
            Vector3 carSpawn = World.GetNextPositionOnStreet(character.Position.Around(250f, 500f));
            Vector3 playerLocation = World.GetNextPositionOnStreet(character.Position.Around(10f, 50f));

            //Start of main code to deliver vehicle
            IsCarDeliveryInProcess = true;
            GameFiber.StartNew(new ThreadStart(VehicleMenuThread));
            spawnedVehicle = new Vehicle(vehicleModel, carSpawn);
            driver = spawnedVehicle.CreateRandomDriver();
            driver.WarpIntoVehicle(spawnedVehicle, -1);
            vehicleBlip = new Blip(spawnedVehicle);
            vehicleDeliveryBlip = new Blip(playerLocation);
            vehicleBlip.IsFriendly = true;
            vehicleDeliveryBlip.IsFriendly = false;

            //Setting driver and car as persistant
            spawnedVehicle.IsPersistent = true;
            driver.IsPersistent = true;
            driver.BlockPermanentEvents = true;

            //Tasks to drive to your location
            driver.Tasks.DriveToPosition(playerLocation, 20f, VehicleDrivingFlags.Emergency).WaitForCompletion(360000);
            if (driver.Exists()) driver.Tasks.LeaveVehicle(LeaveVehicleFlags.LeaveDoorOpen).WaitForCompletion(10000);
            if (driver.Exists()) driver.Tasks.Wander();

            if (spawnedVehicle.Exists())
            {
                Game.DisplayNotification("Vehicle delived to your location");
                IsCarDeliveryInProcess = false;
            }
            VehicleMenuThreadEnabled = false;
            if (vehicleDeliveryBlip.Exists()) vehicleDeliveryBlip.Delete();
            if (spawnedVehicle.Exists())
            {
                spawnedVehicle.Repair();
                if (invincible) spawnedVehicle.IsInvincible = true;
                if (vehicleDeliveryBlip.Exists()) vehicleBlip.Flash(2000, 2000);

                GameFiber.StartNew(delegate
                {
                    DateTime future = DateTime.Now.AddSeconds(20);

                    while (true)
                    {
                        GameFiber.Yield();

                        if (character.IsInVehicle(spawnedVehicle, true) | future < DateTime.Now)
                        {
                            vehicleBlip.Delete();
                            if (spawnedVehicle.Exists()) spawnedVehicle.IsPersistent = false;
                            if (driver.Exists())
                            {
                                driver.IsPersistent = false;
                                driver.BlockPermanentEvents = false;
                            }

                            break;
                        }
                    }
                }, "LSPDE Thread");
            }
        }

        private void RemoveWindowTint()
        {
            if (player.LastVehicle.Exists())
            {
                int vehicleWindowTint = NativeFunction.CallByName<int>("GET_VEHICLE_WINDOW_TINT", player.LastVehicle);

                if (vehicleWindowTint != 0)
                {
                    NativeFunction.CallByName<uint>("SET_VEHICLE_WINDOW_TINT", player.LastVehicle, 0);
                }
                else
                {
                    Game.DisplayNotification("No need to remove Window Tint if there is none!");
                }
            }
        }

        private enum FixType { Engine, Vehicle }
        private void FixVehicle(FixType type)
        {
            if ((int)type == 0)
            {
                if (player.LastVehicle.Exists())
                {
                    player.LastVehicle.Repair();
                }
            }
            if ((int)type == 1)
            {
                if (player.LastVehicle.Exists())
                {
                    player.LastVehicle.EngineHealth = 1000;
                }
            }
        }
        #endregion

        #region quickSetupMenu
        public void StartQuickSetup()
        {
            SetPlayerModel();

            if (cbSpawnWithWeapons.Checked)
            {
                if (!c.IsRealisticWeaponOptionEnabled()) GiveOfficerLoadout();
                else DeliverOfficerLoadout();

                while (true)
                {
                    if (inventory.HasLoadedWeapon)
                    {
                        break;
                    }
                }
            }

            if (c.IsRealisticCarOptionEnabled())
            {
                DeliverVehicle();
            }
            else
            {
                SpawnVehicle();
            }
        }
        #endregion

        #region weaponMenu
        private void AddWeaponToQueue()
        {
            int wpnIndex = weaponsList.Index;

            if (weaponQueue.Contains(l.WeaponModels[wpnIndex]))
            {
                weaponQueue.Remove(l.WeaponModels[wpnIndex]);

                Game.DisplayNotification(string.Format("The weapon ~r~{0}~w~ has been removed from the queue", l.WeaponNames[wpnIndex]));
                
            }
            else
            {
                weaponQueue.Add(l.WeaponModels[wpnIndex]);

                Game.DisplayNotification(string.Format("The weapon ~g~{0}~w~ has been added to the queue", l.WeaponNames[wpnIndex]));
            }
        }

        private void SpawnWeapon()
        {
            int wpnIndex = weaponsList.Index;
            string wpnName = weaponsList.IndexToItem(weaponsList.Index);

            WeaponAsset wa = l.WeaponModels[wpnIndex];
            inventory.GiveNewWeapon(wa, (short)Ammo.max, true);

            if (cbSpawnWithAttachments.Checked)
            {
                AddAttachmentsToWeapon(wa);
            }
        }

        private static bool IsWeaponDeliveryInProcess { get; set; }
        private static Ped officer;
        private static Vehicle policeVehicle;
        private static Blip officerBlip;
        private void DeliverWeapons()
        {
            int carModelSelection = new Random().Next(c.CarModelsList().Count);
            Game.LogTrivial("index=" + carModelSelection);
            Game.LogTrivial("size=" + c.CarModelsList().Count);
            Model policeCarModel = c.CarModelsList()[carModelSelection];
            int pedModelSelection = new Random().Next(c.CharacterModelsList().Count);
            Game.LogTrivial("index=" + pedModelSelection);
            Game.LogTrivial("size=" + c.CharacterModelsList().Count);
            Model pedModel = c.CharacterModelsList()[pedModelSelection];
            Vector3 spawnPoint = World.GetNextPositionOnStreet(character.Position.Around(250f, 750f));
            Vector3 playerAroundPos;
            Vector3 playerFrontPos;

            //Start of main code
            IsWeaponDeliveryInProcess = true;
            if (character.IsInAnyVehicle(false))
            {
                if (player.LastVehicle.Speed != 0f) Game.DisplayNotification("Bring your vehicle to a complete stop to start the process...");
                while (true)
                {
                    GameFiber.Yield();

                    if (player.LastVehicle.Speed == 0f)
                    {
                        character.Tasks.LeaveVehicle(LeaveVehicleFlags.None).WaitForCompletion();
                        character.Tasks.FollowNavigationMeshToPosition(player.LastVehicle.GetOffsetPositionRight(-5f), 0f, 2f).WaitForCompletion();
                        break;
                    }
                }
            }

            GameFiber weaponThread = new GameFiber(new ThreadStart(WeaponMenuThread), "LSPDE Thread");
            weaponThread.Start();

            character.IsPositionFrozen = true;
            playerAroundPos = World.GetNextPositionOnStreet(character.Position.Around(10f, 15f));
            playerFrontPos = character.GetOffsetPositionFront(2f);
            policeVehicle = new Vehicle(policeCarModel, spawnPoint);
            officer = new Ped(pedModel, policeVehicle.GetOffsetPositionFront(5f), 0f);
            officer.WarpIntoVehicle(policeVehicle, -1);
            officerBlip = officer.AttachBlip();

            officerBlip.IsFriendly = true;
            officerBlip.IsRouteEnabled = true;

            officer.IsPersistent = true;
            officer.BlockPermanentEvents = true;
            policeVehicle.IsPersistent = true;

            policeVehicle.IsSirenOn = true;
            officer.Tasks.DriveToPosition(playerAroundPos, 20f, VehicleDrivingFlags.Emergency).WaitForCompletion();

            if (IsNothingQueued())
            {
                CancelDelivery(CancelType.WeaponDelivery);
                Game.DisplayNotification("Weapon Delivery Canceled because no weapons were queued");
            }

            if (officer.Exists() && policeVehicle.Exists()) do
                {
                    officer.Tasks.LeaveVehicle(policeVehicle, LeaveVehicleFlags.None);

                    #region weaponDeliveryWeapon
                    officer.Tasks.FollowNavigationMeshToPosition(playerFrontPos, character.Heading + 180f, 2f).WaitForCompletion();

                    for (int i = 0; i < weaponQueue.Count; i++)
                    {
                        WeaponAsset wp = weaponQueue[i];
                        officer.Inventory.GiveNewWeapon(wp, (short)Ammo.min, true);
                        GameFiber.Sleep(1000);
                        NativeFunction.CallByName<uint>("REMOVE_ALL_PED_WEAPONS", officer, true);
                        inventory.GiveNewWeapon(wp, (short)Ammo.max, true);
                        int index = l.WeaponModels.IndexOf(wp.Hash);
                        Game.DisplaySubtitle(string.Format("~y~Officer~w~: Here is your {0} sir", l.WeaponNames[index]));
                        if (cbSpawnWithAttachments.Checked) AddAttachmentsToWeapon(wp);
                        GameFiber.Sleep(1000);
                    }

                    break;
                    #endregion
                } while (officer.Exists());
            IsWeaponDeliveryInProcess = false;
            character.IsPositionFrozen = false;
            WeaponMenuThreadEnabled = false;

            RemoveAllWeaponsFromQueue();

            if (policeVehicle.Exists() && officer.Exists())
            {
                officer.Tasks.EnterVehicle(policeVehicle, -1).WaitForCompletion();
                officer.Tasks.DriveToPosition(World.GetNextPositionOnStreet(character.Position.Around(250f, 750f)), 20f, VehicleDrivingFlags.FollowTraffic);
                policeVehicle.IsSirenOn = false;
                officer.IsPersistent = false;
                officer.BlockPermanentEvents = false;
                policeVehicle.IsPersistent = false;
            }

            if (officerBlip.Exists()) officerBlip.Delete();
        }

        private void GiveOfficerLoadout()
        {
            l.WeaponModels.ForEach(wa =>
            {
                inventory.GiveNewWeapon(wa, (short)(Ammo.max), false);
                if (cbSpawnWithAttachments.Checked) AddAttachmentsToWeapon(wa);
            });
        }

        private bool IsRequestComingFromDeliverOfficerLoadout { get; set; }
        private void DeliverOfficerLoadout()
        {
            SilentAddAllWeaponsToQueue();
            IsRequestComingFromDeliverOfficerLoadout = true;

            DeliverWeapons();
            IsRequestComingFromDeliverOfficerLoadout = false;
        }

        private void AddAttachmentsToWeapon(WeaponAsset e)
        {
            if (e.Hash == (uint)(WeaponHash.Pistol))
            {
                NativeFunction.CallByName<uint>("GIVE_WEAPON_COMPONENT_TO_PED", character, 0x1B06D571, 0x359B7AAE); //Pistol Flashlight
                NativeFunction.CallByName<uint>("GIVE_WEAPON_COMPONENT_TO_PED", character, 0x1B06D571, 0xED265A1C); //Pistol Extended Clip
            }
            if (e.Hash == (uint)(WeaponHash.CombatPistol))
            {
                NativeFunction.CallByName<uint>("GIVE_WEAPON_COMPONENT_TO_PED", character, 0x5EF9FEC4, 0x359B7AAE); //Combat Pistol Flashlight
                NativeFunction.CallByName<uint>("GIVE_WEAPON_COMPONENT_TO_PED", character, 0x5EF9FEC4, 0xD67B4F2D); //Combat Pistol Extended Clip
            }
            if (e.Hash == (uint)(WeaponHash.CarbineRifle))
            {
                NativeFunction.CallByName<uint>("GIVE_WEAPON_COMPONENT_TO_PED", character, 0x83BF0278, 0x91109691); //Carbine Rifle Extended Clip
                NativeFunction.CallByName<uint>("GIVE_WEAPON_COMPONENT_TO_PED", character, 0x83BF0278, 0xC164F53); //Carbine Rifle Grip
                NativeFunction.CallByName<uint>("GIVE_WEAPON_COMPONENT_TO_PED", character, 0x83BF0278, 0x7BC4CDDC); //Carbine Rifle Flashlight
            }
            if (e.Hash == (uint)(WeaponHash.PumpShotgun))
            {
                NativeFunction.CallByName<uint>("GIVE_WEAPON_COMPONENT_TO_PED", character, 0x1D073A89, 0x7BC4CDDC); //Pump Shotgun Flashlight
            }
        }

        private void RefillAmmo()
        {
            if (inventory.EquippedWeapon == null)
            {
                Game.DisplayNotification("Equip a weapon first");
            }
            else
            {
                WeaponDescriptor weapon = inventory.EquippedWeapon;
                weapon.Ammo = (short)Ammo.max;
            }
        }

        private enum Ammo
        {
            infinite = -1,
            min = 0,
            onek = 1000,
            twok = 2000,
            threek = 3000,
            fourk = 4000,
            fivek = 5000,
            sixk = 6000,
            sevenk = 7000,
            eightk = 8000,
            ninek = 9000,
            max = 9999
        }

        private void RemoveWeapons()
        {
            NativeFunction.CallByName<uint>("REMOVE_ALL_PED_WEAPONS", character, true);
        }

        #region weaponQueue
        private List<WeaponAsset> weaponQueue = new List<WeaponAsset>();

        private bool IsNothingQueued()
        {
            return weaponQueue.Count == 0;
        }

        private void RemoveAllWeaponsFromQueue()
        {
            for (int i = 0; i < weaponQueue.Count; i++)
            {
                weaponQueue.RemoveAt(i);
            }

            Game.DisplayNotification("~r~Removed~w~ all weapons from queue");
        }

        private void SilentAddAllWeaponsToQueue()
        {
            l.WeaponModels.ForEach(wp =>
            {
                if (!weaponQueue.Contains(wp)) weaponQueue.Add(wp);
            });
        }
        #endregion

        #endregion

        #region environmentMenu
        private void SetEnvironment(int time)
        {
            World.DateTime = new DateTime(1970, 1, 1, time, 0, 0);
        }

        private void SetEnvironment(string weatherType)
        {
            NativeFunction.CallByName<uint>("SET_WEATHER_TYPE_NOW", weatherType);
        }

        private bool FreezeTimeEnabled { get; set; } = true;
        private void FreezeTime()
        {
            Game.LogTrivial("Starting freezeTime void");

            GameFiber.StartNew(delegate
            {
                while (FreezeTimeEnabled)
                {
                    int index = timeList.Index;

                    GameFiber.Sleep(2000);

                    SetEnvironment(l.TimeInt[index]);
                }
            }, "LSPDE Thread");

            Game.LogTrivial("Ending freezeTime void");
            FreezeTimeEnabled = true;
        }

        private bool FreezeWeatherEnabled { get; set; } = true;
        private void FreezeWeather()
        {
            Game.LogTrivial("Starting freezeWeather void");

            GameFiber.StartNew(delegate
            {
                while (FreezeWeatherEnabled)
                {
                    int index = weatherList.Index;

                    GameFiber.Sleep(2000);

                    SetEnvironment(l.WeatherType[index]);
                }
            }, "LSPDE Thread");

            Game.LogTrivial("Ending freezeWeather Thread");
            FreezeWeatherEnabled = true;
        }
        #endregion

        private enum CancelType { VehicleDelivery, WeaponDelivery }
        private void CancelDelivery(CancelType type)
        {
            if ((int)type == 0)
            {
                if (spawnedVehicle.Exists())
                {
                    spawnedVehicle.IsPersistent = false;
                }
                if (driver.Exists())
                {
                    driver.IsPersistent = false;
                    driver.BlockPermanentEvents = false;
                }
                if (vehicleBlip.Exists())
                {
                    vehicleBlip.Delete();
                }
                if (vehicleDeliveryBlip.Exists())
                {
                    vehicleDeliveryBlip.Delete();
                }

                StopVehicleDeliveryMenu.Visible = false;
                VehicleMenuThreadEnabled = false;
                IsCarDeliveryInProcess = false;
            }
            if ((int)type == 1)
            {
                character.Tasks.ClearImmediately();

                if (officer.Exists())
                {
                    officer.IsPersistent = false;
                    officer.BlockPermanentEvents = false;
                    officer.Delete();
                }
                if (policeVehicle.Exists())
                {
                    policeVehicle.IsPersistent = false;
                    policeVehicle.Delete();
                }
                if (officerBlip.Exists())
                {
                    officerBlip.Delete();
                }

                character.IsPositionFrozen = false;
                WeaponMenuThreadEnabled = false;
                IsWeaponDeliveryInProcess = false;
            }
        }

        #region other
        private bool VehicleMenuThreadEnabled { get; set; } = true;
        private void VehicleMenuThread()
        {
            StopVehicleDeliveryMenu.Visible = true;
            _MenuPool.ProcessMenus();

            while (VehicleMenuThreadEnabled)
            {
                GameFiber.Yield();

                if (Game.IsKeyDown(c.GetKeyBinding()))
                {
                    StopVehicleDeliveryMenu.Visible = !StopVehicleDeliveryMenu.Visible;
                }

                MainMenu.Visible = false;
                vehicleMenu.Visible = false;
                quickSetupMenu.Visible = false;

                _MenuPool.ProcessMenus();
            }

            vehicleMenu.Visible = true;
            StopVehicleDeliveryMenu.Visible = false;
            _MenuPool.ProcessMenus();
            VehicleMenuThreadEnabled = true;
        }

        private bool WeaponMenuThreadEnabled { get; set; } = true;
        private void WeaponMenuThread()
        {
            StopWeaponDeliveryMenu.Visible = true;
            _MenuPool.ProcessMenus();

            while (WeaponMenuThreadEnabled)
            {
                GameFiber.Yield();

                if (Game.IsKeyDown(c.GetKeyBinding()))
                {
                    StopWeaponDeliveryMenu.Visible = !StopWeaponDeliveryMenu.Visible;
                }

                MainMenu.Visible = false;
                weaponMenu.Visible = false;
                quickSetupMenu.Visible = false;

                _MenuPool.ProcessMenus();
            }

            weaponMenu.Visible = true;
            StopVehicleDeliveryMenu.Visible = false;
            _MenuPool.ProcessMenus();
            WeaponMenuThreadEnabled = true;
        }

        private bool AutodriveProcessThreadEnabled { get; set; } = true;
        private void AutodriveProcessThread()
        {
            while (AutodriveProcessThreadEnabled)
            {
                GameFiber.Yield();
            }

            AutodriveProcessThreadEnabled = true;
        }
        #endregion

        #region ConsoleCommands
        internal static void LSPDECleanUp()
        {
            World.CleanWorld(true, true, true, true, true, true);
            Game.LocalPlayer.Character.IsPositionFrozen = false;
        }
        #endregion


        #region GUIHandler Items
        private static bool cbFreezeTimeChecked = false;

        private static bool cbFreezeWeatherChecked = false;

        internal void CheckCheckboxes()
        {
            if (cbPlayerInvincible.Checked == true)
            {
                Game.LocalPlayer.IsInvincible = true;
            }
            if (!cbPlayerInvincible.Checked)
            {
                Game.LocalPlayer.IsInvincible = false;
            }

            if (cbNeverWanted.Checked == true)
            {
                Game.LocalPlayer.WantedLevel = 0;
            }

            if (cbUnlimitedAmmo.Checked == true)
            {
                if (Game.LocalPlayer.Character.Inventory.EquippedWeapon != null)
                {
                    WeaponDescriptor equipWeapon = Game.LocalPlayer.Character.Inventory.EquippedWeapon;
                    equipWeapon.Ammo = 9999;
                }
            }

            if (cbNoRagdoll.Checked == true)
            {
                Game.LocalPlayer.Character.CanRagdoll = false;
            }
            else
            {
                Game.LocalPlayer.Character.CanRagdoll = true;
            }

            if (cbFreezeWeather.Checked && !cbFreezeWeatherChecked)
            {
                GameFiber freezeWeatherThread = new GameFiber(new ThreadStart(FreezeWeather), "LSPDE Thread");
                freezeWeatherThread.Start();
                cbFreezeWeatherChecked = true;
                GameFiber.Sleep(50);
            }
            if (!cbFreezeWeather.Checked && cbFreezeWeatherChecked)
            {
                FreezeWeatherEnabled = false;
                cbFreezeWeatherChecked = false;
                GameFiber.Sleep(50);
            }
        }
        #endregion
    }
}