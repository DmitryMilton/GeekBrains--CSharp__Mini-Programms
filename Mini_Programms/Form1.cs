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
        Dictionary<string, double> metrica;

        public MainForm()
        {
            InitializeComponent();
            rnd = new Random();
            metrica = new Dictionary<string, double>();
            metrica.Add("mm", 1);
            metrica.Add("sm", 10);
            metrica.Add("dm", 100);
            metrica.Add("m", 1000);
            metrica.Add("km", 1000000);
            metrica.Add("mile", 1609344);
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

        private void btnConvert_Click(object sender, EventArgs e)
        {
            double m1 = metrica[cbFrom.Text];
            double m2 = metrica[cbTo.Text];
            double n = Convert.ToDouble(tbFrom.Text);
            tbTo.Text = (n * m1 / m2).ToString();
        }

        private void btnSwap_Click(object sender, EventArgs e)
        {
            string t = cbFrom.Text;
            cbFrom.Text = cbTo.Text;
            cbTo.Text = t;
        }

        private void cbMetric_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbMetric.Text)
            {
                case "длина":
                    metrica.Clear();
                    metrica.Add("mm", 1);
                    metrica.Add("sm", 10);
                    metrica.Add("dm", 100);
                    metrica.Add("m", 1000);
                    metrica.Add("km", 1000000);
                    metrica.Add("mile", 1609344);
                    cbFrom.Items.Clear();
                    cbFrom.Items.Add("mm");
                    cbFrom.Items.Add("sm");
                    cbFrom.Items.Add("dm");
                    cbFrom.Items.Add("m");
                    cbFrom.Items.Add("km");
                    cbFrom.Items.Add("mile");
                    cbTo.Items.Clear();
                    cbTo.Items.Add("mm");
                    cbTo.Items.Add("sm");
                    cbTo.Items.Add("dm");
                    cbTo.Items.Add("m");
                    cbTo.Items.Add("km");
                    cbTo.Items.Add("mile");
                    cbFrom.Text = "mm";
                    cbTo.Text = "mm";
                    break;
                case "вес":
                    metrica.Clear();
                    metrica.Add("g", 1);
                    metrica.Add("kg", 1000);
                    metrica.Add("t", 1000000);
                    metrica.Add("lb", 453.6);
                    metrica.Add("oz", 283);
                    cbFrom.Items.Clear();
                    cbFrom.Items.Add("g");
                    cbFrom.Items.Add("kg");
                    cbFrom.Items.Add("t");
                    cbFrom.Items.Add("lb");
                    cbFrom.Items.Add("oz");
                    cbTo.Items.Clear();
                    cbTo.Items.Add("g");
                    cbTo.Items.Add("kg");
                    cbTo.Items.Add("t");
                    cbTo.Items.Add("lb");
                    cbTo.Items.Add("oz");
                    cbFrom.Text = "g";
                    cbTo.Text = "g";
                    break;
            }
        }
    }
}
