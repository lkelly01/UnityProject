using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { Freeroam, Dialog, Battle }

public class GameController : MonoBehaviour
{
    [SerializeField] PlayerController playerController;

    GameState state;

    private void Update()
    {
        if(state == GameState.Freeroam)
        {
            playerController.HandleUpdate();
        }
        else if (state == GameState.Dialog)
        {
            // Logic for dialog state
        }
        else if (state == GameState.Battle)
        {
            // Logic for battle state
        }
    }
}

