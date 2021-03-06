﻿using System;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
namespace Minesweeper
{
    public partial class FormLevel : Form
    {

        //Initialize object of type Mines
        Playboard buttons = new Playboard();
        Mines mines = new Mines();
        //Number of Mines,rows and cols(of the playboard)
        private sbyte numMines;
        private sbyte rows;
        private sbyte cols;
        //Number of times clicked
        private int clicks;
        //Time played
        private int timePlayed;

        public FormLevel(sbyte mines, sbyte numRows, sbyte numCols)
        {
            InitializeComponent();
            numMines = mines;
            rows = numRows;
            cols = numCols;
        }
        // Generate the playboard of buttons and resize the form depending on level
        private void FormLevel_Load(object sender, EventArgs e)
        {
            FormLvlSelection.ActiveForm.Hide();
            if (rows == 30)
            {
                this.Size = new Size(25 * (rows + 3), 25 * (cols + 4));
            }
            else
            {
                this.Size = new Size(25 * (cols + 3), 25 * (rows + 4));
            }
            mines.Generate(numMines, rows, cols);
            Button[,] fields = new Button[rows, cols];
            int x = 25;
            int y = 40;
            for (int i = 0; i < fields.GetLength(0); i++)
            {
                for (int j = 0; j < fields.GetLength(1); j++)
                {
                    //Set all the properties and events needed to the button
                    Button btn = new Button();
                    btn.BackColor = Color.White;
                    btn.Text = "";
                    btn.Location = new Point(x + (25 * i), y + (25 * j));
                    btn.Size = new Size(25, 25);
                    btn.Name = string.Format("btnR{0}C{1}", i, j);
                    btn.Click += (sender1, ex) =>
                    {
                        ButtonClickEvent(btn, fields);          
                    };
                    btn.MouseDown += (sender2, ex2) =>
                    {
                        if (ex2.Button == MouseButtons.Right && btn.Text == "")
                        {
                            btn.Text = "B";
                        }
                        else if (ex2.Button == MouseButtons.Right && btn.Text == "B")
                        {
                            btn.Text = "";   
                        }
                    };
                    fields[i, j] = btn;
                    this.Controls.Add(btn);
                }
            }
            lblBombs.Text = string.Format("Bombs: {0}", numMines);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void changeLevelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Text = "New Game!";
        }

        private void viewHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(@"..\..\How to play minesweeper.txt");
        }

        private void aboutMinesweeperToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://en.wikipedia.org/wiki/Microsoft_Minesweeper");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timePlayed++;
            lblTime.Text = string.Format("Time played:{0}s", timePlayed);
        }
        //What to do when the button is clicked
        private void ButtonClickEvent(Button btn,Button[,] fields)
        {
            if (btn.Text == "B")
            {
                return;
            }
            mines.CheckForMines(btn, fields);
            if (btn.Text == "0")
            {
                buttons.ClearField(btn, fields);
            }
            clicks++;
            if (clicks > (rows * cols - numMines * 2))
            {
                mines.IsWinner(fields);
            }
        }
    }
}