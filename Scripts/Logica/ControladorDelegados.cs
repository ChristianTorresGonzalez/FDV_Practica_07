using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorDelegados : MonoBehaviour
{
    public delegate void PlayerPerks(string perk);
    public delegate void PlayerWeapons(Weapon weapon);
    public delegate void PlayerPoints();
    public delegate void PlayerLife();

    public event PlayerPerks ActivePlayerPerk;
    public event PlayerWeapons ActivePlayerWeapon;
    public event PlayerPoints ActivePlayerPoints;
    public event PlayerLife ActivePlayerHit;

    public void SetPlayerPerk(string perk)
    {
        if (ActivePlayerPerk != null)
        {
            ActivePlayerPerk(perk);
        }
    }

    public void SetPlayerWeapon(Weapon weapon)
    {
        if (ActivePlayerWeapon != null)
        {
            ActivePlayerWeapon(weapon);
        }
    }

    public void SetPlayerPoints()
    {
        if (ActivePlayerPoints != null)
        {
            ActivePlayerPoints();
        }
    }

    public void SetPlayerHit()
    {
        if (ActivePlayerHit != null)
        {
            ActivePlayerHit();
        }
    }
}
