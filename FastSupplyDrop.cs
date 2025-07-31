using Oxide.Core.Plugins;
using UnityEngine;

namespace Oxide.Plugins
{
    [Info("Fast Supply Drop", "Djimbou", "1.0.0")]
    [Description("Makes supply drops fall faster to the ground")]
    public class FastSupplyDrop : RustPlugin
    {
        private const float DropSpeedMultiplier = 3.0f; // Increase this to make it fall faster

        void OnEntitySpawned(BaseEntity entity)
        {
            if (entity == null || entity.PrefabName == null) return;

            if (entity.PrefabName.Contains("supply_drop"))
            {
                Rigidbody rb = entity.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.drag = 0f; // no air resistance
                    rb.useGravity = true;
                    rb.velocity = new Vector3(0f, -DropSpeedMultiplier * 10f, 0f); // direct downward speed
                    Puts($"[FastSupplyDrop] Increased drop speed for supply drop at {entity.transform.position}");
                }
            }
        }
    }
}
