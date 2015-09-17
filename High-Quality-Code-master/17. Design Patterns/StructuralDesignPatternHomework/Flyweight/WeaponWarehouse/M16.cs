namespace WeaponWarehouse
{
    using System;

    public class M16: IWeapon
    {
        public string Name
        {
            get
            {
                return "M-16";
            }
        }

        public long Size
        {
            get
            {
                return 3;
            }
        }

        public long Weight
        {
            get
            {
                return 3;
            }
        }

        public void Shot()
        {
            Console.WriteLine("Shoot" + Name);
        }
    }
}
