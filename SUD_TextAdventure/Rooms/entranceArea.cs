using System;

namespace SUD_TextAdventure.Rooms
{
    public class entranceArea
    {
        public Program _Program;

        public entranceArea(Program program)
        {
            _Program = program;
        }

        private bool _isDownstairs = false;

        public string run()
        {
            Console.WriteLine(
                "Du befindest Dich auf der oberen Ebene. Von der Decke hängt ein großer Kronleuchter und hinter dir hängen unzählige Gemälde, die längst verstorbebe Personen zeigen. \nWas willst Du tun? \nUmsehen? \nTreppe hinunter? \nZur Tür?");
            String[] validInput = {"umsehen", "tür", "treppe", "gemälde"};
            string confirmation = _Program.checkInput(validInput);

            switch (confirmation)
            {
                case "umsehen":
                    break;
                case "tür":
                    break;
                case "treppe":
                    Console.WriteLine(
                        "Du gehst die Treppe herunter.");
                    while (_isDownstairs)
                    {
                        Console.WriteLine(
                            "Von hier aus kannst Du zwei weitere Wege erkennen. Außerdem siehst Du die große Tür des Eingangsbereichs.\nUmsehen? \nZur Einganstür? \nZur linken Tür? \nZur rechten Tür? \nTreppe hinauf?");
                        validInput = new[] {"umsehen", "eingangstür", "link", "recht", "treppe"};
                        confirmation = _Program.checkInput(validInput);
                        switch (confirmation)
                        {
                            case "umsehen":
                                break;
                            case "eingangstür":
                                if (_Program._character.Inventory.Exists(x => x.ItemName == "schlüssel"))
                                {
                                    Console.WriteLine(
                                        "Du versuchst den Schlüssel ins Schloss zu stecken und Du kannst den Schlüssel im Schloss herumdrehen. Das Schloss klickt und Du schiebst die schwere Tür zur Seite\n Mit deiner neu gefundenen Freiheit rennst Du die Straße hinunter und findest eine Telefonzelle mit der Du die Polizei rufst. Herzlichen Glückwunsch, Du bist entkommen!");
                                }
                                else
                                {
                                    Console.WriteLine("Du drückst Dich gegen die Tür, aber sie bewegt sich kein Stück.");
                                }

                                break;
                            case "link":
                                break;
                            case "recht":
                                break;
                            case "treppe":
                                break;
                        }
                    }

                    break;
                case "gemälde":
                    break;
            }

            return "";
        }
    }
}