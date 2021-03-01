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
 
        public readonly Character _character = new Character();
        public bool _gameFinished = false;
        private String _room = "bedroom";

        public String noteKey = "";
        
        
        public int RunProgram()
        {
            _character.Inventory = new List<Item>();
            
            Console.WriteLine( 
                "Du gehst gerade nach Hause, als du plötztlich von hinten einen Schlag auf den Kopf bekommst!" + 
                "\nAls du wieder zu dir kommst, spürst du einen stechenden Schmerz an deinem Hinterkopf. Warte, wer warst Du noch einmal?"); 
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
                    "Du kannst nicht viel sehen. Das Einzige, das Du erkennen kannst, sind die Umrisse des Betts. Du versuchst aufzustehen."); 
                Console.WriteLine("Du tastest Dich weiter und erfühlst eine Kerze und Streichhölzer!");
                // if (_character.Inventory.Exists(x => x.ItemName == "Kerze"))
                // {
                    // Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                // }
            } 
 
            if (confirmation.ToLower().Equals("aufstehen")) 
            { 
                Console.WriteLine("Du tastest Dich weiter und erfühlst eine Kerze und Streichhölzer!"); 
            }
            
            _character.Inventory.Add(new Item() {ItemName = "Kerze"});
            Console.WriteLine("\nDu zündest die Kerze an und kannst nun Deine Umgebung besser erkennen.");
 
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
                                "Du gehst auf die Tür zu und versuchst die Tür mit dem Schlüssel zu öffnen. Der Schlüssel lässt sich im Schloss umdrehen und die Tür öffnet sich. \nDu gehst hindurch."); 
                            doorOpened = true; 
                            _room = "corridorOne"; 
                            break; 
                        } 
 
                        Console.WriteLine( 
                            "Du gehst auf die Tür zu. Sie wirkt ziemlich alt.\nDu versuchst sie zu öffnen, aber sie bewegt sich keinen Zentimeter."); 
                        break; 
                    case "schrank": 
                        Console.WriteLine( 
                            "Der Schrank steht in der Ecke des Raums. So wie es aussieht, scheint nur unbrauchbares Zeug darin zu liegen."); 
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
                        while (_room == "bedroom")
                        {
                            string retval = new bedroom(this).run();
                            if (retval.Equals(""))
                            {
                                _room = "";
                            }
                        }
                        
                        break; 
                    case "corridorOne": 
                        while (_room == "corridorOne")
                        {
                            string retval = new corridor1(this).run();
                            if (retval.Equals("attic"))
                            {
                                _room = "attic";
                            }
                            else if (retval.Equals("entranceArea"))
                            {
                                _room = "entranceArea";
                            }
                        } 
                        break; 
                    case "attic":
                        while (_room == "attic")
                        {
                            string retval = new attic(this).run();
                            if (retval.Equals("corridorOne"))
                            {
                                _room = "corridorOne";
                            }
                        }
                        break; 
                    case "entranceArea":
                        while (_room == "entranceArea")
                        {
                            string retval = new entranceArea(this).run();
                            if (retval.Equals(""))
                            {
                                _room = "";
                            }
                        }
                        
                        break; 
                    case "kitchen":
                        while (_room == "kitchen")
                        {
                            string retval = new kitchen(this).run();
                            if (retval.Equals(""))
                            {
                                _room = "";
                            }
                        }
                        
                        break; 
                    case "garden":
                        while (_room == "garden")
                        {
                            string retval = new garden(this).run();
                            if (retval.Equals(""))
                            {
                                _room = "";
                            }
                        }
                        
                        break; 
                    case "ballroom":
                        while (_room == "ballroom")
                        {
                            string retval = new ballroom(this).run();
                            if (retval.Equals(""))
                            {
                                _room = "";
                            }
                        }
                        
                        break; 
                    case "balcony":
                        while (_room == "balcony")
                        {
                            string retval = new balcony(this).run();
                            if (retval.Equals(""))
                            {
                                _room = "";
                            }
                        }
                        
                        break; 
                    case "corridorTwo":
                        while (_room == "corridorTwo")
                        {
                            string retval = new corrdidor2(this).run();
                            if (retval.Equals(""))
                            {
                                _room = "";
                            }
                        }
                        
                        break; 
                    case "library":
                        while (_room == "library")
                        {
                            string retval = new library(this).run();
                            if (retval.Equals(""))
                            {
                                _room = "";
                            }
                        }
                        
                        break; 
                    case "dungeon":
                        while (_room == "dungeon")
                        {
                            string retval = new dungeon(this).run();
                            if (retval.Equals(""))
                            {
                                _room = "";
                            }
                        }
                        
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
                    if (input.ToLower().Contains(valid.ToString())) 
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

 