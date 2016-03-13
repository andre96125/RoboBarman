using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InTheHand;
using InTheHand.Net.Bluetooth;
using InTheHand.Net.Sockets;
using InTheHand.Net;
using InTheHand.Net.Ports;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using ExtendCSharp;

namespace programma_con_classi
{
    public partial class Form1 : Form
    {
        private Guid service = BluetoothService.SerialPort;
        private BluetoothClient bluetoothClient;
        condivisi dati = new condivisi();
        List<Thread> ListaThread = new List<Thread>();
        TcpListener Listener;
        Thread ricerca_connessioni;

        public Form1()
        {
            InitializeComponent();
            Listener = new TcpListener(3334);
            CheckForIllegalCrossThreadCalls = false;
            
        }

      

        private void button2_Click(object sender, EventArgs e)
        {
            ricerca_connessioni = new Thread(()=>{
                connetti();
            }); 
        }

        private void connetti()
        {
            
            Listener.Start();
            while (true)
            {

                TcpClient c = Listener.AcceptTcpClient();
                
                new Thread((object o) =>
                {
                    TcpClient cc = (TcpClient)o;
                    thread t = new thread(cc);
                    t.main();

                }).Start(c);


            }
        }

       

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Listener.Stop();
            ricerca_connessioni.Abort();
            //Conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Listener.Stop();
        }

       
    }
}
