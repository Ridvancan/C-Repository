using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            String text = "Uzun uzun yapraklar dökülüyor ormanlar ben atama doymadım doysun kara topraklar";
            string[] metin = text.Split(' ');
            string aranacakKelime = "uzun";

            foreach (var m in metin)
            {
                if (aranacakKelime == m)
                {
                    Console.WriteLine("Aranan Kelime Bulundu...");
                }
            }
            
        }
    }
}
