﻿namespace TradeCompany
{
    using System;

    public class Article : IComparable<Article>
    {
        public string Barcode { get; set; }
        public  string Vendor { get; set; }
        public  string Title { get; set; }
        public  decimal Price { get; set; }

        public int CompareTo(Article other)
        {
            return this.Price.CompareTo(other.Price);
        }
    }
}
