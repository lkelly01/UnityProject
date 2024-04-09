using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { Freeroam, Dialog, Battle }

public class GameController : MonoBehaviour
{
    [SerializeField] PlayerController playerController;

    GameState state;

    private void Start()
    {
        DialogManager.Instance.OnShowDialog += () =>
        {
            state = GameState.Dialog;
        };
        DialogManager.Instance.OnHideDialog += () =>
        {
            if (state == GameState.Dialog)
                state = GameState.Freeroam;
        };
    }
    private void Update()
    {
        if(state == GameState.Freeroam)
        {
            playerController.HandleUpdate();
        }
        else if (state == GameState.Dialog)
        {
            DialogManager.Instance.HandleUpdate();
        }
        else if (state == GameState.Battle)
        {
            // Logic for battle state
        }
    }
}

