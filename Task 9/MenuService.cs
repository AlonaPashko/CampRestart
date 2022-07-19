using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task9
{
    internal static class MenuService
    {
        public static bool TryGetTotalSum(Menu menu, Pricelist pricelist, out double menuTotalSum)//сумарна вартість всього меню
        {
            menuTotalSum = default;
            for (int i = 0; i < menu.Length; i++)
            {
                if (!TryGetDishPrice(menu[i], pricelist, out double sumPrice))
                {
                    return false;
                }
                menuTotalSum += sumPrice;
            }
            return true;
        }
        public static bool TryGetDishPrice(Dish dish, Pricelist pricelist, out double sumPrice)//сумарна вартість кожної страви
        {
            sumPrice = default;
            foreach (string key in dish.Keys)
            {
                if (!pricelist.TryGetProductPrice(key, out double productPrice))
                {
                    return false;
                }
                sumPrice += productPrice * dish[key];
            }
            return true;
        }

    }
}
