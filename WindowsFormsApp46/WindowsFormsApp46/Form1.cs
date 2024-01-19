using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp46
{
    public partial class Form1 : Form
    {
        struct produkt
        {
           public string naim;
           public int kol;
           public int stoimost;
        }
        List<produkt> produkt1 = new List<produkt>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            /* if (textBox1.Text.Trim().Length == 0) 
             {
                 MessageBox.Show("Вы не ввели наименование");
                 textBox1.Focus();
             }
             else if (textBox2.Text.Trim().Length == 0)
             {
                 MessageBox.Show("Вы не ввели количество на складе");
                 textBox2.Focus();
             }
             else if (textBox3.Text.Trim().Length == 0)
             {
                 MessageBox.Show("Вы не ввели стоймость");
                 textBox3.Focus();
             }
             else if (Convert.ToInt32(textBox2.Text) < 0)
             {
                 MessageBox.Show("товар на складе не может быть меньше нуля");
                 textBox2.Focus();
             }
             else if (Convert.ToInt32(textBox3.Text) < 0)
             {
                 MessageBox.Show("товар не может стоить меньше нуля");
                 textBox3.Focus();
             }
             else
             {
                 produkt p = new produkt();
                 p.naim = textBox1.Text;
                 p.kol = Convert.ToInt32(textBox2.Text);
                 p.stoimost = Convert.ToInt32(textBox3.Text);
                 produkt1.Add(p);


                 matr.RowCount = produkt1.Count;
                 for (int i = 0; i < produkt1.Count; i++)
                 {
                     matr[0, i].Value = produkt1[i].naim;
                     matr[1, i].Value = produkt1[i].kol.ToString();
                     matr[2, i].Value = produkt1[i].stoimost.ToString();
                 }
                 textBox1.Text = "";
                 textBox2.Text = "";
                 textBox3.Text = "";
             }
            */
            Form2 f = new Form2();
            if (f.ShowDialog() == DialogResult.OK)
            {
                produkt p = new produkt();
                p.naim = f.textBox1.Text;
                p.kol = Convert.ToInt32(f.textBox2.Text);
                p.stoimost = Convert.ToInt32(f.textBox3.Text);
                produkt1.Add(p);


                matr.RowCount = produkt1.Count;
                for (int i = 0; i < produkt1.Count; i++)
                {
                    matr[0, i].Value = produkt1[i].naim;
                    matr[1, i].Value = produkt1[i].kol.ToString();
                    matr[2, i].Value = produkt1[i].stoimost.ToString();
                }

            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (matr.CurrentRow == null)
            {
                MessageBox.Show("Вы не выделили строку");
            }
            else
            {
                DialogResult result = MessageBox.Show(
                    "Точно удалить элемент?", "Точно удалить элемент?",MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Information,MessageBoxDefaultButton.Button1,MessageBoxOptions.DefaultDesktopOnly);
                if (result == DialogResult.OK)
                {
                 int n = matr.CurrentRow.Index;
                 produkt1.RemoveAt(n);
                 matr.RowCount = produkt1.Count;
                 for (int i = 0; i < produkt1.Count; i++)
                 {
                    matr[0, i].Value = produkt1[i].naim;
                    matr[1, i].Value = produkt1[i].kol.ToString();
                    matr[2, i].Value = produkt1[i].stoimost.ToString();
                 }
                }
            
            }
        }

        private void matr_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void matr_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          
            
        }

      

        private void button4_Click(object sender, EventArgs e)
        {
            StreamWriter wr = new StreamWriter("1.txt") ;
            for (int i = 0;i < produkt1.Count; i++)
            {
                wr.WriteLine(matr[0, i].Value.ToString());
                wr.WriteLine(matr[1, i].Value.ToString());
                wr.WriteLine(matr[2, i].Value.ToString());
            }
            wr.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            produkt1.Clear();
            StreamReader read = new StreamReader("1.txt");
            while(read.EndOfStream== false)
            {
                produkt p = new produkt();
                p.naim = read.ReadLine();
                p.kol = Convert.ToInt32(read.ReadLine());
                p.stoimost = Convert.ToInt32(read.ReadLine());
                produkt1.Add(p);
            }
            matr.RowCount = produkt1.Count;
            for (int i = 0; i < produkt1.Count; i++)
            {
                matr[0, i].Value = produkt1[i].naim;
                matr[1, i].Value = produkt1[i].kol.ToString();
                matr[2, i].Value = produkt1[i].stoimost.ToString();
            }
            read.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < produkt1.Count;i++)
            {
                for (int j = 0; j < produkt1.Count - i - 1; j++)
                {
                    if (produkt1[j].kol < produkt1[j + 1].kol)
                    {
                        produkt p = produkt1[j];
                        produkt1[j]= produkt1[j+1];
                        produkt1[j + 1] = p;

                    }
                }
            }
            dataGridView1.RowCount = produkt1.Count;    
            for (int i = 0; i < produkt1.Count;i++)
            {
                dataGridView1[0,i].Value = produkt1[i].naim;
                dataGridView1[1, i].Value = produkt1[i].kol.ToString();
                dataGridView1[2, i].Value = produkt1[i].stoimost.ToString();
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            int n = matr.CurrentRow.Index;
            f.textBox1.Text = matr[0, n].Value.ToString();
            f.textBox2.Text = matr[1, n].Value.ToString();
            f.textBox3.Text = matr[2, n].Value.ToString();

            if (f.ShowDialog() == DialogResult.OK)
            {
                int d = matr.CurrentRow.Index;
                produkt p = new produkt();
                p.naim = f.textBox1.Text;
                p.kol = Convert.ToInt32(f.textBox2.Text);
                p.stoimost = Convert.ToInt32(f.textBox3.Text);
                produkt1[d] = p;
                matr.RowCount = produkt1.Count;
                for (int i = 0; i < produkt1.Count; i++)
                {
                    matr[0, i].Value = produkt1[i].naim;
                    matr[1, i].Value = produkt1[i].kol.ToString();
                    matr[2, i].Value = produkt1[i].stoimost.ToString();
                }
            }
        }
    }
}
