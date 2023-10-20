using UnityEngine;

public class PyramidMaker : MonoBehaviour
{
    void Start()
    {
        // Add a MeshRenderer to the GameObject and set its material to the default "Standard" shader
        MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();
        meshRenderer.sharedMaterial = new Material(Shader.Find("Standard"));

        // Add a MeshFilter to the GameObject and set its mesh to the Pyramid we defined in MeshUtilities
        MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();
        meshFilter.mesh = MeshUtilities.Pyramid(1.0f);
    }
}
