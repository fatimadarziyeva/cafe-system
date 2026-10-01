using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WinFormsApp7
{
    public partial class Form1 : Form
    {
        private Dictionary<string, double> menu = new Dictionary<string, double>()
        {
            { "Tort", 4.50 },
            { "Kruassan", 3.00 },
            { "Keks", 2.50 },
            { "Kofe", 3.50 },
            { "Milkseyk", 5.00 },
            { "Sendvic", 4.50 }
        };

        public Form1()
        {
            InitializeComponent();
        }

        private void EkleSebete(string urunAdi)
        {
            listBox1.Items.Add(urunAdi);
        }
        private void pictureBox1_Click(object sender, EventArgs e) { EkleSebete("Tort"); }
        private void pictureBox2_Click(object sender, EventArgs e) { EkleSebete("Tort"); }
        private void pictureBox3_Click(object sender, EventArgs e) { EkleSebete("Kruassan"); }
        private void pictureBox4_Click(object sender, EventArgs e) { EkleSebete("Keks"); }
        private void pictureBox5_Click(object sender, EventArgs e) { EkleSebete("Kofe"); }
        private void pictureBox6_Click(object sender, EventArgs e) { EkleSebete("Milkseyk"); }
        private void pictureBox7_Click(object sender, EventArgs e) { EkleSebete("Sendvic"); }



        private void Hesabla_Islem()
        {
            if (string.IsNullOrEmpty(textBox4.Text))
            {
                MessageBox.Show("Əvvəlcə Yekun hesabı hesablayın!", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            double hesab, mableg;
            bool hesabParsed = double.TryParse(textBox4.Text, out hesab);
            bool mablegParsed = double.TryParse(textBox2.Text, out mableg);

            if (!hesabParsed || !mablegParsed)
            {
                MessageBox.Show("Zəhmət olmasa Məbləğ xanasına düzgün ədəd daxil edin!", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (mableg < hesab)
            {
                MessageBox.Show("Daxil edilən məbləğ hesabdan azdır", "Bildiriş", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                double qaliq = mableg - hesab;
                textBox3.Text = qaliq.ToString("0.00");
            }
        }
        private void button1_Click(object sender, EventArgs e) { Hesabla_Islem(); }
        private void button1_Click_1(object sender, EventArgs e) { Hesabla_Islem(); }
        private void btnHesabla_Click(object sender, EventArgs e) { Hesabla_Islem(); }



        private void Temizle_Islem()
        {
            textBox2.Clear();
            textBox3.Clear();
        }
        private void button2_Click(object sender, EventArgs e) { Temizle_Islem(); }
        private void button2_Click_1(object sender, EventArgs e) { Temizle_Islem(); }
        private void btnTemizle_Click(object sender, EventArgs e) { Temizle_Islem(); }



        private void SebetdenSil_Islem()
        {
            if (listBox1.SelectedItem != null)
            {
                string yemakAdi = listBox1.SelectedItem.ToString();
                listBox1.Items.Remove(listBox1.SelectedItem);
                MessageBox.Show($"{yemakAdi} səbətdən silindi", "Bildiriş", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Silmək üçün səbətdən yemək seçin!", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void button3_Click(object sender, EventArgs e) { SebetdenSil_Islem(); }
        private void button3_Click_1(object sender, EventArgs e) { SebetdenSil_Islem(); }
        private void btnSebetdenSil_Click(object sender, EventArgs e) { SebetdenSil_Islem(); }


        private void Yenile_Islem()
        {
            DialogResult cavab = MessageBox.Show("Xanalar sıfırlansınmı?", "Təsdiq", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cavab == DialogResult.Yes)
            {
                listBox1.Items.Clear();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
            }
        }
        private void button4_Click(object sender, EventArgs e) { Yenile_Islem(); }
        private void button4_Click_1(object sender, EventArgs e) { Yenile_Islem(); }
        private void btnYenile_Click(object sender, EventArgs e) { Yenile_Islem(); }



        private void YekunHesab_Islem()
        {
            if (listBox1.Items.Count == 0)
            {
                MessageBox.Show("Səbətdə yemək yoxdur!", "Bildiriş", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                double cemi = 0;
                foreach (var item in listBox1.Items)
                {
                    string yemakAdi = item.ToString();
                    if (menu.ContainsKey(yemakAdi))
                    {
                        cemi += menu[yemakAdi];
                    }
                    else
                    {
                        cemi += 4.00;
                    }
                }
                textBox4.Text = cemi.ToString("0.00");
            }
        }
        private void button5_Click(object sender, EventArgs e) { YekunHesab_Islem(); }
        private void button5_Click_1(object sender, EventArgs e) { YekunHesab_Islem(); }
        private void btnYekunHesab_Click(object sender, EventArgs e) { YekunHesab_Islem(); }


        private void textBox4_TextChanged(object sender, EventArgs e)
        {
        }
    }
}