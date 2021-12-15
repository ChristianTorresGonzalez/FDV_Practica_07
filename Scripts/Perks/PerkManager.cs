using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class PerkManager
{
    public ControladorDelegados controlador;
    private GameObject player;
    private GameObject perkMachine;
    private int quickRevivePoints;
    private int doubleTapPoints;
    private int SpeedColaPoints;
    private bool perkBought;
    private string buyPerkText;

    public void InitializePerksPrice()
    {
        quickRevivePoints = 500;
    }

    public void BuyPlayerPerk(GameObject pMachine, string perk)
    {
        player = GameObject.FindWithTag("Player");
        perkMachine = pMachine;
        controlador = GameObject.FindWithTag("MainCamera").GetComponent<ControladorDelegados>();

        if (perk == "QuickRevive") {
            if (player.GetComponent<PlayerPerks>().GetQuickRevive()) {
                buyPerkText = "Ya tienes comprado QuickRevive";
            } else if (player.GetComponent<PlayerPoints>().GetPlayerPoints() >= quickRevivePoints) {
                controlador.SetPlayerPerk("quickRevive");
                player.GetComponent<PlayerPoints>().BuyPlayerPoints(quickRevivePoints);
                
                buyPerkText = "Has comprado QuickRevive por " + quickRevivePoints + "puntos";
            } else {
                buyPerkText = "No dispones de puntos suficientes para comprar QuickRevive";
            }
        }

        perkMachine.GetComponent<DialogueManager>().DisplayNewText(buyPerkText);
    }
}
