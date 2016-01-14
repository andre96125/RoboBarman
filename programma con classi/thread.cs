﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using ExtendCSharp;
using System.Windows.Forms;

namespace programma_con_classi
{
    class thread
    {
        StreamReader sr;
        StreamWriter sw;
        MySQLext Conn;

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

        public void inserimentoDB(string nome, string value)
        {
            Conn = new MySQLext("localhost", "test", "root", "");
            string istruzione = "insert into test(" + nome + ") values('" + value + "')";
            Conn.ExecuteQuery(istruzione);
            Conn.Close();
        }

        public void ricercaDB(int ID, string nome)
        {
            Conn = new MySQLext("localhost", "test", "root", "");
            List<Type> l = new List<Type>();
            l.Add(typeof(int));
            l.Add(typeof(String));

            string istruzione = "select " + ID + "," + nome + " from test";
            List<object[]> ll = Conn.ExecuteReaderQuery(istruzione, l);

            foreach (object[] o in ll)
            {
                (Application.OpenForms["Form1"] as Form1).Controls["textBox1"].Text += (int)o[0] + " " + (String)o[1]; 
            }
            Conn.Close();
        }
    }
}
