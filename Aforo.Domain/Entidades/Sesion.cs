using Aforo.Domain.Enumerators;
using Aforo.Domain.Modelos;

namespace Aforo.Domain.Entidades
{
    /// <summary>
    /// clase que define la sesion de cada evento
    /// </summary>
    public class Sesion
    {
        /// <summary>
        /// evento al cual se le esta haciendo la sesion
        /// como no existe sesion sin evento se deja dentro de la construccion del evento dado que sin el no se deberia de crear en primera instancia
        /// </summary>
        public Evento Evento { get; init; }
        /// <summary>
        /// cantidad de boletos vendidos actualmente
        /// se vuelve publico pero con el set en privado para no poder asingar valor si no es por el metodo
        /// </summary>
        public int BoletosVendidos { get; private set; }
        /// <summary>
        /// id que define la sesion
        /// </summary>
        public Guid SesionID { get; init; }
        /// <summary>
        /// varaible que almacena el aforo de la sesion del evento
        /// se valida que el aforo sea mayor a 0
        /// se deja como init para que no se pueda editar una vez creado
        /// </summary>
        public int Aforo
        {
            get;

            init => field = value > 0 ? value : throw new ArgumentOutOfRangeException(nameof(value), Message.ESesion002.ToString());
        }

        public Sesion(Evento evento, Guid sesionID, int aforo)
        {
            this.SesionID = sesionID;
            this.Evento = evento;
            this.Aforo = aforo;
        }

        /// <summary>
        /// elegi una tupla para mantener la funcionalidad de mandar estatus y codigo de mensaje para posteriormente meter traducciones
        /// </summary>
        /// <returns></returns>
        private Message DescontarBoleto()
        {
            Message result;

            if (Aforo < BoletosVendidos + 1)
                // nomenclatura para errores E de error 001 numeral de identificacion
                result = Message.ESesion001;
            else
            {
                BoletosVendidos += 1;
                // momenclatura de exito A para acepted 001 numeral de identificacion
                result = Message.ASesion001;
            }

            return result;
        }

        /// <summary>
        /// por ahora se uno a uno pero tengo pensado poder comprar boletos en bulk
        /// es la forma de comprobar si es correcto la compra por eso queria dejar el boleano para saber si fue exito o no
        /// ademas de que se genera y retorna el boleto o sino un nulo, podria tomar una estructura compartida para validar result, podria ser para despues pero si esta bien asi? 
        /// </summary>
        /// <returns></returns>
        public Resultado<Boleto>? ComprarBoleto(decimal precio)
        {
            var result = DescontarBoleto();

            if (result == Message.ASesion001)
                return new Resultado<Boleto>(true, new Boleto(Guid.NewGuid(), this, precio), null);
            else
                return new Resultado<Boleto>(false, null, result);
        }
    }
}
