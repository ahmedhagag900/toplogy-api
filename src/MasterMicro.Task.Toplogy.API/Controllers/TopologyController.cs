using MasterMicro.Task.Toplogy.API.Requests;
using MasterMicro.Task.Toplogy.Application.Interfaces;
using MasterMicro.Task.Toplogy.Application.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MasterMicro.Task.Toplogy.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class TopologyController : ControllerBase
    {

        private readonly ITopologyService _topologyService;
        public TopologyController(ITopologyService topologyService)
        {
            _topologyService = topologyService ?? throw new ArgumentNullException(nameof(topologyService));
        }
        [HttpGet]
        [Route("~/api/Topologies")]
        [ProducesResponseType(typeof(IEnumerable<TopologyModel>),(int)HttpStatusCode.OK)]
        public IActionResult GetAllTopologies()
        {
            var topologies = _topologyService.GetAllTopologies();
            return Ok(topologies);
        }

        [HttpPost]
        [ProducesResponseType(typeof(TopologyModel),(int)HttpStatusCode.OK)]
        public async Task<IActionResult> AddTopology([FromBody] AddTopologyRequest request)
        {
            var topology = await _topologyService.ReadTopologyFromJson(request.FilePath);
            return Ok(topology);
        }
        [HttpPut]
        [Route("{topId}")]
        [ProducesResponseType(typeof(TopologyModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> SaveTopology([FromRoute]string topId)
        {
            var topology = await _topologyService.SaveTopologyToJson(topId);
            return Ok(topology);
        }

        [HttpDelete]
        [Route("{topId}")]
        [ProducesResponseType(typeof(TopologyModel), (int)HttpStatusCode.NoContent)]
        public  IActionResult RemoveTopology([FromRoute] string topId)
        {
            _topologyService.RemoveTopology(topId);
            return NoContent();
        }

        [HttpGet]
        [Route("{topId}/devices")]
        [ProducesResponseType(typeof(IEnumerable<DeviceModel>), (int)HttpStatusCode.OK)]
        public IActionResult GetDevices([FromRoute] string topId)
        {
            var devices=_topologyService.GetDevices(topId);
            return Ok(devices);
        }
        [HttpGet]
        [Route("{topId}/metlist/{netId}/devices")]
        [ProducesResponseType(typeof(IEnumerable<DeviceModel>), (int)HttpStatusCode.OK)]
        public IActionResult GetDevices([FromRoute] string topId,[FromRoute] string netId)
        {
            var devices = _topologyService.GetDevices(topId,netId);
            return Ok(devices);
        }
    }
}
