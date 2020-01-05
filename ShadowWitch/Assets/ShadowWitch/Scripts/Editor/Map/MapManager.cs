using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System;
using ShadowWitch.Editor.Layer;
using ShadowWitch.Runtime.DataStructures;
using ShadowWitch.Runtime.Map;
using ShadowWitch.Runtime.MonoBehaviours;

namespace ShadowWitch.Editor.Map
{
    public static class MapManager
    {
        #region fields
        private static List<Type> mapTypeList;
        private static MapBehaviour mainMapBehaviour;
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
        public static void Init()
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
            mapBehaviour.Init(map, CreateLayerGameObjects());
            mainMapBehaviour = mapBehaviour;
            BoxCollider boxCollider = mapGO.AddComponent<BoxCollider>();
            boxCollider.isTrigger = true;
            boxCollider.center = new Vector3(mapSize.Width / 2f * cellSize.Width, 0f, -mapSize.Height / 2f * cellSize.Height);
            boxCollider.size = new Vector3(mapSize.Width * cellSize.Width, 0f, mapSize.Height * cellSize.Height);
            return mainMapBehaviour;
        }

        public static Type[] GetMapTypes()
        {
            return mapTypeList.ToArray();
        }

        private static Dictionary<string, GameObject> CreateLayerGameObjects()
        {
            string[] layerNames = LayerManager.GetLayerNames();
            Dictionary<string, GameObject> layerGODict = new Dictionary<string, GameObject>();

            foreach (string layerName in layerNames)
            {
                GameObject layerGO = new GameObject(layerName);
                layerGO.transform.parent = mainMapBehaviour.transform;
                layerGODict.Add(layerName, layerGO);
            }

            return layerGODict;
        }
        #endregion
    }
}