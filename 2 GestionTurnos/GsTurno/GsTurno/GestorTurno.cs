using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GsTurno
{
    public class GestorTurno
    {
        private List<Turno> _turnos;
        private const string ArchivoTurnos = "Turnos.json";

        public GestorTurno()
        {
            CargarTurno();
        }


        public List<Turno> turnos
        {
            get { return this._turnos; }
            set { this._turnos = value; }
        }




        public void CargarTurno()
        {
            if (File.Exists(ArchivoTurnos))
            {
                string jsonString = File.ReadAllText(ArchivoTurnos);
                turnos = JsonSerializer.Deserialize<List<Turno>>(jsonString);
            }
            else 
            { 
                turnos = new List<Turno>();
            }
        }


        public void GuardarTurno()
        {
            string jsonString = JsonSerializer.Serialize(turnos, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(ArchivoTurnos, jsonString);

        }
    }
}
