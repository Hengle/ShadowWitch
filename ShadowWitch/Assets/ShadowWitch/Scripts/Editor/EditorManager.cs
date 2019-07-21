using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ShadowWitch.Editor.Window;

namespace ShadowWitch.Editor
{
    public class EditorManager : UnityEditor.Editor
    {
        #region fields
        private static List<WindowBase> windowList;
        #endregion
        
        #region constructors
        static EditorManager()
        {
            Init();
        }
        #endregion
        
        #region methods
        public static void AddWindow(WindowBase window)
        {
            windowList.Add(window);                        
        }

        public static int GetWindowCount()
        {
            return windowList.Count;
        }

        public static WindowBase GetWindow(int index)
        {
            return windowList[index];
        }
        
        private static void Init()
        {
            windowList = new List<WindowBase>();    
        }
        #endregion
    }
}
