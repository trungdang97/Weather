using AutoMapper;
using AutoMapper.EquivalencyExpression;
using System.Collections.Generic;

namespace Weather.Data.V1
{
    public static class AutoMapperUtils
    {
        private static IMapper GetMapper<TSource, TDestination>()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.AddCollectionMappers();
                cfg.ValidateInlineMaps = false;
                cfg.AllowNullCollections = true;
                cfg.AllowNullDestinationValues = true;
                cfg.CreateMap<TSource, TDestination>(MemberList.None);
            });

            IMapper mapper = new Mapper(config);
            return mapper;
        }
        private static IMapper GetMapper<TSource, TDestination>(string idString)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.AddCollectionMappers();
                cfg.ValidateInlineMaps = false;
                cfg.AllowNullCollections = true;
                cfg.AllowNullDestinationValues = true;
                cfg.CreateMap<TSource, TDestination>(MemberList.None).ForSourceMember(idString, s => s.Ignore()).ForMember(idString, s => s.Ignore());

            });

            IMapper mapper = new Mapper(config);
            return mapper;
        }
        private static IMapper GetMapper<TSource, TDestination>(params string[] excludeProps)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.AddCollectionMappers();
                cfg.ValidateInlineMaps = false;
                cfg.AllowNullCollections = true;
                cfg.AllowNullDestinationValues = true;
                var cr = cfg.CreateMap<TSource, TDestination>(MemberList.None);
                for (var i = 0; i < excludeProps.Length; i++)
                {
                    cr.ForSourceMember(excludeProps[i], s => s.Ignore()).ForMember(excludeProps[i], s => s.Ignore());
                }
            });

            IMapper mapper = new Mapper(config);
            return mapper;
        }
        #region Single
        public static TDestination AutoMap<TSource, TDestination>(TSource source)
        {
            var mapper = GetMapper<TSource, TDestination>();
            TDestination dest = mapper.Map<TDestination>(source);
            return dest;
        }

        public static TDestination AutoMap<TSource, TDestination>(TSource source, string idString)
        {
            var mapper = GetMapper<TSource, TDestination>(idString);
            TDestination dest = mapper.Map<TDestination>(source);
            return dest;
        }
        public static TDestination AutoMap<TSource, TDestination>(TSource source, TDestination dest)
        {
            var mapper = GetMapper<TSource, TDestination>();
            dest = mapper.Map(source, dest);
            return dest;
        }

        public static TDestination AutoMap<TSource, TDestination>(TSource source, TDestination dest, string idString)
        {
            var mapper = GetMapper<TSource, TDestination>(idString);
            dest = mapper.Map(source, dest);
            return dest;
        }
        public static TDestination AutoMap<TSource, TDestination>(TSource source, params string[] excludeProps)
        {
            var mapper = GetMapper<TSource, TDestination>(excludeProps);
            TDestination dest = mapper.Map<TDestination>(source);
            return dest;
        }
        #endregion
        #region List
        public static List<TDestination> AutoMap<TSource, TDestination>(List<TSource> source)
        {
            var mapper = GetMapper<TSource, TDestination>();
            List<TDestination> dest = mapper.Map<List<TDestination>>(source);
            return dest;
        }

        public static List<TDestination> AutoMap<TSource, TDestination>(List<TSource> source, string idString)
        {
            var mapper = GetMapper<TSource, TDestination>(idString);
            List<TDestination> dest = mapper.Map<List<TDestination>>(source);
            return dest;
        }
        public static List<TDestination> AutoMap<TSource, TDestination>(List<TSource> source, params string[] excludeProps)
        {
            var mapper = GetMapper<TSource, TDestination>(excludeProps);
            List<TDestination> dest = mapper.Map<List<TDestination>>(source);
            return dest;
        }
        public static List<TDestination> AutoMap<TSource, TDestination>(List<TSource> source, List<TDestination> dest)
        {
            var mapper = GetMapper<TSource, TDestination>();
            dest = mapper.Map(source, dest);
            return dest;
        }

        public static List<TDestination> AutoMap<TSource, TDestination>(List<TSource> source, List<TDestination> dest, string idString)
        {
            var mapper = GetMapper<TSource, TDestination>(idString);
            dest = mapper.Map(source, dest);
            return dest;
        }
        #endregion

    }
}
