using System;
using SUD_TextAdventure.Models;

namespace SUD_TextAdventure.Rooms
{
    public class garden
    {
        public Program _Program;

        public garden(Program program)
        {
            _Program = program;
        }


        public string run()
        {

            Console.WriteLine(
                "Du kommst Dir vor als wärst Du im Paradies. Überall Blumen in vollster Pracht und in der Mitte steht ein wunderschöner Pavillion. " +
                "Auf der anderen Seite siehst Du Licht schimmern. Leider ist der Garten von einem hohen Zaun umgeben." +
                "\nWas willst du tun? \nUmsehen? \nZum Pavillion? \nZum Licht? \nZurück?");
            String[] validInput = {"umsehen", "pavillion", "licht", "zurück"};
            string confirmation = _Program.CheckInput(validInput);

            switch (confirmation)
            {
                case "umsehen":
                    Console.WriteLine(
                        "Langsam gehst Du durch den Garten und nimmst alles in Dich auf. Du fragst Dich wer wohl diesen schönen Garten angelgt hat. " +
                        "\nEin alter Graf vielleicht? Fast vergisst Du, dass Du entführt wurdest.");
                    break;
                case "pavillion":
                    Console.WriteLine(
                        "Am Pavillion angekommen, kannst Du über den ganzen Garten schauen. Wunderschön! Aber was ist das für eine Kiste? " +
                        "\nMöchtest Du sie öffnen?");
                    String[] validInputConfirm = {"ja", "nein"};
                    String confirmationInputLadder = _Program.CheckInput(validInputConfirm);
                    if (confirmationInputLadder.Equals("ja"))
                    {
                        Console.WriteLine("Du öffnest die Kiste und findest eine Brechstange, die Du in Deine Tasche steckt. Sie wird Dir bestimmt noch nützlich sein.");
                        _Program.Character.Inventory.Add(new Item() {ItemName = "Brechstange"});
                    }
                    break;
                case "licht":
                    Console.WriteLine("Am anderen Ende angekommen, findest Du vor dir eine riesige Glasfront. Möchtest Du durch die Tür hindurch gehen?");
                    String[] validInputLadder = {"ja", "nein"};
                    String confirmationLadder = _Program.CheckInput(validInputLadder);
                    if (confirmationLadder.Equals("ja"))
                    {
                        return "ballroom";
                    }
                    break;
                case "zurück":
                    Console.WriteLine("Du gehst zurück in die Küche. Du denkst nicht, dass Du hier im Garten weiterkommst.");
                    return "kitchen";
            }
            return "";
        }
    }
}