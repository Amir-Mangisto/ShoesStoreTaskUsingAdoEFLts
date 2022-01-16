using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoesStoreTaskUsingAdoEFLts.Models
{
    public class ExitShoes
    {
        public int Id { get; set; }
        public string ComapnyName { get; set; }
        public string Gender { get; set; }
        public bool HasHeel { get; set; }
        public bool InStore { get; set; }
        public int Size { get; set; }
        public int Price { get; set; }
    }
}