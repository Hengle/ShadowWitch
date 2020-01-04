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
        
        #region properties
        public abstract string Name { get; }
        #endregion

        #region methods
        public virtual void OnEnable()
        {
        }

        public virtual void OnDisable()
        {
        }
        
        public abstract void OnGUI();
        #endregion
    }
}
