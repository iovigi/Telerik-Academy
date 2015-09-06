namespace AbstractFactory
{
    using System;
    using Academy;
    using School;

    public class Factory : IFactory
    {
        public readonly SchoolType SchoolType;

        private readonly IFactory SchoolFactory;

        public Factory(SchoolType schoolType)
        {
            this.SchoolType = schoolType;

            switch (SchoolType)
            {
                case SchoolType.Academy:
                    SchoolFactory = new AcademyFactory();
                    break;
                case SchoolType.School:
                    SchoolFactory = new SchoolFactory();
                    break;
                default:
                    throw new NotSupportedException(SchoolType.ToString());
            }
        }

        public SchoolType School
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public SchoolFactory SchoolFactoryProperty
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public AcademyFactory AcademyFactory
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public ITeacher CreateTeacher()
        {
            return SchoolFactory.CreateTeacher();
        }

        public IManager CreateManager()
        {
            return SchoolFactory.CreateManager();
        }
    }
}
