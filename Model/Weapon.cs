namespace MilitaryManagement.Model
{
    public class Weapon : BaseAsset
    {
        public string Caliber {  get; set; }
        public string SerialNumber { get; set; }
        public int AmmunitionCount { get; set; }
        public Weapon() : base(AssetType.Weapon) { }

    }
}
