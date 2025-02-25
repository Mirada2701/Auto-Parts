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
    public class ProviderService : IProviderService
    {
        private readonly AutoPartsDbContext _context;
        private readonly IMapper _mapper;
        public ProviderService(AutoPartsDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public ProviderDto? Get(int id)
        {
            var provider = _context.Providers.Where(x => x.Id == id).FirstOrDefault();

            if (provider == null) throw new HttpException($"Provider with id: {id} not found.", HttpStatusCode.NotFound);

            return _mapper.Map<ProviderDto>(provider);
        }

        public IEnumerable<ProviderDto> GetAll()
        {
            var providers = _context.Providers.ToList();
            return _mapper.Map<List<ProviderDto>>(providers);
        }
    }
}
