using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ROP_menu
{
    internal class SudokuCell : Button
    {
        public event EventHandler<CellClickedEventArgs> CellClicked;
        public int Value { get; set; }
        public bool IsLocked { get; set; }
        public int X { get; set; }
        public int Y { get; set; }



        public void Clear()
        {
            this.Text = string.Empty;
            this.IsLocked = false;
            this.BackColor = SystemColors.Control; // Vrátí původní barvu
         
        }
        public SudokuCell()
        {
            this.Click += SudokuCell_Click;
          
        }

        private void SudokuCell_Click(object sender, EventArgs e)
        {
            SudokuCell clickedCell = sender as SudokuCell;

            CellClicked?.Invoke(this, new CellClickedEventArgs(clickedCell.X, clickedCell.Y));

            // Highlight cells in the same row           
            
        }
    }
}
