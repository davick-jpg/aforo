using Aforo.Domain.Enumerators;

namespace Aforo.Domain.Entidades
{
    public class Boleto
    {
        /// <summary>
        /// identificador del boleto
        /// </summary>
        public Guid Folio { get; init; }
        /// <summary>
        /// identificador de la sesion con la informacion del evento
        /// </summary>
        public Sesion Sesion { get; init; }
        /// <summary>
        /// se cambia a decimal por la forma en la que se manejan los double
        /// </summary>
        public decimal Precio
        {
            get;

            init => field = value > 0 ? value : throw new ArgumentOutOfRangeException(nameof(value), Message.EBoleto001.ToString());
        }

        internal Boleto(Guid folio, Sesion sesion, decimal precio)
        {
            this.Folio = folio;
            this.Sesion = sesion;
            this.Precio = precio;
        }
    }
}
