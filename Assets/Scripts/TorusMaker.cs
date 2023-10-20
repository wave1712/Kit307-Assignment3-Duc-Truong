using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorusMaker : MonoBehaviour
{
    public Texture2D texture;
    public float mainRadius = 1f;
    public float tubeRadius = 0.4f;
    public int radialSegments = 24;
    public int tubularSegments = 8;

    void Start()
    {
        MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();
        MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();

        // Create the torus mesh
        meshFilter.mesh = MeshUtilities.Torus(mainRadius, tubeRadius, radialSegments, tubularSegments);

        // Assign a material to the torus
        meshRenderer.material = new Material(Shader.Find("Standard"));
        meshRenderer.material.mainTexture = texture;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
