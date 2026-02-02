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
                        
                        GsT.AgregarTarea(names, descriptions);
                        salir = false;
                        break;

                    case 2:
                        Console.Clear();
                        Console.WriteLine("1- Todas");
                        Console.WriteLine("2- Pendientes");
                        Console.WriteLine("3- Completadas");
                        Console.Write("Opción: ");
                        int filtro;
                        int.TryParse(Console.ReadLine(), out filtro);

                        if (GsT.ObtenerTodas().Count == 0)
                        {
                            Console.WriteLine("No hay tareas guardadas en el sistema!");
                        }
                        else
                        { 
                            switch (filtro)
                            {
                                case 1:
                                    foreach (Tarea tars in GsT.ObtenerTodas())
                                    {
                                        Console.WriteLine($"Id: {tars.id}");
                                        Console.WriteLine($"Nombre: {tars.name}");
                                        Console.WriteLine($"Descripción: {tars.description}");
                                        if (tars.completed == false)
                                        {
                                            Console.WriteLine("Completada: Tarea Pendiente!");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Completada: Tarea Completada!");
                                        }
                                    }
                                    break;

                                case 2:
                                    Console.Clear();
                                    List<Tarea> pendientes = GsT.ObtenerPendientes();

                                    if (pendientes.Count == 0)
                                    {
                                        Console.WriteLine("No hay tareas pendientes.");
                                    }
                                    else
                                    {
                                        foreach (Tarea t in pendientes)
                                        {
                                            Console.WriteLine($"Id: {t.id}");
                                            Console.WriteLine($"Nombre: {t.name}");
                                            Console.WriteLine($"Descripción: {t.description}");
                                            Console.WriteLine("Estado: Pendiente");
                                            Console.WriteLine("---------------------");
                                        }
                                    }

                                    Console.ReadKey();
                                    break;

                                case 3:
                                    Console.Clear();
                                    List<Tarea> completadas = GsT.ObtenerCompletadas();

                                    if (completadas.Count == 0)
                                    {
                                        Console.WriteLine("No hay tareas completadas.");
                                    }
                                    else
                                    {
                                        foreach (Tarea t in completadas)
                                        {
                                            Console.WriteLine($"Id: {t.id}");
                                            Console.WriteLine($"Nombre: {t.name}");
                                            Console.WriteLine($"Descripción: {t.description}");
                                            Console.WriteLine("Estado: Completada");
                                            Console.WriteLine("---------------------");
                                        }
                                    }
                                    Console.ReadKey();
                                    break;
                            }
                        }
                        Console.ReadKey();
                        break;


                    case 3:
                        Console.Clear();
                        int opss;

                        if (GsT.ObtenerTodas().Count == 0)
                        {
                            Console.WriteLine("No hay tareas para marcar.");
                            Console.ReadKey();
                        }
                        Console.WriteLine("Ingrese el id de la tarea que quiera marcar como completada: "); 
                        while (!int.TryParse(Console.ReadLine(), out opss))
                        {
                            Console.WriteLine("Opción inválida. Ingrese un número.");
                            Console.Write("Opción: ");
                        }

                        bool resultado = GsT.MarcarCompleted(opss);

                        if (resultado)
                        {
                            Console.WriteLine("Tarea marcada como completada!");
                        }
                        else
                        {
                            Console.WriteLine("No existe una tarea con ese ID");
                        }

                        Console.ReadKey();

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
