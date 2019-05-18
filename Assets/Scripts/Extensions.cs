using System;
using UnityEngine;

public static class Extensions
{
    public static Component GetOrAddComponent(this GameObject go, Type componentType)
    {
        var result = go.GetComponent(componentType);
        return result == null ? go.AddComponent(componentType) : result;
    }

    public static T GetOrAddComponent<T>(this GameObject go) where T : Component
    {
        return GetOrAddComponent(go, typeof(T)) as T;
    }

    public static float Volume(this Mesh mesh)
    {
        float volume = 0;
        var vertices = mesh.vertices;
        var triangles = mesh.triangles;
        for (var i = 0; i < mesh.triangles.Length; i += 3)
        {
            var p1 = vertices[triangles[i + 0]];
            var p2 = vertices[triangles[i + 1]];
            var p3 = vertices[triangles[i + 2]];
            volume += SignedVolumeOfTriangle(p1, p2, p3);
        }

        return Mathf.Abs(volume);
    }

    private static float SignedVolumeOfTriangle(Vector3 p1, Vector3 p2, Vector3 p3)
    {
        var v321 = p3.x * p2.y * p1.z;
        var v231 = p2.x * p3.y * p1.z;
        var v312 = p3.x * p1.y * p2.z;
        var v132 = p1.x * p3.y * p2.z;
        var v213 = p2.x * p1.y * p3.z;
        var v123 = p1.x * p2.y * p3.z;
        return (1.0f / 6.0f) * (-v321 + v231 + v312 - v132 - v213 + v123);
    }
}