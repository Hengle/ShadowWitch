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
            for (int i = 0; i < EditorManager.GetWindowCount(); ++i)
            {
                WindowBase window = EditorManager.GetWindow(i);
                window.OnEnable();
            }
        }

        private void OnDisable()
        {
            for (int i = 0; i < EditorManager.GetWindowCount(); ++i)
            {
                WindowBase window = EditorManager.GetWindow(i);
                window.OnDisable();
            }
        }

        private void OnGUI()
        {
            for (int i = 0; i < EditorManager.GetWindowCount(); ++i)
            {
                WindowBase window = EditorManager.GetWindow(i);
                window.OnGUI();
            }
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
