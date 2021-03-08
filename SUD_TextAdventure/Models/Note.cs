using System.Collections.Generic;

namespace SUD_TextAdventure.Models
{
    public class Note
    {
        public Note(string text)
        {
            text = Text;
        }
        public string Text { get; set; }
        public int Room { get; set; }
    }

    public class Notes
    {
        public List<Note> List { get; set; }
    }
}