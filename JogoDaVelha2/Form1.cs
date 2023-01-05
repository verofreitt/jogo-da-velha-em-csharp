using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JogoDaVelha2
{
    public partial class Form1 : Form
    {
        int Xplayer = 0, Oplayer = 0, empatesPontos = 0, rodadas = 0;
        bool turno = true, jogo_final = false;
        string[] texto = new string[9];

        private void btnClear_Click(object sender, EventArgs e)
        {
            btn.Text = "";
            btn1.Text = "";
            btn2.Text = "";
            btn3.Text = "";
            btn4.Text = "";
            btn5.Text = "";
            btn6.Text = "";
            btn7.Text = "";
            btn8.Text = "";
            rodadas = 0;
            jogo_final = false;
            for (int i = 0; i < 9; i++)
            {
                texto[i] = "";
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int buttonIndex = btn.TabIndex;
            if (btn.Text == "" && jogo_final == false)
            {
                if (turno)
                {
                    btn.Text = "X";
                    texto[buttonIndex] = btn.Text;
                    rodadas++;
                    turno = !turno;
                    Checagem(1);
                }
                else
                {
                    btn.Text = "O";
                    texto[buttonIndex] = btn.Text;
                    rodadas++;
                    turno = !turno;
                    Checagem(2);
                } //fim da estrutura do button
            }
        } //fim do metodo do button

        void vencedor(int PlayerQueGanhou)
        {
            jogo_final = true;
            if (PlayerQueGanhou == 1)
            {
                Xplayer++;
                Xpontos.Text = Convert.ToString(Xplayer);
                MessageBox.Show("Joador X ganhou!");
                turno = true;
            }
            else
            {
                Oplayer++;
                Opontos.Text = Convert.ToString(Oplayer);
                MessageBox.Show("Joador O ganhou!");
                turno = false;
            }
        }
   
        void Checagem(int ChecagemPlayer)
        {
            string suporte = "";

            if (ChecagemPlayer == 1)
            {
                suporte = "X";
            }
            else
            {
                suporte = "O";
            } // fim do suporte

        for (int vertical = 0; vertical < 3; vertical ++)
            {
                if (suporte == texto[vertical])
                {
                    if (texto[vertical] == texto[vertical + 3] && texto[vertical] == texto[vertical + 6])
                    {
                        vencedor(ChecagemPlayer);
                        return;
                    }
                }
            } // fim da vertical


        for (int horizontal = 0; horizontal < 8; horizontal += 3)
            {
                if (suporte == texto[horizontal])
                {
                    if (texto[horizontal] == texto[horizontal + 1] && texto[horizontal] == texto[horizontal + 2])
                    {
                        vencedor(ChecagemPlayer);
                        return;
                    }
                }
            } // fim da horizontal

            if (texto[0] == suporte)
            {
                if (texto[0] == texto[4] && texto[0] == texto[8])
                {
                    vencedor(ChecagemPlayer);
                    return;
                }
            }// fim da primeira diagonal

            if (texto[2] == suporte)
            {
                if (texto[2] == texto[4] && texto[2] == texto[6])
                {
                    vencedor(ChecagemPlayer);
                    return;
                }
            }// fim da segunda diagonal

            if (rodadas == 9 && jogo_final == false)
            {
                empatesPontos++;
                empates.Text = Convert.ToString(empatesPontos);
                MessageBox.Show("Empate!");
                jogo_final = true;
                return;
            }


        }
    }
}
