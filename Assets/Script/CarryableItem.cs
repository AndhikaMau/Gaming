using UnityEngine;

public class CarryableItem : MonoBehaviour
{
public GameObject pickupCanvas;

// Icon untuk UI saat item dibawa
public Sprite itemIcon;

// Nama item
public string itemName;

void Start()
{
    if (pickupCanvas != null)
        pickupCanvas.SetActive(false);
}

public void ShowPrompt()
{
    if (pickupCanvas != null)
        pickupCanvas.SetActive(true);
}

public void HidePrompt()
{
    if (pickupCanvas != null)
        pickupCanvas.SetActive(false);
}

}
