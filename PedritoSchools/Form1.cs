using AppCore.Interface;
using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PedritoSchools
{
    public partial class Form1 : Form
    {
        IPedritoService service;

        public Form1(IPedritoService service)
        {
          
            this.service = service;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Estudiante xy = new Estudiante()
            {
                Nombres = textBox1.Text,
                Apellidos = textBox2.Text,
                Carnet = textBox3.Text,
                Phone = textBox4.Text,
                Direccion = textBox5.Text,
                Correo = textBox6.Text,
                Matematica = (int)numericUpDown1.Value,
                Contabilidad = (int)numericUpDown2.Value,
                Programacion = (int)numericUpDown3.Value,
                Estadistica = (int)numericUpDown4.Value,    
                Promedio = service.CalculateProm(numericUpDown1.Value,numericUpDown2.Value,numericUpDown3.Value,numericUpDown4.Value),
            };
            Limpiar();
            service.Create(xy);
            LoadDataGridView();

        }
        private void LoadDataGridView()
        {
            dgvAsset.DataSource = service.GetAll();
        }
        private void Limpiar() 
        { 
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
            numericUpDown3.Value = 0;
            numericUpDown4.Value = 0;
               
        
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
