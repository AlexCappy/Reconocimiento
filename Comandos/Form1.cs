using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Recognition;

namespace Comandos
{
    public partial class Form1 : Form
    {
        private SpeechRecognitionEngine escucha = new SpeechRecognitionEngine();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                escucha.SetInputToDefaultAudioDevice();
                escucha.LoadGrammar(new DictationGrammar());
                escucha.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(lector);
                escucha.RecognizeAsync(RecognizeMode.Multiple);

            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("No se puede abrir mas de una vez");
            }
        }

        public void lector(object sender, SpeechRecognizedEventArgs e)
        {
            foreach (RecognizedWordUnit palabra in e.Result.Words)
            {
                label2.Text = palabra.Text;

                if (palabra.Text == "izquierda")
                {
                    pictureBox1.Location = new Point(pictureBox1.Location.X - 20, pictureBox1.Location.Y);
                }
                else if (palabra.Text == "derecha")
                {
                    pictureBox1.Location = new Point(pictureBox1.Location.X + 20, pictureBox1.Location.Y);
                }
                else if (palabra.Text == "arriba")
                {
                    pictureBox1.Location = new Point(pictureBox1.Location.X, pictureBox1.Location.Y - 20);
                }
                else if (palabra.Text == "sube")
                {
                    pictureBox1.Location = new Point(pictureBox1.Location.X, pictureBox1.Location.Y - 20);
                }
                else if (palabra.Text == "abajo")
                {
                    pictureBox1.Location = new Point(pictureBox1.Location.X, pictureBox1.Location.Y + 20);
                }
            }
        }
    }
}
