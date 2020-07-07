﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            //DortIslem dislem =new  DortIslem(2,3);
            //Console.WriteLine( dislem.Topla2());
            //Console.WriteLine(dislem.Topla(3,4)) ;
            var tip = typeof(DortIslem);
            DortIslem dortIslem= (DortIslem) Activator.CreateInstance(tip,6,7); // DortIslem dislem =new  DortIslem(2,3); aynı şey ama runtime
            Console.WriteLine(dortIslem.Topla(4, 5)  );
            Console.WriteLine(dortIslem.Topla2()); 
            Console.ReadLine();
        }

    }
    public class DortIslem
    {
        int _sayi1;
        int _sayi2;
        public DortIslem(int sayi1,int sayi2)
        {
            _sayi1 = sayi1;
            _sayi2 = sayi2;
        }
        public int Topla(int sayi1,int sayi2)
        {
            return sayi1 + sayi2;
        }
        public int Carp(int sayi1, int sayi2)
        {
            return sayi1 * sayi2;
        }
        public int Topla2()
        {
            return _sayi1 + _sayi2;
        }
        public int Carp2()
        {
            return _sayi1 * _sayi2;
        }


    }
}
