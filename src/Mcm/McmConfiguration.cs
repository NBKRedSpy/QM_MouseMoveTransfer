using ModConfigMenu;
using ModConfigMenu.Objects;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using UnityEngine;

namespace MouseMoveTransfer.Mcm
{
    internal class McmConfiguration : McmConfigurationBase
    {

        public McmConfiguration(ModConfig config) : base (config) { }

        public override void Configure()
        {

            List<ConfigValue> configValues = new List<ConfigValue>();

            configValues.Add(CreateRestartMessage());

            configValues.Add(CreateConfigProperty(nameof(Config.DisableMoveSound),
                "Disables the game's sound when moving an item."));

            int index = 1;

            string readOnlyHeader = "Only available in config file";

            foreach (string item in Config.Keys.Chords.Select(x => x.KeyListToString()))
            {
                

                configValues.Add(new ConfigValue($"__Transfer{index}", $"Transfer Key Combination #{index++}: <color=#FFFEC1>{item}</color>", readOnlyHeader));

            }

            index = 1;
            foreach (string item in Config.RecyclerKey.Chords.Select(x => x.KeyListToString()))
            {
                configValues.Add(new ConfigValue($"__Recycle{index}", $"Recycle Key Combination #{index++}: <color=#FFFEC1>{item}</color>",
                    readOnlyHeader));
            }


            ModConfigMenuAPI.RegisterModConfig("Mouse Move Transfer", configValues, OnSave);
        }
        
    }
}
