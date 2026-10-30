
using UnityEngine;
using UnityEngine.EventSystems;

public class VirtualJoystick : MonoBehaviour,
    IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    public RectTransform handle;
    public RectTransform background;
    public float horizontal;
    public float vertical;

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 position;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            background,
            eventData.position,
            eventData.pressEventCamera,
            out position
        );

        float radius = background.sizeDelta.x / 2f;
        Vector2 input = Vector2.ClampMagnitude(position / radius, 1f);

        horizontal = input.x;
        vertical = input.y;

        handle.anchoredPosition = input * radius;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        horizontal = 0f;
        vertical = 0f;
        handle.anchoredPosition = Vector2.zero;
    }
}
