using UnityEngine;
using System;

namespace Quiz
{
    [Serializable]
    public struct BundleCell
    {
        public CellIdentifier Identifier;
        public Sprite CellSprite;
        public Orientation Orientation;
    }
}