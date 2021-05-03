using System;

namespace SUD_TextAdventure.Rooms
{
    public class balcony
    {
        public Program _Program;

        public balcony(Program program)
        {
            _Program = program;
        }


        public string run()
        {
            Console.WriteLine("Leider ist es hier zu hoch, um hinuter zu klettern." +
                              "\nWas willst Du tun? \nUmsehen? \nZurück");
            String[] validInput = {"umsehen", "zurück"};
            string confirmation = _Program.CheckInput(validInput);

            switch (confirmation)
            {
                case "umsehen":
                    if (_Program.Character.Inventory.Exists(x => x.ItemName == "Seil"))
                    {
                        Console.WriteLine("Um hinunuter zu klettern könntest Du das Seil an dem Geländer festbinden. Möchtest Du das versuchen?");
                        validInput = new[] {"ja", "nein"}; 
                        confirmation = _Program.CheckInput(validInput);
                        if (confirmation.Equals("ja"))
                        {
                            Console.WriteLine("Du machst das Seil fest und kletterst vorsichtig herunter. Unten angekommen rennst Du zur Straße und endeckst eine Telefonzelle." +
                                              "Du rufst die Polizei und bist entkommen. Herzlichen Glückwunsch!");
                            _Program.GameFinished = true;
                        }
                        else
                        {
                            Console.WriteLine("Es ist doch sehr hoch oder? Vielleicht gehst Du zurück und versuchst einen anderen Weg.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Du blickst über grüne Wälder. Eigentlich ist es hier ein sehr schöner Ort.");
                    }
                    break;
                case "zurück":
                    Console.WriteLine("Dir ist kalt geworden und Du gehst zurück in den Ballsaal, um Dich aufzuwärmen.");
                    return "ballroom";
            }
            return "";
        }
    }
}