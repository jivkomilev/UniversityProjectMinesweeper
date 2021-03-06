﻿using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Minesweeper
{
    class Playboard
    {
        //Find and click all mines
        public void ClickBombs(Button[,] playboard, sbyte[,] fields)
        {
            for (int i = 0; i < playboard.GetLength(0); i++)
            {
                for (int j = 0; j < playboard.GetLength(1); j++)
                {
                    if (fields[i, j] == 1)
                    {
                        playboard[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                        playboard[i, j].BackgroundImage = Properties.Resources.bomb;
                        playboard[i, j].Enabled = false;
                    }
                }
            }
        }

        //Click all fields around the clicked field 
        public void ClearField(Button clickedButton, Button[,] playBoard)
        {
            //Get coordinates from the name of the clicked field
            int[] rowCol = clickedButton.Name.ToString().Split(new string[] { "btnR", "C" }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int row = rowCol[0];
            int col = rowCol[1];

            if (row == 0)
            {
                if (col == 0)
                {
                    playBoard[row, col + 1].PerformClick();
                    playBoard[row + 1, col].PerformClick();
                    playBoard[row + 1, col + 1].PerformClick();
                }
                else if (col == playBoard.GetLength(1) - 1)
                {
                    playBoard[row + 1, col].PerformClick();
                    playBoard[row + 1, col - 1].PerformClick();
                    playBoard[row, col - 1].PerformClick();
                }
                else
                {
                    playBoard[row, col - 1].PerformClick();
                    playBoard[row, col + 1].PerformClick();
                    playBoard[row + 1, col - 1].PerformClick();
                    playBoard[row + 1, col].PerformClick();
                    playBoard[row + 1, col + 1].PerformClick();
                }
            }
            else if (row == playBoard.GetLength(0) - 1)
            {
                if (col == 0)
                {
                    playBoard[row, col + 1].PerformClick();
                    playBoard[row - 1, col].PerformClick();
                    playBoard[row - 1, col + 1].PerformClick();
                }
                else if (col == playBoard.GetLength(1) - 1)
                {
                    playBoard[row - 1, col].PerformClick();
                    playBoard[row - 1, col - 1].PerformClick();
                    playBoard[row, col - 1].PerformClick();
                }
                else
                {
                    playBoard[row, col - 1].PerformClick();
                    playBoard[row, col + 1].PerformClick();
                    playBoard[row - 1, col - 1].PerformClick();
                    playBoard[row - 1, col].PerformClick();
                    playBoard[row - 1, col + 1].PerformClick();
                }
            }
            else if (col == 0)
            {
                playBoard[row, col + 1].PerformClick();
                playBoard[row - 1, col].PerformClick();
                playBoard[row - 1, col + 1].PerformClick();
                playBoard[row + 1, col].PerformClick();
                playBoard[row + 1, col + 1].PerformClick();
            }
            else if (col == playBoard.GetLength(1) - 1)
            {
                playBoard[row, col - 1].PerformClick();
                playBoard[row - 1, col].PerformClick();
                playBoard[row - 1, col - 1].PerformClick();
                playBoard[row + 1, col].PerformClick();
                playBoard[row + 1, col - 1].PerformClick();
            }
            else
            {
                playBoard[row, col - 1].PerformClick();
                playBoard[row, col + 1].PerformClick();
                playBoard[row - 1, col - 1].PerformClick();
                playBoard[row - 1, col].PerformClick();
                playBoard[row - 1, col + 1].PerformClick();
                playBoard[row + 1, col - 1].PerformClick();
                playBoard[row + 1, col].PerformClick();
                playBoard[row + 1, col + 1].PerformClick();
            }
        }
    }
}