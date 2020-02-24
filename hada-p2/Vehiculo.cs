using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hada
{
    class Vehiculo
    {
        public static int maxVelocidad { get; set; }
        public static int maxTemperatura { get; set; }
        public static int minCombustible { get; set; }

        public static Random rand { private get; set; }

        public string nombre { get; private set; }

        private int velocidad
        {
            get
            {
                return velocidad;
            }

            set
            {
                if (value > maxVelocidad || value < 0)
                {
                    if (value > maxVelocidad)
                    {

                    }
                    else
                    {
                        velocidad = 0;
                    }
                }
                else
                {
                    velocidad = value;
                }
            }
        }
        private int temperatura
        {
            get
            {
                return temperatura;
            }

            set
            {
                if (value > maxTemperatura)
                {

                }
                else
                {
                    temperatura = value;
                }
            }
        }
        private int combustible
        {
            get
            {
                return velocidad;
            }

            set
            {
                if (value < minCombustible || value < 0 || value > 100)
                {
                    if (value < minCombustible)
                    {

                    }
                    else if (value < 0)
                    {
                        combustible = 0;
                    }
                    else
                    {
                        combustible = 100;
                    }
                }
                else
                {
                    combustible = value;
                }
            }
        }

        public Vehiculo(string nombre, int velocidad, int temperatura, int combustible)
        {
            this.nombre = nombre;
            this.velocidad = velocidad;
            this.temperatura = temperatura;
            this.combustible = combustible;
        }







    }
}
