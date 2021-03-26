using EasyNote.Models;
using EasyNote.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace EasyNote.Controllers
{
    [Authorize]
    public class NotesController : BaseController
    {
        public ActionResult GetNotes()
        {
            string userId = User.Identity.GetUserId();
            List<NoteVM> notes = db.Notes
                .Where(x => x.AuthorId == userId)
                .ToList()
                .Select(x => x.ToViewModel())
                .ToList();
            return Json(notes, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult PostNote(PostNoteVM vm)
        {
            if (ModelState.IsValid)
            {
                Note note = new Note()
                {
                    Title = vm.Title,
                    Content = vm.Content,
                    AuthorId = User.Identity.GetUserId()
                };
                db.Notes.Add(note);
                db.SaveChanges();
                return Json(note.ToViewModel());
            }

            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return Json(ModelState); // return model errors
        }

        [HttpPost]
        public ActionResult UpdateNote(NoteVM vm)
        {
            if (ModelState.IsValid)
            {
                string userId = User.Identity.GetUserId();
                Note note = db.Notes.Find(vm.Id);

                if (note == null || note.AuthorId != userId)
                    return HttpNotFound();

                note.Title = vm.Title;
                note.Content = vm.Content;
                db.SaveChanges();
                return Json(note.ToViewModel());
            }

            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return Json(ModelState); // return model errors
        }

        [HttpPost]
        public ActionResult DeleteNote(int id)
        {
            Note note = db.Notes.Find(id);

            if (note == null || note.AuthorId != User.Identity.GetUserId())
                return HttpNotFound();

            db.Notes.Remove(note);
            db.SaveChanges();
            return Json(note.ToViewModel());
        }
    }
}