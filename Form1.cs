private void btnDesenhar_Click(object sender, EventArgs e)
{
    desenhar = true;
    this.Invalidate();
}

private void Form1_Paint(object sender, PaintEventArgs e)
{
    if (!desenhar) return;
    
    Pen caneta = ObterCaneta();
    decagono(e, caneta.Color.R, caneta.Color.G, caneta.Color.B);
    caneta.Dispose();
}

public void decagono(PaintEventArgs e, int r, int g, int b)
{
    int n = 10;
    int R = 150;
    int tentativas = 80000;
    int largura = 800;
    int altura = 800;
    int centroX = largura / 2;
    int centroY = altura / 2;
    Random rnd = new Random();
    Pen caneta = CriaCor(r, g, b);

    for (int i = 0; i < tentativas; i++)
    {
        int px = rnd.Next(centroX - R, centroX + R);
        int py = rnd.Next(centroY - R, centroY + R);

        float dx = px - centroX;
        float dy = py - centroY;

        float raio = (float)Math.Sqrt(dx * dx + dy * dy);
        float theta = (float)Math.Atan2(dy, dx);

        float seccao = (float)(2.0 * Math.PI / n);
        float alpha = (float)(Modulo(theta, seccao) - (seccao / 2.0));

        float d_max = (float)(R * Math.Cos(Math.PI / n) / Math.Cos(alpha));

        if (raio <= d_max)
        {
            pintaP(e, caneta, px, py);
        }
    }

    caneta.Dispose();
}

private Pen ObterCaneta()
{
    if (cboCor.SelectedItem.ToString() == "Vermelho") return CriaCor(255, 0, 0);
    if (cboCor.SelectedItem.ToString() == "Verde") return CriaCor(0, 255, 0);
    if (cboCor.SelectedItem.ToString() == "Azul") return CriaCor(0, 0, 255);
    if (cboCor.SelectedItem.ToString() == "Ciano") return CriaCor(0, 255, 255);
    if (cboCor.SelectedItem.ToString() == "Magenta") return CriaCor(255, 0, 255);
    return CriaCor(255, 255, 0); // Amarelo
}
