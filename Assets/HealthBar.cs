using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health health;
    private RectTransform rectTransform;
    private float healthPixelRatio = float.MinValue;
    // Start is called before the first frame update
    void Start()
    {
        health.OnChange += Health_OnChange;
        rectTransform = GetComponent<RectTransform>();
        healthPixelRatio = rectTransform.rect.width / health.GetMaxHealth();
        rectTransform.sizeDelta = new Vector2(health.GetHealth() * healthPixelRatio,rectTransform.sizeDelta.y);
    }

    private void Health_OnChange(object sender, System.EventArgs e)
    {
        rectTransform.sizeDelta = new Vector2(health.GetHealth() * healthPixelRatio, rectTransform.sizeDelta.y);
    }

}
