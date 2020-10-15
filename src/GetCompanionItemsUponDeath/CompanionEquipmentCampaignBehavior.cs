using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.Core;

namespace GetCompanionItemsUponDeath
{
    public class CompanionEquipmentCampaignBehavior : CampaignBehaviorBase

    {
        public override void RegisterEvents()
        {
            
        }

        public override void SyncData(IDataStore dataStore) { }
        
        // private OnHeroKilled
        // Checker OnHeirSelectionOver | 

/*        protected static void AddLeftHeroEquipmentToRightHeroPartyInventory(Hero leftHero, Hero rightHero)
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
*/
    }
}