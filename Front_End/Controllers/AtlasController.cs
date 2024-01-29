using Front_End.Models;
using Front_End.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Front_End.Controllers
{
    public class AtlasController : Controller
    {
        private readonly IAtlasService _atlasService;

        public AtlasController(IAtlasService atlasService)
        {
            _atlasService = atlasService;
        }

        public async Task<ActionResult> AtlasIndex()
        {
            List<AtlasPhoto>? photos = new List<AtlasPhoto>();

            ResponseDto? response = await _atlasService.GetPhotosAsync();

            if (response != null && response.IsSuccess == true)
            {
                string jsonPhotos = Convert.ToString(response.Data);
                photos = JsonConvert.DeserializeObject<List<AtlasPhoto>>(jsonPhotos);
            }

            return View(photos);
        }

        public async Task<ActionResult> AtlasCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AtlasCreate(AtlasPhoto model)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? response = await _atlasService.PostPhotoAsync(model);

                if (response != null && response.IsSuccess == true)
                {
                    return RedirectToAction(nameof(AtlasIndex));
                }

            }

            return View(model);
        }

        public async Task<ActionResult> AtlasDelete(int id)
        {
            ResponseDto? response = await _atlasService.GetPhotoByIdAsync(id);

            if (response != null && response.IsSuccess == true)
            {
                string jsonPhoto = Convert.ToString(response.Data);
                AtlasPhoto? model = JsonConvert.DeserializeObject<AtlasPhoto>(jsonPhoto);

                return View(model);
            }


            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult> AtlasDelete(AtlasPhoto model)
        {
            ResponseDto? response = await _atlasService.DeletePhotoAsync(model.Id);

            if (response != null && response.IsSuccess == true)
            {
                return RedirectToAction(nameof(AtlasIndex));
            }

            return View(model);
        }

        public async Task<ActionResult> AtlasEdit(int id)
        {
            ResponseDto? response = await _atlasService.GetPhotoByIdAsync(id);

            if (response != null && response.IsSuccess == true)
            {
                string jsonPhoto = Convert.ToString(response.Data);
                AtlasPhoto? model = JsonConvert.DeserializeObject<AtlasPhoto>(jsonPhoto);

                return View(model);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult> AtlasEdit(AtlasPhoto model)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? response = await _atlasService.PutPhotoAsync(model);

                if (response != null && response.IsSuccess == true)
                {
                    return RedirectToAction(nameof(AtlasIndex));
                }

            }

            return View(model);
        }
    }
}

