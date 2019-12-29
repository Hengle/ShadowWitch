using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace ShadowWitch.Editor.Window
{
    public abstract class WindowBase
    {
        #region constructors
        // public WindowBase();
        #endregion
        
        #region methods
        public abstract void OnGUI();
        #endregion
    }
}
