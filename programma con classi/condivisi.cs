using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace programma_con_classi
{
    class condivisi
    {
        static List<String> ListaAccount = new List<String>();
        static public void aggiungi(string dati)
        {
            ListaAccount.Add(dati);
        }

    }
}
