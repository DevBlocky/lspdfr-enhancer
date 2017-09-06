using Rage;
using System.Collections.Generic;

namespace LSPDFR_Enhancer.GUI
{
    public class GUIList
    {
        public List<string> VehicleModels { get { return vehicleModels; } internal set { vehicleModels = value; } }
        public List<dynamic> VehicleModelNames { get { return vehicleModelNames; } internal set { vehicleModelNames = value; } }
        public List<dynamic> VehicleDirections { get { return vehicleDirections; } }
        public List<uint> WeaponModels { get { return weaponModels; } internal set { weaponModels = value; } }
        public List<dynamic> WeaponNames { get { return weaponNames; } internal set { weaponNames = value; } }
        public List<dynamic> WeatherName { get { return weatherName; } internal set { weatherName = value; } }
        public List<string> WeatherType { get { return weatherType; } internal set { weatherType = value; } }
        public List<dynamic> Time { get { return time; } internal set { time = value; } }
        public List<int> TimeInt { get { return timeInt; } internal set { timeInt = value; } }
        public List<dynamic> WantedLevel { get { return wantedLevel; } }
        public List<int> WantedLevelInt { get { return wantedLevelInt; } }
        public List<dynamic> PlayerModelNames { get { return playerModelNames; } internal set { playerModelNames = value; } }
        public List<string> PlayerModels { get { return playerModels; } internal set { playerModels = value; } }

        private static List<string> vehicleModels = new List<string>
        {
            "POLICE",
            "POLICE2",
            "POLICE3",
            "POLICE4",
            "SHERIFF",
            "SHERIFF2",
            "FBI",
            "FBI2",
            "POLICEB",
            "POLICET",
            "RIOT"
        };
        private static List<dynamic> vehicleModelNames = new List<dynamic>
        {
            "Police Cruiser",
            "Police Buffalo",
            "Police Intercepter",
            "Unmarked Police",
            "Sheriff Cruiser",
            "Sheriff SUV",
            "FIB Cruiser",
            "FIB SUV",
            "Police Transporter",
            "Police Bike",
            "Riot Truck"
        };
        private static List<dynamic> vehicleDirections = new List<dynamic>
        {
            "Front",
            "Back"
        };
        private static List<uint> weaponModels = new List<uint>
        {
            (uint)(WeaponHash.Pistol),
            (uint)WeaponHash.CombatPistol,
            (uint)WeaponHash.CarbineRifle,
            (uint)WeaponHash.PumpShotgun,
            (uint)WeaponHash.StunGun,
            (uint)WeaponHash.Flashlight,
            (uint)WeaponHash.Nightstick,
        };
        private static List<dynamic> weaponNames = new List<dynamic>
        {
            "Pistol",
            "Combat Pistol",
            "Carbine Assault Rifle",
            "Shotgun",
            "Tazer",
            "Flashlight",
            "Baton"
        };
        private static List<dynamic> weatherName = new List<dynamic>
        {
            "Extra Sunny",
            "Clear",
            "Cloudy",
            "Smoggy",
            "Foggy",
            "Overcast",
            "Rain",
            "Thunder",
            "Drizzle",
            "Neutral"
        };
        private static List<string> weatherType = new List<string>
        {
            "EXTRASUNNY",
            "CLEAR",
            "CLOUDS",
            "SMOG",
            "FOGGY",
            "OVERCAST",
            "RAIN",
            "THUNDER",
            "CLEARING",
            "NEUTRAL"
        };
        private static List<dynamic> time = new List<dynamic>
        {
            "Early Morning",
            "Morning",
            "Noon",
            "Afternoon",
            "Evening",
            "Midnight"
        };
        private static List<int> timeInt = new List<int>
        {
            4,
            7,
            12,
            15,
            21,
            2
        };
        private static List<dynamic> wantedLevel = new List<dynamic>
        {
            "None",
            "1 Star",
            "2 Stars",
            "3 Stars",
            "4 Stars",
            "5 Stars"
        };
        private static List<int> wantedLevelInt = new List<int>
        {
            0,
            1,
            2,
            3,
            4,
            5
        };
        private static List<dynamic> playerModelNames = new List<dynamic>
        {
            "Male Sheriff",
            "Male Police",
            "Female Police",
            "Male CHP",
            "Male Snow Police"
        };
        private static List<string> playerModels = new List<string>
        {
            "csb_cop",
            "s_m_y_cop_01",
            "s_f_y_cop_01",
            "s_m_y_hwaycop_01",
            "s_m_m_snowcop_01"
        };
    }
}
