using System;
using System.Collections.Generic;
namespace Item.InWorldSpace
{
    internal abstract class ItemWorldSpaceManager
    {
        public abstract void RemoveItemInventoryToWorldSpace(ItemBase itemBase);
        public abstract void AddItemToInventory(ItemBase itemBase);
    }
}
