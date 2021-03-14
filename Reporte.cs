using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlquileresBollen
{
    class Reporte
    {
        string nombre;
        string placa;
        string marca;
        int modelo;
        string color;
        DateTime fechaDevolucion;
        float totalPagar;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Placa { get => placa; set => placa = value; }
        public string Marca { get => marca; set => marca = value; }
        public int Modelo { get => modelo; set => modelo = value; }
        public string Color { get => color; set => color = value; }
        public DateTime FechaDevolucion { get => fechaDevolucion; set => fechaDevolucion = value; }
        public float TotalPagar { get => totalPagar; set => totalPagar = value; }
    }
}
