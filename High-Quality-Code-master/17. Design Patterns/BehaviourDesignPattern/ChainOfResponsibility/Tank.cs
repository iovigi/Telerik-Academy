using System;

namespace ChainOfResponsibility
{
    public class Tank : Weapon
    {
        public Tank()
            :base(new NuclearWeapon())
        {

        }

        protected override int FirePower
        {
            get
            {
                return 5000;
            }
        }

        public override void Get(int firePower)
        {
            if (firePower <= FirePower)
            {
                Console.WriteLine("tank is best choose for you");
            }
            else
            {
                NextClassWeapon.Get(firePower);
            }
        }
    }
}
