using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MouseMoveTransfer
{
    /// <summary>
    /// A input helper that returns true if one or more key chords are being pressed.
    /// </summary>
    public class KeyChordHandler
    {
        public List<List<KeyCode>> Chords { get; set; } = new List<List<KeyCode>>();

        public KeyChordHandler()
        {
                
        }

        public KeyChordHandler(List<List<KeyCode>> chords)
        {
            Chords = chords;
        }

        /// <summary>
        /// Returns ture if one or more chords are pressed.
        /// </summary>
        /// <returns></returns>
        public bool IsPressed()
        {
            foreach (List<KeyCode> chord in Chords)
            {
                if (chord.Count == 0) continue;

                bool allPressed = true;
                foreach (KeyCode key in chord)
                {
                    if (!Input.GetKey(key))
                    {
                        allPressed = false;
                        break;
                    }
                }
                if (allPressed)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
