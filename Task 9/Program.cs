
using Task9;

Dish dish1 = new Dish();
dish1.Name = "Borscht";

Dish dish2 = new Dish();
dish2.Name = "Palyanytsya";

Console.WriteLine(dish1 + " " + dish2);

List<Dish> dishes1 = new List<Dish>();
dishes1.Add(dish1);
dishes1.Add(dish2);

Menu menu1 = new Menu("Menu.txt");


Console.WriteLine(menu1);

Dictionary<string, double> products1 = new Dictionary<string, double>();

products1.Add("Beet", 9.0);
products1.Add("Sour cream", 12.2);
products1.Add("Potato", 10.5);
products1.Add("Flour", 18.2);

Pricelist price1 = new Pricelist();
price1.ProductPrice = products1;

Pricelist price2 = new Pricelist("Prices.txt");
Console.WriteLine(price2);







