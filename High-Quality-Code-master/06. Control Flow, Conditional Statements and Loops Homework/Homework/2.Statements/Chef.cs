namespace _2.Statements
{
    using System;

    public class Chef
    {
        public void MakePotato()
        {
            Potato potato = this.GetPotate();

            if (potato != null && !(potato.HasNotBeenPeeled && potato.IsRotten))
            {
                this.Cook(potato);
            }
        }

        private Potato GetPotate()
        {
            throw new NotImplementedException();
        }

        private void Cook(Potato potato)
        {
            throw new NotImplementedException();
        }
    }
}
