
using UnityEngine;

public class GameSetup : MonoBehaviour
{
    void Start()
    {
        SetupArena();
        SetupCamera();
        SetupLighting();
    }

    void SetupArena()
    {
        GameObject arena = new GameObject("WILD ARENA");
        arena.AddComponent<ArenaBuilder>();
    }

    void SetupCamera()
    {
        Camera cam = Camera.main;

        if (cam == null)
        {
            GameObject cameraObject = new GameObject("Main Camera");
            cameraObject.tag = "MainCamera";
            cam = cameraObject.AddComponent<Camera>();
        }

        cam.transform.position = new Vector3(0f, 14f, -10f);
        cam.transform.rotation = Quaternion.Euler(55f, 0f, 0f);
    }

    void SetupLighting()
    {
        if (FindFirstObjectByType<Light>() == null)
        {
            GameObject lightObject = new GameObject("Arena Sun");
            Light sun = lightObject.AddComponent<Light>();

            sun.type = LightType.Directional;
            sun.intensity = 1.2f;
            lightObject.transform.rotation =
                Quaternion.Euler(50f, -30f, 0f);
        }
    }
}
