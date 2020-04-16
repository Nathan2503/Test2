using AspProjet.Areas.Client.Models;
using AspProjet.Models;
using AspProjet.Tools;
using DalWebApiProjet.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspProjet.Areas.Client.Controllers
{
    public class ClientController : Controller
    {
        // GET: Client/Client
        public ActionResult Index()
        {
            if (Utils.Client != null)
            {
                ClientApiService clientApi =  ClientApiService.GetLoadBalancer();
                return View(clientApi.GetOne(Utils.Client.clientId).GetClientASP());
            }
            else
            {
                return RedirectToAction("Accueil", "Home", new { area = "" });
            }
            
        }
        [HttpGet]
        public ActionResult EditClient(int id)
        {
            if (Utils.Client != null)
            {
                ClientApiService clientApi =  ClientApiService.GetLoadBalancer();
                return View(clientApi.GetOne(id).GetClientASP().GetEditClient());
            }
            else
            {
                return RedirectToAction("Accueil", "Home", new { area = "" });
            }
        }
        public ActionResult EditClient(EditClient clientASP)
        {
            if (Utils.Client != null)
            {
                if (Verif.IsLoginValid(clientASP.clientLogin))
                {
                    ClientApiService clientApi =  ClientApiService.GetLoadBalancer();
                    clientApi.Update(clientASP.GetCommandeASPFromEditClient().GetClientDalAPI());
                    Utils.Client.clientLogin = clientASP.clientLogin;
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Messages = "Login non valide";
                    return View(clientASP);
                }
            }
            else
            {
                return RedirectToAction("Accueil", "Home", new { area = "" });
            }
            
           
        }
        public ActionResult DeleteClient(int id)
        {
            if (Utils.Client != null)
            {
                ClientApiService clientApi =  ClientApiService.GetLoadBalancer();
                clientApi.Delete(id);
                Session.Clear();
                Session.Abandon();
                return RedirectToAction("Accueil", "Home", new { area = "" });
            }
            else
            {
                return RedirectToAction("Index");
            }
           
            
        }
        public ActionResult Commande()
        {
            if (Utils.Client != null)
            {
             CommandeApiService commandeApi =  CommandeApiService.GetLoadBalancer();
                //return View(commandeApi.GetAll().Where(p => p.clientLogin == Utils.Client.clientLogin).Select(p => p.GetCommandeASP()).ToList());
                return View(commandeApi.GetByLogin(Utils.Client.clientLogin).Select(p => p.GetCommandeASP()).ToList());
            }
            else
            {
                return RedirectToAction("Accueil","Home",new {area=""});
            }
        }
        public ActionResult DetailCommande(int id)
        {
            if (Utils.Client != null)
            {
                CommandeApiService commandeApi =  CommandeApiService.GetLoadBalancer();
                return View(commandeApi.GetOne(id).GetCommandeASP());
            }
            else
            {
                return RedirectToAction("Accueil", "Home", new { area = "" });
            }
           
        }
        [HttpGet]
        public ActionResult CreateCommande()
        {
            if (Utils.Client != null)
            {
                return View(new FormCommande());
            }
            else
            {
                return RedirectToAction("Accueil", "Home", new { area = "" });
            }
        }
        public ActionResult CreateCommande(FormCommande commandeASP)
        {
            if (Utils.Client != null)
            {
                if (Verif.IsBiereValid(commandeASP.biereNom) && Verif.IsNumber(commandeASP.commandeQuantite.ToString()))
                {
                    commandeASP.clientLogin = Utils.Client.clientLogin;
                    string test = commandeASP.biereNom;
                    CommandeApiService apiService =  CommandeApiService.GetLoadBalancer();
                    apiService.Create(commandeASP.GetCommandeASPFromFormCommande().GetCommandeDalAPI());
                    return RedirectToAction("Commande");
                }
                else
                {
                    ViewBag.Messages = "Commande non valide";
                    return View(commandeASP);
                }
            }
            else
            {
                return RedirectToAction("Accueil", "Home", new { area = "" });
            }
           
            
        }

    }
}