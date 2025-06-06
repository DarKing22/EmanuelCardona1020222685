using System;
using System.Collections.Generic;

namespace MiProyectoCICD
{
    class Estudiante
    {
        public string Nombre { get; set; }
        public double Nota { get; set; }
    }

    class Program
    {
        static List<Estudiante> estudiantes = new List<Estudiante>();

        static void Main(string[] args)
        {
            int opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("=== SISTEMA DE NOTAS ===");
                Console.WriteLine("1. Agregar estudiante");
                Console.WriteLine("2. Listar estudiantes");
                Console.WriteLine("3. Calcular promedio general");
                Console.WriteLine("4. Salir");
                Console.WriteLine("5. Buscar estudiante por nombre");
                Console.Write("Seleccione una opción: ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        AgregarEstudiante();
                        break;
                    case 2:
                        ListarEstudiantes();
                        break;
                    case 3:
                        CalcularPromedio();
                        break;
                    case 4:
                        Console.WriteLine("¡Hasta pronto!");
                        break;
                    case 5:
                        BuscarEstudiante();
                        break;
                    default:
                        Console.WriteLine("Opción inválida.");
                        break;
                }

                if (opcion != 4)
                {
                    Console.WriteLine("\nPresiona una tecla para continuar...");
                    Console.ReadKey();
                }

            } while (opcion != 4);
        }

        static void AgregarEstudiante()
        {
            Console.Write("Nombre del estudiante: ");
            string nombre = Console.ReadLine();

            Console.Write("Nota final (0 - 5): ");
            if (double.TryParse(Console.ReadLine(), out double nota) && nota >= 0 && nota <= 5)
            {
                estudiantes.Add(new Estudiante { Nombre = nombre, Nota = nota });
                Console.WriteLine("Estudiante agregado correctamente.");
            }
            else
            {
                Console.WriteLine("Nota inválida.");
            }
        }

        static void ListarEstudiantes()
        {
            Console.WriteLine("\n--- LISTA DE ESTUDIANTES ---");
            if (estudiantes.Count == 0)
            {
                Console.WriteLine("No hay estudiantes registrados.");
                return;
            }

            foreach (var est in estudiantes)
            {
                Console.WriteLine($"Nombre: {est.Nombre} - Nota: {est.Nota}");
            }
        }

        static void CalcularPromedio()
        {
            if (estudiantes.Count == 0)
            {
                Console.WriteLine("No hay estudiantes para calcular el promedio.");
                return;
            }

            double suma = 0;
            foreach (var est in estudiantes)
            {
                suma += est.Nota;
            }

            double promedio = suma / estudiantes.Count;
            Console.WriteLine($"Promedio general: {promedio:F2}");
        }
        static void BuscarEstudiante()
        {
            Console.Write("Ingrese el nombre del estudiante a buscar: ");
            string nombre = Console.ReadLine();

            var encontrado = estudiantes.Find(e => e.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));

            if (encontrado != null)
            {
                Console.WriteLine($"Estudiante encontrado: {encontrado.Nombre} - Nota: {encontrado.Nota}");
            }
            else
            {
                Console.WriteLine("Estudiante no encontrado.");
            }
        }
    }
}