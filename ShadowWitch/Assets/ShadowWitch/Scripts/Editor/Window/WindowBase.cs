using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace ShadowWitch.Editor.Window
{
    public abstract class WindowBase : ScriptableObject
    {
        #region constructors
        // public WindowBase();
        #endregion
        
        #region methods
        public abstract void OnGUI();
        #endregion
    }
}
