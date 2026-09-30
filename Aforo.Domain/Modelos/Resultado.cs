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
        public Message? Error { get; set; }

        public Resultado(bool estatus, T? contenido, Message? error)
        {
            Estatus = estatus;

            // validaciones para no permitir estados incorrectos
            if (estatus && (contenido == null || error != null))
                throw new ArgumentOutOfRangeException(nameof(contenido), Message.EResultado001.ToString());
            else if (!estatus && (error == null || contenido != null))
                throw new ArgumentOutOfRangeException(nameof(error), Message.EResultado001.ToString());

            Contenido = contenido;
            this.Error = error;
        }
    }
}
