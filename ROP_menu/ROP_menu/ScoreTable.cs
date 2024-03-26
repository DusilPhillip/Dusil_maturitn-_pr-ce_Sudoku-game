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

namespace ROP_menu
{
    public partial class ScoreTable : Form
    {
        public ScoreTable()
        {
            InitializeComponent();
            
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Close(); // Zavře aktuální formulář TableScore
            
        }
        private void LoadScoreData()
        {
            try
            {
                // Otevřete soubor pro čtení binárních dat
                using (BinaryReader reader = new BinaryReader(File.Open("TableScore.dat", FileMode.Open)))
                {
                    // Čtěte data ze souboru
                    while (reader.BaseStream.Position < reader.BaseStream.Length)
                    {
                        // Čtěte data ze souboru ve stejném pořadí, v jakém byla zapsána
                        string playerName = reader.ReadString();
                        string mode = reader.ReadString();
                        string time = reader.ReadString();

                        // Přidejte řádek do DataGridView
                        dataGridView1.Rows.Add(playerName, mode, time);
                    }
                }
            }
            catch (Exception ex)
            {
                // Zobrazte chybu, pokud dojde k problému při načítání dat
                MessageBox.Show("Chyba při načítání dat ze souboru: " + ex.Message);
            }
        }

        private void ScoreTable_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Add("PlayerName", "Player Name");
            dataGridView1.Columns.Add("GameMode", "Game Mode");
            dataGridView1.Columns.Add("Time", "Time");
            LoadScoreData();
        }
        private void Sort(string searchText, string sortBy)
        {
            // Procházíme pouze platné řádky (bez nově vytvořeného řádku)
            foreach (DataGridViewRow row in dataGridView1.Rows.Cast<DataGridViewRow>().Where(r => !r.IsNewRow))
            {
                // Kontrola, zda hodnota buňky není null a zda obsahuje hledaný text
                if (row.Cells[sortBy].Value != null && row.Cells[sortBy].Value.ToString().Contains(searchText))
                {
                    row.Visible = true; // Pokud řádek odpovídá zadanému textu, zobrazíme ho
                }
                else
                {
                    row.Visible = false; // Pokud řádek neodpovídá zadanému textu, skryjeme ho
                }
            }
        }



        private void button2_Click(object sender, EventArgs e)
        {
            string searchText = textBox1.Text.Trim(); // Získání textového řetězce ze vstupního pole
            string sortBy = ""; // Sloupec, podle kterého budeme třídit

            // Určení sloupce, podle kterého se bude třídit, na základě vybraného RadioButtonu
            if (radioButton1.Checked)
            {
                sortBy = "playerName";
            }
            else if (radioButton2.Checked)
            {
                sortBy = "GameMode";
            }
            else if (radioButton3.Checked)
            {
                sortBy = "time";
            }

            // Zavolejte metodu Sort s textem a sloupcem
            Sort(searchText, sortBy);
        }
    }
}
