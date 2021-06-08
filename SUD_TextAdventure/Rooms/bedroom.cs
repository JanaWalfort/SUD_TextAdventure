using System;

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
            Console.WriteLine("Du bist zurück im Schlafzimmer");
            Console.WriteLine("Du siehst: Einen Schrank, ein Bett und eine Tür. Was willst Du Dir genauer ansehen?");
            var validInput = new[] {"tür", "schrank", "bett", "zurück"};
            var confirmation = _Program.CheckInput(validInput);
            switch (confirmation)
            {
                case "tür":
                    Console.WriteLine("Du gehst zurück in den Flur.");
                    return "corridorOne";
                case "schrank":
                    // ToDo: Add text
                    // ToDo: Tipp verstecken?
                    break;
                case "bett":
                    // ToDo: Add text
                    break;
                case "zurück":
                    Console.WriteLine("Du gehst zurück in den Flur.");
                    return "corridorOne";
            }
            
            
            return "";
        }
    }
}