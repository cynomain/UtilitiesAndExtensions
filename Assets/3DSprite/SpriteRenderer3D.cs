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

    public class QuadCreator
    {
        private Mesh _mesh;
        private float width = 1f;
        private float height = 1f;

        public QuadCreator(float width, float height)
        {
            this.width = width;
            this.height = height;
        }

        public Mesh Create()
        {
            //var mf = GetComponent<MeshFilter>();
            _mesh = new Mesh();
            //mf.mesh = _mesh;

            var vertices = new Vector3[4];

            vertices[0] = new Vector3(0, 0, 0);
            vertices[1] = new Vector3(width, 0, 0);
            vertices[2] = new Vector3(0, height, 0);
            vertices[3] = new Vector3(width, height, 0);

            _mesh.vertices = vertices;

            var tri = new int[6];

            tri[0] = 0;
            tri[1] = 2;
            tri[2] = 1;

            tri[3] = 2;
            tri[4] = 3;
            tri[5] = 1;

            _mesh.triangles = tri;

            var normals = new Vector3[4];

            normals[0] = -Vector3.forward;
            normals[1] = -Vector3.forward;
            normals[2] = -Vector3.forward;
            normals[3] = -Vector3.forward;

            _mesh.normals = normals;

            var uv = new Vector2[4];

            uv[0] = new Vector2(0, 0);
            uv[1] = new Vector2(1, 0);
            uv[2] = new Vector2(0, 1);
            uv[3] = new Vector2(1, 1);

            _mesh.uv = uv;

            return _mesh;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireMesh(_mesh, Vector3.zero);
        }
    }
}
