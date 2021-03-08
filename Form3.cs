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
        List<Cliente> clientes = new List<Cliente>();
        List<Vehiculo> vehiculos = new List<Vehiculo>();
        // Funciones propias
        private void LeerAlquiler()
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
        private void LeerCliente()
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
        private void GuardarClientes()
        {
            FileStream stream = new FileStream("Clientes.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);

            foreach (var p in clientes)
            {
                writer.WriteLine(p.Nit);
                writer.WriteLine(p.Nombre);
                writer.WriteLine(p.Direccion);
            }

            writer.Close();
        }
        private void GuardarAlquileres()
        {
            FileStream stream = new FileStream("Alquileres.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);

            foreach (var p in alquileres)
            {
                writer.WriteLine(p.Nit);
                writer.WriteLine(p.Nombre);
                writer.WriteLine(p.Direccion);
                //
                writer.WriteLine(p.Placa);
                writer.WriteLine(p.Marca);
                writer.WriteLine(p.Modelo);
                writer.WriteLine(p.Color);
                writer.WriteLine(p.PrecioKilometro);
                writer.WriteLine(p.FechaAlquiler);
                writer.WriteLine(p.FechaDevolucion);
                writer.WriteLine(p.KilometrosRecorridos);
                writer.WriteLine(p.TotalPagar);
            }

            writer.Close();
        }
        //
        private int busqueda()
        {
            for (int x = 0; x < clientes.Count; x++)
            {
                if (clientes[x].Nit.Contains(txtNit.Text))
                {
                    return 1;
                }
            }
            return 0;
        }
        private int busqueda2()
        {
            for (int x = 0; x < vehiculos.Count; x++)
            {
                if (vehiculos[x].Placa.Contains(txtPlaca.Text))
                {
                    return 1;
                }
            }
            return 0;
        }
        private int busqueda3()
        {
            for (int x = 0; x < alquileres.Count; x++)
            {
                if (alquileres[x].Placa.Contains(txtPlaca.Text))
                {
                    return 1;
                }
            }
            return 0;
        }
        private void Limpiar()
        {
            txtNit.Clear();
            txtNombre.Clear();
            txtDireccion.Clear();
            txtPlaca.Clear();
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
            int bandera; int bandera2; int bandera3;
            bandera = busqueda(); bandera2 = busqueda2(); bandera3 = busqueda3();
            if (bandera == 0)
            {
                // Almacenar al cliente
                Cliente clientesTemp = new Cliente();
                clientesTemp.Nit = txtNit.Text;
                clientesTemp.Nombre = txtNombre.Text;
                clientesTemp.Direccion = txtDireccion.Text;

                clientes.Add(clientesTemp);
                GuardarClientes();
            }
            //
            if(bandera2 == 1)
            {
                if(bandera3 == 0)
                {
                    // Buscar los datos del vehículo
                    Vehiculo b = vehiculos.Find(p => p.Placa == txtPlaca.Text);
                    // Almacenar los datos del Alquiler
                    Alquiler alquilerTemp = new Alquiler();
                    alquilerTemp.Nit = txtNit.Text;
                    alquilerTemp.Nombre = txtNombre.Text;
                    alquilerTemp.Direccion = txtDireccion.Text;
                    alquilerTemp.Placa = b.Placa;
                    alquilerTemp.Marca = b.Marca;
                    alquilerTemp.Modelo = b.Modelo;
                    alquilerTemp.Color = b.Color;
                    alquilerTemp.PrecioKilometro = b.PrecioKilometros;
                    alquilerTemp.FechaAlquiler = mcFechaAlquiler.SelectionStart;
                    alquilerTemp.FechaDevolucion = mcFechaDevolucion.SelectionStart;
                    alquilerTemp.KilometrosRecorridos = float.Parse(txtKmRecorridos.Text);
                    alquilerTemp.TotalPagar = (b.PrecioKilometros) * (float.Parse(txtKmRecorridos.Text));

                    alquileres.Add(alquilerTemp);
                    GuardarAlquileres();
                    Limpiar();
                    MessageBox.Show("Alquiler realizado con exito.");
                }
                else
                    MessageBox.Show("Este vehículo ya esta en alquiler.");
            }
            else
                MessageBox.Show("La Placa ingresada no existe en la base de datos.");               
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            if(clientes.Count > 0)
                LeerCliente();
            LeerVehiculo();
            LeerAlquiler();
            txtNombre.Enabled = false;
            txtDireccion.Enabled = false;
        }

        private void txtNit_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnComprobar_Click(object sender, EventArgs e)
        {
            // Limpiar los campos
            txtNombre.Clear();
            txtDireccion.Clear();
            // Comprobar
            int bandera; bandera = busqueda();
            if (bandera == 0)
            {
                txtNombre.Enabled = true;
                txtDireccion.Enabled = true;
            }
            else
            {
                Cliente b = clientes.Find(p => p.Nit == txtNit.Text);
                txtNombre.Text = b.Nombre;
                txtDireccion.Text = b.Direccion;
            }
        }
    }
}
