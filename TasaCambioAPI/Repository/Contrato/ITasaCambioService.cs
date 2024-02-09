using TasaCambioAPI.Models;

namespace TasaCambioAPI.Repository.Contrato
{
    public interface ITasaCambioService
    {
        Task <bool> ObtenerTasaCambio(DateTime fecha);

        Task<TasaCambio> GetTasaCambio(DateTime fecha);
    }
}
