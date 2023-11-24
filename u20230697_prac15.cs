using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace MyApp// Note: actual namespace depends on the project name.
{
    internal class Program
    {
        class ConsultaMedica
        {
            public string? NombrePaciente { get; set; }

            public DateTime FechaCita { get; set; }

            public string? RazonConsulta { get; set; }

            public double CostoConsulta { get; set; }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("\n---------CITAS DE CLINCIA DENTISTA---------------");
            Console.WriteLine("\nIngrese la cantidad de citas a crear: ");
            int cantidadCitas = Convert.ToInt32(Console.ReadLine());

            for (int i = 1; i <= cantidadCitas; i++)
            {
                ConsultaMedica consulta = new ConsultaMedica();

                Console.WriteLine($"Ingrese los datos para la cira {i}:");
                Console.Write("Nombre del paciente: ");
                consulta.NombrePaciente = Console.ReadLine();

                Console.Write("Fecha de ;a cita (DD/MM/YYYY HH:MM): ");
                consulta.FechaCita = Convert.ToDateTime(Console.ReadLine());

                Console.Write("Razon de la consulta: ");
                consulta.RazonConsulta = Console.ReadLine();

                Console.Write("Costo de la consulta: ");
                consulta.CostoConsulta = Convert.ToDouble(Console.ReadLine());

                // CREAR EL NOMBRE DEL ARCHIVO SEGUN EL FORMATO ESPECIFICADO
                string nombreArchivo = $"Cita{i:D3}";
                GuardarConsultaEnArchivo(consulta, nombreArchivo);
            }
            
            Console.WriteLine("Citas guardadas exitosamente.\n");
        }

        static void GuardarConsultaEnArchivo(ConsultaMedica consulta, string nombreArchivo)
        {
            // AGREGAR EL NUMERO DE ITERACION AL NOMBRE DEL ARCHIVO
            string nombreCompleto = $"{nombreArchivo}#{consulta.NombrePaciente}.txt";

            // CREAR EL CONTENIDO DEL ARCHIVO
            string contenido = $"Nombre del paciente: {consulta.NombrePaciente}\n" +
                               $"Fecha de cita: {consulta.FechaCita}\n" +
                               $"Razon de Consulta: {consulta.RazonConsulta}\n" +
                               $"Costo de consulta: {consulta.CostoConsulta}\n";

            // GUARDAR EL CONTENIDO EN EL ARCHIVO
            File.WriteAllText(nombreCompleto, contenido);

            Console.WriteLine($"\nCita guardada en el archivo: {nombreCompleto}");

        }
    }
}

// NOMBRE: PEDRO ANTONIO ALVAREZ HERNANDEZ
// CODIGO: U20230697