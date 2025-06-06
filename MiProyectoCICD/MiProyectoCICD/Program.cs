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
                Console.WriteLine("3. Salir");
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
                        Console.WriteLine("¡Hasta pronto!");
                        break;
                    default:
                        Console.WriteLine("Opción inválida.");
                        break;
                }

                if (opcion != 3)
                {
                    Console.WriteLine("\nPresiona una tecla para continuar...");
                    Console.ReadKey();
                }

            } while (opcion != 3);
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
            foreach (var est in estudiantes)
            {
                Console.WriteLine($"Nombre: {est.Nombre} - Nota: {est.Nota}");
            }
        }


    }
}
