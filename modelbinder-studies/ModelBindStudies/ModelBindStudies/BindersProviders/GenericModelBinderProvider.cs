using Microsoft.AspNetCore.Mvc.ModelBinding;
using ModelBindStudies.Binders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelBindStudies.BindersProviders
{
    public class GenericModelBinderProvider : IModelBinderProvider
    {
        public static readonly IModelBinderProvider Instance = new GenericModelBinderProvider();
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context.Metadata.ModelType == typeof(object))
                return new GenericModelBinder();

            return null;
        }
    }
}
