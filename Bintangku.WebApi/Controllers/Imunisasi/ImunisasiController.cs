using System;
using System.Threading.Tasks;
using Bintangku.WebApi.Data.DTO;
using Bintangku.WebApi.Data.Entities.Imunisasi;
using Bintangku.WebApi.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bintangku.WebApi.Controllers.Imunisasi
{
    [Authorize]
    public class ImunisasiController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        public ImunisasiController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<ImunisasiAnak>> GetImunisasiAsync()
        {
            var imunisasi = await _unitOfWork.ImunisasiRepository.GetImunisasiAsync();
            if(imunisasi == null)
                return BadRequest("Imunisasi Aanak Tidak Ditemukan");
            return Ok(imunisasi);
        }

        /* Hepatitis B */
        [HttpGet("hepatitis-b/{dataAnakId:int?}")]
        public async Task<ActionResult<ImunisasiDto>> GetImunisasiHepatitisB(int dataAnakId)
        {
            try
            {
                var imunisasi = await _unitOfWork.ImunisasiHepatitisBRepository
                    .GetImunisasiHepatitisBAsync(dataAnakId);
                
                if(imunisasi != null)
                    return Ok(imunisasi);
                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex}");
            }
        }

        [HttpPut("hepatitis-b/{dataAnakId:int}")]
        public async Task<IActionResult> UpdateImunisasiHepatitisB(int dataAnakId, [FromBody]ImunisasiDto dto)
        {
            try
            {
                await _unitOfWork.ImunisasiHepatitisBRepository.UpdateImunisasiHepatitisBAsyn(dataAnakId, dto);

                await _unitOfWork.Complete();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex}");
            }
        }
        /* End - Hepatitis B */

        /* Polio */
        [HttpGet("polio/{dataAnakId:int}")]
        public async Task<ActionResult<ImunisasiDto>> GetImunisasiPolio(int dataAnakId)
        {
            try
            {
                var polio = await _unitOfWork.ImunisasiPolioRepository
                    .GetImunisasiPolioAsync(dataAnakId);    
                
                if(polio != null)
                    return Ok(polio);
                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex}");
            }
        }

        [HttpPut("polio/{dataAnakId:int}")]
        public async Task<ActionResult> UpdateImunisasiPolio(int dataAnakId, [FromBody] ImunisasiDto dto)
        {
            try
            {
                await _unitOfWork.ImunisasiPolioRepository.UpdateImunisasiPolioAsync(dataAnakId, dto);

                await _unitOfWork.Complete();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex}");
            }
        }
        /* End - Polio */

        /* Bcg */
        [HttpGet("bcg/{dataAnakId:int}")]
        public async Task<ActionResult<ImunisasiDto>> GetImunisasiBcg(int dataAnakId)
        {
            try
            {
                var bcg = await _unitOfWork.ImunisasiBcgRepository
                    .GetImunisasiBcgAsync(dataAnakId);
                
                if(bcg != null)
                    return Ok(bcg);
                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex}");
            }
        }

        [HttpPut("bcg/{dataAnakId:int}")]
        public async Task<ActionResult> UpdateImunisasiBcg(int dataAnakId, ImunisasiDto dto)
        {
            try
            {
                await _unitOfWork.ImunisasiBcgRepository
                    .UpdateImunisasiBcgAsync(dataAnakId, dto);
                
                await _unitOfWork.Complete();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex}");
            }
        }
        /* End - Bcg */
        /* DTP */
        [HttpGet("dtp/{dataAnakId:int}")]
        public async Task<ActionResult<ImunisasiDto>> GetImunisasiDtp(int dataAnakId)
        {
            try
            {
                var dtp = await _unitOfWork.ImunisasiDtpRepository
                    .GetImunisasiDtpAsync(dataAnakId);
                
                if(dtp != null)
                    return Ok(dtp);
                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex}");
            }
        }

        [HttpPut("dtp/{dataAnakId:int}")]
        public async Task<ActionResult> UpdateImunisasiDtp(int dataAnakId, ImunisasiDto dto)
        {
            try
            {
                await _unitOfWork.ImunisasiDtpRepository
                    .UpdateImunisasiDtpAsync(dataAnakId, dto);

                await _unitOfWork.Complete();                
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex}");
            }           
        }
        /* End - DTP */
        /* Hib */
        [HttpGet("hib/{dataAnakId:int}")]
        public async Task<ActionResult<ImunisasiDto>> GetImunisasiHib(int dataAnakId)
        {
            try
            {
                var hib = await _unitOfWork.ImunisasiHibRepository
                    .GetImunisasiHibAsync(dataAnakId);

                if(hib != null)
                    return Ok(hib);
                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex}");
            }
        }

        [HttpPut("hib/{dataAnakId:int}")]
        public async Task<IActionResult> UpdateImunisasiHib(int dataAnakId, ImunisasiDto dto)
        {
            try
            {
                await _unitOfWork.ImunisasiHibRepository
                    .UpdateImunisasiHibAsync(dataAnakId, dto);
                
                await _unitOfWork.Complete();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex}");
            }
        }
        /* End - Hib */
        /* Pcv */
        [HttpGet("pcv/{dataAnakId:int}")]
        public async Task<ActionResult<ImunisasiDto>> GetImunsasiPcv(int dataAnakId)
        {
            try
            {
                var pcv = await _unitOfWork.ImunisasiPcvRepository
                    .GetImunisasiPcvAsync(dataAnakId);
                
                if(pcv != null)
                    return Ok(pcv);
                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex}");
            }
        }

        [HttpPut("pcv/{dataAnakId:int}")]
        public async Task<IActionResult> UpdateImunisasiPcv(int dataAnakId, ImunisasiDto dto)
        {
            try
            {
                await _unitOfWork.ImunisasiPcvRepository
                    .UpdateImunisasiPcvAsync(dataAnakId, dto);

                await _unitOfWork.Complete();               
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex}");
            }
        }
        /* End - Pcv */
        /* Rotavirus */
        [HttpGet("rotavirus/{dataAnakId:int}")]
        public async Task<ActionResult<ImunisasiDto>> GetImunisasiRotavirus(int dataAnakId)
        {
            try
            {
                var rotavirus = await _unitOfWork.ImunisasiRotavirusRepository
                    .GetImunisasiRotavirusAsync(dataAnakId);
                
                if(rotavirus != null)
                    return Ok(rotavirus);
                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex}");
            }
        }

        [HttpPut("rotavirus/{dataAnakId:int}")]
        public async Task<IActionResult> UpdateImunisasiRotavirus(int dataAnakId, ImunisasiDto dto)
        {
            try
            {
                await _unitOfWork.ImunisasiRotavirusRepository  
                    .UpdateImunisasiRotavirusAsync(dataAnakId, dto);

                await _unitOfWork.Complete();               
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex}");
            }
        }
        /* End - Rotavirus */
        /* Influenza */
        [HttpGet("influenza/{dataAnakId:int}")]
        public async Task<ActionResult<ImunisasiDto>> GetImunisasiInfluenza(int dataAnakId)
        {
            try
            {
                var influenza = await _unitOfWork.ImunisasiInfluenzaRepository
                    .GetImunisasiInfluenzaAsync(dataAnakId);
                
                if(influenza != null)
                    return Ok(influenza);
                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex}");
            }
        }

        [HttpPut("influenza/{dataAnakId:int}")]
        public async Task<IActionResult> UpdateImunisasiInfluenza(int dataAnakId, ImunisasiDto dto)
        {
            try
            {
                await _unitOfWork.ImunisasiInfluenzaRepository
                    .UpdateImunisasiInfluenzaAsync(dataAnakId, dto);

                await _unitOfWork.Complete();               
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex}");
            }           
        }
        /* End - Influenza */
        /* Campak */
        [HttpGet("campak/{dataAnakId:int}")]
        public async Task<ActionResult<ImunisasiDto>> GetImunisasiCampak(int dataAnakId)
        {
            try
            {
                var campak = await _unitOfWork.ImunisasiCampakRepository
                    .GetImunisasiCampakAsync(dataAnakId);
                
                if(campak != null)
                    return Ok(campak);
                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex}");
            }
        }

        [HttpPut("campak/{dataAnakId:int}")]
        public async Task<IActionResult> UpdateImunisasiCampak(int dataAnakId, ImunisasiDto dto)
        {
            try
            {
                await _unitOfWork.ImunisasiCampakRepository
                    .UpdateImunisasiCampakAsync(dataAnakId, dto);
                
                await _unitOfWork.Complete();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex}");
            }
        }
        /* End - Camapk */
        /* Mmr */
        [HttpGet("mmr/{dataAnakId:int}")]
        public async Task<ActionResult<ImunisasiDto>> GetImunisasiMmr(int dataAnakId)
        {
            try
            {
                var mmr = await _unitOfWork.ImunisasiMmrRepository
                    .GetImunisasiMmrAsync(dataAnakId);
                
                if(mmr != null)
                    return Ok(mmr);
                
                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex}");
            }
        }

        [HttpPut("mmd/{dataAnakId:int}")]
        public async Task<IActionResult> UpdateImunisasiMmr(int dataAnakId, ImunisasiDto dto)
        {
            try
            {
                await _unitOfWork.ImunisasiMmrRepository
                    .UpdateImunisasiMmrAsync(dataAnakId, dto);
                
                await _unitOfWork.Complete();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex}");
            }
        }
        /* End - Mmr */
        /* Tifoid */
        [HttpGet("tifoid/{dataAnakId:int}")]
        public async Task<ActionResult<ImunisasiDto>> GetImunisasiTifoid(int dataAnakId)
        {
            try
            {
                var tifoid = await _unitOfWork.ImunisasiTifoidRepository
                    .GetImunisasiTifoidAsync(dataAnakId);
                
                if(tifoid != null)
                    return Ok(tifoid);
                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex}");
            }
        }

        [HttpPut("tifoid/{dataAnakId:int}")]
        public async Task<IActionResult> UpdateImunisasiTifoid(int dataAnakId, ImunisasiDto dto)
        {
            try
            {
                await _unitOfWork.ImunisasiTifoidRepository
                    .UpdateImunisasiTifoidAsync(dataAnakId, dto);

                await _unitOfWork.Complete();               
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex}");
            }
        }
        /* End - Tifoid */
        /* Hepatitis A */
        [HttpGet("hepatitis-a/{dataAnakId:int}")]
        public async Task<ActionResult<ImunisasiDto>> GetImunisasiHepatitisA(int dataAnakId)
        {
            try
            {
                var hepatitisA = await _unitOfWork.ImunisasiHepatitisARepository
                    .GetImunisasiHepatitisAAsync(dataAnakId);
                
                if(hepatitisA != null)
                    return Ok(hepatitisA);
                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex}");
            }
        }

        [HttpPut("hepatitis-a/{dataAnakId:int}")]
        public async Task<IActionResult> UpdateImunisasiHepatitisA(int dataAnakId, ImunisasiDto dto)
        {
            try
            {
                await _unitOfWork.ImunisasiHepatitisARepository
                    .UpdateImunisasiHepatitisAAsync(dataAnakId, dto);
                
                await _unitOfWork.Complete();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex}");
            }
        }
        /* End - Hepatitis A */
        /* Varisela */
        [HttpGet("varisela/{dataAnakId:int}")]
        public async Task<ActionResult<ImunisasiDto>> GetImunisasiVarisela(int dataAnakId)
        {
            try
            {
                var varisela = await _unitOfWork.ImunisasiVariselaRepository
                    .GetImunisasiVariselaAsync(dataAnakId);
                
                if(varisela != null)
                    return Ok(varisela);
                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex}");
            }
        }

        [HttpPut("varisela/{dataAnakId:int}")]
        public async Task<IActionResult> UpdateImunisasiVarisela(int dataAnakId, ImunisasiDto dto)
        {
            try
            {
                await _unitOfWork.ImunisasiVariselaRepository
                    .UpdateImunisasiVariselaAsync(dataAnakId, dto);               
                
                await _unitOfWork.Complete();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex}");
            }
        }
        /* End - Varisela */
        /* Hpv */
        [HttpGet("hpv/{dataAnakId:int}")]
        public async Task<ActionResult<ImunisasiDto>> GetImunisasiHpv(int dataAnakId)
        {
            try
            {
                var hpv = await _unitOfWork.ImunisasiHpvRepository
                    .GetImunisasiHpvAsync(dataAnakId);
                
                if(hpv != null)
                    return Ok(hpv);
                return BadRequest(hpv);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex}");
            }
        }

        [HttpPut("hpv/{dataAnakId:int}")]
        public async Task<IActionResult> UpdateImunisasiHpv(int dataAnakId, ImunisasiDto dto)
        {
            try
            {
                await _unitOfWork.ImunisasiHpvRepository
                    .UpdateImunisasiHpvAsync(dataAnakId, dto);
                
                await _unitOfWork.Complete();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex}");
            }
        }
        /* End - Hpv */
        /* Japanese Encephalitis */
        [HttpGet("japanese-encephalitis/{dataAnakId:int}")]
        public async Task<ActionResult<ImunisasiDto>> GetImunisasiJapaneseEncephalitis(int dataAnakId)
        {
            try
            {
                var je = await _unitOfWork.ImunisasiJapaneseEncephalitisRepository
                    .GetImunisasiJapaneseEncephalitisAsync(dataAnakId);
                
                if(je != null)
                    return Ok(je);
                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex}");
            }
        }

        [HttpPut("japanese-encephalitis/{dataAnakId:int}")]
        public async Task<IActionResult> UpdateImunisasiJapaneseEncephalitis(int dataAnakId, ImunisasiDto dto)
        {
            try
            {
                await _unitOfWork.ImunisasiJapaneseEncephalitisRepository
                    .UpdateImunisasiJapaneseEncephalitisAsync(dataAnakId, dto);
                
                await _unitOfWork.Complete();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex}");
            }
        }
        /* End - Japanese Encephalitis */
        /* Dengue */
        [HttpGet("dengue/{dataAnakId:Int}")]
        public async Task<ActionResult<ImunisasiDto>> GetImunisasiDengue(int dataAnakId)
        {
            try
            {
                var dengue = await _unitOfWork.ImunisasiDengueRepository
                    .GetImunisasiDengueAsync(dataAnakId);
                
                if(dengue != null)
                    return Ok(dengue);
                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex}");
            }
        }

        [HttpPut("dengue/{dataAnakId:int}")]
        public async Task<IActionResult> UpdateImunisasiDengue(int dataAnakId, ImunisasiDto dto)
        {
            try
            {
                await _unitOfWork.ImunisasiDengueRepository
                    .UpdateImunisasiDengueAsync(dataAnakId, dto);

                await _unitOfWork.Complete();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex}");
            }
        }
        /* End - Dengue */
    }
}