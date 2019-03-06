using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// This is the code for your desktop app.
// Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.

namespace DesktopApp1
{


    public partial class Form1 : Form
    {
        private string userid;
        private const string serverIP = "127.0.0.1";

        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            Form2 id_form = new Form2();
            id_form.ShowDialog();
            userid = id_form.name;
            Text = "Harmony -- " + userid;
        }

        private void Form1_Shown(Object sender, EventArgs e)
        {
            SetupConnection();
        }

        private void SetupConnection()
        {
            Label l = new Label();
            l.Text = "Attendez -- connexion en cours";

            // Afficher un label temporaire, au centre de la fenêtre
            Size sz = Size;
            l.Size = sz;
            l.TextAlign = ContentAlignment.MiddleCenter;
            Controls.Add(l);

            // Tenter de contacter le socket du serveur
            IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Parse(serverIP),
                                            20000);
            // Create a TCP/IP  socket.  
            Socket sender = new Socket(localEndPoint.AddressFamily,
                SocketType.Stream, ProtocolType.Tcp);

            Console.WriteLine("Socket créé");
            sender.Connect(localEndPoint);
            Console.WriteLine("Socket connecté");


            // Protocole : 
            // 1. On envoie notre version de protocole (int32) et on reçoit celle du serveur (int 32)
            // 1. envoyer sous forme de string < 1024 caractères le groupe auquel on appartient
            // 2. envoyer sous forme de string < 1024 caractères le nom de user dans ce groupe
            // 3. obtenir la liste des gens connectés
            // 4. se "connecter" à un user spécifique de la liste
            // 5. lire / écrire des caractères jusqu'a la déconnexion
            int size;


            // Envoyer notre version

            // Lire la version du serveur
            int srvVersion;
            byte[] srvVersionByte = new byte[4];
            size = sender.Receive(srvVersionByte);

            srvVersion = BitConverter.ToInt32(srvVersionByte, 0);
            Console.WriteLine("Version du serveur = '{0}'", srvVersion);



            // Maintenant, lire la liste des gens connectés
            byte[] msg = new byte[1024];
            size = sender.Receive(msg);

            String liste;
            liste = Encoding.Unicode.GetString(msg);
            MessageBox.Show(liste);


        }
    }
}
