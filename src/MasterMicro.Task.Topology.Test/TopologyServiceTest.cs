using MasterMicro.Task.Toplogy.Application.Interfaces;
using System;
using System.IO;
using System.Linq;
using Xunit;
namespace MasterMicro.Task.Topology.Test
{
    [Collection("Seq")]
    public class TopologyServiceTest
    {
        private readonly ITopologyService _topologyService;
        public TopologyServiceTest(ITopologyService topologyService)
        {
            _topologyService = topologyService ?? throw new ArgumentNullException(nameof(topologyService));
        }

        [Fact]
        public async System.Threading.Tasks.Task  ShouldReadJsonFileAndLoadInMemmory()
        {
            var fileName = "topology.json";
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
            var response=await _topologyService.ReadTopologyFromJson(path);
            Assert.NotNull(response);
        }

        [Fact]
        public async System.Threading.Tasks.Task ShouldThrowsFileNotFoundException()
        {
            var fileName = "topology.json0";
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
            await Assert.ThrowsAsync<FileNotFoundException>(() => _topologyService.ReadTopologyFromJson(path));
        }

        [Fact]
        public async System.Threading.Tasks.Task ShouldWriteToJsonFile()
        {

            var fileName = "topology.json";
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
            var top =await _topologyService.ReadTopologyFromJson(path);
            var savedFile = await _topologyService.SaveTopologyToJson(top.Id);
            Assert.True(File.Exists(savedFile));
        }

        [Fact]
        public async System.Threading.Tasks.Task ShouldGetDevicesOnTopology()
        {

            var fileName = "topology.json";
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
            var top1 = await _topologyService.ReadTopologyFromJson(path);
            var devices = _topologyService.GetDevices(top1.Id);
            Assert.NotNull(devices);
        }


        [Fact]
        public async System.Threading.Tasks.Task ShouldGetDevicesOnToplogyWithNetList()
        {

            var fileName = "topology.json";
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
            var top1 = await _topologyService.ReadTopologyFromJson(path);
            var device = _topologyService.GetDevices(top1.Id, top1.Components?.Select(x => x.Netlist?.Id).FirstOrDefault());
            Assert.NotNull(device);
        }

    }
}
