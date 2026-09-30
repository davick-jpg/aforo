namespace Aforo.Domain.Entidades
{
    /// <summary>
    /// clase que define las propiedades de un evento
    /// </summary>
    public class Evento
    {
        /// <summary>
        /// id para identificar el evento
        /// </summary>
        public Guid EventoID { get; init; }
        /// <summary>
        /// fecha y hora en la cual se dara el evento
        /// </summary>
        public DateTime FechaEvento { get; set; }
        /// <summary>
        /// descripcion del evento
        /// </summary>
        public required string Descripcion { get; set; }

        public Evento(Guid eventoID)
        {
            this.EventoID = eventoID;
        }
    }
}
