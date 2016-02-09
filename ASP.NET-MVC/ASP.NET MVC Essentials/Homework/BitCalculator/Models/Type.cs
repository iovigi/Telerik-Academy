namespace BitCalculator.Models
{
    using System;

    public enum Type : int
    {
        Bit = 0,
        Byte = 1,
        KiloBit = 2,
        KiloByte = 3,
        Megabit = 4,
        Megabyte = 5,
        Gigabit = 6,
        Gigabyte = 7,
        Terabit = 8,
        Terabyte = 9,
        Petabit = 10,
        Petabyte = 11,
        Exabit = 12,
        Exabyte = 13,
        Zettabit = 14,
        Zettabyte = 15,
        Yottabit = 16,
        Yottabyte = 17
    }

    public static class TypeExtension
    {
        public static double GetBits(this Type type, double value, int kilo)
        {
            if (value == 0)
            {
                return 0;
            }

            switch (type)
            {
                case Type.Bit:
                    return value;
                case Type.Byte:
                    return value * 8;
                case Type.KiloBit:
                    return value * kilo;
                case Type.KiloByte:
                    return value * kilo * 8;
                case Type.Megabit:
                    return value * kilo * kilo;
                case Type.Megabyte:
                    return value * kilo * kilo * 8;
                case Type.Gigabit:
                    return value * kilo * kilo * kilo;
                case Type.Gigabyte:
                    return value * kilo * kilo * kilo * 8;
                case Type.Terabit:
                    return value * kilo * kilo * kilo * kilo;
                case Type.Terabyte:
                    return value * kilo * kilo * kilo * kilo * 8;
                case Type.Petabit:
                    return value * kilo * kilo * kilo * kilo * kilo;
                case Type.Petabyte:
                    return value * kilo * kilo * kilo * kilo * kilo * 8;
                case Type.Exabit:
                    return value * kilo * kilo * kilo * kilo * kilo * kilo;
                case Type.Exabyte:
                    return value * kilo * kilo * kilo * kilo * kilo * kilo * 8;
                case Type.Zettabit:
                    return value * kilo * kilo * kilo * kilo * kilo * kilo * kilo;
                case Type.Zettabyte:
                    return value * kilo * kilo * kilo * kilo * kilo * kilo * kilo * 8;
                case Type.Yottabit:
                    return value * kilo * kilo * kilo * kilo * kilo * kilo * kilo * kilo;
                case Type.Yottabyte:
                    return value * kilo * kilo * kilo * kilo * kilo * kilo * kilo * kilo * 8;
            }

            throw new NotSupportedException(type.ToString());
        }

        public static double GetValue(this Type type, double bits, int kilo)
        {
            if(bits == 0)
            {
                return 0;
            }

            switch (type)
            {
                case Type.Bit:
                    return bits;
                case Type.Byte:
                    return bits / 8;
                case Type.KiloBit:
                    return bits / kilo;
                case Type.KiloByte:
                    return bits / kilo / 8;
                case Type.Megabit:
                    return bits / kilo / kilo;
                case Type.Megabyte:
                    return bits / kilo / kilo / 8;
                case Type.Gigabit:
                    return bits / kilo / kilo / kilo;
                case Type.Gigabyte:
                    return bits / kilo / kilo / kilo / 8;
                case Type.Terabit:
                    return bits / kilo / kilo / kilo / kilo;
                case Type.Terabyte:
                    return bits / kilo / kilo / kilo / kilo / 8;
                case Type.Petabit:
                    return bits / kilo / kilo / kilo / kilo / kilo;
                case Type.Petabyte:
                    return bits / kilo / kilo / kilo / kilo / kilo / 8;
                case Type.Exabit:
                    return bits / kilo / kilo / kilo / kilo / kilo / kilo;
                case Type.Exabyte:
                    return bits / kilo / kilo / kilo / kilo / kilo / kilo / 8;
                case Type.Zettabit:
                    return bits / kilo / kilo / kilo / kilo / kilo / kilo / kilo;
                case Type.Zettabyte:
                    return bits / kilo / kilo / kilo / kilo / kilo / kilo / kilo / 8;
                case Type.Yottabit:
                    return bits / kilo / kilo / kilo / kilo / kilo / kilo / kilo / kilo;
                case Type.Yottabyte:
                    return bits / kilo / kilo / kilo / kilo / kilo / kilo / kilo / kilo / 8;
            }

            throw new NotSupportedException(type.ToString());
        }
    }
}