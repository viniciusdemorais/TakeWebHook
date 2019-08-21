using AutoMapper;
using System.Collections.Generic;

namespace take.webhook.core.Lib
{
    public class Mapper<T, Y>
    {
        public Y Convert(T obj)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MapperProfile<T, Y>());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            return mapper.Map<T, Y>(obj);
        }

        public List<Y> ConvertList(List<T> list)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MapperProfile<T, Y>());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            return mapper.Map<List<Y>>(list);
        }
    }

    public class MapperProfile<T, Y> : Profile
    {
        public MapperProfile()
        {
            CreateMap<T, Y>();
            CreateMap<Y, T>();

        }
    }
}
