using AutoMapper;
using UoW.UoW;

namespace Application.AppService.Base
{
    public abstract class BaseAppService
    {
        protected readonly IMapper Mapper;
        protected readonly IUnitOfWork UoW;

        protected BaseAppService(IMapper mapper, IUnitOfWork uoW)
        {
            Mapper = mapper;
            UoW = uoW;
        }


        public bool Commit()
        {
            return UoW.Commit();
        }
    }
}