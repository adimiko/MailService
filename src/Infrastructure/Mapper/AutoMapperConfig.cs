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
                cfg.CreateMap<Mail, MailDto>()
                .ForMember(d => d.From, s => s.MapFrom(s => s.From.Value))
                .ForMember(d => d.To, s => s.MapFrom(s => s.To.Value));
            }).CreateMapper();
    }
}
