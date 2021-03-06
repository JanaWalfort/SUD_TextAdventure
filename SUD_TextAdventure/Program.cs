﻿using System;
using System.Collections.Generic;
using SUD_TextAdventure.Constants;
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

        public readonly Character Character = new Character();
        public bool GameFinished = false;
        public string Room = "bedroom";
        private bool _isDownstairs = false;
        public bool _isWindowBroken = false;

        public readonly Notes NotesList = new Notes();

        // TODO: Implement in all rooms tips, go back and things to find and put them in the inventar
        // TODO: Solve problem with go back, how do we know from where the person comes
        // ToDo: Add different text when an item was found
        public int RunProgram()
        {
            Character.CollectedNotes = new List<Note>();
            Character.Inventory = new List<Item>();
            distributeNotes();
            TypeWriter typewriter = new TypeWriter();
            Console.SetOut(typewriter);
            Console.WriteLine(
                "Du gehst gerade nach Hause, als du plötztlich von hinten einen Schlag auf den Kopf bekommst!" +
                "\nAls du wieder zu dir kommst, spürst du einen stechenden Schmerz an deinem Hinterkopf. Warte, wer warst Du noch einmal?");
            Character.Name = Console.ReadLine();
            Console.WriteLine($"Ach genau! Du bist {Character.Name}, richtig?");
            String[] validInput = {"nein", "ja"};
            string confirmation = CheckInput(validInput);
            if (confirmation.ToLower().Equals("nein"))
            {
                Console.WriteLine("Wie ist denn dann dein Name?");
                Character.Name = Console.ReadLine();
            }

            Console.WriteLine("Nach allem Anschein wurdest du entführt. Du solltest versuchen dich zu befreien!" +
                              "\nDu ertastest deine Umgebung und merkst, dass du auf einem Bett sitzt. Was willst Du tun?\nAufstehen?\nUmsehen?");


            validInput = new[] {"aufstehen", "umsehen"};
            confirmation = CheckInput(validInput);

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

            Character.Inventory.Add(new Item() {ItemName = "Kerze"});
            Console.WriteLine("\nDu zündest die Kerze an und kannst nun Deine Umgebung besser erkennen.");

            bool doorOpened = false;
            bool keyFound = false;
            while (doorOpened == false)
            {
                Console.WriteLine(
                    "Du siehst: Einen Schrank, ein Bett und eine Tür. Was willst Du Dir genauer ansehen?");
                validInput = new[] {"tür", "schrank", "bett"};
                confirmation = CheckInput(validInput);

                switch (confirmation)
                {
                    case "tür":
                        if (keyFound)
                        {
                            Console.WriteLine(
                                "Du gehst auf die Tür zu und versuchst die Tür mit dem Schlüssel zu öffnen. Der Schlüssel lässt sich im Schloss umdrehen und die Tür öffnet sich. \nDu gehst hindurch.");
                            doorOpened = true;
                            Room = "corridorOne";
                            break;
                        }

                        Console.WriteLine(
                            "Du gehst auf die Tür zu. Sie wirkt ziemlich alt.\nDu versuchst sie zu öffnen, aber sie bewegt sich keinen Zentimeter.");
                        break;
                    case "schrank":
                        if (Character.CollectedNotes.Exists(x => x.Room == (int) Types.NoteRoom.Bedroom)
                            && !NotesList.List.Exists(x => x.Room == (int) Types.NoteRoom.Bedroom))
                        {
                            Console.WriteLine(
                                "Der Schrank steht in der Ecke des Raums. So wie es aussieht, scheint nur unbrauchbares Zeug darin zu liegen.");
                        }
                        else
                        {
                            Console.WriteLine(
                                "Der Schrank steht in der Ecke des Raums. So wie es aussieht, scheint nur unbrauchbares Zeug darin zu liegen. \nWarte, was ist das?");
                            Character.CollectedNotes.Add(
                                NotesList.List.Find(x => x.Room == (int) Types.NoteRoom.Bedroom));
                            Console.WriteLine(
                                $"Du findest einen kleinen Zettel auf dem steht \'für {Character.Name}\'. Darunter steht noch \'{Character.CollectedNotes.Find(x => x.Room == (int) Types.NoteRoom.Bedroom)?.Text}\'");
                        }

                        break;
                    case "bett":
                        Console.WriteLine("Du schaust unters Bett und findest eine Schatulle. Willst Du sie öffnen? ");
                        validInput = new[] {"ja", "nein"};
                        confirmation = CheckInput(validInput);

                        if (confirmation.Equals("nein"))
                        {
                            Console.WriteLine("Bist Du Dir sicher?");
                            confirmation = CheckInput(validInput);
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

            while (!GameFinished)
            {
                switch (Room)
                {
                    case "bedroom":
                        while (Room == "bedroom")
                        {
                            string retval = new bedroom(this).run();
                            if (retval.Equals("corridorOne"))
                            {
                                Room = "corridorOne";
                            }
                        }

                        break;
                    case "corridorOne":
                        while (Room == "corridorOne")
                        {
                            string retval = new corridor1(this).run();
                            if (retval.Equals("attic"))
                            {
                                Room = "attic";
                            }
                            else if (retval.Equals("entranceArea"))
                            {
                                _isDownstairs = false;
                                Room = "entranceArea";
                            }
                            else if (retval.Equals("bedroom"))
                            {
                                Room = "bedroom";
                            }
                        }

                        break;
                    case "attic":
                        while (Room == "attic")
                        {
                            string retval = new attic(this).run();
                            if (retval.Equals("corridorOne"))
                            {
                                Room = "corridorOne";
                            }
                        }

                        break;
                    case "entranceArea":
                        string val = new entranceArea(this).run(_isDownstairs);
                        if (val.Equals("corridorOne"))
                        {
                            Room = "corridorOne";
                        }
                        else if (val.Equals("corridorTwo"))
                        {
                            Room = "corridorTwo";
                        }
                        else if (val.Equals("kitchen"))
                        {
                            Room = "kitchen";
                        }

                        break;
                    case "kitchen":
                        while (Room == "kitchen")
                        {
                            string retval = new kitchen(this).run();
                            if (retval.Equals("entranceArea"))
                            {
                                _isDownstairs = true;
                                Room = "entranceArea";
                            }
                            else if (retval.Equals("garden"))
                            {
                                Room = "garden";
                            }
                        }

                        break;
                    case "garden":
                        while (Room == "garden")
                        {
                            string retval = new garden(this).run();
                            if (retval.Equals("kitchen"))
                            {
                                Room = "kitchen";
                            }
                            else if (retval.Equals("ballroom"))
                            {
                                Room = "ballroom";
                            }
                        }

                        break;
                    case "ballroom":
                        while (Room == "ballroom")
                        {
                            string retval = new ballroom(this).run();
                            if (retval.Equals("corridorTwo"))
                            {
                                Room = "corridorTwo";
                            }
                            else if (retval.Equals("balcony"))
                            {
                                Room = "balcony";
                            }
                        }

                        break;
                    case "balcony":
                        while (Room == "balcony")
                        {
                            string retval = new balcony(this).run();
                            if (retval.Equals("ballroom"))
                            {
                                Room = "ballroom";
                            }
                        }

                        break;
                    case "corridorTwo":
                        while (Room == "corridorTwo")
                        {
                            string retval = new corrdidor2(this).run();
                            if (retval.Equals("entranceArea"))
                            {
                                _isDownstairs = true;
                                Room = "entranceArea";
                            }
                            else if (retval.Equals("library"))
                            {
                                Room = "library";
                            }
                            else if (retval.Equals("dungeon"))
                            {
                                Room = "dungeon";
                            }
                            else if (retval.Equals("corridorTwo"))
                            {
                                Room = "corridorTwo";
                            }
                        }

                        break;
                    case "library":
                        while (Room == "library")
                        {
                            string retval = new library(this).run();
                            if (retval.Equals("corridorTwo"))
                            {
                                Room = "corridorTwo";
                            }
                        }

                        break;
                    case "dungeon":
                        Console.WriteLine("Du gehst langsam die Treppe hinunter, die immer weiter nach unten führt.");
                        if (Character.Inventory.Exists(x => x.ItemName == "Taschenlampe"))
                        {
                            Console.WriteLine("Mit Deiner Taschanlampe in der Hand, kommst Du unten an.");
                        }
                        else
                        {
                            Console.WriteLine("Unten an der Treppe angekommen, kannst Du kaum noch etwas erkennen");
                        }

                        while (Room == "dungeon")
                        {
                            string retval = new dungeon(this).run();
                            if (retval.Equals("corridorTwo"))
                            {
                                Room = "corridorTwo";
                            }
                        }

                        break;
                    default:
                        return 1;
                }
            }

            return 1;
        }


        public string CheckInput(Array validInput)
        {
            var confirmed = false;
            while (confirmed == false)
            {
                var input = Console.ReadLine();
                foreach (var valid in validInput)
                {
                    if (input == null || !input.ToLower().Contains(valid.ToString()!)) continue;
                    confirmed = true;
                    Console.WriteLine("");
                    return valid.ToString();
                }

                Console.WriteLine("Bitte gebe eine gültige Eingabe ein.");
            }

            return "";
        }

        public int distributeNotes()
        {
            var tempList = new Notes();
            tempList.List = new List<Note>();
            NotesList.List = new List<Note>();

            NotesList.List.Add(new Note("key",
                "Es gibt so viele Geschichten auf der Welt, aber in nur einer versteck ich mich."));
            NotesList.List[0].Room = new Random().Next(1, 11);

            tempList.List.Add(new Note("flashlight",
                "Wenn ich richtig überlege – gehen Menschen krumme Wege. Nur das Licht im Treppenhaus, das geht immer grade aus. (~ Erhard Horst Bellermann)"));

            tempList.List.Add(new Note("secretDoor",
                "Hast Du den Beistand der Maus, des Adlers und des Bären, ist am dunkelsten Ort Dein Ziel ganz nah."));

            tempList.List.Add(new Note("crowbar",
                "Am schönsten Ort versteck ich mich. Ich bin frei, aber auch eingesperrt. Hilf mir, so helfe ich dir."));

            tempList.List.Add(new Note("stones",
                "Der Bär hält seinen Winterschlaf östlich von hier. Der Adler fliegt in den Süden, wenn Drohung wittert. Die Maus versteckt ihren Käse vor der Katze in der nördlichsten Ecke"));

            tempList.List.Add(new Note("rope",
                "Im längsten Tunnel findest Du das silberne Seil, um aus dieser Hölle zu entkommen."));


            foreach (var note in tempList.List)
            {
                Random number = new Random();

                bool isUsed = true;
                bool isEqual = false;
                while (isUsed)
                {
                    note.Room = number.Next(1, 11);
                    isEqual = false;
                    foreach (var checkNote in NotesList.List)
                    {
                        if (note.Room == checkNote.Room)
                        {
                            isEqual = true;
                        }
                    }

                    if (!isEqual)
                    {
                        isUsed = false;
                        NotesList.List.Add(note);
                    }
                }
            }

            return 1;
        }
    }
}