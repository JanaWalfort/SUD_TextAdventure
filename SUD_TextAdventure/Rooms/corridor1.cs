using System;
using System.Linq.Expressions;

namespace SUD_TextAdventure.Rooms
{
    public class corridor1
    {
        public Program _Program;

        public corridor1(Program program)
        {
            _Program = program;
        }


        public string run()
        {
            
            Console.WriteLine(
                "Du befindest dich in einem Flur. Du kannst am Ende des Flurs eine weitere Tür sehen. Außerdem scheint es hier auch eine Leiter nach oben zu geben." +
                "\nWas willst Du tun? \nUmsehen? \nZur Tür? \nZur Leiter? \nIns Schlafzimmer?");
            String[] validInput = {"umsehen", "tür", "leiter", "zurück", "schlafzimmer"};
            string confirmation = _Program.CheckInput(validInput);

            switch (confirmation)
            {
                case "umsehen":
                    Console.WriteLine(
                        "Du siehst Dich um und es scheint, dass lange niemand mehr da gewesen ist. \nAn der Wand steht ein Regal mit verstaubten Porzellan und an der Decke hängen Spinnenweben.");
                    break;
                case "tür":
                    Console.WriteLine(
                        "Du gehst den Flur bis zur Tür entlang. Du öffnest sie und siehst wie eine Treppe hinunterführt."); // ToDo: Change text to empathise entering an new room
                    return "entranceArea";
                case "leiter":
                    Console.WriteLine("Du stehst vor der Leiter. Möchtest Du sie hoch klettern?");
                    String[] validInputLadder = {"ja", "nein"};
                    String confirmationLadder = _Program.CheckInput(validInputLadder);
                    if (confirmationLadder.Equals("ja"))
                    {
                        Console.WriteLine("Du kletterst die Leiter hoch und öffnest die Luke zum Dachboden.");
                        return "attic";
                    }
                    break;
                case "schlafzimmer":
                    return "bedroom";
            }

            return "";
        }
    }
}