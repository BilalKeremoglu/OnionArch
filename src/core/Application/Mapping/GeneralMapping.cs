using Application.Dto;
using Application.Features.Commands.CreateProduct;
using AutoMapper;
using ProductApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapping
{
    public class GeneralMapping: Profile
    {
        public GeneralMapping()
        {
            CreateMap<Product, ProdcutViewDto>()
                .ReverseMap();

            CreateMap<Product, CreateProductCommand>()
                .ReverseMap();

            CreateMap<Product, GetProductDetailViewModel>()
                .ReverseMap();
        }
    }
}
