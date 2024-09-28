using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextScript : MonoBehaviour
{
    const float FLASHING_SPEED = 0.8f;
    const float ADJUSTMENT = 5.0f;

    private TextMeshProUGUI text;
    private float time = 0.0f;

    private Color ChangeAlpha(Color color)
    {
        time += Time.deltaTime * ADJUSTMENT * FLASHING_SPEED;
        color.a = Mathf.Sin(time);

        return color;
    }

    void Start()
    {
        text = this.gameObject.GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        text.color = ChangeAlpha(text.color);
    }
}
