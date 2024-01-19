using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp46
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult== DialogResult.OK ) 
            {
                int n = 0;
                try 
                {
            
                    if (textBox1.Text.Trim() == "")
                    {
                        throw new Exception("Вы не ввели Наименование");
                    }
                    n++;
                    if (textBox2.Text.Trim() == "")
                    {
                        throw new Exception("Вы не ввели Обьём партии");
                    }
                    n++;
                    if (textBox3.Text.Trim() == "")
                    {
                        throw new Exception("Вы не ввели Стоимость товара");
                    }
                    n++;
                    if (Convert.ToInt32(textBox2.Text) < 0 || Convert.ToInt32(textBox2.Text) > 1000)
                    {
                        throw new Exception("Обьём партии не может быть меньше нуля и больше 1000");
                    }
                    n++;
                    if (Convert.ToInt32(textBox3.Text) < 0.1 || Convert.ToInt32(textBox3.Text) > 10000)
                    {
                        throw new Exception(" Стоимость товара не может быть меньше нуля целых одного десятого и больше 10000");
                    }
                } 
                catch (FormatException)
                {
                    if (n == 3)
                    {
                        MessageBox.Show("Обьём партии введены не коректно");
                        e.Cancel = true;
                    }
                   else if (n == 4)
                    {
                        MessageBox.Show("Стоимость товара введены не коректно");
                        e.Cancel = true;
                    }
                }
                catch (Exception ex)
                {
                    if (n==0) 
                    {
                        textBox1.Focus();
                    }
                    else if (n == 1)
                    {
                        textBox2.Focus();
                    }
                    else if (n == 2)
                    {
                        textBox3.Focus();
                    }
                    else if (n == 3)
                    {
                        textBox2.Focus();
                    }
                    else if (n == 4)
                    {
                        textBox2.Focus();
                    }
                    MessageBox.Show(ex.Message);
                    e.Cancel = true;
                }
            }
        }
    }
}
