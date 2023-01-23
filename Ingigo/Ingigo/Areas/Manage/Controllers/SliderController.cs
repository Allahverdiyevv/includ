using Ingigo.Helpers;
using Ingigo.Models;
using MessagePack;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;

namespace Ingigo.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class SliderController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly DataContext _dataContext;

        public SliderController(DataContext dataContext , IWebHostEnvironment env)
        {
            _env = env;
            _dataContext = dataContext;
        }
        public IActionResult Index()
        {
            List<Slider> sliders = _dataContext.Sliders.ToList();
            return View(sliders);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Slider slider)
        {
            if (slider == null) return NotFound();
            _dataContext.Sliders.Add(slider);
            _dataContext.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult Update(int id)
        {
            Slider sliderex = _dataContext.Sliders.Find();
            if (sliderex == null) return NotFound();
            return View(sliderex);

        }

        [HttpPost]
        public IActionResult Update(Slider slider)
        {
            Slider sliderex = _dataContext.Sliders.Find(slider.Id);

            if (slider.ImageFile != null)
            {
                string ImageFile = FileManager.SaveFile(_env.WebRootPath, "upload\\slider", slider.ImageFile);

                FileManager.DeleteFile(_env.WebRootPath, "upload\\slider", sliderex.Image);
                slider.Image = ImageFile;
            }

            //FileManager.DeleteFile()

            slider.Title1 = sliderex.Title1;
            slider.Desc = sliderex.Desc;
            _dataContext.SaveChanges();
            return View(slider);
        }

        public IActionResult Delete(int id)
        {
            Slider slider = _dataContext.Sliders.FirstOrDefault(c=>c.Id ==id);
            if (slider == null) return NotFound();
            if (slider.Image !=null)
            {
                FileManager.DeleteFile(_env.WebRootPath, "uploas\\slider", slider.Image);
            }

            _dataContext.Sliders.Remove(slider);
            _dataContext.SaveChanges();
            return Ok();
        }
    }
}
