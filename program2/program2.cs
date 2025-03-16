using UnityEngine;
using UnityEngine.UI;

public class ChangeAppearance : MonoBehaviour
{
    public GameObject cube, sphere, plane;  
    public Material cubeMaterial, sphereMaterial, planeMaterial;
    public Material cubeTexture, sphereTexture, planeTexture;

    private bool isCubeMaterial = true;
    private bool isSphereMaterial = false;
    private bool isPlaneMaterial = true;

    public void ChangeCubeAppearance()
    {
        if (isCubeMaterial)
            cube.GetComponent<Renderer>().material = cubeTexture;
        else
            cube.GetComponent<Renderer>().material = cubeMaterial;

        isCubeMaterial = !isCubeMaterial;
    }

    public void ChangeSphereAppearance()
    {
        if (isSphereMaterial)
            sphere.GetComponent<Renderer>().material = sphereTexture;
        else
            sphere.GetComponent<Renderer>().material = sphereMaterial;

        isSphereMaterial = !isSphereMaterial;
    }

    public void ChangePlaneAppearance()
    {
        if (isPlaneMaterial)
            plane.GetComponent<Renderer>().material = planeTexture;
        else
            plane.GetComponent<Renderer>().material = planeMaterial;

        isPlaneMaterial = !isPlaneMaterial;
    }
}
