using System.Collections.Generic;
using UnityEngine;
using ShadowWitch.Editor.Window;
using System.Reflection;
using System;
using ShadowWitch.Runtime.Map;
using ShadowWitch.Runtime.MonoBehaviours;

namespace ShadowWitch.Editor
{
    public static class EditorManager
    {
        #region fields
        private static List<WindowBase> windowList;
        private static List<Type> mapTypeList;
        private static MapBehaviour mainMapBehaviour;
        #endregion
        
        #region constructors
        static EditorManager()
        {
            InitMapTypes();
            InitWindows();
        }
        #endregion
        
        #region properties
        public static MapBehaviour MainMapBehaviour
        {
            get
            {
                if (mainMapBehaviour != null)
                {
                    return mainMapBehaviour;
                }

                mainMapBehaviour = UnityEngine.Object.FindObjectOfType<MapBehaviour>();
                return mainMapBehaviour;
            }

            set
            {
                if (mainMapBehaviour != null)
                {
                    UnityEngine.Object.DestroyImmediate(mainMapBehaviour.gameObject);
                }

                mainMapBehaviour = value;
            }
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

        public static Type[] GetMapTypes()
        {
            return mapTypeList.ToArray();
        }
        
        private static void InitWindows()
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

                    EditorManager.AddWindow(window);
                }
            }
        }

        private static void InitMapTypes()
        {
            mapTypeList = new List<Type>();
            Assembly assembly = typeof(MapBase).Assembly;
            Type[] types = assembly.GetTypes();

            foreach (Type type in types)
            {
                if (typeof(MapBase).IsAssignableFrom(type) && type.IsClass && !type.IsAbstract)
                {
                    mapTypeList.Add(type);
                }
            }
        }
        #endregion
    }
}
