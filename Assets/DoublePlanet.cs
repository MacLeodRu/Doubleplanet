using UnityEngine;

public class DoublePlanet : MonoBehaviour
{
    public GameObject giantUnityGameObject;
    public GameObject dwarfUnityGameObject;
    
    Planet giant, dwarf;
    double dt;
    readonly double G = 6.7e-11f;

    void Start()
    {
        giantUnityGameObject = GameObject.Find("Giant");
        dwarfUnityGameObject = GameObject.Find("Dwarf");

        giant = new Planet();
        dwarf = new Planet();

        giant.pos = new Vec3(-1E11f, 0, 0);
        dwarf.pos = new Vec3(1.5e11f, 0, 0);

        giantUnityGameObject.transform.position = giant.GetScaledPos();
        dwarfUnityGameObject.transform.position = dwarf.GetScaledPos();

        giant.mass = 15e30;

        giant.p = new Vec3(0, 0, -0.251e4) * giant.mass;

        dwarf.mass = 1e30;
        dwarf.p = -giant.p;

        dt = 4e4;
    }

    void FixedUpdate()
    {
        Vec3 r = dwarf.pos - giant.pos;

        Vec3 F = - G * giant.mass * dwarf.mass / (r.Magnitude() * r.Magnitude()) * (r / r.Magnitude());

        giant.p -= F * dt;
        dwarf.p += F * dt;

        giant.pos += (giant.p / giant.mass) * dt;
        dwarf.pos += (dwarf.p / dwarf.mass) * dt;

        giantUnityGameObject.transform.position = giant.GetScaledPos();
        dwarfUnityGameObject.transform.position = dwarf.GetScaledPos();
    }
}
