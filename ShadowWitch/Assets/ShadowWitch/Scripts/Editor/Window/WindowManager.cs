using System.Collections.Generic;
using UnityEngine;
using ShadowWitch.Editor.Window;
using System.Reflection;
using System;
using ShadowWitch.Runtime.DataStructures;
using ShadowWitch.Runtime.Map;
using ShadowWitch.Runtime.MonoBehaviours;
using UnityEditor;

namespace ShadowWitch.Editor.Window
{
    public static class WindowManager
    {
        #region fields
        private static List<WindowBase> windowList;
        #endregion
        
        #region methods
        public static void Init()
        {
            windowList = new List<WindowBase>();    
            Assembly assembly = Assembly.GetAssembly(typeof(EditorManager));
            Type[] types = assembly.GetTypes();

            foreach (Type type in types)
            {
                if (typeof(WindowBase).IsAssignableFrom(type) && type.IsClass && !type.IsAbstract)
                {
                    WindowBase window = assembly.CreateInstance(type.ToString()) as WindowBase;

                    if (window == null)
                    {
                        continue;
                    }

                    AddWindow(window);
                }
            }
        }
        
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

        public static string[] GetWindowNames()
        {
            string[] names = new string[windowList.Count];

            for (int i = 0; i < names.Length; ++i)
            {
                names[i] = windowList[i].Name;
            }

            return names;
        }
        #endregion
    }
}