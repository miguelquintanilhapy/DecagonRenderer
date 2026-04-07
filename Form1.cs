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

        // FUNÇÃO MODULO - CONFORME ENUNCIADO
        public float Modulo(float a, float b)
        {
            return (a % b + b) % b;
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

        //Button click
        private void btnDesenhar_Click(object sender, EventArgs e)
        {
            desenhar = true;
            this.Invalidate();
        }

        // Paint
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (!desenhar) return;

            Pen caneta = ObterCaneta();
            decagono(e, caneta.Color.R, caneta.Color.G, caneta.Color.B);
            caneta.Dispose();
        }

        // FUNÇÃO DECÁGONO - CONFORME ENUNCIADO
        public void decagono(PaintEventArgs e, int r, int g, int b)
        {
            int n = 10; // Lados
            int R = 150; // Raio externo
            int tentativas = 80000;
            int largura = 800;
            int altura = 800;
            int centroX = largura / 2;
            int centroY = altura / 2;
            Random rnd = new Random();
            Pen caneta = CriaCor(r, g, b);

            for (int i = 0; i < tentativas; i++)
            {
                // 1. Gera ponto aleatório no "bounding box" do decágono
                int px = rnd.Next(centroX - R, centroX + R);
                int py = rnd.Next(centroY - R, centroY + R);

                // 2. Translação para o espaço de objeto
                float dx = px - centroX;
                float dy = py - centroY;

                // 3. Conversão para coordenadas polares
                float raio = (float)Math.Sqrt(dx * dx + dy * dy);
                float theta = (float)Math.Atan2(dy, dx);

                // 4. Redução de simetria (normalização angular)
                float seccao = (float)(2.0 * Math.PI / n);
                float alpha = (float)(Modulo(theta, seccao) - (seccao / 2.0));

                // 5. Cálculo do raio limite (apótema dinâmico)
                float d_max = (float)(R * Math.Cos(Math.PI / n) / Math.Cos(alpha));

                // 6. Teste de inclusão e renderização
                if (raio <= d_max)
                {
                    pintaP(e, caneta, px, py);
                }
            }

            caneta.Dispose();
        }

        // OBTER COR SELECIONADA
        private Pen ObterCaneta()
        {
            if (cboCor.SelectedItem.ToString() == "Vermelho") return CriaCor(255, 0, 0);
            if (cboCor.SelectedItem.ToString() == "Verde") return CriaCor(0, 255, 0);
            if (cboCor.SelectedItem.ToString() == "Azul") return CriaCor(0, 0, 255);
            if (cboCor.SelectedItem.ToString() == "Ciano") return CriaCor(0, 255, 255);
            if (cboCor.SelectedItem.ToString() == "Magenta") return CriaCor(255, 0, 255);
            return CriaCor(255, 255, 0); // Amarelo
        }
    }
}
