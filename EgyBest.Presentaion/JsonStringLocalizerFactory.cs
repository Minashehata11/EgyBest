using Microsoft.Extensions.Localization;

namespace EgyBest.Presentaion
{
    public class JsonStringLocalizerFactory:IStringLocalizerFactory
    {
        public IStringLocalizer Create(Type resourceSource)
        {
            return new JsonBasedLocalization();
        }

        public IStringLocalizer Create(string baseName, string location)
        {
            return new JsonBasedLocalization();
        }
    }
}
