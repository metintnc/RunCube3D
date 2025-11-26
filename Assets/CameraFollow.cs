using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.Controls;


public class CameraFollow : MonoBehaviour
{
    public Transform Player;
    Vector3 offset;
    public float smoothspeed = 3f;
    bool offsetSet = false;
    private Quaternion targetrotation;
    public TextMeshProUGUI kazandýntext;
    private bool kameratakip = false;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    void LateUpdate()
    {
        float distanceZ = Player.position.z - transform.position.z;
        
        if (distanceZ > 7) 
        {
            if (!offsetSet)
            {
                offset = new Vector3(0f, 3f, -7f);
                offsetSet = true;
            }
            Vector3 pos = transform.position;
            if (kameratakip == false)
            {
                
                pos.z = Player.position.z + offset.z;
                transform.position = pos;
            }
            

            if(Player.position.z >200 && Player.position.z < 265 && Player.position.y > 2.9)
            {
                pos.y = 10f;
                transform.position = Vector3.Lerp(transform.position,pos,2f*Time.deltaTime);
            }
            else if(Player.position.z >200 && Player.position.y < 2.9 && Player.position.z < 265 )
            {
                pos.y = 2f;
                transform.position = Vector3.Lerp(transform.position, pos, 2f* Time.deltaTime);
            }
            else if(Player.position.z > 300 && Player.position.z <469)
            {
                pos.y = 11f;
                transform.position = Vector3.Lerp(transform.position, pos, 2f* Time.deltaTime);

            }
            else if (Player.position.z > 470 && Player.position.z < 500)
            {
                pos.y = 13f;
                transform.position = Vector3.Lerp(transform.position, pos, 2f * Time.deltaTime);

            }
            else if (Player.position.z > 500 && Player.position.z < 550)
            {
                pos.y = 19f;
                transform.position = Vector3.Lerp(transform.position, pos, 2f * Time.deltaTime);

            }
            else if (Player.position.z > 550 && Player.position.z < 650)
            {
                pos.y = 6f;
                transform.position = Vector3.Lerp(transform.position, pos, 2f * Time.deltaTime);

            }
            else if (Player.position.z > 975)
            {
                kazandýntext.text = "Kazandýnýz";
                kameratakip = true;

            }
            else if(kameratakip == false)
            {
                pos.y = 3f;
                targetrotation = Quaternion.Euler(25f, 0f, 0f);
                transform.rotation = Quaternion.Lerp(transform.rotation, targetrotation, smoothspeed * Time.deltaTime);

                Vector3 XYeksen = new Vector3(transform.position.x, 3, transform.position.z);
                transform.position = Vector3.Lerp(transform.position, XYeksen, smoothspeed * Time.deltaTime);
            }
            
        }
    }
}
