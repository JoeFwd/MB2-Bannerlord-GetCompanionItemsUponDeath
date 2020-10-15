using NUnit.Framework;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using static GetCompanionItemsUponDeath.Tests.EquipementHelpers;

namespace GetCompanionItemsUponDeath.Tests
{
    [TestFixture]
    public class ItemRosterItemAmountHandlerTests
    {
        [Test]
        public void ChangeAmountOfAllItemsTo_WithANullItemRoster_ReturnsAnEmptyItemRoster()
        {
            int itemAmount = 0;
            ItemRoster input = null;
            ItemRoster expected = GetEmptyItemRoster();
            ItemRosterItemAmountHandler itemRosterItemAmountHandler = new ItemRosterItemAmountHandler();

            ItemRoster actual = itemRosterItemAmountHandler.ChangeAmountOfAllItemsTo(input, itemAmount);
            
            CollectionAssert.AreEqual(expected, actual);
        }
        
        [Test]
        public void ChangeAmountOfAllItemsTo_ItemRosterWithInvalidItemRosterElementsOnly_ReturnsAnEmptyItemRoster()
        {
            int maxItems = GetMaxItemsInEquipment();
            int itemAmount = 0;
            ItemRoster input = GetItemRosterWithInvalidItemRosterElements(maxItems);
            ItemRoster expected = GetEmptyItemRoster();
            ItemRosterItemAmountHandler itemRosterItemAmountHandler = new ItemRosterItemAmountHandler();

            ItemRoster actual = itemRosterItemAmountHandler.ChangeAmountOfAllItemsTo(input, itemAmount);
            
            CollectionAssert.AreEqual(expected, actual);
        }
        
        [Test]
        public void ChangeAmountOfAllItemsTo_ItemRosterWithInvalidItemObjectsOnly_ReturnsAnEmptyItemRoster()
        {
            int maxItems = GetMaxItemsInEquipment();
            int itemAmount = 0;
            ItemRoster input = GetItemRosterWithInvalidItemObjectsOnly(maxItems);
            ItemRoster expected = GetEmptyItemRoster();
            ItemRosterItemAmountHandler itemRosterItemAmountHandler = new ItemRosterItemAmountHandler();

            ItemRoster actual = itemRosterItemAmountHandler.ChangeAmountOfAllItemsTo(input, itemAmount);
            
            CollectionAssert.AreEqual(expected, actual);
        }
        
        [Test]
        public void ChangeAmountOfAllItemsTo_WithANegativeAmount_ReturnsAnEmptyItemRoster()
        {
            int maxItems = GetMaxItemsInEquipment();
            int itemAmount = 0;
            ItemRoster input = GetItemRosterWithInvalidItemRosterElements(maxItems);
            ItemRoster expected = GetEmptyItemRoster();
            ItemRosterItemAmountHandler itemRosterItemAmountHandler = new ItemRosterItemAmountHandler();

            ItemRoster actual = itemRosterItemAmountHandler.ChangeAmountOfAllItemsTo(input, itemAmount);
            
            CollectionAssert.AreEqual(expected, actual);
        }
        
        [Test]
        public void ChangeAmountOfAllItemsTo_WithAnAmountGreaterThanIntMax_ReturnsItemRosterWithIntMaxAmounts()
        {
            int maxItems = GetMaxItemsInEquipment();
            int maxAmount = int.MaxValue;
            ItemRoster input = GetItemRosterWithDefaultValidItemObjectsOnly(maxItems, 0);
            ItemRoster expected = GetItemRosterWithDefaultValidItemObjectsOnly(maxItems, int.MaxValue);
            ItemRosterItemAmountHandler itemRosterItemAmountHandler = new ItemRosterItemAmountHandler();

            ItemRoster actual = itemRosterItemAmountHandler.ChangeAmountOfAllItemsTo(input, maxAmount + 1); // Int Overflow
            
            CollectionAssert.AreEquivalent(expected, actual); // Order does not matter
        }

        private static ItemRoster GetEmptyItemRoster() => new ItemRoster();
        
        private static ItemRoster GetItemRosterWithDefaultValidItemObjectsOnly(int items, int defaultAmount)
        {
            ItemRoster itemRoster = GetEmptyItemRoster();
            
            for (var index = 0; index < items; index++)
            {
                ItemRosterElement defaultItemRosterElement = new ItemRosterElement(new ItemObject(), defaultAmount, new ItemModifier());
                itemRoster.Add(defaultItemRosterElement);
            }

            return itemRoster;
        }

        private static ItemRoster GetItemRosterWithInvalidItemObjectsOnly(int items)
        {
            ItemRoster itemRoster = GetEmptyItemRoster();
            
            for (var index=0; index < items; index++)
            {
                itemRoster.Add(ItemRosterElement.Invalid);
            }
            
            return itemRoster;
        }
        
        private static ItemRoster GetItemRosterWithInvalidItemRosterElements(int items)
        {
            ItemRoster itemRoster = GetEmptyItemRoster();
            
            for (var index=0; index < items; index++)
            {
                itemRoster.Add(ItemRosterElement.Invalid);
            }
            
            return itemRoster;
        }
    }
}