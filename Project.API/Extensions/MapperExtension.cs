using AutoMapper;
using Project.Core.Entities.Business;
using Project.Core.Entities.General;
using Project.Core.Interfaces.IMapper;
using Project.Core.Mapper;

namespace Project.API.Extensions
{
    public static class MapperExtension
    {
        public static IServiceCollection RegisterMapperService(this IServiceCollection services)
        {

            #region Mapper

            services.AddSingleton<IMapper>(sp => new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Cemetery, CemeteryViewModel>();
                cfg.CreateMap<Grave, GraveViewModel>();
            }).CreateMapper());

            // Register the IMapperService implementation with your dependency injection container
            services.AddSingleton<IBaseMapper<Cemetery, CemeteryViewModel>, BaseMapper<Cemetery, CemeteryViewModel>>();
            services.AddSingleton<IBaseMapper<Grave, GraveViewModel>, BaseMapper<Grave, GraveViewModel>>();

            #endregion

            return services;
        }
    }
}