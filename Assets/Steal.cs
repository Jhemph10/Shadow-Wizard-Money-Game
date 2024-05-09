using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Steal : MonoBehaviour, IInteractable
{
    public void Interact(){
        SceneManager.LoadScene("Level Part 2");
    }
}

