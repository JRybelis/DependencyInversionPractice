using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop_2._0.Interfaces;

namespace Shop_2._0.Services.Shop.Console
{
    public class ReturnToMainMenuService
    {
        
        private readonly IReader _reader;
        private readonly ShopUi _shopUi;

        public ReturnToMainMenuService(ShopUi shopUi, IReader reader)
        {
            _shopUi = shopUi;
            _reader = reader;
        }

        public void ReturnToMainMenu()
        {
            _reader.Read();
            _shopUi.MainMenu();
        }
        
    }
}
