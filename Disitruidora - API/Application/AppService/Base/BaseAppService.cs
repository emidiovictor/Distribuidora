using AutoMapper;

namespace Application.AppService.Base
{
    public abstract class BaseAppService
    {
        protected readonly IMapper mapper;

        protected BaseAppService(IMapper mapper)
        {
            this.mapper = mapper;
        }
    }
}