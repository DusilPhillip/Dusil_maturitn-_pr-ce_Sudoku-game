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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            wplay.URL = @"music\loop-menu-preview-109594.wav";
            wplay.controls.play();
            axWindowsMediaPlayer1.Hide();
            wplay.PlayStateChange += new WMPLib._WMPOCXEvents_PlayStateChangeEventHandler(wplay_PlayStateChange);

        }
        public static string NameMode { get; private set; }
        
        private async void wplay_PlayStateChange(int newState)
        {
            int delayMilliseconds = 1000;
            if ((WMPLib.WMPPlayState)newState == WMPLib.WMPPlayState.wmppsStopped)
            {
               
                await Task.Delay(delayMilliseconds);//delay na 1 sekunda
                // Hudba skončila, takže ji znovu spusťte
                wplay.controls.play();
            }
        }

        public static WMPLib.WindowsMediaPlayer wplay = new WMPLib.WindowsMediaPlayer();

//Grafika
//--------------------------------------------------------------------------------
        private void start_button_MouseHover(object sender, EventArgs e)
        {
            start_button.Image=Properties.Resources.start_hover;
           System.Media.SoundPlayer sound2 = new System.Media.SoundPlayer(@".\music\background sound.wav");
            sound2.Play();
        }

        private void option_button_MouseHover(object sender, EventArgs e)
        {
            option_button.Image=Properties.Resources.option_hover;
            System.Media.SoundPlayer sound2 = new System.Media.SoundPlayer(@".\music\background sound.wav");
            sound2.Play();
        }

        private void exit_button_MouseHover(object sender, EventArgs e)
        {
            exit_button.Image=Properties.Resources.exit_hover;
            System.Media.SoundPlayer sound2 = new System.Media.SoundPlayer(@".\music\background sound.wav");
            sound2.Play();
        }

        private void HighScore_Button_MouseHover(object sender, EventArgs e)
        {

        }

        private void start_button_MouseLeave(object sender, EventArgs e)
        {
            start_button.Image = Properties.Resources.start_normal;
        }

        private void option_button_MouseLeave(object sender, EventArgs e)
        {
            option_button.Image=(Properties.Resources.option_normal);
        }

        private void exit_button_MouseLeave(object sender, EventArgs e)
        {
            exit_button.Image =(Properties.Resources.exit_normal);
        }
//--------------------------------------------------------------------------------------------
        private void start_button_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                NameMode = textBox1.Text;
                System.Media.SoundPlayer sound = new System.Media.SoundPlayer(@".\music\menu-selection-102220.wav");

                sound.Play();
                // Game_Sudoku game_Sudoku = new Game_Sudoku(); game_Sudoku.ShowDialog();
                SudokuGames2 Sudoku = new SudokuGames2();
                Sudoku.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Zadejte Jméno");
            }
        }

        private void option_button_Click(object sender, EventArgs e)
        {
            System.Media.SoundPlayer sound = new System.Media.SoundPlayer(@".\music\menu-selection-102220.wav");
            sound.Play();
            option_page option = new option_page();
            option.ShowDialog();
        }

        private void exit_button_Click(object sender, EventArgs e)
        {
           System.Media.SoundPlayer sound = new System.Media.SoundPlayer(@".\music\menu-selection-102220.wav");
            sound.Play();

            Task.Run(async () =>
            {
                await Task.Delay(250);

                Application.Exit();
            });

        }

        private void HighScore_Button_Click(object sender, EventArgs e)
        {
            System.Media.SoundPlayer sound = new System.Media.SoundPlayer(@".\music\menu-selection-102220.wav");
            sound.Play();

            // Otevření formuláře s tabulkou skóre
            ScoreTable scoreTableForm = new ScoreTable();
            this.Hide();
            scoreTableForm.ShowDialog();
        }
    }
}
