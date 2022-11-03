﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TraineeTracker.Data;
using TraineeTracker.Models;
using TraineeTracker.Models.ViewModels;
using TraineeTracker.Service;

namespace TraineeTracker.Controllers
{
    [Authorize]
    public class UserDatasController : Controller
    {
        private readonly IServiceLayer<UserData> _service;
        private IUserManager<User> _userManager;

        public UserDatasController(IServiceLayer<UserData> service, IUserManager<User> userManager)
        {
            _service = service;
            _userManager = userManager;
        }

        private async Task<List<UserDataViewModel>> GetTraineeView(string traineeId)
        {
            var userViewModel = new List<UserDataViewModel>();
            var userData = (await _service.GetAllAsync()).Where(x => x.UserID == traineeId).FirstOrDefault();
            if (userData is not null)
                userViewModel.Add(Utils.UserDataToViewModel(userData));
            return userViewModel;
        }
        private async Task<List<UserDataViewModel>> GetTrainerView()
        {
            var userViewModel = new List<UserDataViewModel>();
            var userDatas = (await _service.GetAllAsync()).Where(x => x.Roles == UserData.Level.Trainee);
            foreach(var userData in userDatas)
            {
                userViewModel.Add(Utils.UserDataToViewModel(userData));
            }
            return userViewModel;
        }
        public async Task<IActionResult> AttemptGetUserDataViewModel(int? id)
        {
            if (id == null || _service.IsNull())
            {
                return NotFound();
            }

            var userData = await _service.FindAsync((int)id);

            if (userData == null)
            {
                return NotFound();
            }

            var userDataViewModel = Utils.UserDataToViewModel(userData);

            return View(userDataViewModel);
        }

        // GET: UserDatas
        [Authorize(Roles ="Trainee, Trainer")]
        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync();

            if (_userManager.IsInRole("Trainee"))
            {
                return View(await GetTraineeView(currentUser.Id));
            }
            else if(_userManager.IsInRole("Trainer"))
            {
                return View(await GetTrainerView());
            }

            return NoContent();
        }

        // GET: UserDatas/Details/5
        public async Task<IActionResult> Details(int? id) => await AttemptGetUserDataViewModel(id);
        public async Task<IActionResult> Edit(int? id) => await AttemptGetUserDataViewModel(id);
        // GET: UserDatas/Delete/5
        public async Task<IActionResult> Delete(int? id) => await AttemptGetUserDataViewModel(id);
        
        // POST: UserDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_service.IsNull())
            {
                return Problem("Entity set 'TraineeTrackerContext.UserDataDB'  is null.");
            }
            var userData = await _service.FindAsync(id);
            if (userData != null)
            {
                await _service.RemoveAsync(userData);
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: UserDatas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID, FirstName,LastName,Title,Education,Experience,Activity,Biography,Skills")] UserDataViewModel userDataViewModel)
        {
            var userData = await _service.FindAsync(id);
            if (id != userDataViewModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    userData.FirstName = userDataViewModel.FirstName;
                    userData.LastName = userDataViewModel.LastName;
                    userData.Title = userDataViewModel.Title;
                    userData.Education = userDataViewModel.Education;
                    userData.Experience = userDataViewModel.Experience;
                    userData.Activity = userDataViewModel.Activity;
                    userData.Biography = userDataViewModel.Biography;
                    userData.Skills = userDataViewModel.Skills;
                    await _service.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_service.Exists(userData.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(userDataViewModel);
        }

    }
}
