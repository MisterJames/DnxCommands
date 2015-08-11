using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Framework.Configuration;
using Microsoft.Framework.Runtime;

namespace DnxCommands
{
    public class Program
    {
        private readonly IApplicationEnvironment _appEnv;

        public Program(IApplicationEnvironment appEnv)
        {
            _appEnv = appEnv;
        }

        public IConfiguration Configuration { get; set; }

        public void Main(string[] args)
        {
            BuildConfiguration(args);

            Console.WriteLine(Configuration.Get("command-text"));
            Console.ReadLine();
        }

        private void BuildConfiguration(string[] args)
        {
            var builder = new ConfigurationBuilder(_appEnv.ApplicationBasePath)
                .AddJsonFile("config.json")
                .AddCommandLine(args);

            Configuration = builder.Build();
        }
    }
}
