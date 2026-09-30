namespace Aforo.Domain.Enumerators
{
    public enum Message
    {
        /// <summary>
        /// codigo de errores
        /// </summary>
        #region Errores
        // codigo de errores de sesiones
        #region Sesion
        ESesion001,
        ESesion002,
        #endregion
        #endregion

        /// <summary>
        /// codigos de aceptacion
        /// </summary>
        #region Aceptado
        // codigos aceptados en sesiones
        #region Sesion
        ASesion001,
        #endregion
        #region Boleto
        EBoleto001
        #endregion
        #endregion

    }
}
