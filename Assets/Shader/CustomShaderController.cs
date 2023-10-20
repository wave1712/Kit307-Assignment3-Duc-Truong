using UnityEngine;

public class CustomShaderController : MonoBehaviour
{
    public Material material;
    public float speed = 1.0f;

    void Start()
    {
        if (material == null)
        {
            Debug.LogError("Material not assigned to CustomShaderController on GameObject: " + gameObject.name);
        }
        else
        {
            Debug.Log("Material assigned successfully to CustomShaderController on GameObject: " + gameObject.name);
        }
    }

    void Update()
    {
        if (material != null)
        {
            float offset = Time.time * speed;
            material.SetTextureOffset("_MainTex", new Vector2(offset, 0f));
        }
    }
}
