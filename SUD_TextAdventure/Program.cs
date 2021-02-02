using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SUD_TextAdventure.Models;
using SUD_TextAdventure.Rooms;

namespace SUD_TextAdventure 
{
    public class Program 
    {
        static void Main(string[] args) 
        { 
            Program mainView = new Program(); 
            mainView.RunProgram(); 
        } 
 
        private readonly Character _character = new Character();
        private bool _gameFinished = false; 
        private String _room = "bedroom"; 
        private bool _bedroom = true; 
        private bool _corridorOne = false; 
        private bool _attic = false; 
        private bool _entranceArea = false; 
        private bool _kitchen = false; 
        private bool _garden = false; 
        private bool _ballroom = false; 
        private bool _balcony = false; 
        private bool _corridorTwo = false; 
        private bool _library = false; 
        private bool _dungeon = false;
        public int RunProgram()
        {
            _character.Inventory = new List<Item>();
            
            Console.WriteLine( 
                "Du gehst gerade nach Hause, als du plötztlich von hinten einen Schlag auf den Kopf bekommst!" + 
                "\nAls du wieder zu dir kommst, spürst du einen stechenden Schmerz an deinem Hintekopf. Warte wer warst Du noch einmal?"); 
            _character.Name = Console.ReadLine(); 
            Console.WriteLine($"Ach genau! Du bist {_character.Name}, richtig?"); 
            String[] validInput = {"nein", "ja"}; 
            string confirmation = checkInput(validInput); 
            if (confirmation.ToLower().Equals("nein")) 
            { 
                Console.WriteLine("Wie ist denn dann dein Name?"); 
                _character.Name = Console.ReadLine(); 
            } 
 
            Console.WriteLine("Nach allem Anschein wurdest du entführt. Du solltest versuchen dich zu befreien!" + 
                              "\nDu ertastest deine Umgebung und merkst, dass du auf einem Bett sitzt. Was willst du tun?\nAufstehen?\nUmsehen?"); 
 
 
            validInput = new[] {"aufstehen", "umsehen"}; 
            confirmation = checkInput(validInput); 
 
            if (confirmation.Equals("umsehen")) 
            { 
                Console.WriteLine( 
                    "Du kannst nicht viel sehen. Das Einzige, dass Du erkennen kannst sind die Umrisse des Betts. Du vesuchst aufzustehen."); 
                Console.WriteLine("Du tastest Dich weiter und erfühlst eine Kerze mit Streichhölzern!");
                _character.Inventory.Add(new Item() {ItemName = "Kerze"});
                // if (_character.Inventory.Exists(x => x.ItemName == "Kerze"))
                // {
                    // Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                // }
            } 
 
            if (confirmation.ToLower().Equals("aufstehen")) 
            { 
                Console.WriteLine("Du tastest Dich weiter und erfühlst einen Lichtschalter!"); 
            } 
 
            Console.WriteLine("\nDer Raum ist nun hell erleuchtet."); 
 
            bool doorOpened = false; 
            bool keyFound = false; 
            while (doorOpened == false) 
            { 
                Console.WriteLine( 
                    "Du siehst: Einen Schrank, ein Bett und eine Tür. Was willst Du Dir genauer ansehen?"); 
                validInput = new[] {"tür", "schrank", "bett"}; 
                confirmation = checkInput(validInput); 
 
                switch (confirmation) 
                { 
                    case "tür": 
                        if (keyFound) 
                        { 
                            Console.WriteLine( 
                                "Du gehst auf die Tür zu und versuchst die Tür mit dem Schlüssel zu öffnen. Der Schlüssel lässt sich im Schloss drehen und die Tür öffnet sich. \nDu gehst hindurch."); 
                            doorOpened = true; 
                            _room = "corridorOne"; 
                            break; 
                        } 
 
                        Console.WriteLine( 
                            "Du gehst auf die Tür zu. Sie wirkt ziemlich alt.\nDu versuchst sie zu öffnen, aber sie bewegt siche keinen Zentimeter."); 
                        break; 
                    case "schrank": 
                        Console.WriteLine( 
                            "Der Schrank steht in der Ecke des Raums. So wie es aus sieht, scheint nur unbrauchbares Zeug darin zu liegen."); 
                        break; 
                    case "bett": 
                        Console.WriteLine("Du schaust unters Bett und findest eine Schatulle. Willst Du sie öffnen? "); 
                        validInput = new[] {"ja", "nein"}; 
                        confirmation = checkInput(validInput); 
 
                        if (confirmation.Equals("nein")) 
                        { 
                            Console.WriteLine("Bist Du Dir sicher?"); 
                            confirmation = checkInput(validInput); 
                            if (confirmation.Equals("ja")) 
                            { 
                                break; 
                            } 
                        } 
 
                        Console.WriteLine( 
                            "Du öffnest die Schatulle, in der sich ein Schlüssel befindet. Wofür könnte dieser sein? "); 
                        keyFound = true; 
                        break; 
                } 
            } 
 
            while (!_gameFinished) 
            { 
                switch (_room)
                { 
                    case "bedroom":
                        new bedroom().run();
                        break; 
                    case "corridorOne": 
                        while (_room == "corridorOne")
                        {
                            string retval = new corridor1().run();
                            if (retval.Equals("attic"))
                            {
                                _attic = true;
                                _corridorOne = false;
                            }
                            else if (retval.Equals("entranceArea"))
                            {
                                _entranceArea = true;
                                _corridorOne = false;
                            }
                        } 
                        break; 
                    case "attic":
                        new attic().run();
                        break; 
                    case "entranceArea":
                        new entranceArea().run();
                        break; 
                    case "kitchen":
                        new kitchen().run();
                        break; 
                    case "garden":
                        new garden().run();
                        break; 
                    case "ballroom":
                        new ballroom().run();
                        break; 
                    case "balcony":
                        new balcony().run();
                        break; 
                    case "corridorTwo":
                        new corrdidor2().run();
                        break; 
                    case "library":
                        new library().run();
                        break; 
                    case "dungeon":
                        new dungeon().run();
                        break; 
                    default: 
                        return 1; 
                } 
            } 
            return 1; 
        } 
 
 
        public string checkInput(Array validInput)
        { 
            bool confirmed = false; 
            while (confirmed == false) 
            { 
                string input = Console.ReadLine(); 
                foreach (var valid in validInput) 
                { 
                    if (input.ToLower().Equals(valid)) 
                    { 
                        confirmed = true; 
                        Console.WriteLine(""); 
                        return valid.ToString(); 
                    } 
                } 
 
                Console.WriteLine("Bitte gebe eine gültige Eingabe ein."); 
            } 
 
            return ""; 
        } 
    } 
} 

 