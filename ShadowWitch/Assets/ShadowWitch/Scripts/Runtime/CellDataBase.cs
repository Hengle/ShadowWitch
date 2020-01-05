using System;
using ShadowWitch.Runtime.DataStructures;
using UnityEngine;

namespace ShadowWitch.Runtime
{
    [Serializable]
    public class CellDataBase : ScriptableObject
    {
        #region fields
        [SerializeField]
        protected RowColumnInt coord;
        #endregion
    }
}