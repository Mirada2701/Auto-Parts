using AutoMapper;
using Core.Dtos;
using Core.Exceptions;
using Core.Interfaces;
using Data.Data;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class ProducerService : IProducerService
    {
        private readonly AutoPartsDbContext _context;
        private readonly IMapper _mapper;
        public ProducerService(AutoPartsDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public ProducerDto? Get(int id)
        {
            var producer = _context.Producers.Where(x => x.Id == id).FirstOrDefault();

            if (producer == null) throw new HttpException($"Producer with id: {id} not found.", HttpStatusCode.NotFound);

            return _mapper.Map<ProducerDto>(producer);
        }

        public IEnumerable<ProducerDto> GetAll()
        {
            var producers = _context.Producers.ToList();
            return _mapper.Map<List<ProducerDto>>(producers);
        }
    }
}
