using System.IO;
using Microsoft.Extensions.Configuration;

namespace IgorMoura.Reminder.ApiTest
{
    public static class TestConfiguration
    {
        public static string ConnectionString
        {
            get
            {
                var pipelineConfig = new ConfigurationBuilder()
                                            .AddJsonFile("pipelinesettings.json")
                                            .Build();

                try
                {
                    var config = new ConfigurationBuilder()
                                    .AddJsonFile("appsettings.json")
                                    .Build();

                    var defaultConnection = config["Data:DefaultConnection:ConnectionString"];

                    if (string.IsNullOrEmpty(defaultConnection) || string.IsNullOrWhiteSpace(defaultConnection))
                    {
                        defaultConnection = pipelineConfig["Data:TestPipelineConnection:ConnectionString"];
                    }

                    return defaultConnection;
                }
                catch (FileNotFoundException)
                {
                    return pipelineConfig["Data:TestPipelineConnection:ConnectionString"];
                }
            }
        }
    }
}
