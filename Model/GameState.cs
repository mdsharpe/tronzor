using System;

namespace Model
{
    public class GameState
    {
        public GameState(string key, int width, int height)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (width < 1) {
                throw new ArgumentOutOfRangeException(nameof(width));
            }

            if (height < 1) {
                throw new ArgumentOutOfRangeException(nameof(height));
            }

            Key = key;
            Width = width;
            Height = height;
        }

        public string Key { get; }
        public int Width { get; }
        public int Height { get; }
    }
}
