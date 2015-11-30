namespace Source
{
    using System;
    using System.Collections.Generic;

    public class Hash
    {
        public ulong Hash1 { get; private set; }
        public ulong Hash2 { get; private set; }

        private const ulong BASE1 = 31;
        private const ulong MODUL1 = 1000000009;

        private const ulong BASE2 = 10037;
        private const ulong MODUL2 = 1000000033;

        private ulong power1;
        private ulong[] powers2;

        private int[] lastIndexes;

        private int[] dists;

        public Hash(string str)
        {
            this.Hash1 = 0;
            this.Hash2 = 0;

            this.power1 = 1;
            this.powers2 = new ulong[str.Length + 1];
            this.powers2[0] = 1;

            this.dists = new int[1000009];
            this.lastIndexes = new int[26];

            for (int i = 0; i < this.lastIndexes.Length; i++)
            {
                lastIndexes[i] = -1;
            }

            for (int i = 0; i < str.Length; i++)
            {
                this.Add(str[i], i);
                this.power1 = this.power1 * BASE1 % MODUL1;
                this.powers2[i + 1] = powers2[i] * BASE2 % MODUL2;
            }
        }

        public void Add(char c, int index)
        {
            this.Hash1 *= BASE1;
            this.Hash2 *= BASE2;

            if ('A' <= c && c <= 'Z')
            {
                this.Hash1 += (ulong)c - 'A' + 1;
                this.Hash2 += MODUL2 - 1;
            }
            else
            {
                this.Hash1 += MODUL1 - 1;
                this.Hash2 += MODUL2 - 2;
                this.dists[index] = (int)MODUL2 - 2;

                if (this.lastIndexes[c - 'a'] > -1)
                {
                    int dist = index - this.lastIndexes[c - 'a'];
                    this.dists[lastIndexes[c - 'a']] = dist;
                    this.Hash2 += (ulong)(dist + 2) * this.powers2[dist];
                }

                this.lastIndexes[c - 'a'] = index;
            }

            this.Hash1 %= MODUL1;
            this.Hash2 %= MODUL2;
        }

        public void Remove(char c, int index)
        {
            if ('A' <= c && c <= 'Z')
            {
                this.Hash1 += MODUL1 * MODUL1 - ((ulong)c - 'A' + 1) * this.power1;
                this.Hash2 += MODUL2 * MODUL2 - (MODUL2 - 1) * this.powers2[this.powers2.Length - 1];
            }
            else
            {
                this.Hash1 += MODUL1 * MODUL1 - (MODUL1 - 1) * this.power1;
                this.Hash2 += MODUL2 * MODUL2 - (ulong)dists[index] * this.powers2[this.powers2.Length - 1];

                if (lastIndexes[c - 'a'] == index)
                {
                    lastIndexes[c - 'a'] = -1;
                }
            }

            this.Hash1 %= MODUL1;
            this.Hash2 %= MODUL2;
        }
    }

    public class StartUp
    {
        public static void Main(string[] args)
        {
            string pattern = Console.ReadLine();
            string text = Console.ReadLine();

            if (pattern.Length > text.Length)
            {
                Console.WriteLine(0);

                return;
            }

            Hash patternHash = new Hash(pattern);
            Hash textHash = new Hash(text.Substring(0, pattern.Length));

            List<int> matches = new List<int>();

            if (patternHash.Hash1 == textHash.Hash1 && patternHash.Hash2 == textHash.Hash2)
            {
                matches.Add(1);
            }

            for (int i = pattern.Length; i < text.Length; i++)
            {
                textHash.Add(text[i], i);
                textHash.Remove(text[i - pattern.Length], i - pattern.Length);

                if (patternHash.Hash1 == textHash.Hash1 && patternHash.Hash2 == textHash.Hash2)
                {
                    matches.Add(i - pattern.Length + 2);
                }
            }

            Console.WriteLine(matches.Count);
            Console.WriteLine(string.Join(" ", matches));
        }
    }
}
