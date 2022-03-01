using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EditorDuplicateObjects : EditorWindow {

    public static float maxWidth = 600f;
    public static float maxHeight = 300f;

    public List<GameObject> objectList;
    public GameObject newGameObject;
    public GameObject spawnLocation;

    public Vector2 scrollPosition = Vector2.zero;

    [MenuItem("Tools/Object Duplicator")]
    static void Init() {

        var window = EditorWindow.GetWindow(typeof(EditorDuplicateObjects), false, "Object Duplicator");
        window.position = new Rect(Screen.width / 2, Screen.height / 2, maxWidth, maxHeight);
        window.Show();
    }


    private void OnGUI() {

        GUILayout.Box("Object Duplicator", GUILayout.Width(maxWidth));

        GUILayout.BeginHorizontal();

        UI_Display();

        GUILayout.EndHorizontal();

    }



    private void UI_Display() {

        GUILayout.BeginVertical();

        scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition, GUILayout.Width(maxWidth));

        GUILayout.Label("Select Objects to be duplicated with a new Game Object", EditorStyles.boldLabel);
        ScriptableObject target = this;
        SerializedObject so = new SerializedObject(target);
        SerializedProperty list = so.FindProperty("objectList");
        EditorGUILayout.PropertyField(list, true, GUILayout.Width(maxWidth - 10f));
        so.ApplyModifiedProperties();

        GUILayout.Label("Select the Game object that will spawn in the same place", EditorStyles.boldLabel);
        newGameObject = EditorGUILayout.ObjectField((Object)newGameObject, typeof(Object), true, GUILayout.Width(maxWidth - 10f)) as GameObject;

        GUILayout.Label("Select the GameObject where the new object will spawn");
        spawnLocation = EditorGUILayout.ObjectField((Object)spawnLocation, typeof(Object), true, GUILayout.Width(maxWidth - 10f)) as GameObject;


        if (GUILayout.Button("Create and Place")) {
            Debug.Log("Creating");
            Create();
        }

        EditorGUILayout.EndScrollView();

        GUILayout.EndVertical();

    }

    private void Create() {
        foreach (GameObject g in objectList) {
            Transform t = g.transform;
            GameObject newObject = Instantiate(newGameObject, spawnLocation.transform);
            Transform nt = newObject.transform;

            nt.position = t.position;
            nt.rotation = t.rotation;
            nt.localScale = t.localScale;

        }
    }



}
