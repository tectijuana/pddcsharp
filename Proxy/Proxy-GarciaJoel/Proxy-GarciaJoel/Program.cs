﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication9
{
    public interface Animacion
    {

        void dibuja();

        void clic();

    }
    /*------------------*/
    public class Video : Animacion
    {

        public void clic() { }

        public void dibuja()
        {

            Console.WriteLine("Mostrar el vídeo");
            Console.ReadKey();

        }

        public void carga()
        {

            Console.WriteLine("Cargar el vídeo");
            Console.ReadKey();

        }

        public void reproduce()
        {

            Console.WriteLine("Reproducir el vídeo");
            Console.ReadKey();

        }

    }
    /*-----------------------------*/
    public class AnimacionProxy : Animacion
    {

        protected Video video = null;

        protected string foto = "mostrar la foto";

        public void clic()
        {

            if (video == null)
            {

                video = new Video();

                video.carga();

            }

            video.reproduce();

        }

        public void dibuja()
        {

            if (video != null)

                video.dibuja();

            else
                dibuja(foto);

        }

        public void dibuja(string foto)
        {

            Console.WriteLine(foto);

        }
        /*---------------------------*/
        public class VistaVehiculo
        {

            static void Main(string[] args)
            {

                Animacion animacion = new AnimacionProxy();

                animacion.dibuja();

                animacion.clic();

                animacion.dibuja();

            }
        }

    }
}