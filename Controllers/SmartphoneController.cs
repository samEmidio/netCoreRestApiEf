using System.Collections;
using System.Linq;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using netCoreRestApiEf.Data;
using netCoreRestApiEf.Dtos;
using netCoreRestApiEf.Model;
using Microsoft.AspNetCore.JsonPatch;

namespace netCoreRestApiEf.Controllers{

    [Route("api/smartphone")]
    [ApiController]
    public class SmartphoneController : ControllerBase
    {    

        private readonly ISmartphoneRepo _repository;
        private readonly IMapper _mapper;

        public SmartphoneController(ISmartphoneRepo repository , IMapper mapper)
        {
            _repository = repository;  
            _mapper = mapper;
        }

        //private readonly MockSmartphoneRepo _repository = new MockSmartphoneRepo();

        [HttpGet]
        public ActionResult <IEnumerable<SmartphoneReadDto>> getAllSmartphones()
        {

            var SmartphoneItens = _repository.GetAllSmartphones();
            
            return Ok(_mapper.Map<IEnumerable<SmartphoneReadDto>>(SmartphoneItens));
            
        }

        [HttpGet("{id}",Name="getSmartphoneById")]
        public ActionResult <SmartphoneReadDto> getSmartphoneById(int id)
        {
            var SmartphoneItem = _repository.GetSmartphoneById(id);
            
            if(SmartphoneItem != null){
                return Ok(_mapper.Map<SmartphoneReadDto>(SmartphoneItem));
            }

            return NoContent();
            

        }


        [HttpPost]
        public ActionResult<SmartphoneReadDto> CreateSmartphone(SmartphoneCreateDto smartphoneCreateDto)
        {
            var smartphoneModel = _mapper.Map<Smartphone>(smartphoneCreateDto);
            _repository.CreateSmartphone(smartphoneModel);
            _repository.saveChanges();

            var smartphoneReadDto = _mapper.Map<SmartphoneReadDto>(smartphoneModel);

            return CreatedAtRoute(nameof(getSmartphoneById),new {id = smartphoneReadDto.id},smartphoneReadDto);
        }



        [HttpPost("{id}")]
        public ActionResult UpdateSmartphone(int id, SmartphoneUpdateDto smartphoneUpdateDto)
        {
            var smartphoneModelFromRepo = _repository.GetSmartphoneById(id);

            if(smartphoneModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(smartphoneUpdateDto,smartphoneModelFromRepo);

            _repository.UpdateSmartphone(smartphoneModelFromRepo);

            _repository.saveChanges();

            return NoContent();

        }


        [HttpPatch("{id}")]
        public ActionResult PartialSmartphoneUpdate(int id,JsonPatchDocument<SmartphoneUpdateDto> patchDoc)
        {
            var smartphoneModelFromRepo = _repository.GetSmartphoneById(id);

            if(smartphoneModelFromRepo == null)
            {
                return NotFound();
            }

            var smartphoneToPatch = _mapper.Map<SmartphoneUpdateDto>(smartphoneModelFromRepo);

            patchDoc.ApplyTo(smartphoneToPatch,ModelState);

            if(!TryValidateModel(smartphoneToPatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(smartphoneToPatch,smartphoneModelFromRepo);

            _repository.saveChanges();

            return NoContent();

        }

    }

}