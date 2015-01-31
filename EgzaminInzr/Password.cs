using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EgzaminInzr
{
    public partial class Password : Form
    {
        public Password()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String sha1 = Features.HashSHA1(Features.GetDateFromFile());
            if (Features.ValidateMD5HashData(textBox1.Text, sha1))
            {
                MessageBox.Show("HASŁO OK");
                
                DialogResult = System.Windows.Forms.DialogResult.OK;
                File.AppendAllText("xyz.cnf",
                 Convert.ToBase64String(Features.GetBytes(textBox1.Text))+ Environment.NewLine);
                File.AppendAllText("xyz.cnf",
                  Convert.ToBase64String(Features.GetBytes(Features.GetMACAddress1())) + Environment.NewLine);
                using (FileStream fs = new FileStream(@"an.cnf", FileMode.Create))
                {

                    using (StreamWriter w = new StreamWriter(fs, Encoding.ASCII))
                    {
                        //using (var md5 = MD5.Create())
                        //{
                            using (var stream = File.OpenRead("xyz.cnf"))
                            {
                                Console.WriteLine(Features.GetMD5HashData(stream.ToString()));
                                w.WriteLine(Convert.ToBase64String(Features.GetBytes(Features.GetMD5HashData(stream.ToString()))));
                            }
                        //}

                            for (int i = 0; i < 100; i++)
                            {
                                w.WriteLine(Convert.ToBase64String(Features.GetBytes(Features.GetSHA1HashData(i + "testAGH" + i))));
                            }

                    }

                }

                FileInfo FI = new FileInfo(@"an.cnf");

                FI.Attributes = FileAttributes.Hidden;
            }
            else
            {
                MessageBox.Show("HASŁO NIEPOPRAWNE!");
                DialogResult = System.Windows.Forms.DialogResult.Ignore;
            }
            
        }
    }
}
