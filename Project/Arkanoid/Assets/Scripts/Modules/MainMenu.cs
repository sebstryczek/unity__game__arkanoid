using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject btnContinue;

    private void Start()
    {
        this.btnContinue.SetActive(GameStateManager.Instance.IsFileExist);
    }
}
