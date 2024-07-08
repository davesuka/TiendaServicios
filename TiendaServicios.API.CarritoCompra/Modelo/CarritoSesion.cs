using System;
using System.Collections.Generic;

namespace TiendaServicios.API.CarritoCompra.Modelo
{
    public class CarritoSesion
    {
        public int CarritoSesionId { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public ICollection<CarritoSesionDetalle> ListDetalle { get; set; }
    }
}
