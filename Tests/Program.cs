using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Gestión_de_Tareas_Tests
{
    //Program Hereda de TaskManager
    internal class Program: TaskManager
    {
        static void Main(string[] args)
        {
            TaskManager taskManager = new TaskManager();
            TaskManagerTests taskManagerTests = new TaskManagerTests();
            string opcion;
            do {
                
                
                Console.WriteLine
                    ("  \r\n" +
                    "===== GESTIÓN DE TAREAS =====\r\n" +
                    "1. Agregar nueva tarea\r\n" +
                    "2. Listar tareas pendientes\r\n" +
                    "3. Marcar tarea como completada\r\n" +
                    "4. Eliminar tarea\r\n" +
                    "5. Salir\r\n" +
                    "Seleccione una opción:");

                opcion = Console.ReadLine();
                try
                {
                    int numero = Convert.ToInt32(opcion);
                    Console.WriteLine($"Número válido: {numero}");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: La entrada no es un número válido.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Error: El número es demasiado grande o demasiado pequeño.");
                }

                switch (opcion)
                {
                    case "1":
                        taskManager.AgregarTarea(3, "Title","des" );
                        Console.WriteLine(" \n" +
                            " Presione Enter para continuar.");
                        Console.ReadKey();
                        break;
                    case "2":
                        taskManager.MostrarTareas();
                        Console.WriteLine(" \n" +
                            " Presione Enter para continuar.");
                        Console.ReadKey();
                        break;
                    case "3":
                        taskManager.CompletarTarea(1,1);
                        Console.WriteLine(" \n" +
                            " Presione Enter para continuar.");
                        Console.ReadKey();
                        break;
                    case "4":
                        taskManager.EliminarTarea(1,1);
                        Console.WriteLine(" \n" +
                            " Presione Enter para continuar.");
                        Console.ReadKey();
                        break;
                    case "5":
                        taskManagerTests.MostrarTareas_DeberiaMostrarLasTareasCorrectamente();
                        taskManagerTests.AgregarTarea_ValidaDatos();
                        taskManagerTests.EliminarTarea_EliminacionExitosa();
                        taskManagerTests.EliminarTarea_EliminacionCancelada();
                        taskManagerTests.EliminarTarea_IdNoEncontrado();
                        break;
                    case "6":
                        Console.WriteLine("Saliendo del sistema...");
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("Opcion invalida, porfavor intente denuevo");
                        break;

                }
            } while (opcion!="5");
            
        }
    }
}
