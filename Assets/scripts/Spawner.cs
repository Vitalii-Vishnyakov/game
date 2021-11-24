
using UnityEngine;
//using UnityEngine.InputSystem;
using UnityEngine;
namespace Spawnobj { 
public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject SpawnObj = null;
    private Camera cam = null;
    private void Start()
    {
        cam = Camera.main;
    }
    private void Update()
    {
        SpawnerOnClick();
    }
    private void SpawnerOnClick()
    {
       /* if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Ray ray = cam.ScreenPointToRay(Mouse.current.position.ReadValue());
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Instantiate(SpawnObj, new Vector3(hit.point.x, hit.point.y + SpawnObj.transform.position.y,hit.point.z), Quaternion.identity);
            }
        }*/
    }
    
}
}