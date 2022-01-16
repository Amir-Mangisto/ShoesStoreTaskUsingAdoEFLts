using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoesStoreTaskUsingAdoEFLts.Models
{
    public class SportShoe
    {
        public SportShoe(int id, string company, string brand, int size, int price)
        {
            Id = id;
            Company = company;
            Brand = brand;
            Size = size;
            Price = price;
        }

        public int Id { get; set; }
        public string Company { get; set; }
        public string Brand { get; set; }
        public int Size { get; set; }
        public int Price { get; set; }
    }
}