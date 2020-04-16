using AspProjet.Models;
using AspProjet.Tools;
using DalWebApiProjet.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Windows.Forms;

namespace AspProjet.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Accueil()
        {
            AccueilApiService accueilApiService =  AccueilApiService.GetLoadBalancer();
            MessageApiService messageApiService =  MessageApiService.GetLoadBalancer();
            List<MessageASP> test = new List<MessageASP>();
            test = messageApiService.GetAll().Select(p => p.GetMessageASP()).ToList();
            if (test.Count() > 0)
            {
                ViewBag.Messages = test;
            }
            return View(accueilApiService.GetAll().Select(a => a.GetAccueilASP()).FirstOrDefault());
        }

        public ActionResult Evenement()
        {
            EvenementApiService evenementApi =  EvenementApiService.GetLoadBalancer();
            return View(evenementApi.GetAll().Select(p => p.GetEvenementASP()));
        }

        public ActionResult Contact()
        {
            ContactApiService contactApiService =  ContactApiService.GetLoadBalancer();

            return View(contactApiService.GetAll().Select(p => p.GetContactASP()));
        }
        public ActionResult Biere()
        {
            BiereApiService biereApi =  BiereApiService.GetLoadBalancer();
            //Verif.rattraperBoulette(biereApi.GetAll().Select(p => p.GetBiereASP()).ToList());
            // return View(Verif.rattraperBoulette(biereApi.GetAll().Select(p => p.GetBiereASP()).ToList()));
            return View(biereApi.GetAll().Select(p => p.GetBiereASP()).ToList());
        }
        public ActionResult DetailBiere(int id)
        {
            BiereApiService biereApi = BiereApiService.GetLoadBalancer();
            //Verif.rattraperBoulette(biereApi.GetAll().Select(p => p.GetBiereASP()).ToList()).Where(p => p.biereId ==id);
            //return View(Verif.rattraperBoulette(biereApi.GetAll().Select(p => p.GetBiereASP()).ToList()).Where(p => p.biereId == id).FirstOrDefault());
            return View(biereApi.GetOne(id).GetBiereASP());
        }
        public ActionResult Emploi()
        {
            EmploiApiService emploiApi =  EmploiApiService.GetLoadBalancer();
            return View(emploiApi.GetAll().Select(p => p.OffreEmploiASP()).ToList());
        }
        public ActionResult DetailEmploi(int id)
        {
            EmploiApiService emploiApi =  EmploiApiService.GetLoadBalancer();
            return View(emploiApi.GetOne(id).OffreEmploiASP());
        }
        [HttpGet]
        public ActionResult Inscription()
        {
            return View(new FormCreateClient());
        }
        public ActionResult Inscription(FormCreateClient createClient)
        {
            if(Verif.IsLoginValid(createClient.clientLogin) && Verif.IsMajeur(createClient.clientDateNaissance))
            {
                ClientApiService clientApiService =  ClientApiService.GetLoadBalancer();
                clientApiService.Create(createClient.GetClientAspFromFormClient().GetClientDalAPI());
                return RedirectToAction("Connection");
            }
            else
            {
                ViewBag.Messages = "Login ou date de naissance pas valide";
                return View(createClient);
            }
           
        }
        [HttpGet]
        public ActionResult Connection()
        {
            return View();
        }
        public ActionResult Connection(string login,string pwd)
        {
            ClientApiService clientApi =  ClientApiService.GetLoadBalancer();
            int? id=clientApi.Connection(login, pwd);
            if (id != null)
            {
                ClientASP client =clientApi.GetOne((int)id).GetClientASP();
                //Session["test4"] = client.clientLogin;
                Utils.Client = client;
                string test=Utils.Client.clientLogin;
                //string test2 = (string)Session["test4"];
                return RedirectToAction("Index","Client/Client");
            }
            else
            {
                ViewBag.Messages = "Login ou mot de passe non valide";
                return View();
            }

        }
        public ActionResult Deconnection()
        {
            if (Utils.Client != null)
            {
                Session.Clear();
                Session.Abandon();
                return RedirectToAction("Accueil");
            }
            else
            {
                return Redirect("Accueil");
            }
            
        }
    }
}