namespace ChainOfResponsibility
{
    public abstract class Weapon
    {
        protected readonly Weapon NextClassWeapon;

        protected Weapon(Weapon nextClassWeapon)
        {
            NextClassWeapon = nextClassWeapon;
        }

        protected abstract int FirePower { get; }

        public abstract void Get(int firePower);
    }
}
