using System;
using System.IO;
using System.Text;
using System.Threading;

namespace SUD_TextAdventure
{
    class TypeWriter : System.IO.TextWriter
    {
        private TextWriter originalOut;

        public TypeWriter()
        {
            originalOut = Console.Out;
        }

        public override void WriteLine(string message)
        {
            foreach (char c in message)
            {
                originalOut.Write(c);

                if (!Console.KeyAvailable)
                {
                    Thread.Sleep(25);
                }
            }

            if (Console.KeyAvailable)
            {
                Console.ReadKey();
            }

            Animate();

            if (Console.KeyAvailable)
            {
                Console.ReadKey();
            }

            originalOut.WriteLine();
        }

        private void Animate()
        {
            Console.CursorVisible = false;

            /*
            for (int i = 0; i < 3; i++)
            {
                originalOut.Write(@"-");
                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                if (AnimationInterrupted()) break;
                originalOut.Write(@"\");
                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                if (AnimationInterrupted()) break;
                originalOut.Write(@"|");
                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                if (AnimationInterrupted()) break;
                originalOut.Write(@"/");
                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                if (AnimationInterrupted()) break;
            }
            */

            originalOut.Write(" ");
            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);

            Console.CursorVisible = true;
        }

        private bool AnimationInterrupted()
        {
            if (!Console.KeyAvailable)
            {
                Thread.Sleep(50);
                return false;
            }
            else
            {
                originalOut.Write(" ");
                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                return true;
            }
        }

        public override Encoding Encoding
        {
            get { return Encoding.Default; }
        }
    }
}


// Source: https://gist.github.com/joshschmelzle/610451c749dd14bb777a