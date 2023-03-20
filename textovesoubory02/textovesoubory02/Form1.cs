using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace textovesoubory02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StreamReader cistcisla = new StreamReader("cisla.txt");
            FileStream datovytok = new FileStream("cisla.dat",FileMode.OpenOrCreate,FileAccess.ReadWrite);
            BinaryWriter zapisovac = new BinaryWriter(datovytok, Encoding.GetEncoding("windows-1250"));
            while (!cistcisla.EndOfStream)
            {
                int cislo = int.Parse(cistcisla.ReadLine());
                zapisovac.Write(cislo);
            }
            //zapisovac.Close();
            BinaryReader ctenar = new BinaryReader(datovytok, Encoding.GetEncoding("windows-1250"));
            ctenar.BaseStream.Position = 0; // kurzor na zacatek
            while(ctenar.BaseStream.Position < ctenar.BaseStream.Length)
            {
                listBox1.Items.Add(ctenar.ReadInt32());
                

            }
            ctenar.Close();
            datovytok.Close();
            cistcisla.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialogotevreni = new OpenFileDialog();
            dialogotevreni.InitialDirectory = Application.StartupPath;
            if (dialogotevreni.ShowDialog() == DialogResult.OK)
            {
                FileStream datovytok = new FileStream("cisla.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                StreamWriter zapisovac = new StreamWriter("cisilka.txt",false, Encoding.GetEncoding("windows-1250"));
                BinaryReader ctenar = new BinaryReader(datovytok, Encoding.GetEncoding("windows-1250"));
                while (ctenar.BaseStream.Position < ctenar.BaseStream.Length)
                {
                    zapisovac.WriteLine(ctenar.ReadInt32());
                }
                //string jmenosouboru = dialogotevreni.FileName;
                //delej veci
                ctenar.Close();
                zapisovac.Close();
                datovytok.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StreamReader read = new StreamReader("cisilka.txt");
            

            SaveFileDialog dialogulozit = new SaveFileDialog();
            dialogulozit.InitialDirectory = Application.StartupPath;
            if (dialogulozit.ShowDialog() == DialogResult.OK)
            {
                //delej veci
                while (!read.EndOfStream)
                {
                    listBox2.Items.Add(read.ReadLine());
                }
            }
            read.Close();
        }
    }
}
