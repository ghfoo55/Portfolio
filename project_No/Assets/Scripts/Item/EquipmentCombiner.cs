using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentCombiner
{
    private readonly Dictionary<int, Transform> rootBoneDictionary = new Dictionary<int, Transform>();

    private readonly Transform transform;

    public EquipmentCombiner(GameObject rootGo)
    {
        transform = rootGo.transform;
        TraverseHierarchy(transform);
    }
    
    public Transform AddLimb(GameObject itemGo, List<string> boneNames)
    {
        Transform limb = processBoneObject(itemGo.GetComponentInChildren<SkinnedMeshRenderer>(), boneNames);
        limb.SetParent(transform);

        return limb;
    }

    private Transform processBoneObject(SkinnedMeshRenderer renderer, List<string> boneNames)
    {
        Transform itemTransform = new GameObject().transform;

        SkinnedMeshRenderer meshRenderer = itemTransform.gameObject.AddComponent<SkinnedMeshRenderer>();

        Transform[] boneTransforms = new Transform[boneNames.Count];
        for(int i = 0; i < boneNames.Count; ++i)
        {
            boneTransforms[i] = rootBoneDictionary[boneNames[i].GetHashCode()];
        }
        meshRenderer.bones = boneTransforms;
        meshRenderer.sharedMesh = renderer.sharedMesh;
        meshRenderer.materials = renderer.sharedMaterials;

        return itemTransform;
    }

    public Transform[] AddMesh(GameObject itemGo)
    {
        Transform[] itemTransforms = ProcessMeshObject(itemGo.GetComponentsInChildren<MeshRenderer>());
        return itemTransforms;
    }

    private Transform[] ProcessMeshObject(MeshRenderer[] meshRenderers)
    {
        List<Transform> itemTransforms = new List<Transform>();

        foreach(MeshRenderer renderer in meshRenderers)
        {
            if(renderer.transform.parent != null)
            {
                Transform parent = rootBoneDictionary[renderer.transform.parent.name.GetHashCode()];

                GameObject itemGo = GameObject.Instantiate(renderer.gameObject, parent);

                itemTransforms.Add(itemGo.transform);
            }
        }

        return itemTransforms.ToArray();
    }

    private void TraverseHierarchy(Transform root)
    {
        foreach(Transform child in root)
        {
            rootBoneDictionary.Add(child.name.GetHashCode(), child);

            TraverseHierarchy(child);
        }
    }
}  