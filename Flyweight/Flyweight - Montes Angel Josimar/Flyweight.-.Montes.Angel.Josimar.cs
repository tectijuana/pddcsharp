using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication6
{
    public class OpcionVehiculo
    {
        protected string nombre;
        protected string descripcion;
        protected int precioEstandar;
        public OpcionVehiculo(string nombre)
        {
            this.nombre = nombre;
            this.descripcion = "Descripcion de " + nombre;
            this.precioEstandar = 100;
        }
        public void visualizar(int precioDeVenta)
        {
            Console.WriteLine("Opción");
            Console.WriteLine("Nombre: " + nombre);
            Console.WriteLine(descripcion);
            Console.WriteLine("Precio estándar: " + precioEstandar);
            Console.WriteLine("Precio de venta: " + precioDeVenta);
        }
    }
    public class FabricaOpcion
    {
        protected IDictionary<string, OpcionVehiculo> opciones = new Dictionary<string, OpcionVehiculo>();
        public OpcionVehiculo getOption(string nombre)
        {
            OpcionVehiculo resultado;
            if (opciones.ContainsKey(nombre))
            {
                resultado = opciones[nombre];
            }
            else
            {
                resultado = new OpcionVehiculo(nombre);
                opciones.Add(nombre, resultado);
            }
            return resultado;
        }
    }
    public class VehiculoSolicitado
    {
        protected IList<OpcionVehiculo> opciones =
        new List<OpcionVehiculo>();
        protected IList<int> precioDeVentaOpciones =
        new List<int>();
        public void agregaOpciones(string nombre, int precioDeVenta,
        FabricaOpcion fabrica)
        {
            opciones.Add(fabrica.getOption(nombre));
            precioDeVentaOpciones.Add(precioDeVenta);
        }
        public void muestraOpciones()
        {
            int indice, tamaño;
            tamaño = opciones.Count;
            for (indice = 0; indice < tamaño; indice++)
            {
                opciones[indice].visualizar(
                precioDeVentaOpciones[indice]);
                Console.WriteLine();
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            FabricaOpcion fabrica = new FabricaOpcion();
            VehiculoSolicitado vehiculo = new VehiculoSolicitado();
            vehiculo.agregaOpciones("air bag", 80, fabrica);
            vehiculo.agregaOpciones("dirección asistida", 90,
            fabrica);
            vehiculo.agregaOpciones("elevalunas eléctricos", 85,
            fabrica);
            vehiculo.muestraOpciones();
            Console.ReadKey();
        }
    }
}