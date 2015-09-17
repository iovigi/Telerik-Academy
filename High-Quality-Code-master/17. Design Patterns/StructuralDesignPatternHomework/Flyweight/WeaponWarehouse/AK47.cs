namespace WeaponWarehouse
{
    using System;

    public class AK47 : IWeapon
    {
        public string Name
        {
            get
            {
                return "AK-47";
            }
        }

        public long Size
        {
            get
            {
                return 5;
            }
        }

        public long Weight
        {
            get
            {
                return 5;
            }
        }

        public void Shot()
        {
            Console.WriteLine("Shoot" + Name);
        }
    }
}
