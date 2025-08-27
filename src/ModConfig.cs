using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MGSC;
using MouseMoveTransfer.Mcm;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using UnityEngine;

namespace MouseMoveTransfer
{
    public class ModConfig : ISave
    {

        /// <summary>
        /// If true, will silence the sound that the item movement makes.
        /// </summary>
        public bool DisableMoveSound { get; set; } = false;

        /// <summary>
        /// The "keys" to use to trigger the mouse move transfer functionality.
        /// </summary>
        public KeyChordHandler Keys = new KeyChordHandler(
            new List<List<KeyCode>>()
            {
                new List<KeyCode>() { KeyCode.LeftControl, KeyCode.Mouse0 },
                new List<KeyCode>() { KeyCode.RightControl, KeyCode.Mouse0 },
            });

        /// <summary>
        /// The hotkey to move items to the recycler.
        /// </summary>
        public KeyChordHandler RecyclerKey= new KeyChordHandler(
            new List<List<KeyCode>>()
            {
                new List<KeyCode>() { KeyCode.R},
            });

        [JsonIgnore]
        private static JsonSerializerSettings SerializerSettings = new JsonSerializerSettings()
        {
            Formatting = Formatting.Indented,
            ObjectCreationHandling = ObjectCreationHandling.Replace
        };

        public static ModConfig LoadConfig(string configPath)
        {
            ModConfig config;

            
            StringEnumConverter stringEnumConverter = new StringEnumConverter()
            {
                AllowIntegerValues = true
            };

            SerializerSettings.Converters.Add(stringEnumConverter);
            if (File.Exists(configPath))
            {
                try
                {
                    string sourceJson = File.ReadAllText(configPath);

                    config = JsonConvert.DeserializeObject<ModConfig>(sourceJson, SerializerSettings);

                    //Add any new elements that have been added since the last mod version the user had.
                    string upgradeConfig = JsonConvert.SerializeObject(config, SerializerSettings);

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
                    Plugin.Logger.LogError(ex, "Error parsing configuration.  Ignoring config file and using defaults");

                    //Not overwriting in case the user just made a typo.
                    config = new ModConfig();
                    return config;
                }
            }
            else
            {
                config = new ModConfig();
                config.Save();

                return config;
            }
        }

        public void Save()
        {
            string json = JsonConvert.SerializeObject(this, SerializerSettings);
            File.WriteAllText(Plugin.ConfigDirectories.ConfigPath, json);

        }
    }
}
