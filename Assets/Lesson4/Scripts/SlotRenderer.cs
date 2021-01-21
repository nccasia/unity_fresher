
using UnityEngine;

[ExecuteInEditMode]
public class SlotRenderer : MonoBehaviour
{
    public Sprite sprite;
    public SpriteRenderer[] Slots;
    private void Update()
    {
        foreach(var slot in Slots)
        {
            slot.sprite = sprite;
        }
    }
}
