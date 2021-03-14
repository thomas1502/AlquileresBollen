using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace AlquileresBollen
{
    public partial class Form3 : Form
    {
        // Instancia las listas
        List<Alquiler> alquileres = new List<Alquiler>();
        List<Vehiculo> vehiculos = new List<Vehiculo>();
        // Funciones propias
        private void LeerVehiculo()
        {
            if (File.Exists("vehiculos.txt"))
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
        private void GuardarAlquileres()
        {
            FileStream stream = new FileStream("Alquileres.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);

            foreach (var p in alquileres)
            {
                writer.WriteLine(p.Nit);
                writer.WriteLine(p.Placa);
                writer.WriteLine(p.FechaAlquiler);
                writer.WriteLine(p.FechaDevolucion);
                writer.WriteLine(p.KilometrosRecorridos);
            }

            writer.Close();
        }
        private void Limpiar()
        {
            txtNit.Clear();
            txtKmRecorridos.Clear();
            //
            txtNit.Focus();
        }
        public Form3()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            Alquiler alquilerTemp = new Alquiler();

            alquilerTemp.Nit = txtNit.Text;
            alquilerTemp.Placa = cmbPlaca.SelectedValue.ToString();
            alquilerTemp.FechaAlquiler = mcFechaAlquiler.SelectionStart;
            alquilerTemp.FechaDevolucion = mcFechaDevolucion.SelectionStart;
            alquilerTemp.KilometrosRecorridos = Convert.ToInt32(txtKmRecorridos.Text);

            alquileres.Add(alquilerTemp);

            GuardarAlquileres();
            Limpiar();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            LeerVehiculo();
            // Cargar las placas al ComboBox
            cmbPlaca.ValueMember = "Placa";
            cmbPlaca.DataSource = null;
            cmbPlaca.DataSource = vehiculos;
        }

        private void txtNit_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnComprobar_Click(object sender, EventArgs e)
        {

        }
    }
}
