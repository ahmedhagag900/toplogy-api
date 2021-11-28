using System;
using System.Collections.Generic;
using System.Text;

namespace MasterMicro.Task.Toplogy.Application.Models
{
    public class TopologyModel
    {
        public string Id { get; set; }
        public DeviceModel[] Components { get; set; }
    }

}
