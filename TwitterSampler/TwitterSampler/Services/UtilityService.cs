using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TwitterSampler.Interfaces;

namespace TwitterSampler.Services
{
    public class UtilityService : IUtilityService
    {
        #region Constructors
        public UtilityService() { }

        #endregion

        #region Public Methods
        public async Task<T> GetEmbeddedJsonFile<T>(string resourceName)
        {
            var json = string.Empty;

            using (var resourceStream = this.GetType().Assembly.GetManifestResourceStream(resourceName))
            using (var reader = new StreamReader(resourceStream))
                json = await reader.ReadToEndAsync();

            T content = JsonConvert.DeserializeObject<T>(json);

            return content;
        }




        #endregion
    }
}
