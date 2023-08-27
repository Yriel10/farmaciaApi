using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Threading.Tasks;
using System.Collections.Generic;
using farmaciaApi.Context;
using farmaciaApi.Models;

namespace farmaciaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaDetalleController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public FacturaDetalleController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("{idFactura}")]
        public async Task<ActionResult<IEnumerable<FacturaDetalleModel>>> Get(int idFactura)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("conexion")))
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand("Facturacion", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@IdFactura", idFactura));

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        var facturacionList = new List<FacturaDetalleModel>();

                        while (await reader.ReadAsync())
                        {
                            facturacionList.Add(new FacturaDetalleModel
                            {
                                IdFactura = Convert.ToInt32(reader["IdFactura"]),
                                Fecha = Convert.ToDateTime(reader["Fecha"]),
                                IdDetalle = Convert.ToInt32(reader["IdDetalle"]),
                                NombreProducto = reader["NombreProducto"].ToString(),
                                Cantidad = Convert.ToInt32(reader["Cantidad"]),
                                Precio = Convert.ToDecimal(reader["Precio"]),
                                Nombres = reader["Nombres"].ToString(),
                                Apellidos = reader["Apellidos"].ToString(),
                                Total = Convert.ToDecimal(reader["Total"])
                            });
                        }

                        return Ok(facturacionList);
                    }
                }
            }
        }
    }
}
