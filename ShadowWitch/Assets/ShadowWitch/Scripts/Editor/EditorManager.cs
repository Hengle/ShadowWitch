using System.Collections.Generic;
using UnityEngine;
using ShadowWitch.Editor.Window;
using System.Reflection;
using System;
using ShadowWitch.Runtime.DataStructures;
using ShadowWitch.Runtime.Map;
using ShadowWitch.Runtime.MonoBehaviours;
using UnityEditor;

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
            AddShadowWitchLayer();
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
        }
        #endregion
        
        #region methods

        public static MapBehaviour CreateMainMap(Type mapType, SizeInt mapSize, Size cellSize)
        {
            MapBehaviour currentMainMapBehaviour = MainMapBehaviour;

            if (currentMainMapBehaviour != null)
            {
                UnityEngine.Object.DestroyImmediate(currentMainMapBehaviour.gameObject);
                currentMainMapBehaviour = null;
            }
            
            GameObject mapGO = new GameObject("Map");
            mapGO.layer = LayerMask.NameToLayer(EditorStringReferences.ShadowWitchLayerName);
            MapBehaviour mapBehaviour = mapGO.AddComponent<MapBehaviour>();
            MapBase map = mapType.Assembly.CreateInstance(mapType.ToString()) as MapBase;
            map.Init(mapSize, cellSize);
            mapBehaviour.Init(map);
            mainMapBehaviour = mapBehaviour;
            BoxCollider boxCollider = mapGO.AddComponent<BoxCollider>();
            boxCollider.isTrigger = true;
            boxCollider.center = new Vector3(mapSize.Width / 2f * cellSize.Width, 0f, -mapSize.Height / 2f * cellSize.Height);
            boxCollider.size = new Vector3(mapSize.Width * cellSize.Width, 0f, mapSize.Height * cellSize.Height);
            return mainMapBehaviour;
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

        private static bool AddShadowWitchLayer()
        {
            if (HasLayer(EditorStringReferences.ShadowWitchLayerName))
            {
                return true;
            }
            
            SerializedObject tagManager = new SerializedObject(AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/Tagmanager.asset"));
            SerializedProperty it = tagManager.GetIterator();
            
            while(it.NextVisible(true))
            {
                if(it.name.Equals("layers") == false)
                {
                    continue;
                }
                
                for(int i = 0; i < it.arraySize; ++i)
                {
                    if( i <= 7)
                    {
                        continue;
                    }
                        
                    SerializedProperty sp = it.GetArrayElementAtIndex(i);
                        
                    if(string.IsNullOrEmpty(sp.stringValue))
                    {
                        sp.stringValue = EditorStringReferences.ShadowWitchLayerName;
                        tagManager.ApplyModifiedProperties();
                        return true;
                    }
                }
            }

            return false;
        }
        
        private static bool HasLayer(string layerName)
        {
            for(int i= 0; i< UnityEditorInternal.InternalEditorUtility.layers.Length; ++i)
            {
                if(UnityEditorInternal.InternalEditorUtility.layers[i].Contains(layerName))
                {
                    return true;
                }
            }
            
            return false;
        }

        #endregion
    }
}
