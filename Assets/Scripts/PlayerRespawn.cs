using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRespawn : MonoBehaviour
{

    public void Respawn()
    {
        //Move player to next checkpoint position
        //If there is a current checkpoint
        if (Checkpoint.currentCheckpoint != null)
        {
            gameObject.transform.position =
                Checkpoint.currentCheckpoint.transform.position;
        }
        else
        {
            //If there is no current checkpoint
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
       
    }

}
