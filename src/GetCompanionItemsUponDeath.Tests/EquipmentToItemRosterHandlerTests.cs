using System;
using System.Collections.Generic;
using NUnit.Framework;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using static GetCompanionItemsUponDeath.Tests.EquipementHelpers;

namespace GetCompanionItemsUponDeath.Tests
{
    public class EquipmentToItemRosterHandlerTests
    {
        [Test]
        public void AddEquipmentItemsToItemRoster_WithANullEquipment_ReturnsAnEmptyItemRoster()
        {
            EquipmentToItemRosterHandler equipmentToItemRosterHandler = new EquipmentToItemRosterHandler();
            Equipment equipment = null;
            ItemRoster expected = new ItemRoster();

            ItemRoster actual = equipmentToItemRosterHandler.AddEquipmentItemsToItemRoster(equipment);
            
            CollectionAssert.AreEqual(expected, actual);
        }
        
        [Test]
        public void AddEquipmentItemsToItemRoster_WithEquipmentHavingInvalidItemsOnly_ReturnsAnEmptyItemRoster()
        {
            EquipmentToItemRosterHandler equipmentToItemRosterHandler = new EquipmentToItemRosterHandler();
            Equipment equipment = GetEquipmentWithInvalidItemsOnly();

            int itemCount = equipmentToItemRosterHandler.AddEquipmentItemsToItemRoster(equipment).Count;
            
            Assert.AreEqual(0, itemCount);
        }

        [Test]
        public void AddEquipmentItemsToItemRoster_WithEquipmentHavingValidItemsOnly_ReturnsItemRosterWithTheSameEquipmentItems()
        {
            EquipmentToItemRosterHandler equipmentToItemRosterHandler = new EquipmentToItemRosterHandler();
            Equipment equipment = GetEquipmentWithValidItemsOnly();
            IEnumerable<EquipmentElement> expectedEquipmentElements = GetEquipmentElementsByEquipmentIndexOrder(equipment);
            
            ItemRoster itemRoster = equipmentToItemRosterHandler.AddEquipmentItemsToItemRoster(equipment);
            
            Assert.NotNull(expectedEquipmentElements);
            CollectionAssert.AreEquivalent(expectedEquipmentElements, itemRoster); // Uses Equals(ItemRosterElement) method from EquipmentElement object. Ignore Order of items. 
        }
    }
}