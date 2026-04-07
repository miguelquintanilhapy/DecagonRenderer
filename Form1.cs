using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private Button btnDesenhar;
        private ComboBox cboCor;
        private bool desenhar = false;
        private Random rnd = new Random();

        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        //  PRIMITIVAS DO PROFESSOR 

        public Color cor(int r, int g, int b)
        {
            return Color.FromArgb(r, g, b);
        }

        public Pen CriaCor(int R, int G, int B)
        {
            return new Pen(cor(R, G, B), 1);
        }

        public void pintaP(PaintEventArgs e, Pen caneta, int x, int y)
        {
            e.Graphics.DrawLine(caneta, x, y, x + 1, y);
        }

        //  INTERFACE 

        private void InitializeComponent()
        {
            cboCor = new ComboBox();
            btnDesenhar = new Button();
            SuspendLayout();

            cboCor.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCor.Items.AddRange(new object[]
            {
                "Vermelho", "Verde", "Azul",
                "Ciano", "Magenta", "Amarelo"
            });
            cboCor.Location = new Point(10, 10);
            cboCor.Size = new Size(150, 25);
            cboCor.SelectedIndex = 0;

            // Botão
            btnDesenhar.Location = new Point(170, 10);
            btnDesenhar.Size = new Size(150, 25);
            btnDesenhar.Text = "Desenhar Decágono";
            btnDesenhar.Click += btnDesenhar_Click;

            ClientSize = new Size(800, 800);
            Controls.Add(cboCor);
            Controls.Add(btnDesenhar);
            Text = "Decágono - Monte Carlo";
            Paint += Form1_Paint;

            ResumeLayout(false);
        }

        //BOTÃO 

        private void btnDesenhar_Click(object sender, EventArgs e)
        {
            desenhar = true;
            this.Invalidate(); // força redesenho
        }

        // PAINT

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (desenhar == false) return;
            Pen caneta = null;

            if (cboCor.SelectedItem.ToString() == "Vermelho") caneta = CriaCor(255, 0, 0);
            if (cboCor.SelectedItem.ToString() == "Verde") caneta = CriaCor(0, 255, 0);
            if (cboCor.SelectedItem.ToString() == "Azul") caneta = CriaCor(0, 0, 255);
            if (cboCor.SelectedItem.ToString() == "Ciano") caneta = CriaCor(0, 255, 255);
            if (cboCor.SelectedItem.ToString() == "Magenta") caneta = CriaCor(255, 0, 255);
            if (cboCor.SelectedItem.ToString() == "Amarelo") caneta = CriaCor(255, 255, 0);

            int n = 10;
            int R = 150;
            int tentativas = 80000;

            int centroX = this.ClientSize.Width / 2;
            int centroY = this.ClientSize.Height / 2;

            for (int i = 0; i < tentativas; i++)
            {
                // Bounding box
                int px = rnd.Next(centroX - R, centroX + R);
                int py = rnd.Next(centroY - R, centroY + R);

                // Translação
                float dx = px - centroX;
                float dy = py - centroY;

                // Polares
                float r = (float)Math.Sqrt(dx * dx + dy * dy);
                float theta = (float)Math.Atan2(dy, dx);

                // Redução de simetria
                float seccao = (float)(2.0 * Math.PI / n);
                float alpha = (float)(((theta % seccao + seccao) % seccao) - (seccao / 2.0));

                // Raio limite
                float d_max = (float)(R * Math.Cos(Math.PI / n) / Math.Cos(alpha));

                // Teste e desenho
                if (r <= d_max)
                {
                    pintaP(e, caneta, px, py);
                }
            }

            caneta.Dispose();
        }
    }
}