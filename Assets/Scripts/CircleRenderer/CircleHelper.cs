using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CircleHelper
{
    public static Vector3[] GetCiclePositions(float radius, int segments)
    {
        if (segments < 3)
        {
            Debug.LogError("Can't calculate positions on a circle with less than 3 points");
            return null;
        }
        if (radius < 0)
        {
            Debug.LogError("Can't calculate positions on a circle with a negative radius");
            return null;
        }

        Vector3[] positions = new Vector3[segments];

        float deltaTheta = (Mathf.PI * 2) / segments;
        float theta = 0;

        for (int i = 0; i < segments; i++)
        {
            positions[i] = new Vector3(radius * Mathf.Cos(theta), radius * Mathf.Sin(theta));
            theta += deltaTheta;
        }

        return positions;
    }
}
