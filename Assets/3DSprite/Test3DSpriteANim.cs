using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Test3DSpriteANim : MonoBehaviour
{
    public SpriteRenderer3D sr3;
    public Flipbook<Texture2D> fb;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Process(fb));
    }

    // Update is called once per frame
    void Update()
    {

    }
    int count;
    public int maxCount = 10;
    IEnumerator Process(Flipbook<Texture2D> flipbook)
    {
        while (count < maxCount)
        {
            Stopwatch sw = new Stopwatch();
                sw.Start();
            for (int i = 0; i < flipbook.objects.Length; i++)
            {
                sr3.SetSprite(flipbook.GetIndex(i));
                yield return new WaitForSeconds(flipbook.delay);
            }
            sw.Stop();
            UnityEngine.Debug.Log("Count : " + count + " StopWatch: " + sw.ElapsedMilliseconds);
            count++;
        }
    }

    [System.Serializable]
    public class Flipbook<T>
    {
        public float delay;
        public T[] objects;

        public T GetIndex(int index)
        {
            return objects[index];
        }
    }
}
