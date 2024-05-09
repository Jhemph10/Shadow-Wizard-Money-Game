using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour, IInteractable
{
    public void Interact(){
        SceneManager.LoadScene("Safe Scene");
    }
}
