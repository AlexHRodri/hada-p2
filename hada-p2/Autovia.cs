﻿using System;
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
   
        private void cuandoVelocidadMaximaExcedida(object sender, VelocidadMaximaExcedidaArgs args)
        {
            Console.WriteLine("Velocidad máxima excedida");
        }

        private void cuandoTemperaturaMaximaExcedida(object sender, TemperaturaMaximaExcedidaArgs args)
        {
            Console.WriteLine("Temperatura máxima excedida");
        }

        private void cuandoCombustibleMinimoExcedido(object sender, CombustibleMinimoExcedidoArgs args)
        {
            Console.WriteLine("Combustible minimo excedido");
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

    }
}
