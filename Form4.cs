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
        // Funciones propias
        private void LeerClientes()
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
        private void LeerVehiculos()
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
        private void LeerAlquileres()
        {
            FileStream stream = new FileStream("Alquileres.txt", FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            while (reader.Peek() > -1)
            {
                Alquiler alquilerTemp = new Alquiler();
                alquilerTemp.Nit = reader.ReadLine();
                alquilerTemp.Nombre = reader.ReadLine();
                alquilerTemp.Direccion = reader.ReadLine();
                alquilerTemp.Placa = reader.ReadLine();
                alquilerTemp.Marca = reader.ReadLine();
                alquilerTemp.Modelo = Convert.ToInt32(reader.ReadLine());
                alquilerTemp.Color = reader.ReadLine();
                alquilerTemp.PrecioKilometro = float.Parse(reader.ReadLine());
                alquilerTemp.FechaAlquiler = Convert.ToDateTime(reader.ReadLine());
                alquilerTemp.FechaDevolucion = Convert.ToDateTime(reader.ReadLine());
                alquilerTemp.KilometrosRecorridos = float.Parse(reader.ReadLine());
                alquilerTemp.TotalPagar = float.Parse(reader.ReadLine());

                alquileres.Add(alquilerTemp);
            }
            reader.Close();
        }
        // Funcion para mostrar
        private void Cargar()
        {
            LeerClientes();
            LeerVehiculos();
            LeerAlquileres();
            // Mostramos los datos 
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = clientes;
            dataGridView1.Refresh();

            dataGridView2.DataSource = null;
            dataGridView2.DataSource = vehiculos;
            dataGridView2.Refresh();

            dataGridView3.DataSource = null;
            dataGridView3.DataSource = alquileres;
            dataGridView3.Refresh();
            // Mostramos el alquiler con más km
            // Ordenamos ascendetemente la lista
            alquileres = alquileres.OrderByDescending(p => p.KilometrosRecorridos).ToList();
            // Extraemos el valor más alto
            label3.Text = (alquileres[0].KilometrosRecorridos).ToString();
        }
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            Cargar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Cargar();
            MessageBox.Show("Datos actualizador correctamente.");
        }
    }
}
