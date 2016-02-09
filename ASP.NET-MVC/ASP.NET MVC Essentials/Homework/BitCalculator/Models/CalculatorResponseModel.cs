namespace BitCalculator.Models
{
    using System;
    using System.Collections.Generic;

    public class CalculatorResponseModel
    {
        public double Qyantity { get; set; }

        public double Bits { get; set; }

        public int Kilo { get; set; }

        public List<string> GetResult()
        {
            var enumArray = Enum.GetValues(typeof(Type));

            List<string> values = new List<string>();

            for (int i = 0; i < enumArray.Length; i++)
            {
                var valueType = (Type)enumArray.GetValue(i);
                values.Add(string.Format("<td>{0}</td><td>{1}</td>", valueType, valueType.GetValue(Bits, Kilo)));
            }

            return values;
        }
    }
}
