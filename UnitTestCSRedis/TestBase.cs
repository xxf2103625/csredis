using Microsoft.VisualStudio.TestTools.UnitTesting;
using Autofac;
using CSRedis;

namespace UnitTestCSRedis
{
    
    public class TestBase
    {
        protected IContainer container; 
        [TestInitialize]
        public void Init()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.Register(m=>new CSRedisClient("192.168.0.198")).As<ICSRedisClient>().SingleInstance();
            container = builder.Build();
        }
        [TestCleanup]
        public void Disponse()
        {
            this.container.Dispose();
        }
        protected ICSRedisClient Client => Resole<ICSRedisClient>();
        protected TService Resole<TService>()
        {
            return this.container.Resolve<TService>();
        }
    }
}
