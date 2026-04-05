# 🟢 DecaginRenderer

## 📌 Sobre o Projeto

O **MonteCarloDecagon** é uma aplicação desktop desenvolvida em **C#** que renderiza um decágono regular utilizando o método de **Monte Carlo**.

Diferente da abordagem tradicional baseada em linhas e formas geométricas prontas, o desenho é construído exclusivamente com **primitivas de ponto**, onde cada ponto é gerado aleatoriamente e validado matematicamente para verificar sua pertença à área do polígono.

---

## 🎯 Objetivos

* Aplicar conceitos fundamentais de **Computação Gráfica**
* Implementar renderização baseada em **amostragem estocástica (Monte Carlo)**
* Trabalhar com **geometria analítica** e **trigonometria**
* Utilizar apenas **primitivas de ponto** para construção da forma

---

## 🧠 Conceitos Aplicados

* Primitivas gráficas (uso de `DrawLine` para simular pontos)
* Método de Monte Carlo
* Coordenadas cartesianas e polares
* Funções trigonométricas
* Teste de pertencimento em polígonos

---

## ⚙️ Como Funciona

1. O usuário seleciona uma cor na interface
2. Clica no botão **"Desenhar Decágono"**
3. O sistema gera milhares de pontos aleatórios dentro da área do canvas
4. Cada ponto passa por um teste matemático de pertencimento
5. Apenas os pontos válidos são renderizados na tela

---

## 🖥️ Interface

* 🎨 Seleção de cores via **ComboBox** (RGB + CMY)
* ▶️ Botão para iniciar a renderização
* 🪟 Canvas de **800x800 pixels**

---

## 🚀 Tecnologias Utilizadas

* C#
* Windows Forms
* GDI+

---

## 📊 Detalhes Técnicos

* Aproximadamente **80.000 pontos** são utilizados na renderização
* A qualidade do preenchimento depende da densidade de amostragem
* Abordagem baseada em **probabilidade**, não em desenho determinístico

---

## 💡 Diferencial do Projeto

Este projeto demonstra, na prática, como formas geométricas complexas podem ser construídas a partir de elementos extremamente simples (**pontos**), utilizando conceitos matemáticos e probabilísticos — uma abordagem pouco convencional, porém poderosa.

---
## ▶️ Como Executar

### ✅ Pré-requisitos

* .NET instalado (recomendado .NET 6 ou superior)
* Windows (projeto utiliza Windows Forms)

---

### 🚀 Executando o projeto

1. Clone o repositório:
```bash
git clone https://github.com/miguelquintanilhapy/DecagonRenderer.git
```
2. Acesse a pasta do projeto:
```bash
cd ProjetoICG1Bim
```
3. Execute a aplicação:
```bash
dotnet run
```
---

## 🧑‍💻 Autores

* Miguel Quintanilha Gomes de Sales
* Cauã Rodrigo Guimas Peres

---

## 📎 Conclusão

O projeto reforça conceitos essenciais de computação gráfica e evidencia como técnicas probabilísticas podem ser aplicadas na geração de imagens, aproximando teoria matemática da prática em desenvolvimento de software.


