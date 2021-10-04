using WebTeste.Models;
using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Data.SqlClient;
using System.Globalization;
using System.Threading;

namespace WebTeste.Controllers
{
    public class UserController : Controller
    {
        public UserDbContext db;
        public UserController()
        {
            db = new UserDbContext();
            db.Database.Connection.Open();
        }
         
        public ActionResult Index()
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("pt-BR");
            List<User> Usuarios = db.Users.ToList();
            List<Sexo> Sexo = db.Sexo.ToList();
            return View(Usuarios);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
               
                var usuario = new User();
                usuario.Nome = model.Nome;
                usuario.DataNascimento = model.DataNascimento;
                usuario.Email = model.Email;
                usuario.Senha = model.Senha;
                usuario.SexoId = model.SexoId;
                

                db.Users.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.User = db.Users;
                return View(model);
            }
        }

        public ActionResult Edit(int? id)
        {
            User usuario = db.Users.Find(id);
            ViewBag.Users = db.Users;
            return View(usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(include: "UsuarioId,Nome,DataNascimento,Email,Senha,SexoId")] User model)
        {
            if (ModelState.IsValid)
            {
                var usuario = db.Users.Find(model.UsuarioId);
                usuario.Nome = model.Nome;
                usuario.DataNascimento = model.DataNascimento;
                usuario.Email = model.Email;
                usuario.Senha = model.Senha;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Users = db.Users;
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            User usuario = db.Users.Find(id);
            ViewBag.Users = db.Users;
            return View(usuario);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User usuario = db.Users.Find(id);
            db.Users.Remove(usuario);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Result()
        {
            List<User> Usuarios = db.Users.ToList();
            List<Sexo> Sexo = db.Sexo.ToList();
            return View();
        }

        public ActionResult Buscar(string nome)
        {
            List<User> Usuarios = db.Users.ToList();
            List<Sexo> Sexo = db.Sexo.ToList();
            return View();
        }

        [HttpPost, ActionName("Buscar")]
        [ValidateAntiForgeryToken]
        public ActionResult BuscarUsuario(string nome)
        {
            var UserBusca = db.Users.Where(m => m.Nome.Contains(nome));
            List<Sexo> Sexo = db.Sexo.ToList();
            ViewBag.Users = db.Users;
            return View("Result", UserBusca);
        }
    }
}
