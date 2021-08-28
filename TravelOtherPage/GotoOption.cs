using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GotoOption : MonoBehaviour
{
    public void GoToOption()
    {
        SceneManager.LoadScene("Option");
    }
}
