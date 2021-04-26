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
            // TODO: Write 2
            Console.WriteLine("Du bist zurück im Schlafzimmer");
            Console.WriteLine("Du siehst: Einen Schrank, ein Bett und eine Tür. Was willst Du Dir genauer ansehen?");
            var validInput = new[] {"tür", "schrank", "bett", "zurück"};
            var confirmation = _Program.CheckInput(validInput);
            switch (confirmation)
            {
                case "tür":
                    // ToDo: Add text
                    break;
                case "schrank":
                    // ToDo: Add text
                    break;
                case "bett":
                    // ToDo: Add text
                    break;
                case "zurück":
                    // ToDo: Add text
                    return "corridorOne";
            }
            
            
            return "";
        }
    }
}