using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ShadowWitch.Runtime.DataStructures;

namespace ShadowWitch.Runtime.Map
{
    public abstract class MapBase
    {
        #region fields
        protected SizeInt mapSize;
        protected Size cellSize;
        #endregion

        #region methods
        public void Init(SizeInt mapSize, Size cellSize)
        {
            this.mapSize = mapSize;
            this.cellSize = cellSize;
        }
        public abstract void DrawMapLine();
        #endregion
    }
}

