﻿using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TiendaServicios.API.Libro.Persistencia;

namespace TiendaServicios.API.Libro.Aplicacion
{
    public class ConsultaFiltro
    {
        public class LibroUnico : IRequest<LibroMaterialDto> 
        {
            public Guid? LibroId { get; set; }
        }

        public class Manejador : IRequestHandler<LibroUnico, LibroMaterialDto>
        {
            private readonly ContextoLibreria _contexto;
            private readonly IMapper _mapper;

            public Manejador(ContextoLibreria contexto, IMapper mapper)
            {
                _contexto = contexto;
                _mapper = mapper;
            }

            public async Task<LibroMaterialDto> Handle(LibroUnico request, CancellationToken cancellationToken)
            {
                var libro = 
                    await _contexto.LibreriaMaterial.
                    Where(x => x.LibreriaMaterialId == request.LibroId).
                    FirstOrDefaultAsync();

                if (libro == null)
                {
                    throw new Exception("No se encontro el libro");
                }

                var libroDto = _mapper.Map<LibroMaterialDto>(libro);

                return libroDto;
            }
        }
    }
}
