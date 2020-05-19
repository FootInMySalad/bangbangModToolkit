// (c) Copyright 2020 Gavin Tantleff. All rights reserved.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace bangbang.API
{
    [CreateAssetMenu(fileName = "ModSetting")]
    public class ModSettings : ScriptableObject
    {
        public string Title;
        public GameTypes GameType = GameTypes.FFA;

        public bool EnableMapImage = false;
        public Sprite MapImage;
    }

    public enum GameTypes
    {
        FFA,
        TDM,
        Death
        // KOTH - Not available yet
    }
}
