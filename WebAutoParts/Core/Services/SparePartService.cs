using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.Dtos;
using Core.Exceptions;
using Core.Interfaces;
using Data.Data;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.Services
{
    public class SparePartService : IPartsService
    {
        private readonly AutoPartsDbContext ctx;
        private readonly IMapper mapper;
        public SparePartService(AutoPartsDbContext ctx, IMapper mapper)
        {
            this.ctx = ctx;
            this.mapper = mapper;
        }       

        public IEnumerable<SparePartDto> GetAll()
        {
            var parts = ctx.SpareParts.Include(x => x.Provider).Include(x => x.Category).Include(x => x.Producer).ToList();
            return mapper.Map<List<SparePartDto>>(parts);
        }
        public SparePartDto? Get(int id)
        {
            var part = ctx.SpareParts.Include(x => x.Provider).Include(x => x.Category).Include(x => x.Producer).Where(x => x.Id == id).FirstOrDefault();


            if (part == null) throw new HttpException($"Part with id: {id} not found.", HttpStatusCode.NotFound);
            

            return mapper.Map<SparePartDto>(part);
        }

        public void Delete(int id)
        {
            var part = ctx.SpareParts.Find(id);

            if(part == null) throw new HttpException($"Part with {id} not found.", HttpStatusCode.NotFound);

            ctx.SpareParts.Remove(part);
            ctx.SaveChanges();
        }

        public void Create(CreateSparePartDto part)
        {
            ctx.SpareParts.Add(mapper.Map<SparePart>(part));
            ctx.SaveChanges();
        }

        public void Edit(EditSparePartDto model)
        {
            ctx.SpareParts.Update(mapper.Map<SparePart>(model));
            ctx.SaveChanges();
        }
    }
}
