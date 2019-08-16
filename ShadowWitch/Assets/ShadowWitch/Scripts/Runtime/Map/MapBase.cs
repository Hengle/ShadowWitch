using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ShadowWitch.Runtime.DataStructures;

namespace ShadowWitch.Runtime.Map
{
    public abstract class MapBase
    {
        #region fields
        protected SizeInt size;
        #endregion

        #region methods
        public abstract void DrawMapLine();
        #endregion
    }
}

