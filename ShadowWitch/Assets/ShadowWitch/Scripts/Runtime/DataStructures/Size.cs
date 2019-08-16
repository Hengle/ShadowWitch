using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShadowWitch.Runtime.DataStructures
{
    public struct Size
    {
        #region fields
        public float Width;
        public float Height;
        #endregion

        #region constructors
        public Size(float widht, float height)
        {
            this.Width = widht;
            this.Height = height;
        }
        #endregion

        #region methods
        public static implicit operator Size(SizeInt sizeInt)
        {
            return new SizeInt(sizeInt.Width, sizeInt.Height);
        }
        #endregion
    }
}
