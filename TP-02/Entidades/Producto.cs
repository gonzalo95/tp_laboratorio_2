﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    /// <summary>
    /// La clase Producto no deberá permitir que se instancien elementos de este tipo.
    /// </summary>
    public abstract class Producto
    {
        public enum EMarca
        {
            Serenisima, Campagnola, Arcor, Ilolay, Sancor, Pepsico
        }

        EMarca marca;
        string codigoDeBarras;
        ConsoleColor colorPrimarioEmpaque;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="patente"></param>
        /// <param name="marca"></param>
        /// <param name="color"></param>
        public Producto(string patente, EMarca marca, ConsoleColor color)
        {
            this.codigoDeBarras = patente;
            this.marca = marca;
            this.colorPrimarioEmpaque = color;
        }

        /// <summary>
        /// ReadOnly: Retornará la cantidad de ruedas del vehículo
        /// </summary>
        protected abstract short CantidadCalorias {get;}

        /// <summary>
        /// Publica todos los datos del Producto.
        /// </summary>
        /// <returns></returns>
        public virtual string Mostrar()
        {
            return (string)this;
        }

        /// <summary>
        /// Expone todos los datos del elemento.
        /// </summary>
        /// <param name="p"></param>
        public static explicit operator string(Producto p)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("CODIGO DE BARRAS: {0}\r\n", p.codigoDeBarras);
            sb.AppendFormat("MARCA          : {0}\r\n", p.marca.ToString());
            sb.AppendFormat("COLOR EMPAQUE  : {0}\r\n", p.colorPrimarioEmpaque.ToString());
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        /// <summary>
        /// Dos productos son iguales si comparten el mismo código de barras
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static bool operator ==(Producto p1, Producto p2)
        {
            return p1.codigoDeBarras == p2.codigoDeBarras;
        }
        /// <summary>
        /// Dos productos son distintos si su código de barras es distinto
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static bool operator !=(Producto p1, Producto p2)
        {
            return !(p1.codigoDeBarras == p2.codigoDeBarras);
        }
    }
}
