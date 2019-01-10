using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace DrawOrSurrender
{
    /// <summary>
    /// Extends native C# lists methods.
    /// </summary>
    static class ListExtension
    {

        private static Random _random = new Random();

        /// <summary>
        /// Randomly shuffles the current list, using cryptography randomization system.
        /// </summary>
        public static void Shuffle<T>(this IList<T> list)
        {
            RNGCryptoServiceProvider randomProvider = new RNGCryptoServiceProvider();
            int i = list.Count;
            while(i > 1)
            {
                byte[] box = new byte[1];

                do { randomProvider.GetBytes(box); }
                while (!(box[0] < i * (Byte.MaxValue / i)));

                int j = (box[0] % i);
                i--;
                T randomValue = list[j];
                list[j] = list[i];
                list[i] = randomValue;
            }
        }

        /// <summary>
        /// Randomly shuffles the current list, using basic randomization system.
        /// </summary>
        public static void QuickShuffle<T>(this IList<T> list)
        {
            int count = list.Count;
            while(count > 1)
            {
                count--;
                int randomIndex = _random.Next(count + 1);
                T randomValue = list[randomIndex];
                list[randomIndex] = list[count];
                list[count] = randomValue;
            }
        }

        /// <summary>
        /// Converts the current list into a Stack collection.
        /// </summary>
        public static Stack<T> ToStackList<T>(this IList<T> list)
        {
            Stack<T> stack = new Stack<T>();
            foreach (T item in list)
            {
                stack.Push(item);
            }
            return stack;
        }

    }
}
