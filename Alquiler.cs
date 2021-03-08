using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlquileresBollen
{
    class Alquiler
    {
        // Propiedades del cliente
        string nit;
        string nombre;
        string direccion;
        // Propiedades del vehículo
        string placa;
        string marca;
        int modelo;
        string color;
        float precioKilometro;
        DateTime fechaAlquiler;
        DateTime fechaDevolucion;
        float kilometrosRecorridos;
        float totalPagar;

        public string Nit { get => nit; set => nit = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Placa { get => placa; set => placa = value; }
        public string Marca { get => marca; set => marca = value; }
        public int Modelo { get => modelo; set => modelo = value; }
        public string Color { get => color; set => color = value; }
        public float PrecioKilometro { get => precioKilometro; set => precioKilometro = value; }
        public DateTime FechaAlquiler { get => fechaAlquiler; set => fechaAlquiler = value; }
        public DateTime FechaDevolucion { get => fechaDevolucion; set => fechaDevolucion = value; }
        public float KilometrosRecorridos { get => kilometrosRecorridos; set => kilometrosRecorridos = value; }
        public float TotalPagar { get => totalPagar; set => totalPagar = value; }
    }
}
