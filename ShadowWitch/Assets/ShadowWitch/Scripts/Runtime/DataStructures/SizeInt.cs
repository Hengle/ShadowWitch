using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShadowWitch.Runtime.DataStructures
{
    public struct SizeInt
    {
        #region fields
        public int Width;
        public int Height;
        #endregion

        #region constructors
        public SizeInt(int widht, int height)
        {
            this.Width = widht;
            this.Height = height;
        }
        #endregion

        #region methods
        public static explicit operator SizeInt(Size size)
        {
            return new SizeInt((int)size.Width, (int)size.Height);
        }
        #endregion
    }
}
