using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Grimaldi.Leonardo._4J.SaveRecord
{
    class Lista
    {
        List<Comune> listaComuni = new List<Comune>();

        public void CSVtoBin(string path, string nomeBin)       // da file csv in binario
        {
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
                foreach (Comune c in listaComuni)
                {
                    bw.Write(c.Nome);
                    bw.Write(c.CodiceCatastale);
                }
            }
        }

        public void ReadBin(string path)    // leggi file binario e trasforma in lista
        {
            listaComuni.Clear();
            FileStream fs = new FileStream(path, FileMode.Open);
            BinaryReader br = new BinaryReader(fs);

            while (br.BaseStream.Position != br.BaseStream.Length)
            {
                Comune c = new Comune();

                c.Nome = br.ReadString();
                c.CodiceCatastale = br.ReadString();

                listaComuni.Add(c);
            }
        }

        public void StampaLista()
        {
            foreach(Comune c in listaComuni)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(c.Nome);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(c.CodiceCatastale);
            }
        }
        
        public void CercaCodice(string codice)
        {
            foreach(Comune c in listaComuni)
            {
                if(codice == c.CodiceCatastale)
                {
                    Console.WriteLine(c.Nome);
                }
            }
        }
    }
}
