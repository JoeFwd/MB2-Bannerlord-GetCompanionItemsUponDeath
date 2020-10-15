using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;

namespace GetCompanionItemsUponDeath
{
    public static class HeroHelper
    {
        private static void AddLeftHeroEquipmentToRightHeroPartyInventory(Hero leftHero, Hero rightHero)
        {
            var battleEquipment = leftHero?.BattleEquipment;
            var civilianEquipment = leftHero?.CivilianEquipment;
            var partyInventory = rightHero?.PartyBelongedTo?.Party?.ItemRoster;
            
            if (battleEquipment == null || civilianEquipment == null || partyInventory == null)
            {
                return;
            }
            
            AddEquipmentToPartyInventory(battleEquipment, partyInventory);
            AddEquipmentToPartyInventory(civilianEquipment, partyInventory);
            
            /*for (EquipmentIndex index = EquipmentIndex.WeaponItemBeginSlot; index < EquipmentIndex.NumEquipmentSetSlots; index++)
            {
                ItemObject battleItemObject = leftHero.CharacterObject?.Equipment[index]?.Item;
                if (battleItemObject != null)
                    rightHero.PartyBelongedTo.Party.ItemRoster.Add(new ItemRosterElement(battleItemObject, 1));
            }
            
            for (EquipmentIndex index = EquipmentIndex.WeaponItemBeginSlot; index < EquipmentIndex.NumEquipmentSetSlots; index++)
            {
                ItemObject civilianItemObject = leftHero.CharacterObject?.FirstCivilianEquipment[index]?.Item;
                if (civilianItemObject != null && rightHero.PartyBelongedTo?.Party?.ItemRoster != null)
                    rightHero.PartyBelongedTo.Party.ItemRoster.Add(new ItemRosterElement(civilianItemObject, 1));
            }*/
        }

        private static void AddEquipmentToPartyInventory(Equipment equipment, ItemRoster partyInventory)
        {
            for (EquipmentIndex index = EquipmentIndex.WeaponItemBeginSlot; index < EquipmentIndex.NumEquipmentSetSlots; index++)
            {
                ItemObject itemObject = equipment[index].Item;
                ItemModifier itemModifier = equipment[index].ItemModifier;
                if (itemObject == null)
                {
                    continue;
                }
                partyInventory.Add(new ItemRosterElement(itemObject, 1, itemModifier));
            }
            
        }
    }
}