using AutoMapper;
using Core.Dtos;
using Core.Exceptions;
using Core.Interfaces;
using Data.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly AutoPartsDbContext ctx;
        private readonly IMapper mapper;
        public CategoryService(AutoPartsDbContext ctx, IMapper mapper)
        {
            this.ctx = ctx;
            this.mapper = mapper;
        }
        public CategoryDto? Get(int id)
        {
            var category = ctx.Categories.Where(x => x.Id == id).FirstOrDefault();


            if (category == null) throw new HttpException($"Category with id: {id} not found.", HttpStatusCode.NotFound);


            return mapper.Map<CategoryDto>(category);
        }

        public IEnumerable<CategoryDto> GetAll()
        {
            var categories = ctx.Categories.ToList();
            return mapper.Map<List<CategoryDto>>(categories);
        }
    }
}
