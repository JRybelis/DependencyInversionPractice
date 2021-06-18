using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop_2._0.BusinessLogic;
using Shop_2._0.Interfaces;

namespace Shop_2._0.Services.Shop
{
    public class AddItemsService
    {
        private readonly ShopLogic _shopLogic;
        private readonly IWriter _iWriter;

        public AddItemsService(ShopLogic shopLogic, IWriter iWriter)
        {
            _shopLogic = shopLogic;
            _iWriter = iWriter;
        }
        public void AddItems(string itemName, int quantity)
        {
            _shopLogic.AddItem(itemName, quantity);
            _iWriter.Write($"You have added {quantity} {itemName}s to the shop inventory.");
        }
    }
}
