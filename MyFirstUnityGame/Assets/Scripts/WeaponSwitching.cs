using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    public int selectedWeapon;
    // Start is called before the first frame update
    void Start()
    {
        selectedWeapon = WeaponChoice.selectedWeapon;
        SelectWeapon();
    }

    void SelectWeapon()
    {
        int i = 0;
        foreach(Transform weapon in transform)
        {
            if (i == selectedWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            i++;
        }
    }
}
