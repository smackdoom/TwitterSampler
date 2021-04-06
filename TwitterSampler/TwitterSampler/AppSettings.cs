using System;
namespace TwitterSampler
{
    public sealed class AppSettings
    {
        #region Properties
        public string ConsumerKey { get; set; }
        public string ConsumerSecret { get; set; }
        public string BearerToken { get; set; }

        #endregion

        #region Constructors
        public AppSettings()
        {
        }

        #endregion
    }
}
