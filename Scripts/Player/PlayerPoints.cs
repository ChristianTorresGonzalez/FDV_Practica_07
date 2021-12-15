using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPoints : MonoBehaviour
{
    public ControladorDelegados controlador;
    public GameObject pointsCanvas;
    private int playerPoints;

    void Start()
    {
        pointsCanvas = GameObject.FindWithTag("CanvasPoints");
        playerPoints = 500;    
    }

    void OnEnable()
    {
        controlador.ActivePlayerPoints += SetPlayerPoints;
    }

    void OnDeseable()
    {
        controlador.ActivePlayerPoints -= SetPlayerPoints;
    }

    private void SetPlayerPoints()
    {
        playerPoints += 10;
        
        SetCanvasPlayerPoints();
    }

    public void RemovePlayerPoints(int points)
    {
        playerPoints -= points;
        
        SetCanvasPlayerPoints();
    }

    public void BuyPlayerPoints(int points)
    {
        playerPoints -= points;
        
        pointsCanvas.GetComponent<CanvasPlayerPoints>().RemovePoints(playerPoints + points, points, playerPoints);
    }

    private void SetCanvasPlayerPoints()
    {
        pointsCanvas.GetComponent<CanvasPlayerPoints>().SetPoints(playerPoints);
    }

    public int GetPlayerPoints()
    {
        return playerPoints;
    }
}
