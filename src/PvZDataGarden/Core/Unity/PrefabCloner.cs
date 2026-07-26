namespace PvZDataGarden.Unity;

using MelonLoader;

using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

internal static class PrefabCloner
{
    public static GameObject InstantiateFromPrefabAsset(
        AssetReferenceGameObject reference,
        bool expectLoaded = false)
    {
        ArgumentNullException.ThrowIfNull(reference);

        GameObject prefabAsset = LoadPrefabReference(reference, expectLoaded);

        return Object.Instantiate(prefabAsset);
    }

    private static GameObject LoadPrefabReference(
        AssetReferenceGameObject reference,
        bool expectLoaded)
    {
        AsyncOperationHandle handle = reference.OperationHandle.IsValid()
           ? reference.OperationHandle
           : reference.LoadAssetAsync<GameObject>();

        bool isLoaded = handle.IsDone;
        if (!isLoaded)
        {
            handle.WaitForCompletion();
        }

        if (handle.Result == null)
        {
            throw new InvalidOperationException(
                $"Failed to load prefab from AssetReference. AssetGUID: '{reference.AssetGUID}'.");
        }

        var result = handle.Result.Cast<GameObject>();

        if (expectLoaded && !isLoaded)
        {
            Melon<Core>.Logger.Warning($"Expected prefab '{result.name}' to be loaded");
        }

        return result;
    }
}
