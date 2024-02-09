using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceReference1;
using System.Data;
using System.Threading;
using System.Xml;
using TasaCambioAPI.Models;
using TasaCambioAPI.Repository.Contrato;
using TasaCambioAPI.Utilidades;

namespace TasaCambioAPI.Repository.Implementacion
{
    public class TasaCambioService : ITasaCambioService
    {
        private readonly TasaCambioDbContext _dbContext;
        private readonly Tipo_Cambio_BCNSoapClient _client;

        public TasaCambioService(TasaCambioDbContext dbContext, Tipo_Cambio_BCNSoapClient client)
        {
            _dbContext = dbContext;
            _client = client;
        }

        public Task<TasaCambio> GetTasaCambio(DateTime fecha)
        {
            try
            {
                return _dbContext.TasaCambios.Where(x => x.Fecha.Value.Month == fecha.Month && x.Fecha.Value.Day == fecha.Day && x.Fecha.Value.Year == fecha.Year).FirstOrDefaultAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> ObtenerTasaCambio(DateTime fecha)
        {
            try
            {

                TasaCambio oTasaCambio = new TasaCambio();

                DateTime fechaBusqueda = fecha.Date;

                int mes = fechaBusqueda.Month;
                int año = fechaBusqueda.Year;

                oTasaCambio = await _dbContext.TasaCambios.FirstOrDefaultAsync(x => x.Fecha.Value.Month == mes && x.Fecha.Value.Year == año);

                if (oTasaCambio != null)
                {
                    return false;
                    //return throw("No se encontró ninguna tasa de cambio para la fecha proporcionada.");
                }

                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;

                // Consumir el servicio de manera asíncrona
                var response = await _client.RecuperaTC_MesAsync(fecha.Year, fecha.Month);

                // Obtener el XML del resultado de la tarea
                var xmlElement = response.Body.RecuperaTC_MesResult;

                // Procesar el XML como lo estabas haciendo
                XmlNodeList xmlNodLista = xmlElement.GetElementsByTagName("Tc");
                DataTable dtTipoCambio = new DataTable();

                // Agregar las columnas al DataTable
                foreach (XmlNode Node in xmlNodLista.Item(0).ChildNodes)
                {
                    DataColumn Col = new DataColumn(Node.Name, typeof(string));
                    dtTipoCambio.Columns.Add(Col);
                }

                // Agregar la información al DataTable
                for (int IntVal = 0; IntVal < xmlNodLista.Count; IntVal++)
                {
                    DataRow dr = dtTipoCambio.NewRow();
                    for (int Col = 0; Col < dtTipoCambio.Columns.Count; Col++)
                    {
                        if ((xmlNodLista.Item(IntVal).ChildNodes[Col].InnerText) != null)
                        {
                            dr[Col] = xmlNodLista.Item(IntVal).ChildNodes[Col].InnerText;
                        }
                        else
                        {
                            dr[Col] = null;
                        }
                    }
                    dtTipoCambio.Rows.Add(dr);
                }


                foreach (DataRow fila in dtTipoCambio.Rows)
                {
                    TasaCambio tasaCambio = new TasaCambio
                    {
                        IdTasaCambio = Guid.NewGuid(),
                        FechaRegistro = DateTime.Now,
                        Fecha = Convert.ToDateTime(fila[0].ToString()).ToDateOnly(),
                        TipoCambio = Convert.ToDouble(fila[1].ToString()),

                    };
                    _dbContext.Set<TasaCambio>().Add(tasaCambio);


                    //listaTasasCambio.Add(tasaCambio);
                }
                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
                throw;
            }
        }
    }
}
