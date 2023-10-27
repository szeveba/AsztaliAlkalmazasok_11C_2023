namespace Suranyisz
{
    static class Feladatsor
    {
        private static bool IsPrime(long num)
        {
            for (int i = 2; i < num; i++)
            {
                if (num % i == 0) return false;
            }
            return true;
        }
        private static double ReadNumberFromConsole(string message)
        {

            while (true)
            {
                Console.Write(message);
                var input = Console.ReadLine();
                try
                {
                    return double.Parse(input);
                }
                catch (Exception)
                {
                    Console.WriteLine("Nem sikerül átalakítani a megadott értéket számmá!");
                }
            }
        }
        /// <summary>
        /// Írj programot, mely beolvassa egy kör átmérőjét, és kiírja a kör kerületét és területét!<br/>
        /// A pi értékének meghatározásához használd a Math.PI értéket!
        /// </summary>
        internal static void F13()
        {
            var d = ReadNumberFromConsole("Kör átmérőjét: ");
            var r = d / 2;
            Console.WriteLine("Kör kerülete: " + d * Math.PI);
            Console.WriteLine("Kör területe: " + r * r * Math.PI);
        }
        /// <summary>
        /// Írj programot, ami beolvassa a körív sugarát és középponti szögét, <br/>
        /// és kiírja a körív területét és a határoló ív hosszát!
        /// </summary>
        internal static void F14()
        {
            var r = ReadNumberFromConsole("Adj meg egy körív sugarát: ");
            var degree = ReadNumberFromConsole("Adj meg egy fokot: ");
            Console.WriteLine("A körív kerülete:" + (degree * r * 2 * Math.PI / 360));
            Console.WriteLine("A körív területe:" + (r * r * Math.PI * degree / 360));
        }
        /// <summary>
        /// Írj programot, mely addig olvas be számokat a billentyűzetről, 
        /// ameddig azok kisebbek, mint tíz.Írja ki ezek után a beolvasott számok összegét!
        /// </summary>
        internal static void F22()
        {
            double sum = 0, num = 0;
            while (num < 10)
            {
                num = ReadNumberFromConsole("Adj meg egy számot: ");
                sum += num;
            }
            Console.WriteLine("Az eddig megadott számok összege: " + nu,);
        }
        internal static void F24() { }
        internal static void F26() { }
        internal static void F27() { }
        internal static void F29() { }

    }
    internal class Program
    {



        static void Main(string[] args)
        {
            Feladatsor.F13();
        }
    }
}