using System;
using System.Collections.Generic;
using System.Text;

namespace Grimaldi.Leonardo._4J.SaveRecord
{
    class Comune
    {
        string nome;

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        string codiceCatastale;

        public string CodiceCatastale
        {
            get { return codiceCatastale; }
            set { codiceCatastale = value; }
        }
    }
}
