
using UnityEngine;

public class ArenaBuilder : MonoBehaviour
{
    public int treeCount = 45;
    public int bushCount = 25;
    public int crateCount = 12;
    public float arenaSize = 100f;

    public Material grassMaterial;
    public Material waterMaterial;
    public Material treeMaterial;
    public Material bushMaterial;
    public Material crateMaterial;

    void Start()
    {
        CreateGround();
        CreateLake();
        CreateTrees();
        CreateBushes();
        CreateCrates();
        CreatePlayer();
    }

    Material MakeMaterial(Color color)
    {
        Material material = new Material(
            Shader.Find("Universal Render Pipeline/Lit")
        );

        if (material.shader == null)
            material.shader = Shader.Find("Standard");

        material.color = color;
        return material;
    }

    void CreateGround()
    {
        GameObject ground = GameObject.CreatePrimitive(
            PrimitiveType.Plane
        );

        ground.name = "Forest Arena";
        ground.transform.localScale =
            new Vector3(arenaSize / 10f, 1f, arenaSize / 10f);

        ground.GetComponent<Renderer>().material =
            grassMaterial != null ? grassMaterial :
            MakeMaterial(new Color(0.25f, 0.45f, 0.18f));
    }

    void CreateLake()
    {
        GameObject lake = GameObject.CreatePrimitive(
            PrimitiveType.Cylinder
        );

        lake.name = "Forest Lake";
        lake.transform.position = new Vector3(15f, 0.02f, 12f);
        lake.transform.localScale = new Vector3(12f, 0.05f, 9f);

        lake.GetComponent<Renderer>().material =
            waterMaterial != null ? waterMaterial :
            MakeMaterial(new Color(0.1f, 0.45f, 0.8f));
    }

    void CreateTrees()
    {
        for (int i = 0; i < treeCount; i++)
        {
            Vector3 position = RandomPosition();

            GameObject trunk = GameObject.CreatePrimitive(
                PrimitiveType.Cylinder
            );

            trunk.name = "Tree Trunk";
            trunk.transform.position = position + Vector3.up * 1.5f;
            trunk.transform.localScale =
                new Vector3(0.8f, 1.5f, 0.8f);

            trunk.GetComponent<Renderer>().material =
                MakeMaterial(new Color(0.35f, 0.18f, 0.08f));

            GameObject leaves = GameObject.CreatePrimitive(
                PrimitiveType.Sphere
            );

            leaves.name = "Tree Leaves";
            leaves.transform.position = position + Vector3.up * 3.5f;
            leaves.transform.localScale = Vector3.one * 3f;

            leaves.GetComponent<Renderer>().material =
                treeMaterial != null ? treeMaterial :
                MakeMaterial(new Color(0.08f, 0.3f, 0.08f));
        }
    }

    void CreateBushes()
    {
        for (int i = 0; i < bushCount; i++)
        {
            GameObject bush = GameObject.CreatePrimitive(
                PrimitiveType.Sphere
            );

            bush.name = "Bush";
            bush.transform.position =
                RandomPosition() + Vector3.up * 0.5f;

            bush.transform.localScale = new Vector3(2f, 1f, 2f);

            bush.GetComponent<Renderer>().material =
                bushMaterial != null ? bushMaterial :
                MakeMaterial(new Color(0.1f, 0.35f, 0.08f));
        }
    }

    void CreateCrates()
    {
        for (int i = 0; i < crateCount; i++)
        {
            GameObject crate = GameObject.CreatePrimitive(
                PrimitiveType.Cube
            );

            crate.name = "Loot Crate";
            crate.transform.position =
                RandomPosition() + Vector3.up * 0.5f;

            crate.GetComponent<Renderer>().material =
                crateMaterial != null ? crateMaterial :
                MakeMaterial(new Color(0.55f, 0.3f, 0.1f));
        }
    }

    void CreatePlayer()
    {
        GameObject player = GameObject.CreatePrimitive(
            PrimitiveType.Capsule
        );

        player.name = "Player";
        player.tag = "Player";
        player.transform.position = new Vector3(0f, 1f, 0f);

        player.AddComponent<CharacterController>();
    }

    Vector3 RandomPosition()
    {
        return new Vector3(
            Random.Range(-arenaSize / 2f, arenaSize / 2f),
            0f,
            Random.Range(-arenaSize / 2f, arenaSize / 2f)
        );
    }
}
