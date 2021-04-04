using INStock.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INStock
{
    public class ProductStock : IProductStock
    {
        private List<IProduct> products;
        private Dictionary<int, IProduct> dict;
        private int index;

        public ProductStock()
        {
            this.products = new List<IProduct>();
            this.dict = new Dictionary<int, IProduct>();
            index = -1;
        }
        public IProduct this[int index]
        { 
            get 
            {
                return this.products[index];
            }
            set 
            { 
                this.products[index] = value; 
            }
        }

        public int Count => this.products.Count;

        public void Add(IProduct product)
        {
            if (!this.products.Any(p => p.Label == product.Label))
            {
                this.products.Add(product);
                this.dict.Add(++index, product);
            }
        }

        public bool Contains(IProduct product)
        {
            return this.products.Any(p => p.Label == product.Label);
        }

        public IProduct Find(int index)
        {
            if (index > this.index || index < this.index)
            {
                throw new IndexOutOfRangeException();
            }
            return this.dict[index];
        }

        public IEnumerable<IProduct> FindAllByPrice(decimal price)
        {
            return this.products.Where(p => p.Price == price);
        }

        public IEnumerable<IProduct> FindAllByQuantity(int quantity)
        {
            return this.products.Where(p => p.Quantity == quantity);
        }

        public IEnumerable<IProduct> FindAllInRange(decimal lowerEnd, decimal higherEnd)
        {
            var greaterThanLower = this.products.Where(p => p.Price >= lowerEnd);
            var lowerThanGreater = greaterThanLower.Where(p => p.Price <= higherEnd).OrderByDescending(p => p.Price);
            return lowerThanGreater;
        }

        public IProduct FindByLabel(string label)
        {
            IProduct product = this.products.FirstOrDefault(p => p.Label == label);
            if (product == null)
            {
                throw new ArgumentException();
            }
            else
            {
                return product;
            }
        }

        public IProduct FindMostExpensiveProduct()
        {
            decimal maxPrice = decimal.MinValue;
            IProduct maxProduct = null;
            foreach (var product in this.products)
            {
                if (product.Price > maxPrice)
                {
                    maxPrice = product.Price;
                    maxProduct = product;
                }
            }
            return maxProduct;
        }

        public IEnumerator<IProduct> GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public bool Remove(IProduct product)
        {
            if (!this.products.Any(p => p.Label == product.Label))
            {
                this.products.Remove(product);
                this.dict.Remove(++index, out product);

                return true;
            }

            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}