using MasterMicro.Task.Toplogy.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;

namespace MasterMicro.Task.Topology.Test
{
    [Collection("Seq")]
    public class TopologyRemoveTest
    {
        private readonly ITopologyService _topologyService;
        public TopologyRemoveTest(ITopologyService topologyService)
        {
            _topologyService = topologyService ?? throw new ArgumentNullException(nameof(topologyService));
        }
        [Fact]
        public async System.Threading.Tasks.Task ShouldRemoveToplogyFromMemmory()
        {

            var fileName = "topology.json";
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
            var top1 = await _topologyService.ReadTopologyFromJson(path);
            _topologyService.RemoveTopology(top1.Id);
            var top2 = _topologyService.GetAllTopologies().Where(x => x.Id == top1.Id).FirstOrDefault();
            Assert.Null(top2);
        }
    }
}
