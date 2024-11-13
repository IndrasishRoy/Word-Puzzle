using System;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(LevelPreview))]
public class LevelPreviewEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        LevelPreview preview = (LevelPreview)target;

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Preview Controls", EditorStyles.boldLabel);

        if (!preview.isPreviewing)
        {
            if (GUILayout.Button("Start Preview"))
            {
                preview.isPreviewing = true;
                preview.StartPreview();
            }
        }
        else
        {
            if (GUILayout.Button("Stop Preview"))
            {
                preview.StopPreview();
            }

            EditorGUILayout.Space();

            foreach (string word in preview.levelData.words)
            {
                if (GUILayout.Button("Select Word: " + word))
                {
                    preview.SelectWord(word);
                }
            }
            
            EditorGUILayout.Space();

            if(GUILayout.Button("Clear Preview"))
            {
                preview.ClearPreview();
            }
        }
    }
}
