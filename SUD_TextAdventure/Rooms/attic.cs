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
                "\n? \n? \n? \nZurück? ");
            String[] validInput = {"umsehen", "zur tür", "zur leiter", "zurück"};
            string confirmation = _Program.checkInput(validInput);

            switch (confirmation)
            {
                case "umsehen":
                    Console.WriteLine(
                        "Du siehst dich um und es scheint, dass lange niemand mehr da gewesen ist. \nAn der Wand steht ein Regal mit verstaubten Porzellan und an der Decke hängen Spinnenweben.");
                    break;
                case "zur tür":
                    Console.WriteLine(
                        "Du gehst den Flur bis zur Tür entlang. Du öffnest sie und siehst wie eine Treppe hinunterführt.");
                    return "entranceArea";
                    break;
                case "zur leiter":
                    Console.WriteLine("Du stehst vor der Leiter. Möchtest du sie hoch klettern?");
                    String[] validInputLadder = {"ja", "nein"};
                    String confirmationLadder = _Program.checkInput(validInputLadder);
                    if (confirmationLadder.Equals("ja"))
                    {
                        Console.WriteLine("Du kletterst die Leiter hoch und öffnest die Luke zum Dachboden.");
                        return "attic";
                    }
                    break;
                default:
                    break;
            }

            return "";
        }
    }
}