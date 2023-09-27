using System;
using System.Collections.Generic;
using System.Linq;
using Compilador.lexico;

namespace Compilador.Interface
{
    public class Interface
    {
        public void Interface1()
        {
            Console.WriteLine("----------------- Trabalho de Compiladores -----------------");
            Console.WriteLine("----------------------- Vitor Brunor -----------------------");
            Console.WriteLine("-------------------------- Lexemas: ------------------------");

            Analex analex = new Analex();
            analex.montarLexemas();
        }
    }
}
