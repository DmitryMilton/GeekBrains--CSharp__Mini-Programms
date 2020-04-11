using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mini_Programms
{
    public partial class MainForm : Form
    {

        int count = 0;
        Random rnd;
        string specChars = "!@#$%^&*()-=<>?{}[]~";

        public MainForm()
        {
            InitializeComponent();
            rnd = new Random();
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsmiAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Мини-программы написанные в рамках прохождения видеокурса \"C#. Мини-программы.\" на портале GeekBrains.\nАвтор: Дмитрий М.", "О программе");
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            count++;
            lblCounter.Text = count.ToString();
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            count--;
            lblCounter.Text = count.ToString();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            count = 0;
            lblCounter.Text = count.ToString();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n = rnd.Next(Convert.ToInt32(nudFrom.Value), Convert.ToInt32(nudTo.Value) + 1);
            lblRandom.Text = n.ToString();
            if (chbUniq.Checked)
            {
                if (tbRand1.Lines.Count() < Convert.ToInt32(nudTo.Value)+1)
                {
                    while (tbRand1.Text.IndexOf(n.ToString()) != -1)
                    {
                        n = rnd.Next(Convert.ToInt32(nudFrom.Value), Convert.ToInt32(nudTo.Value) + 1);
                    }
                    tbRand1.AppendText(n + Environment.NewLine);
                }
            }
            else
            {
                tbRand1.AppendText(n + Environment.NewLine);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbRand1.Clear();
        }

        private void btnRandCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(tbRand1.Text);
        }

        private void tsmiInsertDate_Click(object sender, EventArgs e)
        {
            rtbNote.AppendText(DateTime.Now.ToShortDateString());
        }

        private void tsmiInsertTime_Click(object sender, EventArgs e)
        {
            rtbNote.AppendText(DateTime.Now.ToShortTimeString());
        }

        private void tsmiSave_Click(object sender, EventArgs e)
        {
            try
            {
                rtbNote.SaveFile("notepad.rtf");
            }
            catch
            {
                MessageBox.Show("Ошибка при сохранении");
            }
        }

        void LoadNotepad()
        {
            try
            {
                rtbNote.LoadFile("notepad.rtf");
            }
            catch
            {
                MessageBox.Show("Ошибка при открытии файла");
            }
        }

        private void tsmiOpen_Click(object sender, EventArgs e)
        {
            LoadNotepad();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadNotepad();
            chlbPassw.SetItemChecked(0, true);
            chlbPassw.SetItemChecked(1, true);
            chlbPassw.SetItemChecked(2, true);
        }

        private void btnCreatePassw_Click(object sender, EventArgs e)
        {
            if (chlbPassw.CheckedItems.Count == 0) return;
            string password = "";
            for (int i = 0; i < nudPassLen.Value; i++)
            {
                int n = rnd.Next(0, chlbPassw.CheckedItems.Count);
                string s = chlbPassw.CheckedItems[n].ToString();
                switch (s)
                {
                    case "Цифры":
                        password += rnd.Next(10).ToString();
                        break;
                    
                    case "Прописные буквы":
                        password += Convert.ToChar(rnd.Next(65, 88));
                        break;
                    
                    case "Строчные буквы":
                        password += Convert.ToChar(rnd.Next(97, 122));
                        break;
                    
                    default:
                        password += specChars[rnd.Next(specChars.Length)];
                        break;
                }
                tbPassw.Text = password;
                Clipboard.SetText(password);
            }
        }
    }
}
