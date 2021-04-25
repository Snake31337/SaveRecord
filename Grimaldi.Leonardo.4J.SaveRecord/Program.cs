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

            CSVtoBin("CodiciComuni.csv", "binario");

        }

        public static void CSVtoBin(string path, string nomeBin)
        {
            List<Comune> listaComuni = new List<Comune>();


            string line;
            using (StreamReader reader = new StreamReader(path))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    var splits = line.Split(',');

                    Comune c = new Comune();
                    c.Nome = splits[1];
                    c.CodiceCatastale = splits[0];

                    listaComuni.Add(c);
                }
            }

            using (BinaryWriter bw = new BinaryWriter(File.Open(nomeBin, FileMode.Create)))
            {
                foreach(Comune c in listaComuni)
                {
                    bw.Write(c.Nome);
                    bw.Write(c.CodiceCatastale);
                }
            }
        }

        public static void ReadBin(string path)
        {
            using (FileStream fs = File.OpenRead(path))
            using (BinaryReader reader = new BinaryReader(fs))
            {
                // Read in all pairs.
                while (reader.BaseStream.Position != reader.BaseStream.Length)
                {
                    Item item = new Item();
                    item.UniqueId = reader.ReadString();
                    item.StringUnique = reader.ReadString();
                    result.Add(item);
                }
            }
            return result;
        }
    }
}
