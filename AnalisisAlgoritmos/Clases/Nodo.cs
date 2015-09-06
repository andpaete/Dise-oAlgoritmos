using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnalisisAlgoritmos.Clases
{
    public class Nodo
    {
        public long dato;
        public Nodo nIzq;
        public Nodo nDer;

        public Nodo(long dato)
        {
            this.nIzq = null;
            this.nDer = null;
            this.dato = dato;
        }

        public Nodo(long dato, Nodo nIzq, Nodo nDer)
        {
            this.nDer = nDer;
            this.nIzq = nIzq;
            this.dato = dato;
        }
    }
}