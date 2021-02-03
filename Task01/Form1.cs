using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task01
{
    //    1. а) Добавить в программу «Удвоитель» подсчет количества отданных команд.
    //       б) Добавить меню и команду «Играть». При нажатии появляется сообщение, какое число должен получить игрок.
    //          Игрок должен постараться получить это число за минимальное количество ходов.
    //       в) * Добавить кнопку «Отменить», которая отменяет последние ходы.
    public partial class Удвоитель : Form
    {
        private int counter = 0;
        private Dictionary<int, int> undoNumbers = new Dictionary<int, int>();
        private bool isStart = false;

        public Удвоитель()
        {
            InitializeComponent();
            btnCommand1.Text = "+1";
            btnCommand2.Text = "x2";
            btnReset.Text = "Сброс";
            lblNumber.Text = "0";
            Text = "Удвоитель";
            lblRndNumTxt.Visible = false;
            btnUndo.Visible = false;
        }

        private void btnCommand1_Click(object sender, EventArgs e)
        {
            lblNumber.Text = (int.Parse(lblNumber.Text) + 1).ToString();
            counter++;
            UndoNumberPlus();
            CheckMatch();
        }

        private void btnCommand2_Click(object sender, EventArgs e)
        {
            lblNumber.Text = (int.Parse(lblNumber.Text) * 2).ToString();
            counter++;
            UndoNumberPlus();
            CheckMatch();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            lblNumber.Text = "0";
            counter++;
            UndoNumberPlus();
        }

        #region Task 1.1(б)
        private void playMenuStrip_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int number = random.Next(1, 100); ;
            MessageBox.Show($"Вам нужно получить число {number}.");
            labelRandomNumber.Text = number.ToString();
            lblNumber.Text = "0";
            lblRndNumTxt.Visible = true;
            btnUndo.Visible = true;
            isStart = true;
            counter = 0;
            undoNumbers[0] = 0;
        }

        private void CheckMatch()
        {
            if (isStart)
            {
                if (int.Parse(lblNumber.Text) == int.Parse(labelRandomNumber.Text))
                {
                    MessageBox.Show($"Вы подобрали нужное число за {counter} ходов.");
                    lblNumber.Text = "0";
                    labelRandomNumber.Text = " ";
                    lblRndNumTxt.Visible = false;
                    counter = 0;
                    btnUndo.Visible = false;
                    isStart = false;
                }
            }
        }
        #endregion

        #region Task 1.3(в)
        private void btnUndo_Click(object sender, EventArgs e)
        {
            if (counter > 0)
            {
                counter--;
                lblNumber.Text = undoNumbers[counter].ToString();
            }
            else
            {
                MessageBox.Show("Это и есть нулевой ход.");
            }
        }

        private void UndoNumberPlus()
        {
            if(isStart)
            undoNumbers[counter] = int.Parse(lblNumber.Text);
        }
        #endregion
    }
}
