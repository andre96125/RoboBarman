using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace programma_con_classi
{
    class thread
    {
        StreamReader sr;
        StreamWriter sw;
        public thread(TcpClient c)
        {
            sr = new StreamReader(c.GetStream());
            sw = new StreamWriter(c.GetStream());
        } 

        public void inserisci()
        {
            sw.WriteLine("invia");
            sw.Flush();
            String s = sr.ReadLine();
            condivisi.aggiungi(s);
        }
    }
}
