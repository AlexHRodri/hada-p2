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
        List<Vehiculo> exclimitvel { get; set; } = new List<Vehiculo>();

        List<Vehiculo> exclimittemp { get; set; } = new List<Vehiculo>();
        List<Vehiculo> exclimitcomb { get; set; } = new List<Vehiculo>();



        private void cuandoVelocidadMaximaExcedida(object sender, VelocidadMaximaExcedidaArgs args)
        {
            

            Vehiculo v = (Hada.Vehiculo) sender;
            Console.WriteLine("¡¡Velocidad máxima excedida!!");
            Console.WriteLine("Vehiculo: " + v.nombre);
            Console.WriteLine("Velocidad: " + args.velocidad + "km/h");
           
            if(exclimitvel.Contains(v) == false)
            {
                exclimitvel.Add(v);
            }

        }

        private void cuandoTemperaturaMaximaExcedida(object sender, TemperaturaMaximaExcedidaArgs args)
        {

            Vehiculo v = (Hada.Vehiculo)sender;

            Console.WriteLine("¡¡Temperatura máxima excedida!!");
            Console.WriteLine("Vehiculo: " + v.nombre);
            Console.WriteLine("Temperatura: " + args.temperatura + "ºC");
           
            if (exclimittemp.Contains(v) == false)
            {
                exclimittemp.Add(v);

            }

        }

        private void cuandoCombustibleMinimoExcedido(object sender, CombustibleMinimoExcedidoArgs args)
        {

            Vehiculo v = (Hada.Vehiculo)sender;

            Console.WriteLine("¡¡Combustible mínimo excedido!!");
            Console.WriteLine("Vehiculo: " + v.nombre);
            Console.WriteLine("Combustible: 0%");

            if(exclimitcomb.Contains(v) == false)
            {
                exclimitcomb.Add(v);
            }

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

            for(int j = 0; j < this.capacidad ; j++)
            {
                if (vehiculos[j].todoOk() == true)
                {
                    vehiculos[j].mover();
                    
                    check = true;
                }
            }

            return check;
        }

        public void moverCochesEnBucle()
        {
            while (this.moverCoches() == true)
            {
            }

            return;
        }

        public List<Vehiculo> getCochesExcedenLimiteVelocidad()
        {
            if(this.exclimitvel != null)
            {
                return this.exclimitvel;
            }
            else
            {
                return null;
            }
        }

        public List<Vehiculo> getCochesExcedenLimiteTemperatura()
        {
            if (this.exclimittemp != null)
            {
                return this.exclimittemp;
            }
            else
            {
                return null;
            }

        }

        public List<Vehiculo> getCochesExcedenMinimoCombustible()
        {
            if (this.exclimitcomb != null)
            {
                return this.exclimitcomb;
            }
            else
            {
                return null;
            }

        }

      override
      public string ToString()
        {
            string cadena = "";
            int contvec, conttemp, contcomb;

            if(this.getCochesExcedenLimiteTemperatura() == null)
            {
                contvec = 0;
            }
            else
            {
                contvec = this.getCochesExcedenLimiteVelocidad().Count;
            }

            if(this.getCochesExcedenLimiteVelocidad() == null)
            {
                conttemp = 0;
            }
            else
            {
                conttemp = this.getCochesExcedenLimiteTemperatura().Count;
            }

            if (this.getCochesExcedenMinimoCombustible() == null)
            {
                contcomb = 0;
            }
            else
            {
                contcomb = this.getCochesExcedenMinimoCombustible().Count;
            }


            cadena = "[AUTOVÍA] Exceso velocidad: " + contvec + "; Exceso temperatura: " + conttemp + "; Déficit combustible: " + contcomb + "\n";

            for(int i = 0; i < this.capacidad; i++)
            {
                cadena += vehiculos[i].ToString();
            }

            return cadena;
        }

    }
}
