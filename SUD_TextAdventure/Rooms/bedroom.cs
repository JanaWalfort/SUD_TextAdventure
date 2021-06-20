using System;
using SUD_TextAdventure.Constants;

namespace SUD_TextAdventure.Rooms
{
    public class bedroom
    {
        public Program _Program;

        public bedroom(Program program)
        {
            _Program = program;
        }

        public string run()
        {
            Console.WriteLine("Du bist zurück im Schlafzimmer.");
            Console.WriteLine("Du siehst: Einen Schrank, ein Bett und eine Tür. Was willst Du Dir genauer ansehen?");
            var validInput = new[] {"tür", "schrank", "bett", "zurück"};
            var confirmation = _Program.CheckInput(validInput);
            switch (confirmation)
            {
                case "tür":
                    Console.WriteLine("Du gehst zurück in den Flur.");
                    return "corridorOne";
                case "schrank":
                    if (_Program.Character.CollectedNotes.Exists(x => x.Room == (int) Types.NoteRoom.Bedroom)
                        && !_Program.NotesList.List.Exists(x => x.Room == (int) Types.NoteRoom.Bedroom))
                    {
                        Console.WriteLine(
                            "Der Schrank steht in der Ecke des Raums. So wie es aussieht, scheint nur unbrauchbares Zeug darin zu liegen.");
                    }
                    else
                    {
                        Console.WriteLine(
                            "Du schaust in den Schrank und so wie es aussieht, scheint nur unbrauchbares Zeug darin zu liegen. \nWarte, was ist das?");
                        _Program.Character.CollectedNotes.Add(
                            _Program.NotesList.List.Find(x => x.Room == (int) Types.NoteRoom.Bedroom));
                        Console.WriteLine(
                            $"Du findest einen kleinen Zettel auf dem steht \'für {_Program.Character.Name}\'. Darunter steht noch \'{_Program.Character.CollectedNotes.Find(x => x.Room == (int) Types.NoteRoom.Bedroom)?.Text}\'");
                    }

                    break;
                case "bett":
                    Console.WriteLine(
                        "Das Bett scheint, wie alles andere auch mit einer winzigen Staubschicht bedeckt zu sein, bis auf die eine Stelle auf der Du gelegen hast.");
                    break;
                case "zurück":
                    Console.WriteLine("Du gehst zurück in den Flur.");
                    return "corridorOne";
            }


            return "";
        }
    }
}