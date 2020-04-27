using System;
using ContratosApi.Data;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace ContratosApi.Binder {
    public class ContractEntityBinderProvider : IModelBinderProvider {
        public IModelBinder GetBinder (ModelBinderProviderContext context) {
            
            if (context == null) {
                throw new ArgumentNullException (nameof (context));
            }

            if (context.Metadata.ModelType == typeof (Contract)) {
                return new BinderTypeModelBinder (typeof (ContractEntityBinder));
            }

            return null;
        }
    }
}