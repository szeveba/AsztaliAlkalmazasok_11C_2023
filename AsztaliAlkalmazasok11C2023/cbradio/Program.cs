using System.Collections;

namespace cbradio
{
    internal class Program
    {
        static int AtszamolPercre(int ora, int perc)
        {
            return ora * 60 + perc;
        }
        static bool Feladat4(string[] lines)
        {
            for (int i = 1; i < lines.Length; i++)
            {
                var splits = lines[i].Split(';');
                if (splits[2] == "4") return true;
            }
            return false;
        }
        //LINQ - Language Integrated Query
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("cb.txt");
            var splits = new string[lines.Length][];
            for (int i = 0; i < lines.Length; i++)
            {
                splits[i] = lines[i].Split(';');
            }

            var md = new string[lines.Length, 4];
            for (int i = 0; i < lines.Length; i++)
            {
                var s = lines[i].Split(';');
                md[i, 0] = s[0];
                md[i, 1] = s[1];
                md[i, 2] = s[2];
                md[i, 3] = s[3];
            }

            Console.WriteLine($"3. feladat: A bejegyzések száma: {lines.Length - 1} db");
            int idx = 1;
            while (idx < lines.Length && !(lines[idx].Split(';')[2] == "4"))
            {
                idx++;
            }
            bool van = idx < lines.Length;
            Console.WriteLine($"4. feladat: {(van ? "Volt" : "Nem volt")} négy adást indító sofőr.");

            Console.Write("5. feladat: Kérek egy nevet: ");
            string nev = Console.ReadLine()!;
            int sum = 0;
            for (int i = 1; i < lines.Length; i++)
            {
                if (splits[i][3] == nev) sum += int.Parse(splits[i][2]);
            }
            if (sum == 0) Console.WriteLine("\tNincs ilyen nevű sofőr!");
            else Console.WriteLine($"\t{nev} {sum}x használta a CB-rádiót.");
            var op = new string[lines.Length];
            op[0] = "Kezdes;Nev;AdasDb";
            for (int i = 1; i < lines.Length; i++)
            {
                op[i] = $"{AtszamolPercre(int.Parse(splits[i][0]), int.Parse(splits[i][1]))};{splits[i][3]};{splits[i][2]}";
            }
            File.WriteAllLines("cb2.txt", op);


            HashSet<string> names = new HashSet<string>();
            for (int i = 1; i < lines.Length; i++)
            {
                names.Add(splits[i][3]);
            }
            Console.WriteLine($"8. feladat: A sofőrök száma: {names.Count} fő");

            Dictionary<string, int> dict = new Dictionary<string, int>();
            Dictionary<string, int> dict1 = new Dictionary<string, int>();
            var dict2 = new Dictionary<string, int>();
            Dictionary<string, int> dict3 = new();
            for (int i = 1; i < lines.Length; i++)
            {
                if (dict.ContainsKey(splits[i][3]))
                {
                    dict[splits[i][3]] += int.Parse(splits[i][2]);
                }
                else
                {
                    dict[splits[i][3]] = int.Parse(splits[i][2]);
                }
            }

            string maxKey = dict.First().Key;
            foreach (var item in dict)
            {
                if (dict[maxKey] < item.Value) maxKey = item.Key;
            }

            Console.WriteLine("9. feladat: A legtöbb adást indító sofőr");
            Console.WriteLine("\tNév: " + maxKey);
            Console.WriteLine("\tAdások száma: " + dict[maxKey] + " alkalom");
        }
    }
}