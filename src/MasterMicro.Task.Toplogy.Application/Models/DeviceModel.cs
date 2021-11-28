namespace MasterMicro.Task.Toplogy.Application.Models
{
    public class DeviceModel
    {
        public string Type { get; set; }
        public string Id { get; set; }
        public ResistanceModel Resistance { get; set; }
        public NetlistModel Netlist { get; set; }
        public MLModel Ml { get; set; }
    }

}
