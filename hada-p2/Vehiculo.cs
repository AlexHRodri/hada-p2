using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hada
{
    class Vehiculo
    {

        public event EventHandler<VelocidadMaximaExcedidaArgs> velocidadMaximaExcedida;

        public event EventHandler<TemperaturaMaximaExcedidaArgs> temperaturaMaximaExcedida;

        public event EventHandler<CombustibleMinimoExcedidoArgs> combustibleMinimoExcedido;

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
                        velocidadMaximaExcedida(this, new VelocidadMaximaExcedidaArgs(value));
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
                    temperaturaMaximaExcedida(this, new TemperaturaMaximaExcedidaArgs(value));
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
                        combustibleMinimoExcedido(this, new CombustibleMinimoExcedidoArgs(value));
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

        public void incVelocidad()
        {
            this.velocidad = this.velocidad + rand.Next(1, 8);
        }

        public void incTemperatura()
        {
            this.temperatura = this.temperatura + rand.Next(1, 6);
        }
        
        public void decCombustible()
        {
            this.combustible = this.combustible - rand.Next(1, 6);
        }

        public bool todoOk()
        {
            bool check = false;

            if(this.combustible >= minCombustible && this.temperatura <= maxTemperatura)
            {
                check = true;
            }

            return check;
        }

        public void mover()
        {
            if(this.todoOk() == true)
            {
                this.incVelocidad();
                this.incTemperatura();
                this.decCombustible();
            }
        }


        override
        public string ToString()
        {
            string cadena = "";

            _ = "[" + nombre + "] Velocidad: " + velocidad + " km/h; Temperatura: " + temperatura + " ºC; Combustible: " + combustible + " %; Ok: " + todoOk() + "\n";

            return cadena;
        }


    }

    public class VelocidadMaximaExcedidaArgs : EventArgs
    {
        public int velocidad { get; set; }

        public VelocidadMaximaExcedidaArgs (int vel)
        {
            this.velocidad = vel;
        }
    }


    public class TemperaturaMaximaExcedidaArgs : EventArgs
    {
        public int temperatura { get; set; }

        public TemperaturaMaximaExcedidaArgs(int temp)
        {
            this.temperatura = temp;
        }
    }

   
    public class CombustibleMinimoExcedidoArgs : EventArgs
    {
        public int combustible { get; set; }

        public CombustibleMinimoExcedidoArgs(int comb)
        {
            this.combustible = comb;
        }
    }


}
