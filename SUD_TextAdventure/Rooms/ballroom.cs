using System;
using SUD_TextAdventure.Models;

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
                "\nWas willst du tun? \nUmsehen? \nZum Balkon? \nZurück in den Garten? \nZurück in den Flur?");
            String[] validInput = {"umsehen", "balkon", "garten", "flur"};
            string confirmation = _Program.CheckInput(validInput);

            switch (confirmation)
            {
                case "umsehen":
                    Console.WriteLine(
                        "Der ganze Raum ist voller Spiegel und Marmor. Doch was Dich wirklich interessiert sind die Ritterrüstungen. " +
                        "\n Möchtest Du dir diese genauer anschauen?");
                    String[] validInputConfirm = {"ja", "nein"};
                    String confirmationInputLadder = _Program.CheckInput(validInputConfirm);
                    if (confirmationInputLadder.Equals("ja"))
                    {
                        Console.WriteLine("Die eine Ritterrüstung fällt fast auseinander und Du entdeckst ein Schwert, das Dir auf Deiner Flucht vielleicht weiterhelfen wird!");
                        _Program.Character.Inventory.Add(new Item() {ItemName = "Schwert"});
                    }
                    break;
                case "balkon":
                    Console.WriteLine("Du gehst hinaus auf den Balkon. Du atmest die frische Luft ein.");
                    return "balcony";
                case "garten":
                    Console.WriteLine("Der Garten in den Du hineingehst ist wundervoll. Vielleicht gibt es hier eine Fluchtmöglichkeit.");
                    return "garden";
                case "flur":
                    Console.WriteLine("Du gehst wieder zurück durch die Tür in den Flur.");
                    return "corridorTwo";
            }
            return "";
        }
    }
}