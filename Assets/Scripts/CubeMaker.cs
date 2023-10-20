using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMaker : MonoBehaviour
{
    public Texture2D texture;
    // Start is called before the first frame update
    void Start()
    {
        MeshRenderer meshRenderer =
            gameObject.AddComponent<MeshRenderer>();
        meshRenderer.sharedMaterial =
            new Material(Shader.Find("Standard"));

        MeshFilter meshFilter =
            gameObject.AddComponent<MeshFilter>();

        meshFilter.mesh = MeshUtilities.Cube(1.0f);

        meshRenderer.sharedMaterial.mainTexture = texture;


    }

    // Update is called once per frame
    void Update()
    {

    }
}
