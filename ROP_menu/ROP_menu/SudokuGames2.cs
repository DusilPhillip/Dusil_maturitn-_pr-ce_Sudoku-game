using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ROP_menu
{

    public partial class SudokuGames2 : Form

    {
        private SudokuValidator sudokuValidator;
        public SudokuGames2()
        {
            InitializeComponent();
            createCells();
            createCellsforNotes();
            startNewGame();
            sudokuValidator = new SudokuValidator(cells); // Inicializace SudokuValidator

            // Volání metody pro přiřazení událostí tlačítkům v panelu2
            AssignPanel2ButtonEvents();

            // Nastavení času spuštění hry
            gameStartTime = DateTime.Now;

            // Spuštění aktualizace zobrazení uplynulého času
            UpdateElapsedTime();

            // Inicializace timeru
            InitializeTimer();

        }
        private void InitializeTimer()
        {
            // Inicializace timeru
            timer = new Timer();
            timer.Interval = 1000; // 1 sekunda
            timer.Tick += Timer_Tick;
            timer.Start();
        }
                      
        //metoda pro resetovani casu
        private void ResetTimer()
        {
            gameStartTime = DateTime.Now;
            elapsedTime = TimeSpan.Zero;
            timer.Start();
        }
        private void StartTimer()
        {
            // Pokud čas nebyl zastaven, nemá smysl ho spouštět
            if (!timer.Enabled)
            {
                // Přidáme uplynulý čas k aktuálnímu času, abychom začali tam, kde jsme skončili
                gameStartTime = DateTime.Now - elapsedTime;
                timer.Start();
            }
        }

           // SudokuCell[,] cells = new SudokuCell[9, 9];
        Color[,] originalCellColors = new Color[9, 9];
        private TimeSpan elapsedTime;
        private Timer timer;
        private DateTime gameStartTime;




        private int lastSelectedX = -1;
        private int lastSelectedY = -1;


        private void startNewGame()
        {
            loadValues();
            int hintsCount = option_page.HintsCount;
            // Přiřazení počtu nápověd na základě 
            // zvolené úrovně hráče
            showRandomValuesHints(hintsCount);
            UpdateNoteCell();
                                      
        }
        private void UpdateElapsedTime()
        {
            // Aktualizace textu na základě uplynulé doby
            string elapsedTimeString = string.Format("{0:D2}:{1:D2}:{2:D2}",
                                                       elapsedTime.Hours,
                                                       elapsedTime.Minutes,
                                                       elapsedTime.Seconds);

            // Nastavení textu do pole v tabulce
            Table.Items[5] = elapsedTimeString;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Inkrementace uplynulé doby o jednu sekundu
            elapsedTime = DateTime.Now - gameStartTime;

            // Aktualizace zobrazení uplynulého času
            UpdateElapsedTime();
        }

        private void UpdateNoteCell()
        {
            // Aktualizuj poznámkové buňky na základě hodnot v hracím poli
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    // Pokud je buňka v hracím poli prázdná, aktualizuj odpovídající poznámkovou buňku
                    if (string.IsNullOrEmpty(cells[i, j].Text))
                    {
                        Notescells[i, j].Text = "         ";
                        Notescells[i, j].Size = new Size(40, 50);
                        Notescells[i, j].Font = new Font(SystemFonts.DefaultFont.FontFamily, 7, FontStyle.Regular);
                    }
                    else
                    {
                        if (cells[i, j].IsLocked)
                        {
                            Notescells[i, j].Text = cells[i, j].Text;
                            Notescells[i, j].Font = new Font(SystemFonts.DefaultFont.FontFamily, 20);
                            Notescells[i, j].ForeColor = Color.Black;
                        }
                        else 
                        {
                            if (IsValidInBlock(cells[i,j].Text,i,j) && IsValidInColumn(cells[i, j].Text, i, j) && IsValidInBlock(cells[i, j].Text, i, j)) {
                              
                                Notescells[i, j].Text = cells[i, j].Text;
                                Notescells[i, j].Font = new Font(SystemFonts.DefaultFont.FontFamily, 20);
                                Notescells[i, j].ForeColor = SystemColors.ControlDarkDark;
                            }  
                        }
                    }
                }
            }
        }
        private void AssignPanel2ButtonEvents()
        {
            foreach (Control control in panel2.Controls)
            {
                if (control is Button panel2Button)
                {
                    panel2Button.Click += Panel2Button_Click;
                }
            }
        }
        private void Panel2Button_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;


            if (lastSelectedX != -1 && lastSelectedY != -1)
            {
                if (cells[lastSelectedX, lastSelectedY].IsLocked)
                        return;
                else if (noteMode == false)
                {                     
                        cells[lastSelectedX, lastSelectedY].Text = clickedButton.Text;                 
                }
                else
                {
                    if (!string.IsNullOrEmpty(cells[lastSelectedX, lastSelectedY].Text) && IsValidInBlock(cells[lastSelectedX, lastSelectedY].Text, lastSelectedX, lastSelectedY) && IsValidInColumn(cells[lastSelectedX, lastSelectedY].Text, lastSelectedX, lastSelectedY) && IsValidInBlock(cells[lastSelectedX, lastSelectedY].Text, lastSelectedX, lastSelectedY))
                    {
                        return;
                    }
                    char pressedNumber = clickedButton.Text[0];
                    String currentText = Notescells[lastSelectedNoteX, lastSelectedNoteY].Text;

                    if (currentText.Length < 9)
                        currentText = currentText.PadRight(9, ' ');

                    StringBuilder newText = new StringBuilder(currentText);

                    // Nahrazení čísla na dané pozici mezerou, pokud je již obsaženo
                    for (int i = 0; i < newText.Length; i++)
                    {
                        if (newText[i] == pressedNumber)
                        {
                            newText[i] = ' ';
                            Notescells[lastSelectedNoteX, lastSelectedNoteY].Text = newText.ToString();
                            return;
                        }
                    }

                    // Uprav text buňky na základě zmáčknutého čísla
                    switch (pressedNumber)
                    {
                        case '1':
                            newText[0] = pressedNumber;
                            break;
                        case '2':
                            newText[1] = pressedNumber;
                            break;
                        case '3':
                            newText[2] = pressedNumber;
                            break;
                        case '4':
                            newText[3] = pressedNumber;
                            break;
                        case '5':
                            newText[4] = pressedNumber;
                            break;
                        case '6':
                            newText[5] = pressedNumber;
                            break;
                        case '7':
                            newText[6] = pressedNumber;
                            break;
                        case '8':
                            newText[7] = pressedNumber;
                            break;
                        case '9':
                            newText[8] = pressedNumber;
                            break;
                        default:
                            break;
                    }
                    Notescells[lastSelectedNoteX, lastSelectedNoteY].Font = new Font(SystemFonts.DefaultFont.FontFamily, 7, FontStyle.Regular);
                    Notescells[lastSelectedNoteX, lastSelectedNoteY].Size = new Size(40, 50);
                    Notescells[lastSelectedNoteX, lastSelectedNoteY].Text = newText.ToString();
                }
            }                        
        }
        // Metoda pro zachycení vybrané buňky
        private void SudokuCell_Click(object sender, CellClickedEventArgs e)
        {
            // Získání souřadnic kliknutého políčka z argumentu události
            int clickedX = e.X;
            int clickedY = e.Y;

            // Uložení souřadnic posledního vybraného políčka
            lastSelectedX = clickedX;
            lastSelectedY = clickedY;

            // Uložení souřadnic posledního vybraného políčka pro poznámky (pokud jsou aktivní)
            lastSelectedNoteX = clickedX;
            lastSelectedNoteY = clickedY;
           

        }

        Random random = new Random();

        private void showRandomValuesHints(int hintsCount)
        {
            // Zobrazení hodnoty v náhodných buňkách
            // Počet nápověd je založen na zvolené úrovni hráče
            for (int i = 0; i < hintsCount; i++)
            {
                int rX = random.Next(9);
                int rY = random.Next(9);

                // Stylujte buňky nápovědy jinak a
                // uzamkněte buňku, aby hráč nemohl upravovat hodnotu
                cells[rX, rY].Text = cells[rX, rY].Value.ToString();
                cells[rX, rY].ForeColor = Color.Black;
                cells[rX, rY].IsLocked = true;
            }
        }

        private bool infoAddedToListBox = false;
        private void loadValues()
        {
            // Vymažte hodnoty v každé buňce
            foreach (var cell in cells)
            {
                cell.Value = 0;// Nastaví hodnotu buňky na 0
                cell.Clear();// Vymaže obsah buňky

            }
            foreach (var cell in Notescells)
            {
                cell.Value = 0; // Nastaví hodnotu poznámky na 0
                cell.Clear();  // Vymaže obsah poznámky
            }
            // Projděte všechny buňky mřížky
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    // Obnova původní barvy buňky
                    cells[i, j].BackColor = originalCellColors[i, j];
                    Notescells[i, j].BackColor = originalCellColors[i, j];
                }
            }
            // Tato metoda bude volána rekurzivně - funkce znovu volána dříve, než je dokončeno její předchozí volání.
            // dokud nenajde vhodné hodnoty pro jednotlivé buňky
            findValueForNextCell(0, -1);

            string Name = Form1.NameMode;
            string gameMode = option_page.NameMode;

            if (!infoAddedToListBox)
            {
                //Table.Items.Clear(); // Vyčistíme ListBox, pokud již obsahuje nějaké položky
                Table.Items[1] += Name; //  Přidáme hodnotu name na 2 pozici
                Table.Items[2] += gameMode; // Přidáme hodnotu gameMode na 3 pozici

                infoAddedToListBox = true;
            }

        }

        private bool findValueForNextCell(int i, int j)
        {
            // Inkrementujte hodnoty i a j pro přechod na další buňku
            // a pokud skončí sloupec, přejděte na další řádek
            if (++j > 8)
            {
                j = 0;

                // Ukončete, pokud končí řádek
                if (++i > 8)
                    return true;
            }

            var value = 0;
            var numsLeft = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // Najděte náhodné a platné číslo pro buňku a přejděte na další buňku
            // a zkontrolujte, zda může být přidělena další náhodné a platné číslo
            do
            {
                // Pokud nezůstávají žádná čísla v seznamu k vyzkoušení, 
                // vraťte se k předchozí buňce a přiřaďte jiné číslo
                if (numsLeft.Count < 1)
                {
                    cells[i, j].Value = 0;
                    return false;
                }

                // Vezměte náhodné číslo ze zbývajících čísel v seznamu
                value = numsLeft[random.Next(0, numsLeft.Count)];
                cells[i, j].Value = value;

               // Odeberte přidělenou hodnotu ze seznamu
                numsLeft.Remove(value);
            }
            while (!isValidNumber(value, i, j) || !findValueForNextCell(i, j));

            // TDO: Odebrat tento řádek po testování
            //cells[i, j].Text = hodnota.ToString();

            return true;
        }

        private bool isValidNumber(int value, int x, int y)
        {
            for (int i = 0; i < 9; i++)
            {
                // Kontrola všech buněk ve svislém směru
                if (i != y && cells[x, i].Value == value)
                    return false;

                // Kontrola všech buněk vodorovně
                if (i != x && cells[i, y].Value == value)
                    return false;
            }

            // Kontrola všech buněk v konkrétním bloku
            for (int i = x - (x % 3); i < x - (x % 3) + 3; i++)
            {
                for (int j = y - (y % 3); j < y - (y % 3) + 3; j++)
                {
                    if (i != x && j != y && cells[i, j].Value == value)
                        return false;
                }
            }

            return true;
        }

        private bool IsValidInColumn(string value, int x, int y)
        {

            for (int i = 0; i < 9; i++)
            {
                if (i != y && !string.IsNullOrEmpty(cells[x, i].Text) && cells[x, i].Text.Equals(value))
                    return false;
            }

            return true;
        }
        private bool IsValidInRow(string value, int x, int y)
        {
            for (int i = 0; i < 9; i++)
            {
                if (i != x && !string.IsNullOrEmpty(cells[i, y].Text) && cells[i, y].Text.Equals(value))
                    return false;
            }

            return true;
        }
        private bool IsValidInBlock(string value, int x, int y)
        {
            string valueStr = value.ToString();
            for (int i = x - (x % 3); i < x - (x % 3) + 3; i++)
            {

                for (int j = y - (y % 3); j < y - (y % 3) + 3; j++)
                {
                    if (x != i || y != j)
                    {
                        if (cells[i, j].Text != "")
                        {
                            if (value == cells[i, j].Text) return false;
                        }
                    }
                }
            }

            return true;
        }

        public void ClearRow(int x, int y)
        {
            for (int i = 0; i < 9; i++)
            {
                cells[i, y].BackColor = originalCellColors[i, y];
            }
        }

        public void ClearColumn(int x, int y)
        {
            for (int i = 0; i < 9; i++)
            {
                cells[x, i].BackColor = originalCellColors[x, i];
            }
        }

        public void ClearBlock(int x, int y)
        {
            for (int i = x - (x % 3); i < x - (x % 3) + 3; i++)
            {
                for (int j = y - (y % 3); j < y - (y % 3) + 3; j++)
                {
                    cells[i, j].BackColor = originalCellColors[i, j];
                }
            }
        }
        private void Cell_TextChanged(object sender, EventArgs e)
        {
            var cell = sender as SudokuCell;

            bool isvalidRow = true;
            bool isvalidcolumm = true;
            bool isvalidBlock = true;

            // Aktualizovat odpovídající buňku v notescell

            if (lastSelectedX != -1 && lastSelectedY != -1)
            {
                string value = cells[lastSelectedX, lastSelectedY].Text;

                isvalidRow = IsValidInRow(value, lastSelectedX, lastSelectedY);
                isvalidcolumm = IsValidInColumn(value, lastSelectedX, lastSelectedY);
                isvalidBlock = IsValidInBlock(value, lastSelectedX, lastSelectedY);


                // HighlightRow(cell.X, cell.Y);
                
                if (isvalidRow == true) { ClearRow(lastSelectedX, lastSelectedY); }
                //MessageBox.Show("Row:" + isvalidRow);
                if (isvalidcolumm == true) { ClearColumn(lastSelectedX, lastSelectedY); }
               // MessageBox.Show("column:" + isvalidcolumm);
                if (isvalidBlock == true) { ClearBlock(lastSelectedX, lastSelectedY); }
                //MessageBox.Show("Block:" + isvalidBlock);

                HighlightInvalidCells();
                if (isvalidRow == true && isvalidcolumm == true && isvalidBlock == true)
                {
                    Notescells[cell.X, cell.Y].Text = cell.Text;
                    Notescells[cell.X, cell.Y].Font = cell.Font;
                    Notescells[cell.X, cell.Y].ForeColor = cell.ForeColor;
                }                             
                    //UpdateNoteCell();

                bool win = AreAllCellsValid();
                if (win == true)
                {
                    MessageBox.Show("you win !!!");

                    winForm WinForm=new winForm();
                    this.Hide();
                    DialogResult result = WinForm.ShowDialog();

                    if(result == DialogResult.Yes)
                    {
                        //Přidat jméno hráče, režim hry a čas do souboru TableScore.dat
                        using (BinaryWriter writer = new BinaryWriter(File.Open("TableScore.dat", FileMode.Append)))
                        {
                            string playerName = Form1.NameMode; 
                            string mode = option_page.NameMode;
                            string time = Table.Items[5].ToString(); 

                            // Zápis řetězců jako bajtů
                            writer.Write(playerName);
                            writer.Write(mode);
                            writer.Write(time);
                        }
                        MessageBox.Show("Data byla úspěšně zapsána do souboru TableScore.dat.");
                        Form1 menu = new Form1();

                        Task.Delay(250).Wait();
                        Close();
                        menu.ShowDialog();
                    }
                    else if(result == DialogResult.OK)
                    {
                        Form1 menu = new Form1();

                        Task.Delay(250).Wait();
                        Close();
                        menu.ShowDialog();
                    }
                    else if(result == DialogResult.Retry)
                    {
                        Task.Run(async () =>
                        {
                            await Task.Delay(250);

                            Application.Exit();
                        });

                    }
                }
            }

        }
        private void HighlightInvalidCells()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (IsValidInRow(cells[i, j].Text, i, j) == false)
                    {
                        sudokuValidator.HighlightRow(i, j);
                        //MessageBox.Show("row");
                    }
                    if (IsValidInColumn(cells[i, j].Text, i, j) == false)
                    {
                        sudokuValidator.HighlightColumn(i, j);
                        //MessageBox.Show("column");
                    }
                    if (IsValidInBlock(cells[i, j].Text, i, j) == false)
                    {
                        sudokuValidator.HighlightBlock(i, j);
                        //MessageBox.Show("block");
                    }
                }
            }
        }
        private bool AreAllCellsValid()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    // Kontrola, zda je buňka prázdná
                    if (string.IsNullOrEmpty(cells[i, j].Text))
                    {
                        return false; // Pokud je alespoň jedna buňka prázdná, vrátíme false
                    }
                    else
                    {
                        // Kontrola platnosti hodnoty v buňce
                        if (!IsValidInRow(cells[i, j].Text, i, j) ||
                            !IsValidInColumn(cells[i, j].Text, i, j) ||
                            !IsValidInBlock(cells[i, j].Text, i, j))
                        {
                            // Pokud alespoň jedna buňka není platná, vrátíme false
                            return false;
                        }
                    }
                }
            }
            return true; // Pokud jsou všechny buňky vyplněné a platné, vrátíme true
        }

        SudokuCell[,] cells = new SudokuCell[9, 9];
        private void createCells()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    //Create 81 cells for with styles and locations based on the index
                    cells[i, j] = new SudokuCell();
                    cells[i, j].BackColor = ((i / 3) + (j / 3)) % 2 == 0 ? SystemColors.Control : Color.LightGray;
                    // cells[i, j].CellClicked += SudokuCell_CellClicked;
                    cells[i, j].CellClicked += SudokuCell_Click;
                    cells[i, j].TextChanged += Cell_TextChanged;
                    cells[i, j].Font = new Font(SystemFonts.DefaultFont.FontFamily, 20);
                    cells[i, j].Size = new Size(40, 40);
                    cells[i, j].ForeColor = SystemColors.ControlDarkDark;
                    cells[i, j].Location = new Point(i * 40, j * 40);
                    cells[i, j].FlatStyle = FlatStyle.Flat;
                    cells[i, j].FlatAppearance.BorderColor = Color.Black;
                    cells[i, j].X = i;
                    cells[i, j].Y = j;

                    // Assign key press event for each cells
                    cells[i, j].KeyPress += cell_keyPressed;

                    panel1.Controls.Add(cells[i, j]);

                    originalCellColors[i, j] = cells[i, j].BackColor;
                }
            }
        }
       
      


        private void cell_keyPressed(object sender, KeyPressEventArgs e)
        {
            var cell = sender as SudokuCell;

            // Do nothing if the cell is locked
            if (cell.IsLocked)
                return;

            int value;

            // Add the pressed key value in the cell only if it is a number
            if (int.TryParse(e.KeyChar.ToString(), out value))
            {
                // Clear the cell value if pressed key is zero
                if (value == 0)
                {                                   
                    cell.Clear(); 
                    cell.BackColor = originalCellColors[lastSelectedX, lastSelectedY];
                    HighlightInvalidCells();
                }
                else
                    cell.Text = value.ToString();

                cell.ForeColor = SystemColors.ControlDarkDark;
            }
        }
        private void newGame_Button_Click(object sender, EventArgs e)
        {
            lastSelectedX = -1;
            lastSelectedY = -1;
            ResetTimer();
            /*System.Media.SoundPlayer sound = new System.Media.SoundPlayer(@"U:\SPŠT\RPR\RPR\Projekt\ROP_menu\ROP_menu\Resources\menu-selection-102220.wav");
            sound.Play();*/
            startNewGame();
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    // Obnova původní barvy buňky
                    bool isLocked;
                    isLocked = cells[i, j].IsLocked;
                    cells[i, j].BackColor = originalCellColors[i, j];
                    cells[i, j].ForeColor = isLocked ? Color.Black : SystemColors.ControlDarkDark;
                }
            }
        }

        private void Delete_button_Click(object sender, EventArgs e)
        {
            if (lastSelectedX != -1 && lastSelectedY != -1)
            {
                if (!cells[lastSelectedX, lastSelectedY].IsLocked)

                {
                    cells[lastSelectedX, lastSelectedY].Clear();
                    cells[lastSelectedX, lastSelectedY].BackColor = originalCellColors[lastSelectedX, lastSelectedY];
                    HighlightInvalidCells();

                }
            }
        }
        SudokuCell[,] Notescells = new SudokuCell[9, 9];
        private int lastSelectedNoteX = -1;
        private int lastSelectedNoteY = -1;
        private void createCellsforNotes()
        {
            // char[] numbers = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Notescells[i, j] = new SudokuCell();
                    Notescells[i, j].BackColor = ((i / 3) + (j / 3)) % 2 == 0 ? SystemColors.Control : Color.LightGray;
                    Notescells[i, j].Font = new Font(SystemFonts.DefaultFont.FontFamily, 7, FontStyle.Regular);
                    Notescells[i, j].CellClicked += SudokuCell_Click;
                    Notescells[i, j].Size = new Size(40, 50);
                    Notescells[i, j].ForeColor = SystemColors.ControlDarkDark;
                    Notescells[i, j].Location = new Point(i * 40, j * 50);
                    Notescells[i, j].FlatStyle = FlatStyle.Flat;
                    Notescells[i, j].FlatAppearance.BorderColor = Color.Black;
                    Notescells[i, j].X = i;
                    Notescells[i, j].Y = j;

                    /* string text = "";

                     foreach (char number in numbers)
                     {
                         text += number.ToString().ToLower();

                     */
                    Notescells[i, j].Text = "         ";
                    Notescells[i, j].KeyPress += Notescell_KeyPress;

                    panel3.Controls.Add(Notescells[i, j]);
                }
            }

        }
        private void Notescell_KeyPress(object sender, KeyPressEventArgs e)
        {
            SudokuCell cell = sender as SudokuCell;

            if (cells[lastSelectedNoteX, lastSelectedNoteY].IsLocked)
                return;
            else if (char.IsDigit(e.KeyChar))
            {
                char pressedNumber = e.KeyChar;
                string currentText = cell.Text;

                // Pokud je vstupní text menší než 9 znaků, doplň nulami
                if (currentText.Length < 9)
                    currentText = currentText.PadRight(9, ' ');

                StringBuilder newText = new StringBuilder(currentText);

                // Nahrazení čísla na dané pozici mezerou, pokud je již obsaženo
                for (int i = 0; i < newText.Length; i++)
                {
                    if (newText[i] == pressedNumber)
                    {
                        newText[i] = ' ';
                        cell.Text = newText.ToString();
                        return;
                    }
                }

                // Uprav text buňky na základě zmáčknutého čísla
                switch (pressedNumber)
                {
                    case '1':
                        newText[0] = pressedNumber;
                        break;
                    case '2':
                        newText[1] = pressedNumber;
                        break;
                    case '3':
                        newText[2] = pressedNumber;
                        break;
                    case '4':
                        newText[3] = pressedNumber;
                        break;
                    case '5':
                        newText[4] = pressedNumber;
                        break;
                    case '6':
                        newText[5] = pressedNumber;
                        break;
                    case '7':
                        newText[6] = pressedNumber;
                        break;
                    case '8':
                        newText[7] = pressedNumber;
                        break;
                    case '9':
                        newText[8] = pressedNumber;
                        break;
                    default:
                        break;
                }

                cell.Text = newText.ToString();
            }
        }

        private bool noteMode = false;
        private void button11_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
            noteMode = !noteMode;
            if (noteMode)
            {

                // Kód pro zapnutí režimu poznámek
                // Například změna textu tlačítka na "Notes: On"
                button11.Text = "Notes: On";


            }

            else
            {
                panel3.Visible = false;
                // Kód pro vypnutí režimu poznámek
                // Například změna textu tlačítka na "Notes: Off"
                button11.Text = "Notes: Off";

                // Zde můžete přidat logiku pro skrytí buněk pro poznámky
                // nebo deaktivaci režimu poznámek v herní mřížce
            }

        }

        private void button12_Click(object sender, EventArgs e)
        {
            EscMenu esc = new EscMenu();          
            timer.Stop();
            this.Hide();
            DialogResult result = esc.ShowDialog();
            
            
            if (result == DialogResult.Cancel)
            {
               StartTimer();
                esc.Close();
                this.Show();
            }
            else if (result == DialogResult.Yes)
            {
                ResetTimer();
                foreach (var cell in cells)
                {
                    // Clear the cell only if it is not locked
                    if (cell.IsLocked == false)
                    {
                        cell.Clear();

                        for (int i = 0; i < 9; i++)
                        {
                            for (int j = 0; j < 9; j++)
                            {
                                // Obnova původní barvy buňky
                                cells[i, j].BackColor = originalCellColors[i, j];
                            }
                        }
                    }
                }
                this.Show();

            }
            else if (result == DialogResult.OK)
            {
                Form1 menu = new Form1();

                /*System.Media.SoundPlayer sound = new System.Media.SoundPlayer(@"U:\SPŠT\RPR\RPR\Projekt\ROP_menu\ROP_menu\Resources\menu-selection-102220.wav");
                sound.Play();*/

                Task.Delay(250).Wait();
                Close();
                menu.ShowDialog();
            }
        }

        private void Save_button_Click(object sender, EventArgs e)
        {
            string playerName = Form1.NameMode;
            string gameMode = option_page.NameMode;
            string elapsedTime = Table.Items[5].ToString();

            // Vytvoření instance objektu pro ukládání dat do souboru
            using (BinaryWriter writer = new BinaryWriter(File.Open("sudoku.dat", FileMode.Create)))
            {
                // Uložení základních informací
                writer.Write(playerName);
                writer.Write(gameMode);
                writer.Write(elapsedTime);

                // Uložení hodnot buněk do souboru
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        // Uložení hodnoty buňky a informace o uzamčení
                        writer.Write(cells[i, j].Text); // Uložení hodnoty buňky
                        writer.Write(cells[i, j].IsLocked); // Uložení informace o uzamčení
                    }
                }
            }

            MessageBox.Show("Sudoku game saved successfully!");

            Form1 menu = new Form1();

            Task.Delay(250).Wait();
            Close();
            menu.ShowDialog();
        }
        private void LoadButton_Click(object sender, EventArgs e)
        {
            // Kontrola existence souboru
            if (File.Exists("sudoku.dat"))
            {
                // Dotaz uživatele na potvrzení před načtením uložené hry
                DialogResult result = MessageBox.Show("Do you want to load the saved game? Current game progress will be lost.", "Load Game", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Vymazání původních dat hry
                    ClearGameData();

                    // Vytvoření instance objektu pro načítání dat ze souboru
                    using (BinaryReader reader = new BinaryReader(File.Open("sudoku.dat", FileMode.Open)))
                    {
                        // Načtení informací o hráči, herním módu a čase
                        string playerName = reader.ReadString();
                        string gameMode = reader.ReadString();
                        string elapsedTime2 = reader.ReadString();

                        // Nastavení informací o hráči a herním módu v tabulce
                        Table.Items[1] = "Name:" + playerName;
                        Table.Items[2] = "Mode:" + gameMode;

                        // Převedení načteného času do TimeSpan
                        TimeSpan loadedElapsedTime;
                        TimeSpan.TryParse(elapsedTime2, out loadedElapsedTime);

                        // Nastavení aktuálního času hry na načtený čas
                        elapsedTime = loadedElapsedTime;
                        gameStartTime = DateTime.Now - elapsedTime;

                        // Aktualizace zobrazení uplynulého času
                        UpdateElapsedTime();

                        // Načtení hodnot buněk ze souboru
                        for (int i = 0; i < 9; i++)
                        {
                            for (int j = 0; j < 9; j++)
                            {
                                // Pokud nejsme na konci souboru, pokračujeme v čtení dat
                                if (reader.PeekChar() != -1)
                                {
                                    // Načtení textu buňky
                                    string cellText = reader.ReadString();

                                    // Pokud je buňka uzamčená, načtěte příznak uzamčení
                                    bool isLocked = reader.ReadBoolean();

                                    // Nastavení hodnoty a stavu uzamčení buňky
                                    cells[i, j].Text = cellText;
                                    cells[i, j].IsLocked = isLocked;

                                    // Pokud je buňka uzamčená, nastavte barvu textu na černou, jinak na šedou
                                    cells[i, j].ForeColor = isLocked ? Color.Black : SystemColors.ControlDarkDark;

                                    // Validace buněk, pokud je třeba
                                    if (IsValidInRow(cells[i, j].Text, i, j) == false)
                                    {
                                        sudokuValidator.HighlightRow(i, j);
                                        //MessageBox.Show("row");
                                    }
                                    if (IsValidInColumn(cells[i, j].Text, i, j) == false)
                                    {
                                        sudokuValidator.HighlightColumn(i, j);
                                        //MessageBox.Show("column");
                                    }
                                    if (IsValidInBlock(cells[i, j].Text, i, j) == false)
                                    {
                                        sudokuValidator.HighlightBlock(i, j);
                                        //MessageBox.Show("block");
                                    }
                                }
                                else
                                {
                                    // Pokud jsme dosáhli konce souboru, ukončíme smyčku
                                    break;
                                }
                            }
                        }
                    }

                    UpdateNoteCell();
                    MessageBox.Show("Sudoku game loaded successfully!");
                }
            }
            else
            {
                MessageBox.Show("No saved game found!");
            }
        }

        private void ClearGameData()
        {
            // Vymazání textu z buněk
            foreach (var cell in cells)
            {
                cell.Text = "";
            }
        }

        private void Hint_Button_Click(object sender, EventArgs e)
        {
            if (lastSelectedNoteX != -1 || lastSelectedNoteY != -1)
            {
                string validValue = GetValidValueForCell(lastSelectedX, lastSelectedY);

                if (!string.IsNullOrEmpty(validValue))
                {
                    cells[lastSelectedX, lastSelectedY].Text = validValue;

                    // Zvýšení času o 10 sekund
                    elapsedTime = elapsedTime.Add(TimeSpan.FromSeconds(10));
                    gameStartTime -= TimeSpan.FromSeconds(10);
                    UpdateElapsedTime();
                    // Spuštění aktualizace zobrazení uplynulého času


                }
                else
                {
                    MessageBox.Show("Žádná platná hodnota.");
                }
            }
            else
            {
                MessageBox.Show("Vyberte pole");
            }
    }
        private string GetValidValueForCell(int x, int y)
        {
            for (int value = 1; value <= 9; value++)
            {
                string valueString = value.ToString();

                if (IsValidInRow(valueString, x, y) && IsValidInColumn(valueString, x, y) && IsValidInBlock(valueString, x, y))
                {
                    return valueString;
                }
            }

            return null; // Pokud žádná platná hodnota není nalezena
        }
    }
}

