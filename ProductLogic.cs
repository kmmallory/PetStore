using System;
using System.Linq.Expressions;



namespace PetStore
{
    internal class ProductLogic : IProductLogic
    {
        private List<Product> _products;
        private Dictionary<string, DogLeash> _dogLeash;
        private Dictionary<string, CatFood> _catFood;

        public ProductLogic()
        {
            _products = new List<Product>
            {
                new DogLeash
                {
                    Name = "Kong Brand Nylon Leash",
                    Description = "A 6o inch Kong nylon dog leash.",
                    LengthInches = 60,
                    Material = "Nylon",
                    Price = 19.99m,
                    Quantity = 5
                },

                new CatFood
                {
                    Name = "Purina Adult Wet Cat Food",
                    Description = "A delectable wet cat food for your adult cat.",
                    KittenFood = false,
                    Price = 2.99m,
                    Quantity = 12
                },

                new DryCatFood
                {
                    Name = "Iams Dry Kitten Food",
                    Description = "Tiny morsels perfect for kittens.",
                    WeightPounds = 25,
                    KittenFood = true,
                    Price = 19.99m,
                    Quantity = 0
                }
            };

            _dogLeash = new Dictionary<string, DogLeash>();
            _catFood = new Dictionary<string, CatFood>();
        }

        public void AddProduct(Product product)
        {
            if (product is DogLeash)
            {
                _dogLeash.Add(product.Name, product as DogLeash);
            }

            if (product is CatFood)
            {
                _catFood.Add(product.Name, product as CatFood);
            }

            _products.Add(product);
        }

        public List<Product> GetAllProducts()
        {
            return _products;
        }

        public DogLeash GetDogLeashByName(string name)
        {
            try
            {
                return _dogLeash[name];
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<string> GetOnlyInStockProducts()
        {
            return _products.Where(x => x.Quantity > 0).Select(x => x.Name).ToList();
        }
    }
}







