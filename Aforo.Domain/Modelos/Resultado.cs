using Aforo.Domain.Enumerators;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aforo.Domain.Modelos
{
    /// <summary>
    /// clase que encapsula el resultado de operaciones que necesiten saber el estatus y que al mismo tiempo puedes
    /// tener contenido y errores
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Resultado<T>
    {
        public bool Estatus { get; set; }
        public T? Contenido { get; set; }
        public Message? error { get; set; }

        public Resultado(bool estatus, T? contenido, Message? error)
        {
            Estatus = estatus;
            Contenido = contenido;
            this.error = error;
        }
    }
}
