using Autofac;
using EKadry.Domain.Auth;

namespace EKadry.Infrastructure.Auth
{
    public class AuthModule : Module
    {
        private readonly string _secretKey;
        private readonly int _expire;

        public AuthModule(string secretKey, int expire)
        {
            _secretKey = secretKey;
            _expire = expire;
        }
        
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new JwtService(_secretKey, _expire))
                .As<IAuthService>()
                .InstancePerLifetimeScope();
            
            builder.RegisterType<JwtContainerModel>()
                .As<IAuthContainerModel>()
                .InstancePerLifetimeScope();
        }
    }
}