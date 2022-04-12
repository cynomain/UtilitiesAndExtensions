using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer), typeof(MeshFilter))]
public class SpriteRenderer3D : MonoBehaviour
{
    public Texture2D sprite;
    public Color color = Color.white;
    public bool flipX;
    public bool flipY;
    [Range(0f, 1f)] public float alphaCutoff = 0.01f;
    [Range(0f, 1f)] public float metalic = 0f;
    [Range(0f, 1f)] public float smoothness = 0.5f;

    MeshRenderer mrenderer;

    private void Awake()
    {
        mrenderer = GetComponent<MeshRenderer>();
        if (mrenderer == null)
        {
            mrenderer = GetComponent<MeshRenderer>();
        }
        if (mrenderer == null)
        {
            Debug.LogError("Mesh Renderer is null", this);
        }        
    }

    private void OnValidate()
    {
        if (mrenderer == null)
        {
            mrenderer = GetComponent<MeshRenderer>();
        }
        OnValueChanged();
    }

    void OnValueChanged()
    {
        UpdateShader();
    }

    private void Update()
    {
        UpdateShader();
    }

    void UpdateShader()
    {
        mrenderer.sharedMaterial.SetTexture("_MainTex", sprite);
        mrenderer.sharedMaterial.SetColor("_Tint", color);
        Vector2 tiling = new Vector2(1f, 1f);
        Vector2 offset = new Vector2(0f, 0f);
        if (flipX)
        {
            tiling.x = -1f;
            offset.x = 1f;
        }
        if (flipY)
        {
            tiling.y = -1f;
            offset.y = 1f;
        }
        mrenderer.sharedMaterial.SetVector("_Tiling", tiling);
        mrenderer.sharedMaterial.SetVector("_Offset", offset);
        mrenderer.sharedMaterial.SetFloat("_AlphaCutoff", alphaCutoff);
        mrenderer.sharedMaterial.SetFloat("_Metalic", metalic);
        mrenderer.sharedMaterial.SetFloat("_Smoothness", smoothness);
    }

    public void SetSprite(Texture2D tex)
    {
        sprite = tex;
       // OnValueChanged();
    }

    [UnityEditor.MenuItem("Test", menuItem = "GameObject/Create Other/3D Sprite")]
    public static void OnCreateGameObject()
    {
        GameObject go = GameObject.CreatePrimitive(PrimitiveType.Quad);
        go.AddComponent<SpriteRenderer3D>();
        go.GetComponent<MeshRenderer>().sharedMaterials[0] = Resources.Load<Material>("/Lit3DSpriteMaterial.mat");        
    }
}
