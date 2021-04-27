using System;
using SUD_TextAdventure.Models;

namespace SUD_TextAdventure.Rooms
{
    public class library
    {
        public Program _Program;
        private bool _lookedAround = false;
        private bool _Back = false;

        public library(Program program)
        {
            _Program = program;
        }


        public string run()
        {
            while (_Program.Room == "library")
            {
                // TODO: Write 2
                Console.WriteLine("Der Raum ist geschmückt mit Bücherregalen an jeder Wand.");
                Console.WriteLine(_lookedAround);
                if (_lookedAround)
                    Console.WriteLine("Was möchtest Du Dir genauer ansehen? \nThemen der Bücher? \nDen Sessel?");
                var validInput = new[] {"umsehen", "themen", "bücher", "sessel"};
                var confirmation = _Program.CheckInput(validInput);
                switch (confirmation)
                {
                    case "umsehen":
                        Console.WriteLine(
                            "Der Raum erstreckt sich weit nach oben mit weiteren Bücherregalen und auf der anderen Seite befindet sich ein Sessel und ein Tisch, an dem man vermutlich gelesen hat. Die Bücher scheinen nach Themen sortiert zu sein.");
                        Console.WriteLine("Vielleicht kannst Du hier etwas darüber erfahren wo Du Dich befindest?");
                        _lookedAround = true;
                        break;
                    case "themen":
                        // ToDo: Add text
                        break;
                    case "bücher":
                        // ToDo: Add text
                        break;
                    case "sessel":
                        while (!_Back)
                        {
                            Console.WriteLine(
                                "Der Sessel selbst sieht ziemlich alt aber noch im guten Zustand aus. Auf dem Tisch neben ihm liegen sorar noch ein paar Bücher, als hätte bis gerade noch jemand hier gesessen und gelesen.");
                            Console.WriteLine("Was möchtest Du tun?");
                            validInput = new[] {"bücher", "zurück", "öffnen"};
                            confirmation = _Program.CheckInput(validInput);
                            switch (confirmation)
                            {
                                case "zurück":
                                    _Back = true;
                                    break;
                                case "bücher":
                                    Console.WriteLine(
                                        "Die Bücher scheinen überraschenderweise alle über Käse zu sein. Damit erfährst Du wohl nicht wo Du bist.");
                                    break;
                                case "öffnen":
                                    Console.WriteLine(
                                        "Du nimmst ein Buch vom Tisch und öffnest es. \n Doch was ist das? In den Seiten befindet sich ein größes Loch und darin befindet sich ein komisch aussehender Stein.");
                                    _Program.Character.Inventory.Add(new Item() {ItemName = "Maus"});
                                    break;
                            }
                        }

                        break;
                }
            }

            return "";
        }
    }
}