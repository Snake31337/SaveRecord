using System;
using System.Collections.Generic;
using System.IO;

namespace Grimaldi.Leonardo._4J.SaveRecord
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Benvenuto nel programma 'Save Record' di Leonardo Grimaldi");

            Lista listaComuni = new Lista();

            listaComuni.CSVtoBin("CodiciComuni.csv", "binario");
            Console.WriteLine("Il file CSV e' stato convertito");
            Console.ReadLine();

            listaComuni.ReadBin("binario");
            Console.WriteLine("Il file binario e' stato letto");
            Console.ReadLine();

            //listaComuni.StampaLista();

            Console.WriteLine("Inserisci il codice catastale del comune");
            string codice = Console.ReadLine();

            listaComuni.CercaCodice(codice);


        }

        
    }
}
