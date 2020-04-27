using System;
using System.Threading.Tasks;
using ContratosApi.Data;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ContratosApi.Binder {
    public class ContractEntityBinder : IModelBinder {
        private readonly DataContext _context;

        public ContractEntityBinder (DataContext context) {
            _context = context;
        }

        public Task BindModelAsync (ModelBindingContext bindingContext) {
            if (bindingContext == null) {
                throw new ArgumentNullException (nameof (bindingContext));
            }

            var modelName = bindingContext.ModelName;

            // Tente buscar o valor do argumento pelo nome
            var valueProviderResult = bindingContext.ValueProvider.GetValue(modelName);

            if (valueProviderResult == ValueProviderResult.None) {
                return Task.CompletedTask;
            }

            bindingContext.ModelState.SetModelValue (modelName, valueProviderResult);

            var value = valueProviderResult.FirstValue;

            // Verifique se o valor do argumento é nulo ou vazio
            if (string.IsNullOrEmpty (value)) {
                return Task.CompletedTask;
            }

            if (!int.TryParse (value, out var id)) {
                // Argumentos não inteiros resultam em erros de estado do modelo
                bindingContext.ModelState.TryAddModelError (
                    modelName, "Contract Id must be an integer.");

                return Task.CompletedTask;
            }

            // O modelo será nulo se não for encontrado, inclusive para
            // valores de ID fora do intervalo (0, -3 etc.)
            var model = _context.Contracts.Find (id);
            bindingContext.Result = ModelBindingResult.Success (model);
            return Task.CompletedTask;
        }
    }
}