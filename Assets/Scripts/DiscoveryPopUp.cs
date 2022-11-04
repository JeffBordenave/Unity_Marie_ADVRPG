using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DiscoveryPopUp : MonoBehaviour
{
    [SerializeField] Animator popUpAnimator;
    [SerializeField] Text textComponent;

    public static UnityAction<string> EnteredNewArea;

    void DiscoveredNewArea(string areaName)
    {
        popUpAnimator.Play("DiscoveryPanel_Anim");
        textComponent.text = areaName;
    }

    private void OnEnable()
    {
        EnteredNewArea += DiscoveredNewArea;
    }
    private void OnDisable()
    {
        EnteredNewArea -= DiscoveredNewArea;
    }


}
