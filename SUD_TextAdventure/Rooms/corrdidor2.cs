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
            // ToDo: Add Hidig spot for note + Tipp verstecken
            Console.WriteLine("Du befindest Dich in einem langen Korridor, der ein paar Meter vor Dir eine Kurve macht.");
            var validInput = new[] {"umsehen", "rot", "braun", "marmor", "metall"}; // ToDo: How do I know what to do
            var confirmation = _Program.CheckInput(validInput);
            switch (confirmation)
            {
                case "umsehen":
                    Console.WriteLine("Dieser Korridor scheint nicht viel anders als der Andere auszusehen. Hier und da steht etwas Dekoration, die schon länger nicht mehr geputzt wurde.");
                    Console.WriteLine("Du gehst um die Ecke und erkennst, dass der Korridor insgesamt zu vier Räumen führt.");
                    Console.WriteLine("Die braune Tür führt zurück zur Eingangshalle. Die zweite Tür wirkt ziemlich imposant und ist komplett aus Marmor gemacht. Die Dritte Tür hat einen rötlicheren Ton als die Türen, die Du bis jetzt gesehnen hast" +
                                      "und die vierte Tür scheint aus Metall zu sein");
                    break;
                case "rot":
                    Console.WriteLine("Du näherst Dich der roten Tür und öffnest sie.");
                    return "library";
                case "braun":
                    Console.WriteLine("Du öffnest die Tür zum Eingangsbereich.");
                    return "entranceArea";
                case "marmor":
                    Console.WriteLine("Du drückst die Klinke der Tür hinunter und betrittst den Raum.");
                    return "ballroom";
                case "metall":
                    Console.WriteLine("Du öffnest die schwere Metalltür und siehst eine Treppe, die tiefer in die Dunkelheit führt.");
                    if (_Program.Character.Inventory.Exists(x => x.ItemName == "Taschenlampe"))
                    {
                        Console.WriteLine("Zum Glück hast Du eine Taschenlampe gefunden. Damit wirdst Du Dich dort unten bestimmt besser zurecht finden.");
                    }
                    return "dungeon";
            }

            return "";
        }
    }
}