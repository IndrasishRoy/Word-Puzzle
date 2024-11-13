using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

public class LevelEditorWindow : EditorWindow
{
    private LevelData levelData;

    [MenuItem("WordPuzzle/Level Editor")]
    public static void ShowWindow()
    {
        GetWindow<LevelEditorWindow>("Level Editor");
    }

    private void OnGUI()
    {
        GUILayout.Label("Level Editor", EditorStyles.boldLabel);

        levelData = (LevelData)EditorGUILayout.ObjectField("Level Data", levelData, typeof(LevelData), false);

        if (levelData != null)
        {
            EditorGUILayout.Space();
            DrawWordList();
            DrawCorrectWords();
            //DrawAnimationField();

            if (GUILayout.Button("Save Level"))
            {
                EditorUtility.SetDirty(levelData);
                AssetDatabase.SaveAssets();
            }
        }
    }

    private void DrawWordList()
    {
        EditorGUILayout.LabelField("Words", EditorStyles.label);
        for (int i = 0; i < levelData.words.Count; i++)
        {
            levelData.words[i] = EditorGUILayout.TextField($"Word {i + 1}", levelData.words[i]);
        }

        if (GUILayout.Button("Add Word"))
        {
            levelData.words.Add("");
        }

        if (GUILayout.Button("Remove Last Word"))
        {
            if (levelData.words.Count > 0)
                levelData.words.RemoveAt(levelData.words.Count - 1);
        }
    }

    private void DrawCorrectWords()
    {
        EditorGUILayout.LabelField("Correct Words", EditorStyles.label);
        for (int i = 0; i < levelData.correctWords.Count; i++)
        {
            levelData.correctWords[i] = EditorGUILayout.TextField($"Correct Word {i + 1}", levelData.correctWords[i]);
        }

        if (GUILayout.Button("Add Correct Word"))
        {
            levelData.correctWords.Add("");
        }

        if (GUILayout.Button("Remove Last Correct Word"))
        {
            if (levelData.correctWords.Count > 0)
                levelData.correctWords.RemoveAt(levelData.correctWords.Count - 1);
        }
    }

    /*private void DrawAnimationField()
    {
        levelData.levelAnimation = (AnimationClip)EditorGUILayout.ObjectField("Level Animation", levelData.levelAnimation, typeof(AnimationClip), false);
    }*/
}
