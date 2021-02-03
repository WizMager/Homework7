using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task02
{
    //  2. Используя Windows Forms, разработать игру «Угадай число». Компьютер загадывает число от 1 до 100, 
    //     а человек пытается его угадать за минимальное число попыток.
    //     Для ввода данных от человека используется элемент TextBox.
    public partial class Form1 : Form
    {
        public int RandNumber { get; set; }
        public int Counter { get; set; }

        private event EventHandler NewGame;
        private event EventHandler Check;
        public Form1()
        {
            InitializeComponent();
            inputTextBox.Visible = false;
            btnCheck.Visible = false;
            lblCounter.Text = "";
            NewGame += Form1_NewGame;
            Check += Form1_Check;
        }

        private void Form1_Check(object sender, EventArgs e)
        {
            if (int.TryParse(inputTextBox.Text, out int number))
            {
                if(number == RandNumber)
                {
                    Counter++;
                    lblHint.Text = $"Вы угадали! Загаданное число: {RandNumber}.";
                    lblCounter.Text = $"Сделанные попытки: {Counter}";
                    btnCheck.Visible = false;
                    inputTextBox.Visible = false;
                }
                else if (number < RandNumber)
                {
                    Counter++;
                    lblCounter.Text = $"Сделанные попытки: {Counter}";
                    lblHint.Text = $"Введённое число меньше загаданного.";
                }
                else
                {
                    Counter++;
                    lblCounter.Text = $"Сделанные попытки: {Counter}";
                    lblHint.Text = $"Введённое число больше загаданного.";
                }
            }
            else
            {
                lblHint.Text = "Вы ввели некоректное значение.";
            }
        }

        private void Form1_NewGame(object sender, EventArgs e)
        {
            Random random = new Random();
            RandNumber = random.Next(0, 100);
            Counter = 0;
            MessageBox.Show(@"Загадано целое число от 0 до 100.");
            lblHint.Text = @"Введите число и нажмите 'Check'.";
            lblCounter.Text = $"Сделанные попытки: {Counter}";
            inputTextBox.Visible = true;
            inputTextBox.Text = "";
            btnCheck.Visible = true;
        }

        private void playToolStrip_Click(object sender, EventArgs e)
        {
            //if (NewGame != null){NewGame.Invoke(sender, e);}
            NewGame?.Invoke(sender, e);
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            //if (Check != null){Check.Invoke(sender, e);}
            Check?.Invoke(sender, e);
        }
    }
}
