using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VAT;

namespace VAT
{
    public partial class Form1 : Form
    {

        private string _jsonFile;
        private string _companyNameFile;
        public Form1()
        {
            InitializeComponent();

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            int size = -1;
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string file = openFileDialog1.FileName;
                try
                {
                    _jsonFile= File.ReadAllText(file);
                    MessageBox.Show("Lista de bonuri de casa a fost incarcata cu succes !");
                }
                catch (IOException)
                {
                    MessageBox.Show("A aparut o eroare la incarcarea listei de bonuri fiscale !");
                }
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            var myContext = new VatContext();

            var myService = new VatService(new UnityOfWork(myContext), new VatRepository(myContext));

            
            var listChecks = new JsonService(JsonDeserializer.Deserialize(_jsonFile, _companyNameFile));

           
            var generatedWordFile = Directory.GetCurrentDirectory() + "\\" + String.Format("{0:y}", DateTime.Now).Trim() + ".docx";

            var wp = new WordProcessor(listChecks.ListOfChecks, generatedWordFile);
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            int size = -1;
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string file = openFileDialog1.FileName;
                try
                {
                    _companyNameFile = File.ReadAllText(file, Encoding.GetEncoding(1251));
                    MessageBox.Show("Lista cu denumirea firmelor fost incarcata cu succes !");
                }
                catch (IOException)
                {
                    MessageBox.Show("A aparut o eroare la incarcarea listei cu denumirea firmelor !");
                }
            }
            
        }
    }
}
