using System.Composition;
using Microsoft.Extensions.Logging;

namespace WaterMango_Service.Utils
{
    [Export(typeof(ILoggerFactory))]
    public class MefLoggerFactory : LoggerFactory
    {
        
    }
}