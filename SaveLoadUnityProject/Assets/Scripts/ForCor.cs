using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ForCor {

    public static IEnumerator Example(Ref<float> lalala)
    {
        float startTime = Time.realtimeSinceStartup;
        float fraction = 0f;
        startTime = Time.realtimeSinceStartup;
        fraction = 0f;
        while (fraction < 1f)
        {
            fraction = Mathf.Clamp01((Time.realtimeSinceStartup - startTime) / 50.0f);
            float val = Mathf.Lerp(0, 100, fraction);
            lalala.Value = val;
            yield return null;
        }
    }
}

public class Ref<T>
{
    private T backing;
    public T Value { get { return backing; } set { backing = value; } }
    public Ref(T reference)
    {
        backing = reference;
    }
}