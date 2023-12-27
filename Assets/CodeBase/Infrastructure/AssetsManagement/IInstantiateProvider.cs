using Infrastructure.Services;
using UnityEngine;

namespace Infrastructure.AssetsManagement {
    public interface IInstantiateProvider : IService{
        GameObject Instantiate(string Path, Vector3 At);
        GameObject Instantiate(string Path);
    }
}