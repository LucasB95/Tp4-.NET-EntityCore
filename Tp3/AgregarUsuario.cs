using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Tp3
{
    public partial class AgregarUsuario : Form
    {
        AgenciaManager ag = new AgenciaManager();
        public AgregarUsuario()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 login = new Form1();
            login.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {


            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty(textBox4.Text))
            {
                MessageBox.Show("No se completaron los datos");
            }
            else if (textBox1.Text != null && textBox2 != null && textBox3.Text != null && textBox4.Text != null)
            {

                Usuario usuarioAgregado = new Usuario(int.Parse(textBox1.Text), textBox2.Text, textBox3.Text, textBox4.Text);
            

                if (ag.AgregarUsuario(usuarioAgregado))
                {


                    MessageBox.Show("Usuario creado con exito :" + textBox2.Text);
                    this.Hide();
                    Form1 login = new Form1();
                    login.Show();
                    MessageBox.Show("contador de rows" + ag.prueba);

                }
                else
                {
                    MessageBox.Show("Ya existen datos con el DNI");
                    MessageBox.Show("contador de rows" + ag.prueba);
                }

            }


        }
    }
}
