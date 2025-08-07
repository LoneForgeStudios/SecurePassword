using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace SecurePasswordGenerator
{
    public static class SecurePassword
    {
        public static string Generate(int length, int percentDigits, int percentSpecials)
        {
            int countDigits = (int)(length * percentDigits / 100.0);
            int countSpecials = (int)(length * percentSpecials / 100.0);
            int countLetters = length - countDigits - countSpecials;

            string digits = "0123456789";
            string specials = "!@#$%^&*()_+-=[]{}|;:,.<>?";
            string letters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

            List<char> passwordChars = new List<char>();

            passwordChars.AddRange(GetSecureRandomChars(digits, countDigits));
            passwordChars.AddRange(GetSecureRandomChars(specials, countSpecials));
            passwordChars.AddRange(GetSecureRandomChars(letters, countLetters));

            return new string(Shuffle(passwordChars).ToArray());
        }

        private static IEnumerable<char> GetSecureRandomChars(string source, int count)
        {
            var result = new List<char>();
            for (int i = 0; i < count; i++)
            {
                int index = GetSecureRandomInt(0, source.Length);
                result.Add(source[index]);
            }
            return result;
        }

        private static List<char> Shuffle(List<char> list)
        {
            for (int i = list.Count - 1; i > 0; i--)
            {
                int j = GetSecureRandomInt(0, i + 1);
                (list[i], list[j]) = (list[j], list[i]);
            }
            return list;
        }

        private static int GetSecureRandomInt(int minValue, int maxValue)
        {
            byte[] uint32Buffer = new byte[4];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(uint32Buffer);
                uint random = BitConverter.ToUInt32(uint32Buffer, 0);
                return (int)(minValue + (random % (uint)(maxValue - minValue)));
            }
        }
    }
}
