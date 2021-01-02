using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayGame : MonoBehaviour
{
    ToggleGroup WeaponGroup;
    public void startLevel1()
    {
        WeaponGroup = GameObject.Find("ToggleGroup").GetComponent<ToggleGroup>();
  
        foreach (Toggle item in WeaponGroup.ActiveToggles())
        {
            if (item.isOn)
            {
                switch (item.name)
                {
                    case "ToggleWeapon1":
                        WeaponChoice.selectedWeapon = 0;
                        break;
                    case "ToggleWeapon2":
                        WeaponChoice.selectedWeapon = 1;
                        break;
                    default:
                        Debug.LogError("Selected weapon is invalid");
                        WeaponChoice.selectedWeapon = 0;
                        break;
                }
            }
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }
}
