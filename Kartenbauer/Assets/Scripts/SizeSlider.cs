using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SizeSlider : MonoBehaviour
{
    [SerializeField]
    private RectTransform transform;

    [SerializeField]
    private Slider slider;

    public float width, height;
    // Start is called before the first frame update
    void Start()
    {
        width = transform.rect.width;
        height = transform.rect.height;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateImageSize()
    {
        float size = width * slider.value;

        transform.sizeDelta = new Vector2(size, size);
    }
}
