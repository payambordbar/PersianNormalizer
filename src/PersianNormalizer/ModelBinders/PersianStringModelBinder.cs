using Microsoft.AspNetCore.Mvc.ModelBinding;

using PersianNormalizer.Extensions;

namespace PersianNormalizer.ModelBinders;

public class PersianStringModelBinder : IModelBinder
{
    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        if (bindingContext == null)
        {
            throw new ArgumentNullException(nameof(bindingContext));
        }

        var modelName = bindingContext.ModelName;

        // Try to fetch the value of the argument by name
        var valueProviderResult = bindingContext.ValueProvider.GetValue(modelName);

        if (valueProviderResult == ValueProviderResult.None)
        {
            return Task.CompletedTask;
        }

        bindingContext.Result = ModelBindingResult.Success(valueProviderResult.FirstValue?.CleanString());

        return Task.CompletedTask;
    }
}