using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Elgamal_Nhom7
{
    public partial class ElGamal : Form
    {
        public ElGamal()
        {
            InitializeComponent();
        }

        private int p, a, x, k, y, c1, c2, K, K2;

        private void label3_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void label6_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void groupBox1_Enter(object sender, EventArgs e) { }
        private void label12_Click(object sender, EventArgs e) { }
        private void label13_Click(object sender, EventArgs e) { }
        private void label14_Click(object sender, EventArgs e) { }
        private void groupBox2_Enter(object sender, EventArgs e) { }
        private void ElGamal_Load(object sender, EventArgs e) { }
        private void txta_TextChanged(object sender, EventArgs e) { }
        private void txtk_TextChanged(object sender, EventArgs e) { }
        private void txtx_TextChanged(object sender, EventArgs e) { }
        private void txtp_TextChanged(object sender, EventArgs e) { }
        private void label20_Click(object sender, EventArgs e) { }
        private void textBox2_TextChanged(object sender, EventArgs e) { }

        private void cmd_giaima_Click(object sender, EventArgs e)
        {
            txtbanro1.Text = Giaima(txtbanma1.Text);
        }

        private void label24_Click(object sender, EventArgs e) { }

        private void cmd_tudong_Click(object sender, EventArgs e)
        {
            if (txtp.Text != "" && txta.Text != "" && txtx.Text != "")
            {
                Random rd = new Random();
                txtk.Text = rd.Next(5, int.Parse(txtp.Text)).ToString();
            }
            else
            {
                MessageBox.Show("Làm ơn nhập đầy đủ đầu vào p,a,x!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmd_taokhoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtp.Text != "" && txta.Text != "" && txtx.Text != "" && txtk.Text != "")
                {
                    p = int.Parse(txtp.Text);
                    a = int.Parse(txta.Text);
                    x = int.Parse(txtx.Text);
                    k = int.Parse(txtk.Text);
                    y = mod(a, x, p);
                    txtcongkhai.Text = p.ToString() + " - " + a.ToString() + " - " + y.ToString();
                    txtcongkhai1.Text = p.ToString() + " - " + a.ToString() + " - " + y.ToString();
                    txtbimat.Text = x.ToString();
                    txtbimat1.Text = x.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
        }

        private void cmd_lamlai_Click(object sender, EventArgs e)
        {
            txtp.Text = "";
            txta.Text = "";
            txtx.Text = "";
            txtk.Text = "";
            txtcongkhai.Text = "";
            txtbimat.Text = "";
            txtbanro.Text = "";
            txtbanro1.Text = "";
            txtbanma.Text = "";
            txtbanma1.Text = "";
            txtbimat1.Text = "";
            txtp.Focus();
        }

        private void cmd_mahoa_Click(object sender, EventArgs e)
        {
            if (txtbanro.Text != "")
            {
                txtbanma.Text = MaHoa(txtbanro.Text);
                txtbanma1.Text = txtbanma.Text;
            }
            else
            {
                MessageBox.Show("Làm ơn nhập bản rõ!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                txtp.Focus();
            }
        }

        public int mod(int m, int e, int n)
        {
            int[] a = new int[100];
            int k = 0;
            do
            {
                a[k] = e % 2;
                k++;
                e = e / 2;
            }
            while (e != 0);

            int kq = 1;
            for (int i = k - 1; i >= 0; i--)
            {
                kq = (kq * kq) % n;
                if (a[i] == 1)
                    kq = (kq * m) % n;
            }
            return kq;
        }

        private string MaHoa(string plainText)
        {
            StringBuilder cipherText = new StringBuilder();
            foreach (char ch in plainText)
            {
                int tk = (int)ch;
                k = int.Parse(txtk.Text);
                K = mod(y, k, p);
                c1 = mod(a, k, p);
                c2 = (K * tk) % p;
                cipherText.Append(c1.ToString() + "-" + c2.ToString() + " ");
            }
            return cipherText.ToString().Trim();
        }

        private string Giaima(string cipherText)
        {
            StringBuilder plainText = new StringBuilder();
            string[] parts = cipherText.Split(' ');
            foreach (string part in parts)
            {
                string[] cParts = part.Split('-');
                c1 = int.Parse(cParts[0]);
                c2 = int.Parse(cParts[1]);
                K2 = mod(c1, x, p);
                int invK2 = modInverse(K2, p);
                int m = (c2 * invK2) % p;
                plainText.Append((char)m);
            }
            return plainText.ToString();
        }

        private int modInverse(int a, int m)
        {
            for (int x = 1; x < m; x++)
            {
                if ((a * x) % m == 1)
                    return x;
            }
            throw new Exception("Modular inverse does not exist.");
        }
    }
}


