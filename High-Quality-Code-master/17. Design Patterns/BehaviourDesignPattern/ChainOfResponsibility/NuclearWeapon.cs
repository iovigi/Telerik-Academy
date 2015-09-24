using System;

namespace ChainOfResponsibility
{
    class NuclearWeapon : Weapon
    {
        public NuclearWeapon()
            :base(null)
        {

        }

        protected override int FirePower
        {
            get
            {
                return int.MaxValue;
            }
        }

        public override void Get(int firePower)
        {
             Console.WriteLine("nuclear weapon is best choose for you");
        }
    }
}
