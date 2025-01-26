using UnityEngine;

public class LookAtCursor : MonoBehaviour
{
    private new Camera camera;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        Vector3 mousePos = new Vector3(0,0,0);
        if (Physics.Raycast(ray, out RaycastHit raycastHit)) {
            if (raycastHit.collider.tag != "Player") {
                mousePos = raycastHit.point;
            }
        }
        transform.LookAt(mousePos);
    }
}
