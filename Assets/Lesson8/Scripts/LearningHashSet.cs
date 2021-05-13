using System.Collections.Generic;
using UnityEngine;

namespace Learning
{
    public enum ArmorType {
        Wood,
        Silver,
        Gold
    }
    public class LearningHashSet : MonoBehaviour
    {
        public HashSet<ArmorType> equipment = new HashSet<ArmorType>(){
            ArmorType.Wood // Default
        };
        public HashSet<ArmorType> extension = new HashSet<ArmorType>(){
            ArmorType.Wood // Default
        };
        private void Start() {
            Equip(equipment, ArmorType.Silver);
            Equip(extension, ArmorType.Gold);
        }

        public void Equip(HashSet<ArmorType> type, ArmorType armorType) {
            type.Add(armorType);
        }

        public void Merge(HashSet<ArmorType> equipment, HashSet<ArmorType> extension) {
            equipment.UnionWith(extension);
        }

        public void Fusion(HashSet<ArmorType> equipment, HashSet<ArmorType> extension) {
            equipment.IntersectWith(extension);
        }
    }
}
