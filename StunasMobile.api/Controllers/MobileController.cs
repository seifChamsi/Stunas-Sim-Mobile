using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StunasMobile.Core;
using StunasMobile.Core.Utils;
using StunasMobile.Data.DbContext;
using StunasMobile.Data.Repositories;
using StunasMobile.Entities.Entitites;

namespace StunasMobile.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MobileController : ControllerBase
    {
        private readonly IMobileRepository _mobileRepo;
        private readonly IMapper _mapper;


        public MobileController(IMobileRepository MobileRepo,IMapper mapper)
        {
            _mobileRepo = MobileRepo;
            _mapper = mapper;
        }
        [HttpGet("GetAllByPaginate")]
        public async Task<Object> GetAll([FromQuery]PaginationParams param)
        {
            var allMobilesInfo = await _mobileRepo.GetAllWithPagination(param);
            return new
            {
                succuess = true,
                data = allMobilesInfo
            };
        }

        [HttpGet("GetAll")]
        public async Task<Object> GetAllMobiles()
        {
            return new
            {
                succuess = true,
                data = await _mobileRepo.GetAll()
            };
        }

        [HttpGet("{id}")]
        public async Task<Object> GetById(int id)
        {
            Mobile mob = await _mobileRepo.GetById(id);
            if (mob == null)
            {
                return BadRequest("Le record de mobile est inexisstant");
            }

            return new
            {
                data = mob
            };
        }

        [HttpPost("addNewMobile")]
        public async Task<Object> AddMobile(MobileModelView MobileFromView)
        {
            try
            {
                Mobile mobileToAdd = new Mobile();
                mobileToAdd = _mapper.Map<MobileModelView, Mobile>(MobileFromView);
                await _mobileRepo.Add(mobileToAdd);
                return Ok(new {succuess = true, Data = "Mobile Record Bien Ajoutée"});
            }
            catch (Exception e)
            {
                return BadRequest(new
                    {success = false, data = "il ya un erreur pendant l'ajout de record", exception = e});
            }
            
        }

        [HttpPut("changeData/{id}")]
        public async Task<Object> UpdateMobile(int id, UpdateMobileModelView MobileFromView)
        {
            try
            {

                Mobile mobileToUpdate = await _mobileRepo.GetById(id);
                
                if (mobileToUpdate == null)
                {
                    return BadRequest($"le record avec l'id : {id} n'existe pas");
                }
                
                Mobile UpdatedMobile = new Mobile()
                {
                    Id = mobileToUpdate.Id,
                    Codeclient = MobileFromView.Codeclient,
                    Numero = mobileToUpdate.Numero,
                    Data = MobileFromView.Data,
                    Forfait = MobileFromView.Forfait,
                    Sociéte = MobileFromView.Sociéte,
                    Nom = MobileFromView.Nom,
                    Handset = MobileFromView.Handset,
                    Montant = MobileFromView.Montant,
                    Prixhandset = MobileFromView.Prixhandset,
                    Site = MobileFromView.Site
                };
                await _mobileRepo.Update(UpdatedMobile);

                
                return Ok(new {success = true, status = "le record est bien mis a jour", data = mobileToUpdate});

            }
            catch (Exception e)
            {
                return BadRequest(new {status = "un erreur est servenue", exception = e});
            }

        }

        [HttpDelete("DeleteMobile/{id}")]
        public async Task<Object> DeleteMobile(int id)
        {
            Mobile mobileToDelte = await _mobileRepo.GetById(id);
            if (mobileToDelte == null)
            {
                return BadRequest($"le record avec l'id: {id} n'existe pas");

            }
            await _mobileRepo.Delete(mobileToDelte);
            return Ok(new {message = "le record est bien été supprimé"});
        }

    }
    
}