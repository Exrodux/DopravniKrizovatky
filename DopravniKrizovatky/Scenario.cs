using System.Collections.Generic;
using System.Text.Json.Serialization; // Důležité pro [JsonIgnore]

namespace DopravniKrizovatky
{
    // Hlavní třída pro celou křižovatku
    public class Scenario
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string Explanation { get; set; } // Obecné vysvětlení
        public string BackgroundImage { get; set; }

        public List<Vehicle> Vehicles { get; set; }
        public List<TrafficSign> Signs { get; set; } // Seznam značek
    }

    // Třída pro dopravní značku
    public class TrafficSign
    {
        public string ImageName { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
    }

    // Třída pro vozidlo
    public class Vehicle
    {
        public string Id { get; set; }
        public string Type { get; set; }

        // Startovní pozice
        public int X { get; set; }
        public int Y { get; set; }
        public int Rotation { get; set; }
        public string ImageName { get; set; }

        // Logika průjezdu
        public int CorrectOrder { get; set; }
        public string TurnSignal { get; set; } // "Left", "Right", "None"
        public string Reason { get; set; }     // Vysvětlení pro konkrétní auto

        // --- ANIMACE (CÍL) ---
        public int TargetX { get; set; }
        public int TargetY { get; set; }
        public int TargetRotation { get; set; }

        // --- ZATÁČENÍ (Bézierův bod) ---
        // Pokud jsou null, jede auto rovně. Pokud jsou vyplněné, jede obloukem.
        public int? ControlX { get; set; }
        public int? ControlY { get; set; }

        // --- PROMĚNNÉ PRO BĚH APLIKACE (neukládají se do JSON) ---
        [JsonIgnore]
        public float CurrentX { get; set; }
        [JsonIgnore]
        public float CurrentY { get; set; }
        [JsonIgnore]
        public float CurrentRotation { get; set; }
        [JsonIgnore]
        public bool IsFinished { get; set; } // Zda už auto odjelo
    }
}