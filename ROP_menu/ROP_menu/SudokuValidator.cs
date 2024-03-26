using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROP_menu
{
    internal class SudokuValidator
    {
        private SudokuCell[,] cells;
        public SudokuValidator(SudokuCell[,] cells)
        {
            this.cells = cells;


        }
        public void HighlightRow(int x, int y)
        {
            for (int i = 0; i < 9; i++)
            {                           
                    cells[i, y].BackColor = Color.Red;                               
            }
        }

        public void HighlightColumn(int x, int y)
        {
            for (int i = 0; i < 9; i++)
            {                             
                    cells[x, i].BackColor = Color.Red;                                  
            }
        }

        public void HighlightBlock(int x, int y)
        {
            
            for (int i = x - (x % 3); i < x - (x % 3) + 3; i++)
            {
                for (int j = y - (y % 3); j < y - (y % 3) + 3; j++)
                {
                    cells[i,j].BackColor = Color.Red;
                }
            }
        }
       
    }    
}