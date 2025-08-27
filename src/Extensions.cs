using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MouseMoveTransfer
{
    public static class Extensions
    {
        public static string KeyListToString(this List<KeyCode> keyCodes)
        {
            return string.Join(", ", keyCodes).Trim();
        }
    }
}
