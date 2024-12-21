using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeTareas_MatthiasPaniagua
{
    public class Task
    {
        public List<int> ID = new List<int>();
        public List<String> Title = new List<String>();
        public List<String> Description = new List<String>();
        public List<bool> IsCompleted = new List<bool>();
    }
    //Clase TaskManager modifica las tareas

    //Hereda de Task para tener acceso a las listas
    class TaskManager : Task
    {
        private static string w;
        static int idCounter = 1; // Contador para generar IDs únicos
        private static string Nt, dt;
        private static bool bt = false;

        public void MostrarTareas()
        {
            Console.WriteLine("\nLista de Tareas:");
            for (int i = 0; i < ID.Count; i++)
            {
                Console.WriteLine($" ");
                Console.WriteLine($"Tarea numero {ID[i]} Titulo: {Title[i]} ");
                Console.WriteLine($"Descripcion: {Description[i]}");
                Console.WriteLine($"Tarea completada: {IsCompleted[i]}");
            }
        }
        public void AgregarTarea()
        {
            Console.WriteLine(" \n" +
                "Cuantas tareas desea agregar?");
            w = Console.ReadLine();
            try
            {
                int numero = Convert.ToInt32(w);
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
            int j = int.Parse(w);
            for (int i = 0; i < j; i++)
            {
                Console.WriteLine($"\nAgregando tarea {i + 1}:");
                Console.WriteLine("Defina un nombre para la tarea:");
                Nt = Console.ReadLine();
                Console.WriteLine("Agregue una descripción para la tarea:");
                dt = Console.ReadLine();
                Title.Add(Nt); Description.Add(dt); ID.Add(idCounter++); IsCompleted.Add(bt);
            }
        }
        public void CompletarTarea()
        {
            Task at = new Task();
            Console.Write("Cual tarea desea marcar como completa? Responda con el numero de ID: ");
            int marcar = int.Parse(Console.ReadLine());
            if (marcar <= 10)
            {
                try
                {
                    int numero = Convert.ToInt32(marcar);
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
            }
            else
            { Console.WriteLine("Solo hay 10 tareas disponibles"); }
            for (int i = 0; i < ID.Count; i++)
            {
                if (marcar == ID[i])
                {
                    Console.WriteLine($"Seguro que desea marcar como completada la tarea numero: {ID[i]}" +
                        $" \n[1] Para completar   [2] Para descartar");
                    int ct = int.Parse(Console.ReadLine());
                    if (ct == 1)
                    {
                        IsCompleted[i] = true;
                        Console.WriteLine($" Tarea {ID[i]} completada");
                    }
                }
            }
        }
        public void EliminarTarea()
        {
            Task at = new Task();
            Console.Write("Cual tarea desea borrar? Responda con el numero de ID: ");
            int borrar = int.Parse(Console.ReadLine());
            if (borrar <= 10)
            {
                try
                {
                    int numero = Convert.ToInt32(borrar);
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
            }
            else
            { Console.WriteLine("Solo hay 10 tareas disponibles"); }
            for (int i = 0; i < ID.Count; i++)
            {
                if (borrar == ID[i])
                {
                    Console.WriteLine($"Seguro que desea borrar la tarea {Title[i]} numero: {ID[i]}" +
                    $" \n[1] Para completar   [2] Para descartar");
                    int bt = int.Parse(Console.ReadLine());
                    if (bt == 1)
                    {
                        Console.WriteLine($" Tarea {ID[i]} borrada");
                        ID.Remove(i); Title.RemoveAt(i); Description.RemoveAt(i); IsCompleted.RemoveAt(i);
                    }
                }
            }
        }
    }

}
