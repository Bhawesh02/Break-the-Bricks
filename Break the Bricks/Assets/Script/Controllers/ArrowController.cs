
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    public float Angle;
    void Update()
    {
        Vector2 directon = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(directon.y, directon.x) * Mathf.Rad2Deg;
        if (angle < 30 || angle > 150)
            return;
        Angle = angle;
        Quaternion rotaion = Quaternion.AngleAxis(angle,Vector3.forward);
        transform.rotation = rotaion;
    }
}
