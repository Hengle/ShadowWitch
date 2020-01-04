using System;
using System.Collections.Generic;
using System.Reflection;

namespace ShadowWitch.Editor.Layer
{
    public static class LayerManager
    {
        #region fields
        private static List<LayerBase> layerList;
        private static int currentLayerIndex;
        #endregion

        #region properties
        public static int CurrentLayerIndex
        {
            get { return currentLayerIndex; }
            set { currentLayerIndex = value; }
        }

        public static LayerBase CurrentLayer
        {
            get { return layerList[currentLayerIndex]; }
        }
        #endregion
        
        #region methods
        public static void Init()
        {
            layerList = new List<LayerBase>();
            Assembly assembly = typeof(LayerBase).Assembly;
            Type[] types = assembly.GetTypes();

            foreach (Type type in types)
            {
                if (typeof(LayerBase).IsAssignableFrom(type) && type.IsClass && !type.IsAbstract)
                {
                    layerList.Add(assembly.CreateInstance(type.ToString()) as LayerBase);
                }
            }
        }

        public static string[] GetLayerNames()
        {
            string[] names = new string[layerList.Count];

            for (int i = 0; i < names.Length; ++i)
            {
                names[i] = layerList[i].Name;
            }

            return names;
        }
        #endregion
    }
}