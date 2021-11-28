using MasterMicro.Task.Toplogy.Application.Interfaces;
using MasterMicro.Task.Toplogy.Application.Models;
using MasterMicro.Task.Toplogy.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMicro.Task.Toplogy.Application.Services
{
    public class TopologyService : ITopologyService
    {
        private readonly IRepository<TopologyModel> _topologiesRepo;
        private List<TopologyModel> _inMemmoryTopologies;
        public TopologyService(IRepository<TopologyModel> topologiesRepo)
        {
            _topologiesRepo = topologiesRepo ?? throw new ArgumentNullException(nameof(topologiesRepo));
            _inMemmoryTopologies = new List<TopologyModel>();
        }
        public IEnumerable<TopologyModel> GetAllTopologies()
        {
            return _inMemmoryTopologies;
        }

        public IEnumerable<DeviceModel> GetDevices(string topologyId)
        {
            var deviceList = _inMemmoryTopologies.Where(x => x.Id == topologyId).FirstOrDefault()?.Components?.ToList();
            return deviceList;
        }

        public IEnumerable<DeviceModel> GetDevices(string topologyId, string netlistId)
        {
            var topology = _inMemmoryTopologies.Where(x => x.Id == topologyId).FirstOrDefault();

            var deviceList = topology?.Components?.Where(x => x.Netlist.Id == netlistId).ToList();
            return deviceList;
        }

        public async Task<TopologyModel> ReadTopologyFromJson(string filePath)
        {
            var topologyToRead = await _topologiesRepo.GetByJsonFileName(filePath);
            _inMemmoryTopologies.Add(topologyToRead);
            return topologyToRead;
        }

        public void RemoveTopology(string topologyId)
        {
            var topologyToRemove = _inMemmoryTopologies.Where(x => x.Id == topologyId).FirstOrDefault();
            _inMemmoryTopologies.Remove(topologyToRemove);
        }

        public async Task<TopologyModel> SaveTopologyToJson(string topologyId)
        {
            var topologyToSave = _inMemmoryTopologies.Where(x => x.Id == topologyId).FirstOrDefault();
            
            topologyToSave = await _topologiesRepo.SaveToJsonFile(topologyToSave, CreateJsonFileName());
            return topologyToSave;
        }

        private string CreateJsonFileName()
        {
            var fileName = new Guid().ToString() + ".json";
            return fileName;
        }
    }
}
