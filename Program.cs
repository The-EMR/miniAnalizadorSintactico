﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace MiniSintactico
{
    class Program
    {
        int[,] tablaLR = new int[5, 4] { { 2, 0, 0, 1 }, { 0, 0, -1, 0 }, { 0, 3, 0, 0 }, { 4, 0, 0, 0 }, { 0, 0, -2, 0 } };
        static void Main(string[] args)
        {
            Program sintac = new Program();
            sintac.ejemplo1();
        }

        public void ejemplo1()
        {
            string entrada = "a+b$";
            Stack pila = new Stack();

            int fila = 0;
            int columna = 0;
            int accion = 10;

            pila.Push("$");
            pila.Push("0");

            foreach(char s in entrada)
            {
                if(accion == 0)
                {
                    Console.WriteLine("Error de sintaxis");
                    pila.Clear();
                    break;
                }
                if (char.IsLetter(s))
                    columna = 0;
                else if (s == '+')
                    columna = 1;
                else if (s == '$')
                    columna = 2;

                accion = tablaLR[fila, columna];

                if (accion > 0)
                {
                    pila.Push(s);
                    pila.Push(accion);
                }
                else
                {
                    if(s == '$')
                    {
                        accion = tablaLR[Math.Abs(accion), 2];
                        Console.WriteLine("Cadena aceptada");
                    }
                    else
                    {
                        Console.WriteLine("Error sintáctico");
                        pila.Clear();
                    }
                }

                fila = accion;
            }
            Console.WriteLine("\n Pila \n");
            while(pila.Count > 0)
            {
                Console.WriteLine(pila.Peek());
                pila.Pop();
            }

        }
    }
}
