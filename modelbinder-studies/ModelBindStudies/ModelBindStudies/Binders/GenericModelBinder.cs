using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ModelBindStudies.Binders
{
    public sealed class GenericModelBinder : IModelBinder
    {
        private const string ContentType = "application/json";

        public async Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext.HttpContext.Request.ContentType.StartsWith(ContentType, StringComparison.OrdinalIgnoreCase) == true)
            {
                dynamic data = null;
                var response = new PostTest();

                var body = bindingContext.HttpContext.Request.Body;
                var reader = new StreamReader(body);
                var text = await reader.ReadToEndAsync();
                var contract = JsonConvert.DeserializeObject<object>(text);
                response.Data = contract;
                //var properties = typeof(object).GetProperties();

                //foreach (var property in properties)
                //{
                //    var valueProvider = bindingContext.ValueProvider.GetValue(property.Name);
                //    var valueProvider = contract.GetType().GetProperty(property.Name).GetValue(contract, null);
                //    if (string.IsNullOrWhiteSpace(valueProvider.FirstValue) is false)
                //    {
                //        property.SetValue(contract, valueProvider.FirstValue);
                //    }
                //TODO: Get params from header
                //TODO: Get params from claims
                //}

                var token = bindingContext.HttpContext.Request.Headers[HeaderNames.Authorization][0];
                var document = bindingContext.HttpContext.Request.Headers["Document"][0];
                response.Token = token;
                response.Document = document;

                bindingContext.Result = ModelBindingResult.Success(response);
            }
        }
    }
}
