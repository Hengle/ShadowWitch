using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ShadowWitch.Runtime.DataStructures;

namespace ShadowWitch.Runtime.Map
{
    [Serializable]
    public abstract class MapBase
    {
        #region fields
        [SerializeField]
        protected SizeInt mapSize;
        [SerializeField]
        protected Size cellSize;
        #endregion

        #region properties
        public SizeInt MapSize
        {
            get { return mapSize; }
        }

        public Size CellSize
        {
            get { return cellSize; }
        }
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

