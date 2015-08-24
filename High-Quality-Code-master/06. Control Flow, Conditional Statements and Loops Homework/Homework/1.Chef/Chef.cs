namespace _1.Chef
{
    using System;

    public class Chef
    {
        public void Cook()
        {
            Potato potato = this.GetPotato();
            this.Peel(potato);
            this.Cut(potato);

            Carrot carrot = this.GetCarrot();
            this.Peel(carrot);
            this.Cut(carrot);

            Bowl bowl = this.GetBowl();
            bowl.Add(potato);
            bowl.Add(carrot);
        }

        private Potato GetPotato()
        {
            throw new NotImplementedException();
        }

        private Carrot GetCarrot()
        {
            throw new NotImplementedException();
        }

        private void Peel(Vegetable potato)
        {
            throw new NotImplementedException();
        }

        private void Cut(Vegetable potato)
        {
            throw new NotImplementedException();
        }

        private Bowl GetBowl()
        {
            throw new NotImplementedException();
        }
    }
}
