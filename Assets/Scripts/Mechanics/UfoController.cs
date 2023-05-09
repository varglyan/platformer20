using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Platformer.Mechanics
{
    public class UfoController : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _ufoRenderer;
        [SerializeField] private AssetReference _ufoSpriteRef;

        void Awake()
        {
            if (_ufoSpriteRef != null)
                SetSprite();
        }

        private void OnDestroy()
        {
            _ufoSpriteRef?.ReleaseAsset();
        }

        private void SetSprite()
        {
            AsyncOperationHandle handle = _ufoSpriteRef.LoadAssetAsync<Sprite>();
            handle.Completed += OnLoadCompleted;
            void OnLoadCompleted(AsyncOperationHandle h)
            {
                if (h.Status != AsyncOperationStatus.Succeeded) return;
                _ufoRenderer.sprite = (Sprite)h.Result;
            }
        }
    }
}