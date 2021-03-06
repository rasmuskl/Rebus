﻿using System.Configuration;

namespace Rebus.Timeout.Configuration
{
    public class TimeoutConfigurationSection : ConfigurationSection
    {
        const string ConfigSectionName = "timeout";
        const string InputQueueAttributeName = "inputQueue";
        const string StorageTypeAttributeName = "storageType";
        const string ParametersAttributeName = "parameters";

        [ConfigurationProperty(InputQueueAttributeName)]
        public string InputQueue
        {
            get { return (string)this[InputQueueAttributeName]; }
            set { this[InputQueueAttributeName] = value; }
        }

        [ConfigurationProperty(StorageTypeAttributeName)]
        public string StorageType
        {
            get { return (string) this[StorageTypeAttributeName]; }
            set { this[StorageTypeAttributeName] = value; }
        }

        [ConfigurationProperty(ParametersAttributeName)]
        public string Parameters
        {
            get { return (string)this[ParametersAttributeName]; }
            set { this[ParametersAttributeName] = value; }
        }

        public static TimeoutConfigurationSection GetSection()
        {
            var section = ConfigurationManager.GetSection(ConfigSectionName);

            if (section == null) return null;

            if (!(section is TimeoutConfigurationSection))
            {
                throw new ConfigurationErrorsException(
                    string.Format(@"Could not find configuration section named '{0}' (or else
the configuration section was not of the {1} type?)

Please make sure that the declaration at the top matches the XML element further down. And please note
that it is NOT possible to rename this section, even though the declaration makes it seem like it.",
                                  ConfigSectionName,
                                  typeof (TimeoutConfigurationSection)));
            }

            return (TimeoutConfigurationSection) section;
        }
    }
}