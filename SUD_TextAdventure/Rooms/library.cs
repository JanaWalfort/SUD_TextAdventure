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
                Console.WriteLine(
                    "Der Raum erstreckt sich weit nach oben mit vielen Bücherregalen und auf der anderen Seite befindet sich ein Sessel und ein Tisch, an dem man vermutlich gelesen hat.");
                Console.WriteLine("Was möchtest Du Dir genauer ansehen? \nDie Regale? \nDie Bücher? \nDen Sessel?");
                var validInput = new[] {"themen", "bücher", "sessel"};
                var confirmation = _Program.CheckInput(validInput);
                switch (confirmation)
                {
                    case "regale":
                        // ToDo: Add text
                        Console.WriteLine(
                            "Von hier kannst Du mehrere Reihen an Bücherregalen erkennen. Die Bücher behandeln Themen von Geschichte und Mythologie bis zu Fantasy und Horror.");
                        Console.WriteLine("");
                        // Themen der Bücher: Geschichte, Mythologie, Fantasy, Horror, Käsearten, ...
                        break;
                    case "bücher":
                        Console.WriteLine(
                            "Du nimmst Dir ein Buch aus dem Regal, das mit \'Geschichte\' gekennzeichnet ist.");
                        Console.WriteLine("Das Buch heißt ... und handelt über ..."); // ToDo: Add + Tipp verstecken
                        break;
                    case "sessel":
                        while (!_Back)
                        {
                            Console.WriteLine(
                                "Der Sessel selbst sieht ziemlich alt aber noch im guten Zustand aus. Auf dem Tisch neben ihm liegen sorar noch ein paar Bücher, als hätte bis gerade noch jemand hier gesessen und gelesen.");
                            Console.WriteLine("Was möchtest Du tun? \nBücher angucken? \nEin Buch öffnen? \n Zurück zur Tür?");
                            // add todos
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
                                    _Back = true;
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