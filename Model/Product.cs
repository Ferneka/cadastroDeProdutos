using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroDeProdutos.Model
{
    public class Product
    {
        public int Id {get; set;}
        public string Description {get; set;}
        public double Price {get; set;}
        public int Stock {get; set;}
        public int IdCategory {get; set;}
        public virtual Category Category {get; set;}
    }
}