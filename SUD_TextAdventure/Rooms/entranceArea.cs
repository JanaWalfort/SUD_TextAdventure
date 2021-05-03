using System;
using SUD_TextAdventure.Models;

namespace SUD_TextAdventure.Rooms
{
    public class entranceArea
    {
        public Program _Program;

        public entranceArea(Program program)
        {
            _Program = program;
        }

        public string run(bool isDownstairs)
        {
            while (_Program.Room == "entranceArea")
            {
                if (isDownstairs)
                {
                    while (isDownstairs)
                    {
                        Console.WriteLine(
                            "Von hier aus kannst Du zwei weitere Wege erkennen. Außerdem siehst Du die große Tür des Eingangsbereichs." +
                            "\nUmsehen? \nZur Einganstür? \nZur linken Tür? \nZur rechten Tür? \nTreppe hinauf?");
                        String[] validInput = {"umsehen", "eingangstür", "link", "recht", "treppe"};
                        string confirmation = _Program.CheckInput(validInput);
                        switch (confirmation)
                        {
                            case "umsehen":
                                Console.WriteLine("Über Dir schwebt ominös der Kronleuchter. Dir gegenüber liegt eine große, robuste Tür. Du kannst ausgefallene und seltsame Schnitzereien an ihr erkennen.");
                                break;
                            case "eingangstür":
                                if (_Program.Character.Inventory.Exists(x => x.ItemName == "Schlüssel"))
                                {
                                    Console.WriteLine(
                                        "Du versuchst den Schlüssel ins Schloss zu stecken und kannst den Schlüssel im Schloss herumdrehen. Das Schloss klickt und Du schiebst die schwere Tür zur Seite." +
                                        "\nMit deiner neu gefundenen Freiheit rennst Du die Straße hinunter und findest eine Telefonzelle mit der Du die Polizei rufst. Herzlichen Glückwunsch, Du bist entkommen!");
                                    _Program.GameFinished = true;
                                }
                                else
                                {
                                    Console.WriteLine(
                                        "Du drückst Dich gegen die Tür, aber sie bewegt sich kein bisschen.");
                                }

                                break;
                            case "link":
                                Console.WriteLine("Du öffnest die Tür und gehst hindurch in einen Flur.");
                                return "corridorTwo";
                            case "recht":
                                Console.WriteLine("Du gehst auf die Tür zu und öffnest sie. Was duftet denn da so?");
                                return "kitchen";
                            case "treppe":
                                Console.WriteLine("Du gehst die Treppe hoch.");
                                isDownstairs = false;
                                break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine(
                        "Du befindest Dich auf der oberen Ebene. Von der Decke hängt ein großer Kronleuchter und hinter Dir hängen unzählige Gemälde, die längst verstorbene Personen zeigen." +
                        "\nWas willst Du tun? \nUmsehen? \nTreppe hinunter? \nZur Tür?");
                    String[] validInput = {"umsehen", "tür", "treppe", "gemälde"};
                    string confirmation = _Program.CheckInput(validInput);

                    switch (confirmation)
                    {
                        case "umsehen":
                            Console.WriteLine(
                                "Du schaust Dich ein bisschen um. Was ist das? Unter Deinem rechten Fuß wackelt eine Fliese. Willst Du Dir das genauer anschauen?");
                            validInput = new[] {"ja", "nein"};
                            confirmation = _Program.CheckInput(validInput);
                            if (confirmation.Equals("ja") && !_Program.Character.Inventory.Exists(x => x.ItemName == "Taschenlampe"))
                            {
                                Console.WriteLine(
                                    "Du hebst die Fliese hoch und entdeckst eine Taschenlampe. Sie wird bestimmt nützlich sein und Du packst sie ein.");
                                _Program.Character.Inventory.Add(new Item() {ItemName = "Taschenlampe"});
                            }
                            else
                            {
                                Console.WriteLine("Sonst gibt es hier nichts weiter zu sehen.");
                            }

                            break;
                        case "tür":
                            Console.WriteLine("Du gehst durch die Tür hindurch.");
                            return "corridorOne";
                        case "treppe":
                            Console.WriteLine(
                                "Du gehst die Treppe herunter.");
                            isDownstairs = true;
                            break;
                        case "gemälde":
                            Console.WriteLine("Du schaust Dir die Gemälde etwas genauer an. Sie sehen sehr alt aus. Haben sie hier vielleicht mal gelebt?"); //ToDo: Tipp verstecken
                            break;
                    }
                }
            }
            return "1";
        }
    }
}