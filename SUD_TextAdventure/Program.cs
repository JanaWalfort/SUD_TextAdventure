using System; 
using System.Linq.Expressions; 
 
namespace SUD_TextAdventure 
{ 
    class Program 
    { 
        static void Main(string[] args) 
        { 
            Program mainView = new Program(); 
            mainView.RunProgram(); 
        } 
 
        private String _charName = ""; 
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
        // Hallo 
 
        public int RunProgram() 
        { 
            Console.WriteLine( 
                "Du gehst gerade nach Hause, als du plötztlich von hinten einen Schlag auf den Kopf bekommst!" + 
                "\nAls du wieder zu dir kommst, spürst du einen stechenden Schmerz an deinem Hintekopf. Warte wer warst Du noch einmal?"); 
            _charName = Console.ReadLine(); 
            Console.WriteLine($"Ach genau! Du bist {_charName}, richtig?"); 
            String[] validInput = {"nein", "ja"}; 
            string confirmation = checkInput(validInput); 
            if (confirmation.ToLower().Equals("nein")) 
            { 
                Console.WriteLine("Wie ist denn dann dein Name?"); 
                _charName = Console.ReadLine(); 
            } 
 
            Console.WriteLine("Nach allem Anschein wurdest du entführt. Du solltest versuchen dich zu befreien!" + 
                              "\nDu ertastest deine Umgebung und merkst, dass du auf einem Bett sitzt. Was willst du tun?\nAufstehen?\nUmsehen?"); 
 
 
            validInput = new[] {"aufstehen", "umsehen"}; 
            confirmation = checkInput(validInput); 
 
            if (confirmation.Equals("umsehen")) 
            { 
                Console.WriteLine( 
                    "Du kannst nicht viel sehen. Das Einzige, dass Du erkennen kannst sind die Umrisse des Betts. Du vesuchst aufzustehen."); 
                Console.WriteLine("Du tastest Dich weiter und erfühlst einen Lichtschalter!"); 
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
                        break; 
                    case "corridorOne": 
                        while (_room == "corridorOne") 
                        { 
                            Console.WriteLine( 
                                "Du befindest dich in einem Flur. Du kannst am Ende des Flurs eine weitere Tür sehen. Außerdem scheint es hier auch eine Leiter nach oben zu geben." + 
                                "\nWas willst du tun? \nUmsehen? \nZur Tür? \nZur Leiter? "); 
                            validInput = new[] {"umsehen", "zur tür", "zur leiter"}; 
                            confirmation = checkInput(validInput); 
 
                            switch (confirmation) 
                            { 
                                case "umsehen": 
                                    Console.WriteLine( 
                                        "Du siehst dich um und es scheint, dass lange niemand mehr da gewesen ist. \nAn der Wand steht ein Regal mit verstaubten Porzellan und an der Decke hängen Spinnenweben."); 
                                    break; 
                                case "zur tür": 
                                    Console.WriteLine("Du gehst den Flur bis zur Tür entlang. Du öffnest sie und siehst wie eine Treppe hinunterführt."); 
                                    _room = "entranceArea"; 
                                    break; 
                                case "zur leiter": 
                                    Console.WriteLine("Du stehst vor der Leiter. Möchtest du sie hoch klettern?"); 
                                    String[] validInputLadder = {"ja", "nein"}; 
                                    String confirmationLadder = checkInput(validInputLadder); 
                                    if (confirmationLadder.Equals("ja")) 
                                    { 
                                        Console.WriteLine("Du kletterst die Leiter hoch und öffnest die Luke zum Dachboden."); 
                                        _room = "attic"; 
                                    } 
                                    break; 
                                default: 
                                    break; 
                            } 
                        } 
                        break; 
                    case "attic": 
                        break; 
                    case "entranceArea": 
                        break; 
                    case "kitchen": 
                        break; 
                    case "garden": 
                        break; 
                    case "ballroom": 
                        break; 
                    case "balcony": 
                        break; 
                    case "corridorTwo": 
                        break; 
                    case "library": 
                        break; 
                    case "dungeon": 
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

 