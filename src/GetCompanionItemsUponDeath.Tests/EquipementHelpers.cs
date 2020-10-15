using System.Collections.Generic;
using TaleWorlds.Core;
using static TaleWorlds.Core.EquipmentIndex;

namespace GetCompanionItemsUponDeath.Tests
{
    public static class EquipementHelpers
    {
        internal static Equipment GetEquipmentWithInvalidItemsOnly()
        {
            Equipment equipment = new Equipment();
            
            for (EquipmentIndex index = WeaponItemBeginSlot;
                index < NumEquipmentSetSlots;
                index++)
            {
                equipment[index] = EquipmentElement.Invalid;
            }

            return equipment;
        }
        
        internal static Equipment GetEquipmentWithValidItemsOnly()
        {
            Equipment equipment = new Equipment();
            
            for (EquipmentIndex index = WeaponItemBeginSlot;
                index < NumEquipmentSetSlots;
                index++)
            {
                equipment[index] = new EquipmentElement(new ItemObject(), new ItemModifier());
            }

            return equipment;
        }

        internal static IEnumerable<EquipmentElement> GetEquipmentElementsByEquipmentIndexOrder(Equipment equipment)
        {
            for (EquipmentIndex index = WeaponItemBeginSlot;
                index < NumEquipmentSetSlots;
                index++)
            {
                yield return equipment[index];
            }
        }

        internal static int GetMaxItemsInEquipment() => NumEquipmentSetSlots - WeaponItemBeginSlot;
    }
}