using System;
using SUD_TextAdventure.Models;

namespace SUD_TextAdventure.Rooms
{
    public class attic
    {
        public Program _Program;

        public attic(Program program)
        {
            _Program = program;
        }

        private bool _lookedAround = false;

        public string run()
        {
            if (!_lookedAround)
            {
                Console.WriteLine(
                    "Es ist so staubig, dass Du husten musst. Durch ein Dachfenster siehst Du ein paar Lichtstrahlen. Ist das vielleicht der Mond?" +
                    "\nUmsehen? \nFenster? \nZurück?");
            }
            else
            {
                Console.WriteLine(
                    "Um Dich herum liegen viele Kisten und durch ein Dachfenster siehst Du ein paar Lichtstrahlen." +
                    "\nUmsehen? \nFenster? \nKiste? \nZurück?");
            }

            String[] validInput = {"umsehen", "fenster", "zurück", "kiste"};
            string confirmation = _Program.CheckInput(validInput);

            switch (confirmation)
            {
                case "umsehen":
                    Console.WriteLine(
                        "Der Dachboden ist überfüllt mit Kisten und in jeder Ecke steht Gerümpel. Du kannst Dich kaum bewegen, aber was ist das vor Deinen Füßen? " +
                        "Du findest einen mysteriösen Stein mit einem Adler drauf und steckst ih ein.");
                    _Program.Character.Inventory.Add(new Item() {ItemName = "Adler"});
                    _lookedAround = true;
                    break;
                case "kiste":
                    Console.WriteLine(
                        "Du öffnest eine der Kisten. Du erwartest in der Kiste viel Gerümpel zu finden, aber in ihr ist nur ein einziges Stück Papier."); // ToDo: Tipp verstecken
                    break;
                case "fenster":
                    if (!_Program._isWindowBroken &&
                        _Program.Character.Inventory.Exists(x => x.ItemName == "Brechstange"))
                    {
                        Console.WriteLine(
                            "Mit Deiner Brechstange zerschlägst Du das Fenster. Du schaust hinaus und es ist viel zu hoch, um raus zu klettern.");
                        _Program._isWindowBroken = true;
                    }
                    else if (!_Program._isWindowBroken &&
                             _Program.Character.Inventory.Exists(x => x.ItemName == "Schwert"))
                    {
                        Console.WriteLine(
                            "Mit Deinem Schwert zerschlägst Du das Fenster. Du schaust hinaus und es ist viel zu hoch, um raus zu klettern.");
                        _Program._isWindowBroken = true;
                    }
                    else
                    {
                        Console.WriteLine("Du guckst aus dem Fenster hinaus und siehst den Mond am Himmel stehen.");
                    }

                    if (_Program._isWindowBroken && _Program.Character.Inventory.Exists(x => x.ItemName == "Seil"))
                    {
                        Console.WriteLine(
                            "Um herauszuklettern könntest Du das Seil an der Kiste hinter Dir festbinden. Möchtest Du das versuchen?");
                        validInput = new[] {"ja", "nein"};
                        confirmation = _Program.CheckInput(validInput);
                        if (confirmation.Equals("ja"))
                        {
                            Console.WriteLine(
                                "Du machst das Seil fest und kletterst langsam die Wand herunter. Unten angekommen rennst Du zur Straße und endeckst eine Telefonzelle" +
                                "Du rufst die Polizei und bist entkommen. Herzlichen Glückwunsch!");
                            _Program.GameFinished = true;
                        }
                        else
                        {
                            Console.WriteLine(
                                "Um das Fenster herum liegen Scherben, aber ohne Weiteres kommst Du nicht heraus.");
                        }
                    }

                    break;
                case "zurück":
                    Console.WriteLine("Du kletterst die Leiter wieder herunter und schließt die Luke zum Dachboden.");
                    return "corridorOne";
            }

            return "";
        }
    }
}