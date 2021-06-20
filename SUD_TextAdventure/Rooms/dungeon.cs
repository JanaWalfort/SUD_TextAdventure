using System;

namespace SUD_TextAdventure.Rooms
{
    public class dungeon
    {
        public Program _Program;

        public dungeon(Program program)
        {
            _Program = program;
        }


        public string run()
        {
            // ToDo: Add Text
            if (_Program.Character.Inventory.Exists(x => x.ItemName == "Taschenlampe"))
            {
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("Nur durch das bisschen Licht was von oben herab scheint, erkennst Du, dass sich der enge Korridor in zwei Wege aufteilt, die tiefer in die Dunkelheit führen.");
            }
            Console.WriteLine("Dir läuft es eiskalt den Rücken herunter und Du musst plötzlich an all die alten Horrorspiele denken, die Du schon einmal gesehen hast.");
            
            // ToDo: Add continuation
            Console.WriteLine("Vor lauter Angst entscheidest Du Dich wieder die Treppe hochzulaufen.");
            return "corridorTwo";
        }
    }
}