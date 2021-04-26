using System;

namespace SUD_TextAdventure.Rooms
{
    public class corrdidor2
    {
        public Program _Program;

        public corrdidor2(Program program)
        {
            _Program = program;
        }


        public string run()
        {
            // TODO: Write 2
            Console.WriteLine("Du befindest Dich in einem langen Korridor, der ein paar Meter vor Dir eine Kurve macht.");
            var validInput = new[] {"umsehen", "rot", "braun", "marmor"};
            var confirmation = _Program.CheckInput(validInput);
            switch (confirmation)
            {
                case "umsehen":
                    Console.WriteLine("Dieser Korridor scheint nicht viel anders als der Andere. Hier und da steht etwas Dekoration, der schon länger nicht mehr geputzt wurde.");
                    Console.WriteLine("Du gehst um die Ecke und erkennst, dass der Korridor insgesamt zu drei Räumen führt.");
                    Console.WriteLine("Die braune Tür führt zurück zur Eingangshalle. Die zweite Tür wirkt ziemlich imposant und ist komplett aus Marmor gemacht. Die Dritte Tür hat einen rötlicheren Ton als die Türen, die Du bis jetzt gesenen hast.");
                    break;
                case "rot":
                    // ToDo: Add text
                    return "libarary";
                case "braun":
                    // ToDo: Add text
                    return "entranceArea";
                case "mamor":
                    // ToDo: Add text
                    return "ballroom";
            }

            return "";
        }
    }
}