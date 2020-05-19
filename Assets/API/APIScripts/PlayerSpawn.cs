// (c) Copyright 2020 Gavin Tantleff. All rights reserved.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace bangbang.API
{
    public class PlayerSpawn : MonoBehaviour
    {
        public TeamType teamType = TeamType.Neutral;
    }

    public enum TeamType
    {
        Neutral,
        Red,
        Blue
    }
}