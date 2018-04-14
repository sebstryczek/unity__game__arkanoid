using System;

namespace Utils
{
    class HelpersRandom
    {
        private static Random random = new Random();

        public static T GetRandomFromArray<T>(T[] array)
        {
            int rand = random.Next(0, array.Length);
            return array[rand];
        }
    }
}
