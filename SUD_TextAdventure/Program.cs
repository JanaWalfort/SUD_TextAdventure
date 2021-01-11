using System;

namespace SUD_TextAdventure
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Du gehst gerade nach Hause, als du plötztlich von hinten einen Schlag auf den Kopf bekommst!" +
                              "\nAls du wieder zu dir kommst, spürst du einen stechenden Schmerz an deinem Hintekopf. Warte wer warst Du noch einmal?");
            string char_name = Console.ReadLine();
            Console.WriteLine($"Ach genau! Du bist {char_name}, richtig?");
            string confirmation = Console.ReadLine();
            if (confirmation.ToLower().Equals("ja"))
            {
                Console.WriteLine("Nach allem anschein wurdest du entführt. Du solltest versuchen dich zu befreien!" +
                                  "\nDu ertastest deine Umgebung und merkst, dass du auf einem Bett sitzt. Was willst du tun?\nAufstehen?\nUmsehen?");
                confirmation = Console.ReadLine();
                if (confirmation.ToLower().Equals("aufstehen"))
                {
                    Console.WriteLine("Du tastest Dich weiter und erfühlst einen Lichtschalter!");
                    
                }

            }
            Console.WriteLine("");
        }
    }
}


/*
 * Man geht nach Hause und wird entführt 

Wacht in einem dunklen Raum auf 

“Ich glaube ich wurde entführt!” 

Du ertastest deine Umgebung und merkst, dass du auf einem Bett sitzt. 

-> aufstehen 

Du tastest Dich weiter und erfühlst einen Lichtschalter! 

-> Licht an machen. 

Da das Licht nun an ist kannst du deine Umgebung klar sehen. Du siehst: Einen Schrank, ein Bett und eine Tür. 

-> Unters Bett schauen / Tür / Schrank 

Du schaust unters Bett und findest eine Schatulle. Willst Du sie öffnen? 

-> Ja / Nein 

Du öffnest die Schatulle, in der sich ein Schlüssel befindet. Wofür könnte dieser sein? 

-> Tür öffnen 

Du versuchst die Tür zu öffnen, aber sie ist verschlossen. 

-> Schlüssel benutzen 

Die Tür öffnet sich, und du gehst hindurch. 

Du befindest dich in einem Flur. Du kannst am Ende des Flurs eine weitere Tür sehen. Außerdem scheint es hier auch eine Leiter nach oben zu geben. 
*/