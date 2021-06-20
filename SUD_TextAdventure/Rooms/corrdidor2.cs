using System;
using SUD_TextAdventure.Constants;
using SUD_TextAdventure.Models;

namespace SUD_TextAdventure.Rooms
{
    public class corrdidor2
    {
        public Program _Program;

        public corrdidor2(Program program)
        {
            _Program = program;
        }

        private bool _lookedAround = false;

        public string run()
        {
            // ToDo: Add Hidig spot for note + Tipp verstecken
            Console.WriteLine(
                "Du befindest Dich in einem langen Korridor, der ein paar Meter vor Dir um die Ecke weiter verläuft.");
            if (_lookedAround)
            {
                Console.WriteLine("Was möchtest Du tun?");
                Console.WriteLine("Umsehen? \nWeiße Tür? \nBraune Tür \nRote Tür? \nSchwarze Tür? \nRegal?");
            }
            else
            {
                Console.WriteLine(
                    "Von hier aus kannst Du zwei Türen sehen. Die eine Tür ist braun und die andere ist eine weiße Mamortür.");
                Console.WriteLine("Umsehen? \nrote Tür? \nBraune Tür");
            }

            var validInput = new[] {"umsehen", "rot", "braun", "weiß", "schwarz"};
            var confirmation = _Program.CheckInput(validInput);
            switch (confirmation)
            {
                // ToDo: Add rope
                case "umsehen":
                    Console.WriteLine(
                        "Dieser Korridor scheint nicht viel anders als der Andere auszusehen. Hier und da steht etwas Dekoration, die schon länger nicht mehr geputzt wurde.");
                    Console.WriteLine(
                        "Du gehst um die Ecke und erkennst, dass der Korridor insgesamt zu vier Räumen führt.");
                    Console.WriteLine(
                        "Die Türen vorne im Korridor sind braun und weiß und die anderen im hinteren Teil des Korridors sind rot und schwarz.");
                    Console.WriteLine("Außerdem befindet sich im hinteren Teil des Korridors auch noch ein Regal.");
                    break;
                case "rot":
                    Console.WriteLine("Du näherst Dich der roten Tür und öffnest sie.");
                    return "library";
                case "braun":
                    Console.WriteLine("Du öffnest die braune Tür.");
                    return "entranceArea";
                case "weiß":
                    Console.WriteLine("Du drückst die Klinke der Tür hinunter und betrittst den Raum.");
                    return "ballroom";
                case "schwarz":
                    Console.WriteLine(
                        "Du öffnest die schwere, schwarze Tür und siehst eine Treppe, die tiefer in die Dunkelheit führt.");
                    if (_Program.Character.Inventory.Exists(x => x.ItemName == "Taschenlampe"))
                    {
                        Console.WriteLine(
                            "Zum Glück hast Du eine Taschenlampe gefunden. Damit wirdst Du Dich dort unten bestimmt besser zurecht finden.");
                    }

                    return "dungeon";
                case "regal":
                    if (!_Program.Character.Inventory.Exists(x => x.ItemName == "Seil"))
                    {
                        Console.WriteLine("Du öffnest das Regal und findest ein Seil. Das könnte noch nützlich sein!");
                        _Program.Character.Inventory.Add(new Item() {ItemName = "Seil"});
                        
                        if (!_Program.Character.CollectedNotes.Exists(x => x.Room == (int) Types.NoteRoom.Corridor2)
                            && _Program.NotesList.List.Exists(x => x.Room == (int) Types.NoteRoom.Corridor2))
                        {
                            Console.WriteLine(
                                $"Warte, da leigt noch ein Zettel im Regal! Auf ihm steht \'Für {_Program.Character.Name} \' und \'{_Program.Character.CollectedNotes.Find(x => x.Room == (int) Types.NoteRoom.Corridor2)?.Text}\'.");
                            _Program.Character.CollectedNotes.Add(
                                _Program.NotesList.List.Find(x => x.Room == (int) Types.NoteRoom.Corridor2));
                        }
                    }
                    else
                    {
                        Console.WriteLine("Du öffnest das Regal, aber findest nichts von Intersse.");
                    }

                    break;
            }

            return "";
        }
    }
}