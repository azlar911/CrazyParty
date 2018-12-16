
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;

[CustomEditor(typeof(SceneList))]
public class SceneListEdtior : Editor
{
    private ReorderableList list;

    private void OnEnable()
    {
        list = new ReorderableList(serializedObject,
                serializedObject.FindProperty("levelScenes"),
                true, true, true, true);

        list.drawElementCallback =
            (Rect rect, int index, bool isActive, bool isFocused) =>
            {
                var element = list.serializedProperty.GetArrayElementAtIndex(index);
                rect.y += 2;
                EditorGUI.PropertyField(
                    new Rect(rect.x, rect.y, rect.width - 34, EditorGUIUtility.singleLineHeight),
                    element.FindPropertyRelative("name"), GUIContent.none);

                EditorGUI.PropertyField(
                    new Rect(rect.width + 6, rect.y, 20, EditorGUIUtility.singleLineHeight),
                    element.FindPropertyRelative("active"), GUIContent.none);
            };

        list.drawHeaderCallback = (Rect rect) => {
            EditorGUI.LabelField(new Rect(rect.x + 12, rect.y, rect.width - 32, rect.height), "Level Scenes");
            EditorGUI.LabelField(new Rect(rect.width - 20, rect.y, 40, rect.height), "Active");
        };

        list.onAddCallback = (ReorderableList l) => {
            var index = l.serializedProperty.arraySize;
            l.serializedProperty.arraySize++;
            l.index = index;
            var element = l.serializedProperty.GetArrayElementAtIndex(index);
            element.FindPropertyRelative("name").stringValue = "";
            element.FindPropertyRelative("active").boolValue = true;
        };
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        list.DoLayoutList();
        serializedObject.ApplyModifiedProperties();
    }
}
