using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace AlquileresBollen
{
    public partial class Form2 : Form
    {
        // Instanciar lista de vehiculos
        List<Vehiculo> vehiculos = new List<Vehiculo>();
        // Funciones propias
        private void GuardarVehiculo()
        {
            FileStream stream = new FileStream("Vehiculos.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);

            foreach (var p in vehiculos)
            {
                writer.WriteLine(p.Placa);
                writer.WriteLine(p.Marca);
                writer.WriteLine(p.Modelo);
                writer.WriteLine(p.Color);
                writer.WriteLine(p.PrecioKilometros);
            }

            writer.Close();
        }
        private void LeerVehiculo()
        {
            if (File.Exists("Vehiculos.txt"))
            {
                FileStream stream = new FileStream("Vehiculos.txt", FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(stream);

                while (reader.Peek() > -1)
                {
                    Vehiculo vehiculoTemp = new Vehiculo();
                    vehiculoTemp.Placa = reader.ReadLine();
                    vehiculoTemp.Marca = reader.ReadLine();
                    vehiculoTemp.Modelo = Convert.ToInt32(reader.ReadLine());
                    vehiculoTemp.Color = reader.ReadLine();
                    vehiculoTemp.PrecioKilometros = float.Parse(reader.ReadLine());

                    vehiculos.Add(vehiculoTemp);
                }
                reader.Close();
            }
                
        }
        private void Limpiar()
        {
            txtPlaca.Clear();
            txtMarca.Clear();
            txtModelo.Clear();
            txtColor.Clear();
            txtPrecio.Clear();
            // Enfocar a el textbox de Placa
            txtPlaca.Focus();
        }

        public Form2()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            bool bandera = vehiculos.Exists(v => v.Placa == txtPlaca.Text);

            if (bandera)
                MessageBox.Show("Esta placa ya está registrada", "Atención");
            else
            {
                Vehiculo vehiculoTemp = new Vehiculo();

                vehiculoTemp.Placa = txtPlaca.Text;
                vehiculoTemp.Marca = txtMarca.Text;
                vehiculoTemp.Modelo = Convert.ToInt32(txtModelo.Text);
                vehiculoTemp.Color = txtColor.Text;
                vehiculoTemp.PrecioKilometros = float.Parse(txtPrecio.Text);

                vehiculos.Add(vehiculoTemp);

                GuardarVehiculo();
                Limpiar();
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            LeerVehiculo();
        }
    }
}
