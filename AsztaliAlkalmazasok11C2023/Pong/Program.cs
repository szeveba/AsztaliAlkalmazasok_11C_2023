namespace Pongí
{
    internal class Program
    {
        static void DrawBall(int x, int y)
        {
            if(0<=x && x< Console.WindowWidth && 0<= y && y< Console.WindowHeight)
            {
                Console.SetCursorPosition(x, y);
                Console.CursorVisible = false;
                Console.Write('█');
            }
        }
        static void Main(string[] args)
        {//kódformázás Ctrl + K,D          
            char ball = '█';
            int x = 0;
            int y = 0;
            Console.Write(ball);
            while (true)
            {
                var c = Console.ReadKey(true).Key;
                switch (c)
                {
                    case ConsoleKey.UpArrow:
                        DrawBall(x, ++y);
                        break;
                    case ConsoleKey.DownArrow:
                        DrawBall(x, ++y);
                        break;
                    case ConsoleKey.LeftArrow:
                        DrawBall(--x, y);
                        break;
                    case ConsoleKey.RightArrow:
                        DrawBall(++x, y);
                        break;
                    default:
                        break;
                }
            }



        }
    }
}