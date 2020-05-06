using Commons;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIService : GenericMonoSingleton<UIService>
{
    public TextMeshProUGUI PopUpText;


    public async void ShowPopUpText(string text, float timeForPopUp)
    {
        PopUpText.enabled = true;
        PopUpText.text = text;
        await new WaitForSeconds(timeForPopUp);
        PopUpText.text = null;
        PopUpText.enabled = false;
    }
}
