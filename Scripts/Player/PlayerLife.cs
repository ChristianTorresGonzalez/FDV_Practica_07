using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerLife : MonoBehaviour
{
    public ControladorDelegados controlador;
    private GameObject healthCanvas;
    private GameObject reviveCanvas;
    private Slider slider;
    private int maxHits;
    private int playerHits;
    private int reviveTime;
    private static bool playerAlive;

    void Start()
    {
        healthCanvas = GameObject.FindWithTag("CanvasHealth");
        reviveCanvas = GameObject.FindWithTag("ReviveBar");

        healthCanvas.GetComponent<CanvasLifeSystem>().SetMaxHealth();
        reviveCanvas.GetComponent<CanvasPlayerRevive>().InitializeRevive();

        maxHits = 3;
        playerHits = 0;
        reviveTime = 10;
        playerAlive = true;
    }

    void OnEnable()
    {
        controlador.ActivePlayerHit += SetPlayerHit;
    }

    void OnDeseable()
    {
        controlador.ActivePlayerHit -= SetPlayerHit;
    }

    public void SetPlayerHit()
    {
        playerHits++;

        healthCanvas.GetComponent<CanvasLifeSystem>().SetHealth(maxHits - playerHits, maxHits);

        CheckPlayerHits();
    }

    private void CheckPlayerHits()
    {
        if (playerHits == maxHits) {
            if (GetComponent<PlayerPerks>().GetQuickRevive()) {
                SetPlayerDead();
                StartCoroutine(RevivePlayer());
                
                reviveCanvas.GetComponent<CanvasPlayerRevive>().RevivePlayer(reviveTime);
                healthCanvas.GetComponent<CanvasLifeSystem>().SetMaxHealth();

                GetComponent<PlayerPerks>().RemovePlayerPerk();
            } else {
                SetPlayerDead();
                // Jugador muere (cambiar animacion a jugador muerto, finalizar partida)
            }
        }
    }

    private void SetPlayerDead()
    {
        playerAlive = false;
    }

    private IEnumerator RevivePlayer()
    {
        yield return new WaitForSeconds(reviveTime + 0.5f);
        
        playerHits = 0;
        playerAlive = true;
    }

    public bool GetPlayerAlive()
    {
        return playerAlive;
    }
}
