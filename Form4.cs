using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace AlquileresBollen
{
    public partial class Form4 : Form
    {
        // Instanciar listas temporales
        List<Vehiculo> vehiculos = new List<Vehiculo>();
        List<Cliente> clientes = new List<Cliente>();
        List<Alquiler> alquileres = new List<Alquiler>();
        List<Reporte> reportes = new List<Reporte>();
        // Funciones propias
        private void LeerClientes()
        {
            if(File.Exists("Clientes.txt"))
            {
                FileStream stream = new FileStream("Clientes.txt", FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(stream);

                while (reader.Peek() > -1)
                {
                    Cliente clienteTemp = new Cliente();

                    clienteTemp.Nit = reader.ReadLine();
                    clienteTemp.Nombre = reader.ReadLine();
                    clienteTemp.Direccion = reader.ReadLine();

                    clientes.Add(clienteTemp);
                }
                reader.Close();
            }
        }
        private void LeerVehiculos()
        {
            if(File.Exists("Vehiculos.txt"))
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
        private void LeerAlquileres()
        {
            if(File.Exists("Alquileres.txt"))
            {
                FileStream stream = new FileStream("Alquileres.txt", FileMode.OpenOrCreate, FileAccess.Read);
                StreamReader reader = new StreamReader(stream);

                while (reader.Peek() > -1)
                {
                    Alquiler alquilerTemp = new Alquiler();
                    alquilerTemp.Nit = reader.ReadLine();
                    alquilerTemp.Placa = reader.ReadLine();
                    alquilerTemp.FechaAlquiler = Convert.ToDateTime(reader.ReadLine());
                    alquilerTemp.FechaDevolucion = Convert.ToDateTime(reader.ReadLine());
                    alquilerTemp.KilometrosRecorridos = Convert.ToInt32(reader.ReadLine());

                    alquileres.Add(alquilerTemp);
                }
                reader.Close();
            }
            
        }
        // Funcion para mostrar
        private void Cargar()
        {
            foreach (var alquiler in alquileres)
            {
                Cliente cliente = clientes.Find(c => c.Nit == alquiler.Nit);

                Vehiculo vehiculo = vehiculos.Find(v => v.Placa == alquiler.Placa);

                Reporte reporteTemp = new Reporte();
                reporteTemp.Nombre = cliente.Nombre;
                reporteTemp.Placa = vehiculo.Placa;
                reporteTemp.Marca = vehiculo.Marca;
                reporteTemp.Modelo = vehiculo.Modelo;
                reporteTemp.Color = vehiculo.Color;
                reporteTemp.FechaDevolucion = alquiler.FechaDevolucion;
                reporteTemp.TotalPagar = vehiculo.PrecioKilometros * alquiler.KilometrosRecorridos;

                reportes.Add(reporteTemp);
            }
            // Mostrar Datos en los Data GriedView
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = clientes;
            dataGridView1.Refresh();

            dataGridView2.DataSource = null;
            dataGridView2.DataSource = vehiculos;
            dataGridView2.Refresh();

            dataGridView3.DataSource = null;
            dataGridView3.DataSource = alquileres;
            dataGridView3.Refresh();

            dataGridView4.DataSource = null;
            dataGridView4.DataSource = reportes;
            dataGridView4.Refresh();

            int mayor = alquileres.Max(a => a.KilometrosRecorridos);
            label5.Text = mayor.ToString();
        }
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            LeerVehiculos();
            LeerClientes();
            LeerAlquileres();
            Cargar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Cargar();
            MessageBox.Show("Datos actualizador correctamente.");
        }
    }
}
