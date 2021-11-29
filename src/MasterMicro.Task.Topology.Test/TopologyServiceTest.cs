using MasterMicro.Task.Toplogy.Application.Interfaces;
using System;
using System.IO;
using Xunit;
namespace MasterMicro.Task.Topology.Test
{
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
            var parentDir = Directory.GetParent(Environment.CurrentDirectory).FullName.Replace(@"\bin\Debug", "");
            var path = parentDir + "\\" + fileName;
            var response=await _topologyService.ReadTopologyFromJson(path);
            Assert.NotNull(response);
        }

        [Fact]
        public async System.Threading.Tasks.Task ShouldThrowsFileNotFoundException()
        {
            var fileName = "topology.json0";
            var parentDir = Directory.GetParent(Environment.CurrentDirectory).FullName.Replace(@"\bin\Debug", "");
            var path = parentDir + "\\" + fileName;
            await Assert.ThrowsAsync<FileNotFoundException>(() => _topologyService.ReadTopologyFromJson(path));
        }

        [Fact]
        public void ShouldWriteToJsonFile()
        {
            throw new NotImplementedException();
        }
        public void ShouldGetSpecficTopology()
        {

            throw new NotImplementedException();
        }
        public void ShouldGetDevicesOnToplogy()
        {

            throw new NotImplementedException();
        }
        public void ShouldRemoveToplogyFromMemmory()
        {

            throw new NotImplementedException();
        }
        public void ShouldGetDevicesOnToplogyWithNetList()
        {

            throw new NotImplementedException();
        }

    }
}
