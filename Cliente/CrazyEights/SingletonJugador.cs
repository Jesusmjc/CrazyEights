﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyEights
{
    internal class SingletonJugador
    {
        private static SingletonJugador instance;
        private static readonly object lockObject = new object();

        public string NombreUsuario { get; set; }
    
        private SingletonJugador() { }

        public static SingletonJugador Instance
        {
            get
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new SingletonJugador();
                    }
                }

                return instance;
            }
        }
    }
}
