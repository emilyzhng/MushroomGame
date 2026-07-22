using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class DailyEffects : MonoBehaviour
{
    private float movementX;
    private float movementY;
    private bool reversed = true;  

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void SpeedUp()
    {
        PlayerMovement.moveSpeed = 50;
    }

    public void SlowDown()
    {
       PlayerMovement.moveSpeed = 3; 
    }

    public void Shrink()
    {
        transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
    }
    public void Enlargen()
    {
        transform.localScale = new Vector3(2f, 2f, 2f);
    }

    public void RandomEffect()
    {
        {
            int x = Random.Range(0,4);

            switch (x)
            {
                case 0:
                    SpeedUp();
                    Debug.Log("Effect: speedup");
                    break;

                case 1:
                    SlowDown();
                    Debug.Log("Effect: slowdonw");

                    break;

                case 2:
                    Shrink();
                    Debug.Log("Effect: shrink");
                    break;

                case 3: 
                    Enlargen();
                    Debug.Log("Effect: enlarge");
                    break;
            }

        }
    }

}
