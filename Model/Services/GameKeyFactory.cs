using System;

namespace Model.Services
{
    public class GameKeyFactory : IGameKeyFactory
    {
        private static readonly int Length = 4;
        private static readonly char[] Chars = "abcdefghijklmnopqrstuvwxyz0123456789".ToCharArray();
        private readonly Random Rng = new Random();

        public string Create()
        {
            var chars = new char[Length];

            for (var i = 0; i < chars.Length; i++)
            {
                var index = Rng.Next(Chars.Length);
                chars[i] = Chars[index];
            }

            return new string(chars);
        }
    }
}
