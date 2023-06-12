using UnityEngine;
using TMPro;
public class DamagePopupGenerator : MonoBehaviour
{
    public static DamagePopupGenerator Instance;
    public GameObject Prefab;
    private void Awake()
    {
        Instance = this;
    }

    public void Generator(Vector3 position, string text,Color color)
    {
        var popup = Instantiate(Prefab,position,Quaternion.identity);
        var temp = popup.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        temp.text = text;
        temp.faceColor = color;

        Destroy(popup, 1f);
    }
}
