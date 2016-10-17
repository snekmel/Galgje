using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Galgje
{
    public partial class Form1 : Form
    {

        List<char> UserInput = new List<char>();
        string Antwoord = "woord";
        int VorigeZet = 0;
        int ButtonCounter = 0;



        public int WoordLabelUpdater()
        {

            string ResultString = null;
            int GoedeAntwoorden = 0;

            foreach (char letter in Antwoord)
            {


                if (UserInput.Contains(letter))
                {
                    ResultString = ResultString + letter;
                    GoedeAntwoorden++;
                }
                else
                {
                    ResultString = ResultString + "-";
                }

            }

            label2.Text = ResultString;


            if (ResultString == Antwoord)
            {
                MessageBox.Show("Gewonnen!");
                System.Threading.Thread.Sleep(3);
                this.Close();
            }

            return GoedeAntwoorden;
        }

        public void LabelUpdater(int AantalGoed)
        {

            if (AantalGoed == VorigeZet)
            {

                label6.Text = Convert.ToString(Convert.ToInt32(label6.Text) + 1);
            }
            else
            {
                label5.Text = Convert.ToString(Convert.ToInt32(label5.Text) + 1);

            }
        }


        public Form1()
        {

            InitializeComponent();
            WoordLabelUpdater();

            label5.Text = "0";
            label6.Text = "0";
        }

        private void button1_Click(object sender, EventArgs e)
        {



            ButtonCounter++;


            //Voeg het antwoord toe aan een list en clear de box
            UserInput.Add(Convert.ToChar(textBox1.Text));
            textBox1.Text = "";


            //Woordlabel updater returnt het aantal goede
            int AantalGoedInDezeZet = WoordLabelUpdater();

            //Labelupdater vergelijk het aantal goede met de vorige zet
            LabelUpdater(AantalGoedInDezeZet);

            //Zet de waarden in VorigeZet voor de volgende zet
            VorigeZet = AantalGoedInDezeZet;


            //Kijk of dat er 10 zetten gedaan zijn
            if (ButtonCounter == 10)
            {
                MessageBox.Show("Verloren!, er zijn meer dan 10 zetten geweest");
                System.Threading.Thread.Sleep(3);
                this.Close();
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
