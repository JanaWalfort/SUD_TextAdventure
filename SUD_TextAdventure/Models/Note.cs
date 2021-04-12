using System.Collections.Generic;

namespace SUD_TextAdventure.Models
{
    public class Note
    {
        public Note(string name ,string text)
        {
            Name = name;
            Text = text;
        }
        public string Name { get; set; }
        public string Text { get; set; }
        public int Room { get; set; }
    }

    public class Notes
    {
        public List<Note> List { get; set; }
    }
}