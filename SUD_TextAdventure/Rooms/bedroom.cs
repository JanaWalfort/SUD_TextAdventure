using System;

namespace SUD_TextAdventure.Rooms
{
    public class bedroom
    {
        public Program _Program;

        public bedroom(Program program)
        {
            _Program = program;
        }

        public string run()
        {
            Console.WriteLine("Hello");
            Console.Read();
            return "";
        }
    }
}