using Sistema_de_Gestión_de_Tareas_Tests;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Threading;

namespace Sistema_de_Gestión_de_Tareas_Tests
{
    //Clase Task almacena las tareas
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
                Console.WriteLine($"Tarea numero {ID[i]} Titulo: {Title[i]} ");
                Console.WriteLine($"Descripcion: {Description[i]}");
                Console.WriteLine($"Tarea completada: {IsCompleted[i]}");
            }
        }
        public void AgregarTarea(int cantidad, List<String>titulo, List<String> des)
        {
            if (titulo.Count!=cantidad || des.Count != cantidad) {
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
        }
              
        public void CompletarTarea(int idTarea, int confirmacion) 
        {
            Task at = new Task();
            Console.Write("Cual tarea desea marcar como completa? Responda con el numero de ID: ");
            int marcar=int.Parse(Console.ReadLine());
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
                    int ct=int.Parse(Console.ReadLine());
                    if (ct==1)
                    {
                        IsCompleted[i] = true;
                        Console.WriteLine($" Tarea {ID[i]} completada");
                    }
                }
            }
        }
        public bool EliminarTarea(int idTarea, int confirmacion) 
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
            throw new ArgumentException("ID de tarea no encontrado.");
        }       
     }

    [TestClass]
    //Pruebas Assert
    public class TaskManagerTests:Task
    {

        [TestMethod]
        public void MostrarTareas_DeberiaMostrarLasTareasCorrectamente()
        {
            TaskManager taskManager = new TaskManager();
            taskManager.ID.Add(1);
            taskManager.Title.Add("Tarea 1");
            taskManager.Description.Add("Descripción 1");
            taskManager.IsCompleted.Add(false);

            taskManager.ID.Add(2);
            taskManager.Title.Add("Tarea 2");
            taskManager.Description.Add("Descripción 2");
            taskManager.IsCompleted.Add(true);

            // Redirigir la salida de la consola a un StringWriter
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // Act
            taskManager.MostrarTareas();

            // Assert
            string output = stringWriter.ToString();

            // Verificar que la salida contenga las líneas esperadas
            Assert.IsTrue(output.Contains("Tarea numero 1 Titulo: Tarea 1"));
            Assert.IsTrue(output.Contains("Descripcion: Descripción 1"));
            Assert.IsTrue(output.Contains("Tarea completada: False"));

            Assert.IsTrue(output.Contains("Tarea numero 2 Titulo: Tarea 2"));
            Assert.IsTrue(output.Contains("Descripcion: Descripción 2"));
            Assert.IsTrue(output.Contains("Tarea completada: True"));
        }

        [TestMethod]
        public void AgregarTarea_ValidaDatos()
        {
            TaskManager manager = new TaskManager();
            int cantidad = 3;
            List<String> titulo = new List<String> {"Titulo1","Titulo2","Titulo3"};
            List<String> des = new List<String> { "des1", "des2", "des3" };
            manager.AgregarTarea(cantidad,titulo,des);
            Assert.AreEqual(3, manager.Title.Count); // Verifica que se agregaron 3 tareas.
            Assert.AreEqual("Tarea 1", manager.Title[0]);
            Assert.AreEqual("Descripción 1", manager.Description[0]);
            Assert.AreEqual(false, manager.IsCompleted[0]); // Todas deben estar no completadas.
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AgregarTarea_ExcedeLimite()
        {
            TaskManager manager = new TaskManager();
            int cantidad = 11; // Excede el límite de 10 tareas.
            List<String> titulo = new List<String> { "Titulo1", "Titulo2", "Titulo3" };
            List<String> des = new List<String> { "des1", "des2", "des3" };
            for (int i = 0; i < cantidad; i++)
            {
                titulo.Add(($"Tarea {i + 1}"));
                des.Add(($"Des {i + 1}"));
            }
            manager.AgregarTarea(cantidad, titulo, des);
        }
        [TestMethod]
        public void EliminarTarea_EliminacionExitosa()
        {          
            TaskManager manager = new TaskManager();
            manager.ID.Add(1);
            manager.Title.Add("Tarea 1");
            manager.Description.Add("Descripción 1");
            manager.IsCompleted.Add(false);

            bool resultado = manager.EliminarTarea(1,1); // Elimina la tarea con ID 1.

            Assert.IsTrue(resultado); // Verifica que la eliminación fue exitosa.
            Assert.AreEqual(0, manager.ID.Count); // Verifica que no hay más tareas.
        }

        [TestMethod]
        public void EliminarTarea_EliminacionCancelada()
        {
            TaskManager manager = new TaskManager();
            manager.ID.Add(1);
            manager.Title.Add("Tarea 1");
            manager.Description.Add("Descripción 1");
            manager.IsCompleted.Add(false);

            bool resultado = manager.EliminarTarea(1,2); // Cancela la eliminación.

            Assert.IsFalse(resultado); // Verifica que la eliminación fue cancelada.
            Assert.AreEqual(1, manager.ID.Count); // La tarea sigue existiendo.
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EliminarTarea_IdNoEncontrado()
        {
            TaskManager manager = new TaskManager();

            manager.EliminarTarea(99, 1); // Intenta eliminar un ID inexistente.

        }

        [TestMethod]
        public void CompletarTarea_MarcaComoCompletada()
        {
            TaskManager manager = new TaskManager();

            // Agregar tareas de ejemplo
            manager.ID.Add(1);
            manager.Title.Add("Tarea 1");
            manager.Description.Add("Descripción de la tarea 1");
            manager.IsCompleted.Add(false);

            manager.ID.Add(2);
            manager.Title.Add("Tarea 2");
            manager.Description.Add("Descripción de la tarea 2");
            manager.IsCompleted.Add(false);
            int idTarea = 1; // ID de la tarea a completar
            int confirmacion = 1; // Confirmar la acción
            manager.CompletarTarea(idTarea, confirmacion);

            Assert.IsTrue(manager.IsCompleted[0]); // La tarea con ID 1 debe estar completada
            Assert.IsFalse(manager.IsCompleted[1]); // La tarea con ID 2 debe seguir incompleta
        }


    }
}




   
