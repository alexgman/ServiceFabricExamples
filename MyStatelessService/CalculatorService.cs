using Microsoft.ServiceFabric.Services.Communication.Runtime;
using Microsoft.ServiceFabric.Services.Remoting.Runtime;
using Microsoft.ServiceFabric.Services.Runtime;
using System.Collections.Generic;
using System.Fabric;
using System.Threading.Tasks;

namespace MyStatelessService
{
    internal sealed class CalculatorService : StatelessService, ICalculatorService
    {
        public CalculatorService(StatelessServiceContext serviceContext) : base(serviceContext)
        {
        }

        public Task<string> Add(int a, int b)
        {
            return Task.FromResult(string.Format("Instance{0} returns: {1}", base.Context.InstanceId, a + b));
        }

        public Task<string> Subtract(int a, int b)
        {
            return Task.FromResult(string.Format("Instance{0} returns: {1}", base.Context.InstanceId, a - b));
        }

        protected override IEnumerable<ServiceInstanceListener> CreateServiceInstanceListeners()
        {
            return new[] { new ServiceInstanceListener(context => this.CreateServiceRemotingListener(context)) };
        }
    }
}