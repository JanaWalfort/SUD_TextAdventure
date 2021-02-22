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
        
        private bool isWindowBroken = false;

        public string run()
        {
            Console.WriteLine(
                "Es ist so staubig, dass Du husten musst. Durch ein Dachfenster siehst Du ein paar Lichtstrahlen. Ist das vielleicht der Mond?" +
                "\nUmsehen? \nFenster? \nZurück?");
            String[] validInput = {"umsehen", "fenster", "zurück"};
            string confirmation = _Program.checkInput(validInput);

            switch (confirmation)
            {
                case "umsehen":
                    Console.WriteLine(
                        "Der Dachboden ist überfüllt mit Kisten und in jeder Ecke steht Gerümpel. Du kannst Dich kaum bewegen, aber was ist das vor Deinen Füßen? " +
                        "Du findest einen mysteriösen Stein mit einem Adler drauf.");
                    _Program._character.Inventory.Add(new Item() {ItemName = "Adler"});
                    break;
                case "fenster":
                    if (!isWindowBroken && _Program._character.Inventory.Exists(x => x.ItemName == "Brechstange"))
                    {
                        Console.WriteLine("Mit Deiner Brechstange zerschlägst Du das Fenster. Du schaust heraus und es ist viel zu hoch, um raus zu klettern.");
                        isWindowBroken = true;
                    }
                    else if (!isWindowBroken && _Program._character.Inventory.Exists(x => x.ItemName == "Schwert"))
                    {
                        Console.WriteLine("Mit Deinem Schwert zerschlägst Du das Fenster. Du schaust heraus und es ist viel zu hoch, um raus zu klettern.");
                        isWindowBroken = true;
                    }
                    else
                    {
                        Console.WriteLine("Du guckst aus Fenster hinaus und siehst den Mond am Himmel stehen.");
                    }
                    if (isWindowBroken && _Program._character.Inventory.Exists(x => x.ItemName == "Seil"))
                    {
                        Console.WriteLine("Um herauszuklettern könntest Du das Seil an der Kiste hinter Dir festbinden. Möchtest Du das versuchen?");
                        validInput = new[] {"ja", "nein"}; 
                        confirmation = _Program.checkInput(validInput);
                        if (confirmation.Equals("ja"))
                        {
                            Console.WriteLine("Du machst das Seil fest und kletterst langsam die Wand herunter. Unten angekommen rennst zur Straße und endeckst eine TElefonzelle" +
                                              "Du rufst die Polizei und bist entkommen. Herzlichen Glückwunsch!");
                            _Program._gameFinished = true;
                        }
                        else
                        {
                            Console.WriteLine("Um das Fenster liegen Scherben, aber ohne Weiteres kommst Du nicht heraus.");
                        }
                    }
                    break;
                case "zurück":
                        Console.WriteLine("Du kletterst die Leiter wieder herunter und schließt die Luke zum Dachboden.");
                        return "corridorOne";
                default:
                    break;
            }

            return "";
        }
    }
}