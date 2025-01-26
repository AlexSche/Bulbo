using System.Collections;
using UnityEngine;

public class LookAtCursor : MonoBehaviour
{
    private new Camera camera;
    [SerializeField]
    private LayerMask layerMask;
    private Gun gun;
    Vector3 mousePos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gun = GetComponent<Gun>();
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, layerMask))
        {
            if (raycastHit.collider.tag != "Player")
            {
                mousePos = raycastHit.point;
            }
        }
        if (mousePos != null)
        {
            transform.LookAt(mousePos);
        }
    }

    public void shootAtMouse() {
        if (gun != null) {
            gun.shootAtPosition(mousePos);
        }
    }

    public IEnumerator automaticShooting(float duration) {
        while (true) {
            yield return new WaitForSeconds(duration);
            shootAtMouse();
        }  
    }
}
