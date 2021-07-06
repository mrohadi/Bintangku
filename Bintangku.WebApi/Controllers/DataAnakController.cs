using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Bintangku.WebApi.Data.Entities;
using Bintangku.WebApi.Extensions;
using Bintangku.WebApi.Interfaces;
using Bintangku.WebApi.Data.DTO;

namespace Bintangku.WebApi.Controllers
{
    [Authorize]
    public class DataAnakController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        public DataAnakController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// HTTP Get to get all data anak from data base
        /// </summary>
        /// <returns>List of data anak</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DataAnak>>> GetDataAnaks()
        {
            try
            {
                var dataAnak = await _unitOfWork.DataAnakRepository
                    .GetDataAnaksAsync();
            
                if(dataAnak != null)
                    return Ok(dataAnak);
                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Data Anak Tidak Ditemukan: ${ex}");
            }
        }

        /// <summary>
        /// HTTP Get to get specific data anak based on given id
        /// </summary>
        /// <param name="dataAnakId"></param>
        /// <returns>Specific data anak based on DataAnakId</returns>
        [HttpGet("{dataAnakId}")]
        public async Task<ActionResult<DataAnak>> GetDataAnak(int dataAnakId)
        {
            try
            {
                DataAnakDto dataAnakToReturn = await _unitOfWork.DataAnakRepository
                    .GetDataAnakAsync(dataAnakId);

                if (dataAnakToReturn != null)
                    return Ok(dataAnakToReturn);
                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Data Anak Tidak Ditemukan: {ex}");
            }
        }

        /// <summary>
        /// HTTP Post to create new data anak and then save it onto data base 
        /// </summary>
        /// <param name="dataAnakDto">Data anak transfer object to post into data base</param>
        /// <returns>No Return</returns>
        [HttpPost]
        public async Task<IActionResult> PostDataAnak(
            [FromBody] PostDataAnakDto postDataAnakDto)
        {
            try
            {
                string currentNakesUsername = User.GetUserName();
                
                await _unitOfWork.DataAnakRepository.PostDataAnakAsync(currentNakesUsername, postDataAnakDto);

                if(await _unitOfWork.Complete()) 
                    return Ok();
                else
                    return BadRequest("Failed to Save Data Anak!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex}");
            }
        }
        
        /// <summary>
        /// Update specific data anak based on DataAnakId
        /// </summary>
        /// <param name="dataAnakId">Uniqe dataAnakId</param>
        /// <param name="updateDataAnakDto">Update datan anak transfer object to update in data base</param>
        /// <returns>No Return</returns>
        [HttpPut("{dataAnakId}")]
        public async Task<IActionResult> UpdateDataAnak(
            int dataAnakId, [FromBody]DataAnak dataAnak)
        {
            try
            {
                await _unitOfWork.DataAnakRepository.UpdateDataAnakAsync(dataAnakId, dataAnak);                

                if(await _unitOfWork.Complete())
                    return Ok();
                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex}");
            }
        }

        /// <summary>
        /// Delete data anak based on specific dataAnakId
        /// </summary>
        /// <param name="dataAnakId">Unique dataAnakId</param>
        /// <returns>No Return</returns>
        [HttpDelete("{dataAnakId}")]
        public async Task<IActionResult> DeleteDataAnak(int dataAnakId)
        {
            try
            {
                await _unitOfWork.DataAnakRepository.DeleteDataAnakAsync(dataAnakId);

                if(await _unitOfWork.Complete())
                    return Ok();
                return BadRequest("Failed to Save Data in Data Base!");   
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex}");
            }
        }
    }
}