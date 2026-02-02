using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GsTurno
{
    public enum EstadoTurno
    {
        Pendiente,
        Confirmado,
        Cancelado,
        Finalizado
    }

    public class Turno
    {
        private int _id;
        private string _name;
        private DateTime _date;
        private EstadoTurno _estado;


        public Turno(int id, string name, DateTime date, EstadoTurno estado)
        { 
            this.id = id;
            this.name = name;
            this.date = date;
            this.estado = estado;
        }



        public int id
        {
            get { return this._id; }
            set { this._id = value; }
        }

        public string name
        {
            get { return this._name; }
            set { this._name = value; }
        }
        public DateTime date
        {
            get { return this._date; }
            set { this._date = value; }
        }

        public EstadoTurno estado
        { 
            get { return this._estado; } 
            set { this._estado = value; } 
        }
    }
}
