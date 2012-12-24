using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    public class Duty_c
    {
        public string duty_id { get; set; }

        public string name { get; set; }

        public string unit { get; set; }

        public int price { get; set; }

        public string relatedwords { get; set; }
   
        public double rate { get; set; }

        public Goods_Type type { get; set; }  //外键
        
        public int limits { get; set; }  //外键

        public int grade { get; set; }  //外键
    }
}
