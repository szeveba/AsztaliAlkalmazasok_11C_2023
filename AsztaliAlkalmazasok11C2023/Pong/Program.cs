using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace Pong
{
    /// <summary>
    /// Konzol bemenetet rögzíti blokkolás nélkül.
    /// </summary>
    static class Keylogger
    {
        private static bool running = false;
        private static Queue<ConsoleKey> keys = new Queue<ConsoleKey>();
        /// <summary>
        /// Jelenlegi leütött konzol billentyű, vagy null;
        /// </summary>
        public static ConsoleKey? CurrentKey { get; set; }
        /// <summary>
        /// Elindítja a billentyű leütések rögzítését.
        /// </summary>
        public static void StartLogging()
        {
            running = true;
            Task.Run(() =>
            {
                while (running) keys.Enqueue(Console.ReadKey(true).Key);
            });
        }
        /// <summary>
        /// A CurrentKey tulajdonság értékét átállítja a következő leütött karakterre, vagy nullra, ha nincs következő.
        /// </summary>
        /// <returns>Volt e következő karakter?</returns>
        public static bool NextKey()
        {
            if (keys.TryDequeue(out ConsoleKey op))
            {
                CurrentKey = op;
                return true;
            }
            else
            {
                CurrentKey = null;
                return false;
            }
        }
        /// <summary>
        /// Leállítja a bemenet rögzítését.
        /// </summary>
        public static void StopLogging()
        {
            running = false;
        }
    }
    internal class Program
    {
        
        static void DrawBall(int x, int y)
        {
            if (0 <= x && x < Console.WindowWidth && 0 <= y && y < Console.WindowHeight)
            {
                Console.SetCursorPosition(x, y);
                Console.CursorVisible = false;
                Console.Write('█');
            }
        }

        static int playerSize = 3;
        static char playerChar = '█';
        static int playerEdgeDistance = 3;
        static int playerAYPos = 3;
        static int playerBYPos = 3;

        static void Pong()
        {
            
            bool w = false;
            bool s = false;
            bool up = false;
            bool down = false;
            for (int i = 0; i < playerEdgeDistance; i++)
            {
                Console.SetCursorPosition(playerEdgeDistance, playerAYPos + i);
                Console.Write(playerChar);
                Console.SetCursorPosition(Console.WindowWidth - playerEdgeDistance, playerBYPos + i);
                Console.Write(playerChar);
            }

            Keylogger.StartLogging();
            while (true)
            {
                w = false;
                s = false;
                up = false;
                down = false;
                while (Keylogger.NextKey())
                {
                    switch (Keylogger.CurrentKey)
                    {
                        case ConsoleKey.W:
                            w = true;
                            s = false;
                            break;
                        case ConsoleKey.S:
                            s = true;
                            w = false;
                            break;
                        case ConsoleKey.UpArrow:
                            up = true;
                            down = false;
                            break;
                        case ConsoleKey.DownArrow:
                            down = true;
                            up = false;
                            break;
                        default:
                            break;
                    }
                }
                if (w)
                {
                    if (0 < playerAYPos)
                    {
                        Console.SetCursorPosition(playerEdgeDistance, playerAYPos + playerSize - 1);
                        Console.Write(' ');
                        playerAYPos--;
                        Console.SetCursorPosition(playerEdgeDistance, playerAYPos);
                        Console.Write(playerChar);
                    }
                }
                else if (s)
                {
                    if (playerAYPos < Console.WindowHeight - playerSize)
                    {
                        Console.SetCursorPosition(playerEdgeDistance, playerAYPos);
                        Console.Write(' ');
                        playerAYPos++;
                        Console.SetCursorPosition(playerEdgeDistance, playerAYPos + playerSize - 1);
                        Console.Write(playerChar);
                    }
                }
                if (up)
                {
                    if (0 < playerBYPos)
                    {
                        Console.SetCursorPosition(Console.WindowWidth - playerEdgeDistance, playerBYPos + playerSize - 1);
                        Console.Write(' ');
                        playerBYPos--;
                        Console.SetCursorPosition(Console.WindowWidth - playerEdgeDistance, playerBYPos);
                        Console.Write(playerChar);
                    }
                }
                else if (down)
                {
                    if (playerBYPos < Console.WindowHeight - playerSize)
                    {
                        Console.SetCursorPosition(Console.WindowWidth - playerEdgeDistance, playerBYPos);
                        Console.Write(' ');
                        playerBYPos++;
                        Console.SetCursorPosition(Console.WindowWidth - playerEdgeDistance, playerBYPos + playerSize - 1);
                        Console.Write(playerChar);
                    }
                }

                Console.CursorVisible = false;
                Thread.Sleep(33);
            }

        }
        static bool reading = true;
        static List<ConsoleKey> keys = new List<ConsoleKey>();
        static void Read()
        {
           
        }
        static bool up;
        static bool down;
        static void Pelda()
        {
            
            Task t = Task.Run(() =>
            {
                Console.WriteLine("READING STARTED");
                while (reading)
                {
                    keys.Add(Console.ReadKey(true).Key);
                }
            });
            Console.CursorVisible = false;
            while (true)
            {
                up = keys.Contains(ConsoleKey.UpArrow);
                down = keys.Contains(ConsoleKey.DownArrow);
                keys.Clear();
                Console.Write(up + " " + down + "                           \r");
                Thread.Sleep(60);
            }
            reading = false;
        }

        static void Main(string[] args)
        {
            Pelda();
            return;
            Pong();
            return;
            var q = (x: 0, y: 0);
            List<(int x, int y)> a = new List<(int x, int y)>();
            a.Add((2, 6)); //elem hozzáadása
            a.RemoveAt(0); //első elem törlése
            a.RemoveAt(a.Count - 1); //utolsó elem törlése
            var listaElemszám = a.Count; // lista méretének lekérdezése;

            Queue<(int x, int y)> sor = new Queue<(int x, int y)>();
            sor.Enqueue((2, 3));
            (int x, int y) kivettElem = sor.Dequeue();

            (int x, int y)[] tömb = new (int x, int y)[10];
            //tömb[0] tömb[tömb.Length-1]
            // méret: tömb.Length
            int[,] aa = new int[10, 5];
            int[,,,] aaa = new int[3, 3, 3, 3];

            //kódformázás Ctrl + K,D          
            char ball = '█';
            int x = 0;
            int y = 0;
            Console.Write(ball);
            while (true)
            {
                var c = Console.ReadKey(true).Key;
                if (c == ConsoleKey.UpArrow)
                {

                }
                else if (c == ConsoleKey.DownArrow)
                {

                }
                else if (c == ConsoleKey.LeftArrow)
                {

                }
                else if (c == ConsoleKey.RightArrow)
                {

                }
                else
                {
                    //DEFAULT ÁG
                }
                switch (c)
                {
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.DownArrow:
                        // DrawBall(x, --y);
                        break;
                    case ConsoleKey.LeftArrow:
                        //DrawBall(--x, y);
                        break;
                    case ConsoleKey.RightArrow:
                        //DrawBall(++x, y);
                        break;
                    default:
                        break;
                }

            }



        }
    }
}