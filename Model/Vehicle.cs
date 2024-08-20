namespace MilitaryManagement.Model
{
    public class Vehicle : BaseAsset
    {
        public string Model {  get; set; }
        public string LicensePlate {  get; set; }
        public Status OperationalStatus {  get; set; }

        public Vehicle() : base(AssetType.Vehicle) { }

    }
}
