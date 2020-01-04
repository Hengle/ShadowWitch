using System.Collections.Generic;
using UnityEngine;
using ShadowWitch.Editor.Window;
using System.Reflection;
using System;
using ShadowWitch.Editor.Map;
using ShadowWitch.Runtime.DataStructures;
using ShadowWitch.Runtime.Map;
using ShadowWitch.Runtime.MonoBehaviours;
using UnityEditor;

namespace ShadowWitch.Editor
{
    [InitializeOnLoad]
    public static class EditorManager
    {
        #region constructors
        static EditorManager()
        {
            AddShadowWitchLayer();
            MapManager.Init();
            WindowManager.Init();
        }
        #endregion

        #region methods
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
