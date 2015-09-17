namespace WeaponWarehouse
{
    using System;
    using System.Collections.Generic;

    public class WeaponFactory
    {
        private readonly Dictionary<Weapon, IWeapon> Weapons = new Dictionary<Weapon, IWeapon>(); 

        public IWeapon Get(Weapon weapon)
        {
            IWeapon resultWeapon;

            if(!Weapons.TryGetValue(weapon, out resultWeapon))
            {
                switch(weapon)
                {
                    case Weapon.AK47:
                        resultWeapon = new AK47();
                        break;
                    case Weapon.M16:
                        resultWeapon = new M16();
                        break;
                    default:
                        throw new NotSupportedException();
                }

                Weapons.Add(weapon, resultWeapon);
            }

            return resultWeapon;
        }
    }
}
