using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop_2._0.Interfaces;

namespace Shop_2._0.Services.Shop.Console
{
    public class ShopUi
    {
        private IWriter _writer;
        private IReader _reader;

        public ShopUi(IWriter writer, IReader reader)
        {
            _writer = writer; 
            _reader = reader;
        }


        public string[] MainMenu()
        {
            _writer.Write("  Please select one of the lettered options below.");
            _writer.Write("====================================================");
            _writer.Write("||  . L: list items    .  .  .  .  .  .  .  .  .  ||");
            _writer.Write("||-( )----------------( )( )( )( )( )( )( )( )( )-||");
            _writer.Write("||  \"                  \"  \"  \"  \"  \"  \"  \"  \"  \"  ||");
            _writer.Write("||  .  .  S: sell items   .  .  .  .  .  .  .  .  ||");
            _writer.Write("||-( )( )----------------( )( )( )( )( )( )( )( )-||");
            _writer.Write("||  \"  \"                  \"  \"  \"  \"  \"  \"  \"  \"  ||");
            _writer.Write("||  .  .  . B: show balance  .  .  .  .  .  .  .  ||");
            _writer.Write("||-( )( )( )----------------( )( )( )( )( )( )( )-||");
            _writer.Write("||  \"  \"  \"                  \"  \"  \"  \"  \"  \"  \"  ||");
            _writer.Write("||  .  .  .  . T: topup balance .  .  .  .  .  .  ||");
            _writer.Write("||-( )( )( )( )----------------( )( )( )( )( )( )-||");
            _writer.Write("||  \"  \"  \"  \"                  \"  \"  \"  \"  \"  \"  ||");
            _writer.Write("||  .  .  .  .  . A: add items     .  .  .  .  .  ||");
            _writer.Write("||-( )( )( )( )( )----------------( )( )( )( )( )-||");
            _writer.Write("||  \"  \"  \"  \"  \"                  \"  \"  \"  \"  \"  ||");
            _writer.Write("||  .  .  .  .  .  . C: close up      .  .  .  .  ||");
            _writer.Write("||-( )( )( )( )( )( )----------------( )( )( )( )-||");
            _writer.Write("||  \"  \"  \"  \"  \"  \"                  \"  \"  \"  \"  ||");
            _writer.Write("||  .  .  .  .  .  .  .                  .  .  .  ||");
            _writer.Write("||-( )( )( )( )( )( )( )----------------( )( )( )-||");
            _writer.Write("||  \"  \"  \"  \"  \"  \"  \"                  \"  \"  \"  ||");
            _writer.Write("||  .  .  .  .  .  .  .  .                  .  .  ||");
            _writer.Write("||-( )( )( )( )( )( )( )( )----------------( )( )-||");
            _writer.Write("||  \"  \"  \"  \"  \"  \"  \"  \"                  \"  \"  ||");
            _writer.Write("||  .  .  .  .  .  .  .  .  .                  .  ||");
            _writer.Write("||-( )( )( )( )( )( )( )( )( )----------------( )-||");
            _writer.Write("||  \"  \"  \"  \"  \"  \"  \"  \"  \"                  \"  ||");
            _writer.Write("||  .  .  .  .  .  .  .  .  .  .                  ||");
            _writer.Write("||-( )( )( )( )( )( )( )( )( )( )-----------------||");
            _writer.Write("||  \"  \"  \"  \"  \"  \"  \"  \"  \"  \"                  ||");
            _writer.Write("====================================================");

            string[] menuSelection = _reader.Read().ToLower().Split(" ");
            return menuSelection;

        }
    }
}
