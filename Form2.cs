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
            int tamaño = vehiculos.Count;
            if(tamaño > 0)
            {
                string temporal = txtPlaca.Text; Boolean bandera = false;
                for (int x = 0; x < vehiculos.Count; x++)
                {
                    if (vehiculos[x].Placa.Contains(temporal))
                    {
                        bandera = true;
                        break;
                    }
                }
                // En caso de ser un nuevo vehículo se almacena
                if (!bandera)
                {
                    Vehiculo vehiculoTemp = new Vehiculo();

                    vehiculoTemp.Placa = txtPlaca.Text;
                    vehiculoTemp.Marca = txtMarca.Text;
                    vehiculoTemp.Modelo = Convert.ToInt32(txtModelo.Text);
                    vehiculoTemp.Color = txtColor.Text;
                    vehiculoTemp.PrecioKilometros = float.Parse(txtPrecio.Text);
                    vehiculos.Add(vehiculoTemp);
                    File.Delete("Vehiculos.txt");
                    this.GuardarVehiculo();
                    this.Limpiar();
                    MessageBox.Show("Alquiler realizado con exito.");
                }
                else
                    MessageBox.Show("Esta placa no es valida, ya fue registrada.");
            }
            else
            {
                Vehiculo vehiculoTemp = new Vehiculo();

                vehiculoTemp.Placa = txtPlaca.Text;
                vehiculoTemp.Marca = txtMarca.Text;
                vehiculoTemp.Modelo = Convert.ToInt32(txtModelo.Text);
                vehiculoTemp.Color = txtColor.Text;
                vehiculoTemp.PrecioKilometros = float.Parse(txtPrecio.Text);
                vehiculos.Add(vehiculoTemp);
                File.Delete("Vehiculos.txt");
                this.GuardarVehiculo();              
                this.Limpiar();
                MessageBox.Show("Alquiler realizado con exito.");
                LeerVehiculo();
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if(vehiculos.Count > 0)
                LeerVehiculo();
        }
    }
}
