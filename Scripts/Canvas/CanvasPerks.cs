using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanvasPerks : MonoBehaviour
{
    private GameObject quickRevive;
    private GameObject doubleTap;

    private void Awake() {
        quickRevive = GameObject.FindWithTag("QuickReviveCanvas");
        doubleTap = GameObject.FindWithTag("DoubleTapCanvas");
    }

    public void InitializePerks()
    {
        quickRevive.SetActive(false);
    }

    public void SetPlayerPerk(string perk)
    {
        if (perk == "quickRevive") {
            quickRevive.SetActive(true);
        } else if (perk == "doubleTap") {
            doubleTap.SetActive(true);
        }
    }

    public void RemovePlayerPerk()
    {
        quickRevive.SetActive(false);
        doubleTap.SetActive(false);
    }
}
