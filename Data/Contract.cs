using ContratosApi.Binder;
using Microsoft.AspNetCore.Mvc;

namespace ContratosApi.Data
{
    [ModelBinder(BinderType = typeof(ContractEntityBinder))]
    public class Contract
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public string Bank { get; set; }
        public decimal Value { get; set; }
        public int NumInstallments { get; set; }
    }
}