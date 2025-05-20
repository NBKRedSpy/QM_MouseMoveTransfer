using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MGSC;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using UnityEngine;

namespace MouseMoveTransfer
{
    public class ModConfig
    {

        /// <summary>
        /// If true, will silence the sound that the item movement makes.
        /// </summary>
        public bool DisableMoveSound { get; set; } = false;

        public KeyChordHandler Keys = new KeyChordHandler(
            new List<List<KeyCode>>()
            {
                new List<KeyCode>() { KeyCode.LeftControl, KeyCode.Mouse0 },
                new List<KeyCode>() { KeyCode.RightControl, KeyCode.Mouse0 },
            });

        public static ModConfig LoadConfig(string configPath)
        {
            ModConfig config;

            JsonSerializerSettings serializerSettings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                ObjectCreationHandling = ObjectCreationHandling.Replace
            };
            
            StringEnumConverter stringEnumConverter = new StringEnumConverter()
            {
                AllowIntegerValues = true
            };

            serializerSettings.Converters.Add(stringEnumConverter);
            if (File.Exists(configPath))
            {
                try
                {
                    string sourceJson = File.ReadAllText(configPath);

                    config = JsonConvert.DeserializeObject<ModConfig>(sourceJson, serializerSettings);

                    //Add any new elements that have been added since the last mod version the user had.
                    string upgradeConfig = JsonConvert.SerializeObject(config, serializerSettings);

                    if (upgradeConfig != sourceJson)
                    {
                        Plugin.Logger.Log("Updating config with missing elements");
                        //re-write
                        File.WriteAllText(configPath, upgradeConfig);
                    }


                    return config;
                }
                catch (Exception ex)
                {
                    Plugin.Logger.LogError("Error parsing configuration.  Ignoring config file and using defaults");
                    Plugin.Logger.LogException(ex);

                    //Not overwriting in case the user just made a typo.
                    config = new ModConfig();
                    return config;
                }
            }
            else
            {
                config = new ModConfig();
                
                string json = JsonConvert.SerializeObject(config, serializerSettings);
                File.WriteAllText(configPath, json);

                return config;
            }


        }
    }
}
