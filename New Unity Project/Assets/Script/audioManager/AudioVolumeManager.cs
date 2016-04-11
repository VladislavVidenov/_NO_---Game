using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets
{
    public class AudioVolumeManager
    {
        private static float _music = 1f;
        private static float _sfx = 1f;

        public static float Music
        {
            get { return _music; }
            set { _music = value; }
        }

        public static float Sfx
        {
            get { return _sfx; }
            set { _sfx = value; }
        }
    }
}
