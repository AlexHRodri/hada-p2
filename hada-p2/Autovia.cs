using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hada
{
    class Autovia
    {
        private int capacidad { get; set; }
        List<Vehiculo> vehiculos { get; set; }
        List<Vehiculo> exclimitvel { get; set; }
        List<Vehiculo> exclimittemp { get; set; }
        List<Vehiculo> exclimitcomb { get; set; }


        private void cuandoVelocidadMaximaExcedida(object sender, VelocidadMaximaExcedidaArgs args)
        {
            exclimitvel = new List<Vehiculo>();

            Vehiculo v = (Hada.Vehiculo) sender;
            Console.WriteLine("¡¡Velocidad máxima excedida!!");
            Console.WriteLine("Vehiculo: " + v.nombre);
            Console.WriteLine("Velocidad: " + args.velocidad + "km/h");

            exclimitvel.Add(v);

        }

        private void cuandoTemperaturaMaximaExcedida(object sender, TemperaturaMaximaExcedidaArgs args)
        {
            exclimittemp = new List<Vehiculo>();

            Vehiculo v = (Hada.Vehiculo)sender;

            Console.WriteLine("¡¡Temperatura máxima excedida!!");
            Console.WriteLine("Vehiculo: " + v.nombre);
            Console.WriteLine("Temperatura: " + args.temperatura + "ºC");

            exclimittemp.Add(v);
        }

        private void cuandoCombustibleMinimoExcedido(object sender, CombustibleMinimoExcedidoArgs args)
        {
            exclimitcomb = new List<Vehiculo>();

            Vehiculo v = (Hada.Vehiculo)sender;

            Console.WriteLine("¡¡Combustible mínimo excedido!!");
            Console.WriteLine("Vehiculo: " + v.nombre);
            Console.WriteLine("Combustible: " + args.combustible + "%");

            exclimitcomb.Add(v);

        }

        public Autovia(int nc)
        {
            this.capacidad = nc;

            vehiculos = new List<Vehiculo>();

            for(int i = 0; i < nc; i++)
            {
                Vehiculo v = new Vehiculo("vhc" + i, 50, 50, 50);
                v.velocidadMaximaExcedida += cuandoVelocidadMaximaExcedida;
                v.temperaturaMaximaExcedida += cuandoTemperaturaMaximaExcedida;
                v.combustibleMinimoExcedido += cuandoCombustibleMinimoExcedido;

                vehiculos.Add(v);
            }
  
        }

        public bool moverCoches()
        {
            bool check = false;

            for(int i = 0; i < this.capacidad ; i++)
            {
                if (vehiculos[i].todoOk() == true)
                {
                    vehiculos[i].mover();
                    check = true;
                }
            }

            return check;
        }

        public void moverCochesEnBucle()
        {
            while (this.moverCoches() == true)
            {
                this.moverCoches();
            }
        }

        public List<Vehiculo> getCochesExcedenLimiteVelocidad()
        {
            return this.exclimitvel;
        }

        public List<Vehiculo> getCochesExcedenLimiteTemperatura()
        {
            return this.exclimittemp;

        }

        public List<Vehiculo> getCochesExcedenMinimoCombustible()
        {
            return this.exclimitcomb;

        }

      override
      public string ToString()
        {
            string cadena = "";

            cadena = "[AUTOVÍA] Exceso velocidad: " + this.getCochesExcedenLimiteVelocidad().Count + "; Exceso temperatura: " + this.getCochesExcedenLimiteTemperatura().Count + "; Déficit combustible: " + this.getCochesExcedenMinimoCombustible().Count + "\n";

            for(int i = 0; i < this.capacidad; i++)
            {
                cadena += vehiculos[i].ToString();
            }

            return cadena;
        }

    }
}
