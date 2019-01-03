using Microsoft.Extensions.DependencyInjection;

namespace IoC.Injection
{
    public static class DepedencyInjection
    {
        public static void AddDI(this IServiceCollection servies)
        {
            Injector.RegisterServices(servies);
        }
        
    }
}