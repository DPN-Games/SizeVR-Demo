using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScaleNonVR : MonoBehaviour {
    private float size = 1f;
    private float prevSize = 0f;

    private const float min = 0.1f;
    private const float max = 100f;

    public TextMeshPro text;

    void Update() {
        if (Input.GetKey(KeyCode.R)) {
            size += 0.1f;
        } else if (Input.GetKey(KeyCode.F)) {
            size -= 0.1f;
        }
        
        if (Math.Abs(size - prevSize) > 0) {
            if (size < min) size = min;
            if (size > max) size = max;

            transform.localScale = new Vector3(size * 10, size * 10, size * 10);

            prevSize = size;

            text.text = size.ToString("F2");  
        }
    }
}
