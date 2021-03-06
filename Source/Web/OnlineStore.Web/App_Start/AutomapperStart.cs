﻿namespace OnlineStore.Web.App_Start
{
    using Infrastructure.Mapping;
    using System.Reflection;

    public static class AutomapperStart
    {
        public static void RegisterAllMappings()
        {
            var autoMapperConfig = new AutoMapperConfig();
            autoMapperConfig.Execute(Assembly.GetExecutingAssembly());
        }
    }
}