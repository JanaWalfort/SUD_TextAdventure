using System;

namespace SUD_TextAdventure.Rooms
{
    public class attic
    {
        public Program _Program;
        

        public string run()
        {
            Console.WriteLine(
                "" +
                "Umsehen\n? \n? \n? \nZurück? ");
            String[] validInput = {"umsehen", "", "", "zurück"};
            string confirmation = _Program.checkInput(validInput);

            switch (confirmation)
            {
                case "umsehen":
                    Console.WriteLine(
                        "");
                    break;
                case "":
                    Console.WriteLine(
                        "");
                    return "entranceArea";
                    break;
                case "zurück":
                        Console.WriteLine("Du kletterst die Leiter wieder herunter und schließt die Luke zum Dachboden.");
                        return "corridor1";
                default:
                    break;
            }

            return "";
        }
    }
}