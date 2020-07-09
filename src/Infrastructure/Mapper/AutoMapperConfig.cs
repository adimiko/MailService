using Application.DTOs;
using AutoMapper;
using Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Mapper
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EmailSettings, EmailSettingsDto>();
                cfg.CreateMap<EmailSettings, EmailSettingsDetailsDto>();
            }).CreateMapper();
    }
}
