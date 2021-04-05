using System;

namespace RollABall
{
    public static class Crypto
    {
        public static string CryptoXOR(string text, int key = 19)
        {
            var result = String.Empty;
            for (int i = 0; i < text.Length; i++)
            {
                result += (char)(text[i] ^ key);
            }
            return result;
        }
    }
}
