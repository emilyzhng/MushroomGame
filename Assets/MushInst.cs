using UnityEngine;

public class MushInst : MonoBehaviour
{
    public GameObject Mush;
    public GameObject InspectCam;
    public GameObject InspectBack;
    public GameObject PlayerCam;
    public GameObject InspectButton;
    public GameObject XButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MakeMush()
    {
        Vector3 BackPos = InspectBack.transform.position; 
        Vector3 Offset = new Vector3(0f, 0.6f, -5f);
        Instantiate(Mush, BackPos+ Offset, Quaternion.identity);
        InspectCam.SetActive(true);
        PlayerCam.SetActive(false);
        InspectButton.SetActive(false);
        XButton.SetActive(true);
    }

    public void ExitInspect()
    {
        PlayerCam.SetActive(true);
        InspectCam.SetActive(false);
        XButton.SetActive(false);
    }
}
