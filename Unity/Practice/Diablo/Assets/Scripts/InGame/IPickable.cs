namespace InGame {
    public interface IPickable {
        public struct ItemInfo {
            public string itemName;
            public string itemDescription;
            public string effectResource;
            public float effectAmount;
        }

        public void ItemUse();
    }
}
