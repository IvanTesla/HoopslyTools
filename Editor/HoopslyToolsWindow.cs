using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Unity.Jobs;
using Unity.EditorCoroutines.Editor;

public class HoopslyToolsWindow : EditorWindow
{
    private GUIStyle titleLabelStyle;
    private GUIStyle TitleLableStyle
    {
        get
        {
            if (titleLabelStyle == null)
            {
                titleLabelStyle = new GUIStyle(EditorStyles.label)
                {
                    fontSize = 12,
                    fontStyle = FontStyle.Bold,
                    fixedHeight = 20
                };
            }
            return titleLabelStyle;
        }
    }

    private int m_count1 = 0;
    private int m_count2 = 0;

    [MenuItem("Hoopsly/Tools Window")]
    static void Init()
    {
        HoopslyToolsWindow window = (HoopslyToolsWindow)EditorWindow.GetWindow(typeof(HoopslyToolsWindow), false, "Core tools");
        window.Show();
    }

    private void OnGUI()
    {
        GUILayout.Space(10);
        GUILayout.Label("Counters", TitleLableStyle);
        using (var v = new EditorGUILayout.VerticalScope("box"))
        {
            GUILayout.Space(5);
            GUILayout.Label("Counter 1", EditorStyles.label);
            GUILayout.Space(5);
            GUILayout.BeginHorizontal();
            Rect r = EditorGUILayout.BeginVertical();
            EditorGUI.ProgressBar(r, (float)m_count1/100f, m_count1.ToString());
            GUILayout.Space(20);
            EditorGUILayout.EndVertical();
            if (GUILayout.Button("COUNT 1"))
            {
                Count1();
            }
            GUILayout.EndHorizontal();
            GUILayout.Space(25);
            GUILayout.Label("Counter 2", EditorStyles.label);
            GUILayout.Space(5);
            GUILayout.BeginHorizontal();
            Rect r2 = EditorGUILayout.BeginVertical();
            EditorGUI.ProgressBar(r2, (float)m_count2 / 100f, m_count2.ToString());
            GUILayout.Space(20);
            EditorGUILayout.EndVertical();
            if (GUILayout.Button("COUNT 2"))
            {
                Count2();
            }
            GUILayout.EndHorizontal();
        }
    }

    private void Count1()
    {
        if (m_count1 < 100)
            m_count1++;
        else
            m_count1 = 0;
        Repaint();
    }

    private void Count2()
    {
        if (m_count2 < 100)
            m_count2++;
        else
            m_count2 = 0;
        Repaint();
    }
}
