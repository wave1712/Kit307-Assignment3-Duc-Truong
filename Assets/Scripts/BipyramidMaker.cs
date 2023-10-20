using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BipyramidMaker : MonoBehaviour
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

        meshFilter.mesh = MeshUtilities.HexagonalBipyramid(1.0f);

        meshRenderer.sharedMaterial.mainTexture = texture;

        transform.position = new Vector3(transform.position.x + 4.0f, transform.position.y, transform.position.z);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
