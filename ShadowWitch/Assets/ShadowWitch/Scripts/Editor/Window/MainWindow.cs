using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Reflection;

namespace ShadowWitch.Editor.Window
{
    public class MainWindow : EditorWindow
    {
        #region unity methods
        private void OnEnable()
        {
            Debug.Log("onenable");
            Assembly assembly = Assembly.GetAssembly(this.GetType());
            Type[] types = assembly.GetTypes();

            foreach (Type type in types)
            {
                if (typeof(ShadowWitchWindowBase).IsAssignableFrom(type) && type.IsClass && !type.IsAbstract)
                {
                    Debug.Log(type.Name + " is true");
                }

                else
                {
                    Debug.Log(type.Name + " is false");
                }
            }
        }

        private void OnGUI()
        {
            EditorGUILayout.LabelField("Test");
        }
        #endregion
        
        #region methods
        [MenuItem(EditorStringReferences.MenuName + "/Open")]
        private static void Open()
        {
            MainWindow mainWindow = UnityEditor.EditorWindow.GetWindow<MainWindow>(EditorStringReferences.MainWindowName, true);
            mainWindow.Show();
        }
        #endregion
    }
}
