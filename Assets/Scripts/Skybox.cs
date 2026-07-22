using UnityEngine;

public class Skybox: MonoBehaviour
{
    public float speed;

    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * speed);
    }
}
