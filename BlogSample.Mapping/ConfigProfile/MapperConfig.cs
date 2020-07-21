using System;
using System.Collections.Generic;
using System.Text;

namespace BlogSample.Mapping.ConfigProfile
{
    public class MapperConfig
    {
        public static void RegisterMappers()
        {
            MapperFactory.RegisterMappers();
        }
    }
}
