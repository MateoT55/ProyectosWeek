using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _1_ToDo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Filtrar por completadas o no completadas
            // Id automatico


            Tarea tar = new Tarea();
            GestorTarea GsT = new GestorTarea();

            GsT.CargarTarea();

            bool salir = false;
            int opcion = 0;

            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("====================");
                Console.WriteLine("GESTOR TAREAS - MATTER");
                Console.WriteLine("====================");
                Console.WriteLine("1- Crear Tarea");
                Console.WriteLine("2- Mostrar Tareas");
                Console.WriteLine("3- Marcar tareas completadas");
                Console.WriteLine("4- Eliminar Tareas");
                Console.WriteLine("0- Salir y Guardar");
                Console.WriteLine("====================");
                Console.WriteLine("Opción: ");
                while (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine("Opción inválida. Ingrese un número.");
                    Console.Write("Opción: ");
                }


                Console.Clear();

                switch (opcion)
                {
                    case 0:
                        salir = true;
                        Console.WriteLine("Saliendo y Guardando...");
                        Thread.Sleep(500);
                        break;


                    case 1:
                        Tarea tarea = new Tarea();
                        Console.Clear();
                        string names;
                        string descriptions;
                        do
                        {
                            Console.WriteLine("Ingrese el Nombre de la Tarea: ");
                            names = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(names))
                            {
                                Console.WriteLine("Error: El nombre no puede estar vacío.");
                            }
                        } while (string.IsNullOrWhiteSpace(names));

                        do
                        {
                            Console.WriteLine("Ingrese la Descripción de la Tarea: ");
                            descriptions = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(descriptions))
                            {
                                Console.WriteLine("Error: La descripción no puede estar vacía.");
                            }
                        } while (string.IsNullOrWhiteSpace(descriptions));


                        tarea.name = names;
                        tarea.description = descriptions;

                        GsT.AgregarTarea(tarea);
                        salir = false;
                        break;

                    case 2:
                        Console.Clear();
                        if (GsT.ObtenerTodas().Count == 0)
                        {
                            Console.WriteLine("No hay tareas guardadas en el sistema!");
                        }
                        else
                        {
                            foreach (Tarea tars in GsT.ObtenerTodas())
                            {
                                Console.WriteLine($"Id: {tars.id}");
                                Console.WriteLine($"Nombre: {tars.name}");
                                Console.WriteLine($"Descripción: {tars.description}");
                                Console.WriteLine("Completada: ");
                                if (tars.completed == false)
                                {
                                    Console.WriteLine("Tarea Pendiente!");
                                }
                                else
                                {
                                    Console.WriteLine("Tarea Completada!");
                                }
                            }
                        }
                        Console.ReadKey();
                        break;


                    case 3:




                        break;


                    case 4:
                        Console.Clear();
                        string op;
                        Console.WriteLine("Estas seguro que quieres ELIMINAR TODAS las tareas: (S/N)");
                        op = Console.ReadLine().ToUpper();
                        if (op == "S")
                        {
                            Console.WriteLine("Elimanadas exitosamente!");
                            GsT.EliminarColeccion();
                        }
                        else
                        {
                            Console.WriteLine("Operación de eliminación cancelada.");
                            Thread.Sleep(500);
                        }
                        break;

                    default:
                        Console.WriteLine("Opción no válida, intente de nuevo.");
                        break;
                }

            }

        }
    }
}
