using UnityEngine;

public class CylinderMaker : MonoBehaviour
{
    public Material cylinderMaterial; // Public Material member variable

    void Start()
    {
        MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();
        meshRenderer.sharedMaterial = cylinderMaterial; // Assigning the material

        MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();
        meshFilter.mesh = MeshUtilities.Cylinder(16, 1.0f, 2.0f);  // 16 divisions, radius 1, height 2
    }
}
