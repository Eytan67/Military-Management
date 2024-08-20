namespace MilitaryManagement.Model
{
    public enum AssetType
    {
        Vehicle,
        Weapon,
        Personnel
    }
    public enum Status
    {
        Active,
        Inactive,
        Maintenance
    }
    public interface IAsset
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public AssetType AssetType { get; set; }
        public Status Status { get; set; }
    }
    public abstract class BaseAsset : IAsset
    {
        public int Id {  get; set; }
        public string Name {  get; set; }
        public AssetType AssetType {  get; set; }
        public Status Status {  get; set; }

        protected BaseAsset(AssetType assetType)
        {
            AssetType = assetType;
        }
    }
}
