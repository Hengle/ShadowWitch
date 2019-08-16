using System.Collections.Generic;
using UnityEngine;
using ShadowWitch.Editor.Window;
using System.Reflection;
using System;

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
            InitFields();
            InitWindows();
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
        
        private static void InitFields()
        {
            windowList = new List<WindowBase>();    
        }

        private static void InitWindows()
        {
            Assembly assembly = Assembly.GetAssembly(typeof(EditorManager));
            Type[] types = assembly.GetTypes();

            foreach (Type type in types)
            {
                if (typeof(WindowBase).IsAssignableFrom(type) && type.IsClass && !type.IsAbstract)
                {
                    WindowBase window = ScriptableObject.CreateInstance(type) as WindowBase;

                    if (window == null)
                    {
                        continue;
                    }

                    EditorManager.AddWindow(window);
                }
            }
        }
        #endregion
    }
}
