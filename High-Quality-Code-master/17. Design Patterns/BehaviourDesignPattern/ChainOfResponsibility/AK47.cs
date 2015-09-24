using System;

namespace ChainOfResponsibility
{
    public class AK47 : Weapon
    {
        public AK47()
            :base(new Tank())
        {
            
        }

        protected override int FirePower
        {
            get
            {
                return 100;
            }
        }

        public override void Get(int firePower)
        {
            if (firePower <= FirePower)
            {
                Console.WriteLine("AK 47 is best choose for you");
            }
            else
            {
                NextClassWeapon.Get(firePower);
            }
        }
    }
}
