using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using Valve.VR;

public class Scale : MonoBehaviour {
    private float size = 1f;
	private float prevSize = 0f;

    private const float min = 0.1f;
    private const float max = 100f;

    public TextMeshPro text;
    
    void Start() {
        var vec2 = SteamVR_Input.GetVector2Action("scaleslider", false);
        vec2.onAxis += Vec2OnAxis;
    }

    private void Vec2OnAxis(SteamVR_Action_Vector2 fromaction, SteamVR_Input_Sources fromsource, Vector2 axis, Vector2 delta) {
        size += axis.y * Time.deltaTime * 5 * (size / 10);
    }

    void Update() {
        if (Math.Abs(size - prevSize) > 0) {
            if (size < min) size = min;
            if (size > max) size = max;
            
            transform.localScale = new Vector3(size * 10, size * 10, size * 10);

            prevSize = size;

            text.text = size.ToString("F2");
        }
    }
}
