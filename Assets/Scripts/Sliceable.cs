using UnityEngine;

public class Sliceable : MonoBehaviour
{
    [SerializeField] private float materialDensity = 100;
    [SerializeField] private Material cutMaterial;

    public Material CutMaterial
    {
        get => cutMaterial;
        set => cutMaterial = value;
    }

    public float MaterialDensity
    {
        get => materialDensity;
        set => materialDensity = value;
    }
}