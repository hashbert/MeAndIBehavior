using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColorSwap : MonoBehaviour
{
    [SerializeField] private bool flippedAtStart;
    [SerializeField] private float thresh;

    Renderer m_ObjectRenderer;
    
    void Start()
    {
        m_ObjectRenderer = GetComponent<SpriteRenderer>();
        thresh = flippedAtStart ? 0f : 1f;
        m_ObjectRenderer.material.SetFloat("_Threshold", thresh);
    }
    
    public void Swap()
    {
        thresh = Mathf.Abs(1 - thresh);
        m_ObjectRenderer.material.SetFloat("_Threshold", thresh);
    }

    public void SetSwap(bool flipped)
    {
        thresh = flipped ? 0f : 1f;
        m_ObjectRenderer.material.SetFloat("_Threshold", thresh);
    }

    public void ResetSwap()
    {
        SetSwap(flippedAtStart);
    }
}
