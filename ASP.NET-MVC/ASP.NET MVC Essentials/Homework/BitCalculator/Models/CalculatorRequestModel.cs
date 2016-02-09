namespace BitCalculator.Models
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;

    public class CalculatorRequestModel
    {
        public double Qyantity { get; set; }
        public Type Type { get; set; }
        public int Kilo { get; set; }

        public static List<SelectListItem> GetListFromType()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            
            foreach(var item in Enum.GetValues(typeof(Type)))
            {
                list.Add(new SelectListItem { Text = item.ToString(), Value = ((int)item).ToString() });
            }


            return list;
        }

        public static List<SelectListItem> GetListFromKilo()
        {
            List<SelectListItem> list = new List<SelectListItem>();

            list.Add(new SelectListItem { Value = 1000 + "", Text = 1000 + "" });
            list.Add(new SelectListItem { Value = 1024 + "", Text = 1024 + "" });


            return list;
        }
    }
}