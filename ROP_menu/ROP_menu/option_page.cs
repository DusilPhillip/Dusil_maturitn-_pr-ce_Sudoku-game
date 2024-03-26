using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ROP_menu
{
    public partial class option_page : Form // Definuje třídu "option_page" jako podtřídu formuláře
    {
        // Konstruktor třídy "option_page"
        public option_page()
        {
            InitializeComponent(); // Inicializuje komponenty formuláře
        }

        // Statická vlastnost pro uchování počtu nápověd v obtížnosti
        public static int HintsCount { get; private set; } = 45;

        // Statická vlastnost pro uchování vybrané obtížnosti hry
        public static string NameMode { get; private set; } = "Easy";

        // Událost při posunu trackbaru (posuvníku)
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            // Přehrávání zvuku
            Form1.wplay.controls.play();
            // Nastavení ikony zvuku podle aktuální hodnoty
            Sound_on.Image = Properties.Resources.sound_on;
            // Nastavení hlasitosti na hodnotu trackbaru
            Form1.wplay.settings.volume = trackBar1.Value;

            // Pokud je hlasitost na nule, změní ikonu na vypnutý zvuk
            if (trackBar1.Value == 0)
            {
                Sound_on.Image = Properties.Resources.sound_off;
            }
        }

        // Událost kliknutí na tlačítko "exit_button2"
        private void exit_button2_Click(object sender, EventArgs e)
        {
            // Přehrávání zvuku
            System.Media.SoundPlayer sound = new System.Media.SoundPlayer(@".\music\menu-selection-102220.wav");
            sound.Play();

            // Nastavení obtížnosti a počtu nápověd podle vybrané možnosti
            if (radioButton1.Checked)
            {
                NameMode = radioButton1.Text;
                HintsCount = 45;
            }
            else if (radioButton2.Checked)
            {
                NameMode = radioButton2.Text;
                HintsCount = 35;
            }
            else if (radioButton3.Checked)
            {
                NameMode = radioButton3.Text;
                HintsCount = 20;
            }

            // Zavření okna s přestávkou
            Task.Delay(250).Wait();
            Close();
        }

        // Událost, když myš najede na tlačítko "exit_button2"
        private void exit_button2_MouseHover(object sender, EventArgs e)
        {
            // Přehrávání zvuku
            System.Media.SoundPlayer sound2 = new System.Media.SoundPlayer(@".\music\background sound.wav");
            sound2.Play();
            // Změna obrázku na tlačítku na hover verzi
            exit_button2.Image = Properties.Resources.exit_hover;
        }

        // Událost, když myš opustí tlačítko "exit_button2"
        private void exit_button2_MouseLeave(object sender, EventArgs e)
        {
            // Změna obrázku na tlačítku zpět na normální verzi
            exit_button2.Image = Properties.Resources.exit_normal;
        }
    }
}
