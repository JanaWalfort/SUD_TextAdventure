using System;

namespace SUD_TextAdventure.Rooms
{
    public class kitchen
    {
        public Program _Program;

        public kitchen(Program program)
        {
            _Program = program;
        }


        public string run()
        {
            Console.WriteLine(
                "Du befindest dich in einer Küche. Jemand hat ein schon gut duftendes Brot in den Ofen gestellt. War noch jemand hier?" +
                "\nWas willst du tun? \nUmsehen? \nNach Draußen? \nZum Ofen? ");
            String[] validInput = {"umsehen", "draußen", "ofen"};
            string confirmation = _Program.CheckInput(validInput);

            switch (confirmation)
            {
                case "umsehen":
                    Console.WriteLine(
                        "Wenn Du Dich in der Küche umsiehst, siehst Du weiter nur Gerümpel und eine Glastür, die offenbar nach draußen führt. " +
                        "Du siehst Dich um und gehst zu den Schränken. \nHier steht altes Geschirr und verdorbenes Essen. Es ist nichts brauchbares dabei.");
                    break;
                case "draußen":
                    Console.WriteLine(
                        "Du gehst zur Tür und gelangst nach draußen auf eine schmale Veranda. Du gehst die kleine Treppe hinuter und blickst auf einen perfekten, symmetrischen Garten.");
                    return "garden";
                case "ofen":
                    Console.WriteLine("Du stehst vor dem Ofen. Möchtest Du ihn öffnen?");
                    String[] validInputLadder = {"ja", "nein"};
                    String confirmationLadder = _Program.CheckInput(validInputLadder);
                    if (confirmationLadder.Equals("ja"))
                    {
                        Console.WriteLine("Das Brot scheint fertig zu sein. Du nimmst es heraus und stärkst Dich.");
                        // TODO: Tip
                    }
                    break;
            }
            return "";
        }
    }
}