namespace WeaponWarehouse
{
    public interface IWeapon
    {
        string Name { get; }
        long Size { get; }
        long Weight { get; }

        void Shot();
    }
}
