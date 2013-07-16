using System;
using System.Configuration;

namespace Gauges_dotnet.tests.Support
{
    /// <summary>
    /// Configuration class to be used for unit tests.  Some of these items are secrets
    /// and should be defanged before checking into source control
    /// </summary>
    public abstract class ConfigureContext
    {
        protected ConfigureContext()
        {
            if (!IsValid)
                throw new ConfigurationErrorsException("Please setup the ConfigureContext.TestConfig class with your account details");
        }

        /// <summary>
        /// Set a valid API Key from https://secure.gaug.es/dashboard#/account/clients 
        /// </summary>       
        protected const string ApiKey = "Please Enter API Key";
        protected const string WellKnownEmailAddress = "user@example.com";

        private static bool IsValid
        {
            get
            {
                if (String.IsNullOrWhiteSpace(ApiKey)) return false;
                if (ApiKey.Equals("Please Enter API Key")) return false;
                if (String.IsNullOrWhiteSpace(WellKnownEmailAddress)) return false;

                return true;
            }
        }
    }
}