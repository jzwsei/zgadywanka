using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameModel;

namespace GameGui
{
    public partial class Form1 : Form
    {
        private Game model;

        public Form1()
        {
            InitializeComponent();
            this.updateStatus();
        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            this.model = new Game(0, int.Parse(numericUpDown1.Value.ToString()));
            listBox1.Items.Clear();
            switchControls(true);
            this.updateStatus();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.model.GiveUp();
            this.updateStatus();
        }

        private void switchControls(bool mode)
        {
            button1.Enabled = !mode;
            numericUpDown1.Enabled = !mode;

            button2.Enabled = mode;
            button3.Enabled = mode;
            numericUpDown2.Enabled = mode;
        }

        private void updateStatus()
        {
            string text = "";

            if (this.model == null)
            {
                text = "Naciśnij 'Nowa gra' by rozpocząć";
            }
            else
            {
                switch (this.model.State)
                {
                    case Game.GameState.During:
                        text = "W grze. Liczba ruchów: " + this.model.MovesCounter;
                        break;
                    case Game.GameState.GaveUp:
                        text = "Poddałeś się po " + this.model.MovesCounter + " ruchach";
                        this.switchControls(false);
                        break;
                    case Game.GameState.Won:
                        text = "Gratulacje, odgadłeś liczbę po " + this.model.MovesCounter + " ruchach!";
                        this.switchControls(false);
                        break;
                }
            }

            toolStripStatusLabel1.Text = text;
        }

        private void ToolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            this.model.CheckAnswer(int.Parse(this.numericUpDown2.Value.ToString()));
            listBox1.Items.Add(this.model.History[this.model.History.Count - 1].ToString());
            this.updateStatus();
        }

        private void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
