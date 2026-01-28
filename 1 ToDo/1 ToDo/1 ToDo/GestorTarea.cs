using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace _1_ToDo
{
    public class GestorTarea
    {
        private List<Tarea> _tareas = new List<Tarea>();
        private const string ArchivoTareas = "Tareas.json";

        public GestorTarea()
        {
            CargarTarea();
        }

        public List<Tarea> tareas
        {
            get { return this._tareas; }
            set { this._tareas = value; }
        }


        public bool EliminarColeccion()
        {
            try
            {
                if (File.Exists(ArchivoTareas))
                {
                    File.Delete(ArchivoTareas);
                    _tareas = new List<Tarea>();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al intentar eliminar el archivo: {ex.Message}");
                return false;
            }
        }

        public void GuardarTarea()
        {
            string jsonString = JsonSerializer.Serialize(tareas, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(ArchivoTareas, jsonString );
        }

        public void AgregarTarea(Tarea nuevaTarea)
        { 
            tareas.Add(nuevaTarea);
            GuardarTarea();
        }


        public void CargarTarea()
        {
            if (File.Exists(ArchivoTareas))
            {
                string jsonString = File.ReadAllText(ArchivoTareas);
                tareas = JsonSerializer.Deserialize<List<Tarea>>(jsonString);
            }
            else
            { 
                tareas = new List<Tarea>();
            }
        }

        public List<Tarea> ObtenerTodas()
        { 
            return tareas;
        }
    }
}
