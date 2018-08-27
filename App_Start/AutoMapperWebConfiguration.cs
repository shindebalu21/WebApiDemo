using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using WebApi.Models;
using WebApiDemo.ViewModal;
namespace WebApiDemo.App_Start
{
    public static class AutoMapperWebConfiguration
    {
        public static void Configure()
        {
            ConfigureUserMapping();
            
        }

        private static void ConfigureUserMapping()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Student,StudentViewModal>());

        }

        // ... etc
    }
}