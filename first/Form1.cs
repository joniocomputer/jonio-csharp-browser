//using GNU GENERAL PUBLIC LICENSE; THIS SOFTWARE IS OPEN SOURCE. REDISTRIBUTE IT NAMING THE ORIGINAL AUTHOR IN THE DESCRIPTION.
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
namespace first
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            webBrowser1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            webBrowser1.Stop();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (textBox1.Text.Contains(".it") || textBox1.Text.Contains(".com") || textBox1.Text.Contains(".co.uk") || textBox1.Text.Contains(".us") || textBox1.Text.Contains(".es"))
            {
                webBrowser1.Navigate(textBox1.Text);
            }
            else
            {
                webBrowser1.Navigate("https://www.google.it/search?source=hp&ei=cYWUXfWtBo7dwALp3LLACA&q=" + textBox1.Text);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
            
                if (textBox1.Text.Contains(".it")  || textBox1.Text.Contains(".com")  || textBox1.Text.Contains(".co.uk")  || textBox1.Text.Contains(".us")  || textBox1.Text.Contains(".es") || textBox1.Text.Contains(".org") )
                {
                webBrowser1.Navigate(textBox1.Text);    
                }
                else
                {
                  webBrowser1.Navigate("https://www.google.it/search?source=hp&ei=cYWUXfWtBo7dwALp3LLACA&q=" + textBox1.Text);
                }
            }
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if(webBrowser1.CanGoBack == true)
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
            if (webBrowser1.CanGoForward == true)
            {
                button2.Enabled = true;
            }
            else
            {
                button2.Enabled = false;
            }
            textBox1.Text = Convert.ToString(webBrowser1.Url);
            textBox2.Text = webBrowser1.DocumentTitle;
            Text = webBrowser1.DocumentTitle + " - Browser Cs";
            if (textBox1.Text.Contains("https"))
            {
                textBox1.ForeColor = Color.Green;
            }
            else
            {
                textBox1.ForeColor = Color.Black;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if(panel1.Visible == true)
            {
                panel1.Visible = false;
            }
            else
            {
                panel1.Visible = true;
            }
        }
        private void preferiti()
        {
            listBox1.Items.Clear();
            try
            {
                foreach (string files in Directory.GetFiles("/csb/"))
                {
                    
                    listBox1.Items.Add(System.IO.Path.GetFileNameWithoutExtension(files));
                  
                }

            }
            catch
            {

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if(Directory.Exists("/csb") == false)
            {
                Directory.CreateDirectory("/csb");
            }
            preferiti();
           
        }

        private void button7_Click(object sender, EventArgs e)
        {
            File.WriteAllText("/csb/" + textBox2.Text +".bm", Convert.ToString(webBrowser1.Url)); //csb/google --> "google.it"
            preferiti();
            MessageBox.Show(textBox2.Text + " è stato aggiunto ai preferiti");
            textBox2.Text = string.Empty;

        }

        private void button8_Click(object sender, EventArgs e)
        {
                File.Delete("/csb/" + listBox1.SelectedItem +".bm");
                listBox1.Items.Clear();
                preferiti();
            MessageBox.Show("Preferito cancellato");
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox2.SelectedItem = listBox1.SelectedItem;
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.SelectedItem = listBox2.SelectedItem;
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
           try
            {
            string urlll = File.ReadAllText("/csb/" + Convert.ToString(listBox1.SelectedItem) + ".bm");
            webBrowser1.Navigate(urlll);
            panel1.Visible = false;
            
            }
            catch
            {

            }
           

           
            
        }

        private void rimuoviDaiPreferitiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            File.Delete("/csb/" + listBox1.SelectedItem + ".bm");
            listBox1.Items.Clear();
            preferiti();
            MessageBox.Show("Preferito cancellato");
            panel1.Visible = false;
        }
    }
}
