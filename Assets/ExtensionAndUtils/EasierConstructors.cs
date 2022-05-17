using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CynoMain.EasierConsructors
{
    /// <summary>
    /// Wrapper class for Vector3 with a shorter name
    /// </summary>
    public struct V3
    {
        public Vector3 value;

        public V3(float x, float y, float z)
        {
            value = new Vector3(x, y, z);
        }

        public V3(float x, float y)
        {
            value = new Vector3(x, y);
        }

        public static implicit operator Vector3(V3 v)
        {
            return v.value;
        }

        public static implicit operator Vector2(V3 v)
        {
            return v.value;
        }
    }

    /// <summary>
    /// Wrapper class for Vector2 with a shorter name
    /// </summary>
    public struct V2
    {
        public Vector2 value;

        public V2(float x, float y)
        {
            value = new Vector2(x, y);
        }

        public static implicit operator Vector3(V2 v)
        {
            return v.value;
        }

        public static implicit operator Vector2(V2 v)
        {
            return v.value;
        }
    }

    /// <summary>
    /// Wrapper class for Vector3Int with a shorter name
    /// </summary>
    public struct V3Int
    {
        public Vector3Int value;

        public V3Int(int x, int y, int z)
        {
            value = new Vector3Int(x, y, z);
        }

        public V3Int(int x, int y)
        {
            value = new Vector3Int(x, y);
        }

        public static implicit operator Vector3Int(V3Int v)
        {
            return v.value;
        }

        public static implicit operator Vector2Int(V3Int v)
        {
            return (Vector2Int)v.value;
        }
    }

    /// <summary>
    /// Wrapper class for Vector2Int with a shorter name
    /// </summary>
    public struct V2Int
    {
        public Vector2Int value;

        public V2Int(int x, int y)
        {
            value = new Vector2Int(x, y);
        }

        public static implicit operator Vector3Int(V2Int v)
        {
            return (Vector3Int)v.value;
        }

        public static implicit operator Vector2Int(V2Int v)
        {
            return v.value;
        }
    }

    /// <summary>
    /// Wrapper class for Quaternion with a shorter name
    /// </summary>
    public struct Q
    {
        public Quaternion value;

        public Q(float x, float y, float z, float w)
        {
            value = new Quaternion(x, y, z, w);
        }

        public static implicit operator Quaternion(Q q)
        {
            return q.value;
        }
    }
}
