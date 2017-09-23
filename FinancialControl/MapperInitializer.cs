using AutoMapper;

namespace FinancialControl
{
    public class MapperInitializer
    {
        public void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Repositories.Color, Service.Dto.Color>();
                cfg.CreateMap<Service.Dto.Color, Repositories.Color>();
                cfg.CreateMap<Repositories.Category, Service.Dto.Category>();
                cfg.CreateMap<Service.Dto.Category, Repositories.Category>();
                //cfg.CreateMap<FinancialControl.Repositories.Color, Service.Dto.Color>();
            });
        }
    }
}
