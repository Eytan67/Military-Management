namespace MilitaryManagement.Model
{
    public class Personnel : BaseAsset
    {
        public string Rank {  get; set; }
        public string ServiceNumber { get; set; }
        public string AssignedUnit { get; set; }
        public Personnel() : base(AssetType.Personnel) { }

    }
}
