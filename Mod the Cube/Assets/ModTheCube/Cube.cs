using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    float rotX = 10f;
    float rotY = 10f;
    float rotZ = 10f;
    Material material;
    Color[] colors = new Color[7];
    float timerColor = 0;
    float timerRot = 0;

    float scale = 0.01f;

    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        transform.localScale = Vector3.one * scale;

        material = Renderer.material;
        colors[0] = Color.black;
        colors[1] = Color.blue;
        colors[2] = Color.cyan;
        colors[3] = Color.gray;
        colors[4] = Color.green;
        colors[5] = Color.magenta;
        colors[6] = Color.red;

    }
    
    void Update()
    {
        RotateOverTime();
        ChangeRotationRate();
        ChangeColor();
        ChangeSize();
    }

    private void ChangeSize()
    {
        transform.localScale += Vector3.one * scale;
    }

    private void ChangeRotationRate()
    {
        timerRot += Time.deltaTime;
        if (timerRot < 1f) return;

        rotX = Random.Range(10f, 100f);
        rotY = -Random.Range(5f, 50f);
        rotZ = Random.Range(33f, 90f);
    }

    private void RotateOverTime()
    {
        transform.Rotate(rotX * Time.deltaTime, rotY * Time.deltaTime, rotZ * Time.deltaTime);
    }

    private void ChangeColor()
    {
        timerColor += Time.deltaTime;

        if (timerColor < 1f) return;

        int colorCounter = Random.Range(0, 7);

        material.color = colors[colorCounter];
        timerColor = 0f;
    }
}
