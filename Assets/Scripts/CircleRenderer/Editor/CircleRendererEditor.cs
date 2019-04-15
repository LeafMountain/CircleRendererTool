using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CircleRendererEditor : EditorWindow
{
    public float radius = 1;
    public int segments = 10;
    // public AnimationCurve width = new AnimationCurve();
    public float width = .5f;
    public Color color = Color.black;

    [MenuItem("Tools/Circle Renderer")]
    static void Init()
    {
        CircleRendererEditor window = (CircleRendererEditor)EditorWindow.GetWindow(typeof(CircleRendererEditor));
        window.Show();
    }

    void OnGUI()
    {
        GUILayout.Label("Base Settings", EditorStyles.boldLabel);
        segments = EditorGUILayout.IntSlider("Segments", segments, 3, 50);
        radius = EditorGUILayout.Slider("Radius", radius, .001f, 50);
        color = EditorGUILayout.ColorField("Color", color);
        // width = EditorGUILayout.CurveField("Width", width);
        width = EditorGUILayout.Slider("Width", width, .1f, 2);

        if (GUILayout.Button("Apply"))
        {
            GameObject selected = Selection.activeGameObject;
            LineRenderer lineRenderer = selected.GetComponent<LineRenderer>();
            if (!lineRenderer)
                lineRenderer = selected.AddComponent<LineRenderer>();

            // lineRenderer.loop = true;
            lineRenderer.useWorldSpace = false;
            lineRenderer.widthMultiplier = width;
            lineRenderer.DrawCircle(radius, segments);
            lineRenderer.startColor = color;
            lineRenderer.endColor = color;
        }
    }
}
