using E_Mart.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using E_Mart.DAO;
using E_Mart.DAO.Interfaces;
using System.Threading.Tasks;

namespace E_Mart.Controllers
{
    public class GrocceryController : Controller
    {
        private readonly IGrocceryRepository _grocceryRepository;

        public GrocceryController(IGrocceryRepository grocceryRepository)
        {
            _grocceryRepository = grocceryRepository;
        }

        public async Task<IActionResult> Index()
        {
            var grocceries = await _grocceryRepository.GetAllGrocceriesAsync();
            return View(grocceries);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Groccery groccery)
        {
            if (ModelState.IsValid)
            {
                _grocceryRepository.AddGrocceryAsync(groccery).Wait();
                return RedirectToAction("Index");
            }

            return View(groccery);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var groccery = _grocceryRepository.GetGrocceryByIdAsync(id).Result;
            return View(groccery);
        }

        [HttpPost]
        public IActionResult Edit(Groccery groccery)
        {
            if (ModelState.IsValid)
            {
                _grocceryRepository.UpdateGrocceryAsync(groccery).Wait();
                return RedirectToAction("Index");
            }

            return View(groccery);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var groccery = _grocceryRepository.GetGrocceryByIdAsync(id).Result;
            return View(groccery);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            _grocceryRepository.DeleteGrocceryAsync(id).Wait();
            return RedirectToAction("Index");
        }
    }
}
