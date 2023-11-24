using System.Data.SqlTypes;

namespace Library
{
    public static class AlgorithmicPatterns
    {
        public static int SeriesCalculationMultiplication(int[] array)
        {
            int sum = 1;
            for (int i = 0; i < array.Length; i++)
            {
                sum = sum * array[i];
            }
            return sum;
        }
        public static double SeriesCalculationMultiplication(double[] array)
        {
            double sum = 1;
            for (int i = 0; i < array.Length; i++)
            {
                sum *= array[i];
            }
            return sum;
        }

        public static long SeriesCalculationMultiplication(IEnumerable<long> array)
        {
            long sum = 1;
            foreach (var item in array)
            {
                sum *= item;
            }
            return sum;
        }

        public static decimal SeriesCalculationMultiplication(decimal[] array)
        {
            decimal sum = 1;
            foreach (var item in array) sum *= item;
            return sum;
        }

        public static bool Decision_HasEven(int[] array)
        {
            int i = 0;
            while (i < array.Length && !(array[i] % 2 == 0))
            {
                i++;
            }
            return i < array.Length;
        }

        public static bool Decision_HasOdd(IEnumerable<int> array)
        {
            foreach (var item in array)
            {
                if (item % 2 != 0) return true;
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <returns></returns>
        public static T MaxSelection<T>(IEnumerable<T> collection) where T : IComparable<T>
        {
            var enumerator = collection.GetEnumerator();
            if (enumerator.MoveNext())
            {
                var maxValue = enumerator.Current;
                while (enumerator.MoveNext())
                {
                    if (maxValue.CompareTo(enumerator.Current) < 0)
                    {
                        maxValue = enumerator.Current;
                    }
                }
                return maxValue;
            }
            else
            {
                return default!;
            }
        }
    }
}