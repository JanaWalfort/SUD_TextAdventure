using System;

namespace SUD_TextAdventure.Rooms
{
    public class ballroom
    {
        public Program _Program;

        public ballroom(Program program)
        {
            _Program = program;
        }


        public string run()
        {

            Console.WriteLine(
                "Du befindest Dich in einem riesigen Ballsaal. An der Wand stehen Ritterrüstungen und an der Decke hängen gigantische Kronleuchter. " +
                "\nAm Ende des Raums erkennst Du einen Balkon." +
                "\nWas willst du tun? \nUmsehen? \nZum Balkon \nZurück");
            String[] validInput = {"umsehen", "ritter", "balkon"};
            string confirmation = _Program.CheckInput(validInput);

            switch (confirmation)
            {
                case "umsehen":
                    Console.WriteLine(
                        "Der ganze RAum ist voller Spiegel und Marmor. Doch was Dich wirklich interessiert sind die Ritterrüstungen. " +
                        "\n Möchtest Du dir diese genauer anschauen?");
                    String[] validInputConfirm = {"ja", "nein"};
                    String confirmationInputLadder = _Program.CheckInput(validInputConfirm);
                    if (confirmationInputLadder.Equals("ja"))
                    {
                        Console.WriteLine("Die eine Ritterrüstung fällt was auseinander und Du entdeckst einen Gegenstand, der Dir vielleicht weiterhelfen wird auf Deiner Flucht!");
                        // TODO: Put sth in inventar
                    }
                    break;
                case "balkon":
                    Console.WriteLine("Du gehst hinaus auf den Balkon. Du atmest die frische Luft ein.");
                    return "balcony";
                case "zurück":
                    Console.WriteLine("Der Garten in den Du hineingehst ist wundervoll. Vielleicht gibt es hier eine Fluchtmöglichkeit.");
                    return "garden";
            }
            return "";
        }
    }
}