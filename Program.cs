using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace drinks_inside_the_fridge
{
    //This project is about creating Drink entities that inherit properties and methods of an abstract class Product.
    //Every Product has the properties Name,Type,Price and every Drink entity inherits these Product Properties 
    //and has an extra Property Size
    //1)Display all Products Values
    //2)Display all Products Values whose Price is greater than 0.8 euro
    //3)Create a new Fridge in order to add the Drink entities inside it
    //4)Display all Drinks values inside the new Fridge
    //5)Display all inside the fridge Drinks values whose Price is greater than 0.8 euro
    //6)Display the Max value and the Average of all Prices 
    //7)Use interface,delegate,anonymous methods,Lambda expression and (where) linq  
    abstract class Product
    {
        //only properties & methods can be abstract (not fields)
        public abstract string Name { get; set; }
        public abstract string Type { get; set; }
        public abstract decimal Price { get; set; }
        public abstract void Output();
        public abstract void GetProductPiceGreater_08euro();
    }
    interface Ifridge
    {
        //only properties & methods can be inside the interface (not fields)
        void OutputFridge();
    }
    class Drink : Product, Ifridge
    {
        public override string Name { get; set; }
        public override string Type { get; set; }
        public override decimal Price { get; set; }
        public float Size { get; set; }

        public Drink(string name, string type, float size, decimal price)
        {
            Name = name;
            Type = type;
            Size = size;
            Price = price;
        }
        public override void Output()
        {
            Console.WriteLine($"DRINK | Name: {Name,-10}Type: {Type,-10}Size: {Size,-10}Price: {Price,-10}");
        }
        public void OutputFridge()
        {
            Console.WriteLine("INSIDE THE FRIDGE");
        }

        public override void GetProductPiceGreater_08euro()
        {
            if (Price > 0.8m)
            {
                Console.WriteLine($"DRINK | Name: {Name,-10}Type: {Type,-10}Size: {Size,-10}Price: {Price,-10}");
            }
        }
    }
    class Fridge
    {
        public List<Ifridge> AllifridgeList = new List<Ifridge>();
    }
    delegate void Print();
    class Program
    {
        static void Main(string[] args)
        {
            //Creating products
            Product Drink1 = new Drink(name: "CocaCola", type: "zero", size: 330f, price: 0.85m);
            Product Drink2 = new Drink(name: "CocaCola", type: "normal", size: 330f, price: 0.70m);
            Product Drink3 = new Drink(name: "CocaCola", type: "light", size: 330f, price: 0.75m);
            Product Drink4 = new Drink(name: "CocaCola", type: "stevia", size: 330f, price: 0.90m);
            Product Drink5 = new Drink(name: "Fanta", type: "normal", size: 330f, price: 0.75m);
            Product Drink6 = new Drink(name: "Fanta", type: "light", size: 330f, price: 0.85m);
            Product Drink7 = new Drink(name: "PepsiCola", type: "normal", size: 330f, price: 0.75m);
            Product Drink8 = new Drink(name: "PepsiCola", type: "free", size: 330f, price: 0.80m);
            Product Drink9 = new Drink(name: "Sprite", type: "normal", size: 330f, price: 0.80m);
            Product Drink10 = new Drink(name: "Sprite", type: "light", size: 330f, price: 0.85m);
            Product Drink11 = new Drink(name: "Soda", type: "zero", size: 330f, price: 0.80m);
            Product Drink12 = new Drink(name: "perrie", type: "normal", size: 250f, price: 0.95m);
            Product Drink13 = new Drink(name: "Tonic", type: "normal", size: 330f, price: 0.85m);
            Product Drink14 = new Drink(name: "7up", type: "normal", size: 330f, price: 0.80m);
            Product Drink15 = new Drink(name: "7up", type: "light", size: 330f, price: 0.90m);
            Product Drink16 = new Drink(name: "LiptonTea", type: "lemon", size: 330f, price: 0.95m);
            Product Drink17 = new Drink(name: "LiptonTea", type: "peach", size: 330f, price: 0.95m);
            Product Drink18 = new Drink(name: "NestTea", type: "lemon", size: 330f, price: 0.90m);

            //All Products
            List<Product> AllProductsList = new List<Product>();
            AllProductsList.Add(Drink1); AllProductsList.Add(Drink2); AllProductsList.Add(Drink3);
            AllProductsList.Add(Drink4); AllProductsList.Add(Drink5); AllProductsList.Add(Drink6);
            AllProductsList.Add(Drink7); AllProductsList.Add(Drink8); AllProductsList.Add(Drink9);
            AllProductsList.Add(Drink10); AllProductsList.Add(Drink11); AllProductsList.Add(Drink12);
            AllProductsList.Add(Drink13); AllProductsList.Add(Drink14); AllProductsList.Add(Drink15);
            AllProductsList.Add(Drink16); AllProductsList.Add(Drink17); AllProductsList.Add(Drink18);


            //Display all Products
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("ALL PRODUCTS:");
            Console.ForegroundColor = ConsoleColor.White;
            foreach (Product item in AllProductsList)
            {
                //Lambda Expression
                Print del = () => Console.WriteLine($"DRINK | Name: {item.Name,-10}Type: {item.Type,-10}Size: {(item as Drink).Size,-10}Price: {item.Price,-10}");
                del();
            }
            Console.WriteLine();
            //Display all products whose Price is greater than 0.8 Euro
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("PRODUCTS WHOM PRICE IS GREATER THAN 0.8 EURO:");
            Console.ForegroundColor = ConsoleColor.White;
            foreach (Product item in AllProductsList)
            {
                //Lambda Expression & Ternary operator
                //we need put the 'else' (:) case whenever use Ternary operator
                Print del = () => Console.WriteLine($"DRINK | Name: {item.Name,-10}Type: {item.Type,-10}Size: {(item as Drink).Size,-10}Price: {item.Price,-10}");
                del();
            }
            Console.WriteLine();

            //Creating a new Fridge by name FridgeA
            Fridge FrigeA = new Fridge();
            //Adding Product as Drink insite the FridgeA
            FrigeA.AllifridgeList.Add(Drink2 as Drink);
            FrigeA.AllifridgeList.Add(Drink3 as Drink);
            FrigeA.AllifridgeList.Add(Drink5 as Drink);
            FrigeA.AllifridgeList.Add(Drink6 as Drink);
            FrigeA.AllifridgeList.Add(Drink8 as Drink);
            FrigeA.AllifridgeList.Add(Drink10 as Drink);
            FrigeA.AllifridgeList.Add(Drink12 as Drink);
            FrigeA.AllifridgeList.Add(Drink13 as Drink);
            FrigeA.AllifridgeList.Add(Drink14 as Drink);
            FrigeA.AllifridgeList.Add(Drink15 as Drink);
            FrigeA.AllifridgeList.Add(Drink16 as Drink);
            FrigeA.AllifridgeList.Add(Drink17 as Drink);

            //Display Drinks which are inside the FridgeA
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("ALL DRINKS INSIDE THE FRIDGE:");
            Console.ForegroundColor = ConsoleColor.White;
            foreach (Product item in FrigeA.AllifridgeList)
            {
                (item as Drink).OutputFridge();
                //Lambda Expression
                Print del = () => Console.WriteLine($"DRINK | Name: {item.Name,-10}Type: {item.Type,-10}Size: {(item as Drink).Size,-10}Price: {item.Price,-10}");
                del();
            }
            Console.WriteLine();
            //Display Drinks inside the FridgeA whose Price is greater than 0.8 euro
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("DRINKS INSIDE THE FRIDGE WHOME PRICE IS GREATER THAN 0.8 EURO:");
            Console.ForegroundColor = ConsoleColor.White;
            foreach (Product item in FrigeA.AllifridgeList)
            {
                //Lambda Expression & Ternary operator
                //we need put the 'else' (:) case whenever use Ternary operator
                Print del = () =>
                Console.WriteLine(item.Price > 0.8m ? $"DRINK | Name: {item.Name,-10}Type: {item.Type,-10}Size: {(item as Drink).Size,-10}Price: {item.Price,-10}" : " ");
                del();
            }
            Console.WriteLine();
            decimal Average = 0;
            decimal Sum = 0;
            foreach(Product item in AllProductsList)
            {
                Sum += item.Price;
            }
            Average = Sum / AllProductsList.Count;
            Console.WriteLine("Average 'Price'value of all Products is : {0}", Average);
            Console.WriteLine();

            decimal MaxPrice = AllProductsList.ElementAt(0).Price;
            foreach(Product item in AllProductsList)
            {
                if(item.Price > MaxPrice)
                {
                    MaxPrice = item.Price;
                }
            }
            Console.WriteLine("Max 'Price' value of all Products is : {0}", MaxPrice);

            Console.ReadKey();
        }
    }
}
