using UnityEngine;

public class PowerUp : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            switch(this.name)
            {
                case "PF_TimerPowerUp(Clone)":
                    GameManager_Collectathon.instance.IncreaseTimer();
                break;
                case "PF_SpeedPowerUp(Clone)":
                    GameManager_Collectathon.instance.IncreaseSpeed();
                break;
                default:
                    Debug.Log("This object shouldn't have this script!");
                break;
            }
            Destroy(gameObject);
        }
    }
}
