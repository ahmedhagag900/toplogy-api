using MasterMicro.Task.Toplogy.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MasterMicro.Task.Toplogy.Application.Interfaces
{
    public interface ITopologyService
    {
        /// <summary>
        /// read topology from json file
        /// </summary>
        /// <param name="filePath">file path to the json to read</param>
        /// <returns>topology model read from the file</returns>
        Task<TopologyModel> ReadTopologyFromJson(string filePath);
        /// <summary>
        /// save/write topology to json file
        /// </summary>
        /// <param name="topologyId">topology id to write/save</param>
        /// <returns>path to saved file</returns>
        Task<string> SaveTopologyToJson(string topologyId);
        /// <summary>
        /// get all topolgies saved in memory
        /// </summary>
        /// <returns>list of all topologies</returns>
        IEnumerable<TopologyModel> GetAllTopologies();
        /// <summary>
        /// get all devicess connected on specific topology
        /// </summary>
        /// <param name="topologyId">topology id</param>
        /// <returns>all devicess connected on specific topology</returns>
        IEnumerable<DeviceModel> GetDevices(string topologyId);
        /// <summary>
        /// get all devicess connected on specific topology and netlist
        /// </summary>
        /// <param name="topologyId">topology id</param>
        /// <param name="netlistId">netlist id</param>
        /// <returns>all devices connected on specific topology and netlist</returns>
        IEnumerable<DeviceModel> GetDevices(string topologyId, string netlistId);
        /// <summary>
        /// remove toplogy from memory
        /// </summary>
        /// <param name="topologyId">topology id to remove</param>
        void RemoveTopology(string topologyId);
    }
}
