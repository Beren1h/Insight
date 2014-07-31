using Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.ModelBinding;

namespace Api.Framework
{
    public class Test : IModelBinder
    {
        public bool BindModel(System.Web.Http.Controllers.HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            if (bindingContext.ModelType != typeof(Item))
            {
                return false;
            }

            var val = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
                       

            if (val.RawValue.ToString() == "_id")
            {
                int x = 1;
            }

            return true;
        }
    }
}