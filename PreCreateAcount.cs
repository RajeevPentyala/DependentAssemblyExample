using Helper;
using Microsoft.Xrm.Sdk;
using Newtonsoft.Json;
using System;

namespace DependentAssemblyExample
{
    public class PreCreateAcount : PluginBase
    {
        public PreCreateAcount(string unsecureConfiguration, string secureConfiguration) : base(typeof(PreCreateAcount))
        {

        }

        protected override void ExecuteCdsPlugin(ILocalPluginContext localPluginContext)
        {
            if (localPluginContext == null)
            {
                throw new ArgumentNullException(nameof(localPluginContext));
            }

            var context = localPluginContext.PluginExecutionContext;

            if (context.InputParameters.Contains("Target") && context.InputParameters["Target"] is Entity)
            {
                var entity = (Entity)context.InputParameters["Target"];

                if (entity.LogicalName == "account")
                {
                    entity["name"] = AccountHelper.GetName();
                }
            }
        }
    }
}
