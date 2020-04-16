using AspProjet.Areas.Client.Models;
using AspProjet.Models;
using DalWebApiProjet.Models;
using DalWebApiProjet.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspProjet.Tools
{
    public static class Mappeur
    {
        public static AccueilASP GetAccueilASP(this AccueilDalAPI accueilDalAPI)
        {
            AccueilASP accueilASP = new AccueilASP();
            accueilASP.brasserieId = accueilDalAPI.brasserieId;
            accueilASP.brasseriePresentation = accueilDalAPI.brasseriePresentation;
            accueilASP.heureFermeture = new Temps(accueilDalAPI.heureFermeture);
            accueilASP.heureOuverture = new Temps(accueilDalAPI.heureOuverture);
            accueilASP.horraireDateDebut = accueilDalAPI.horraireDateDebut;
            accueilASP.horraireDateFin = accueilDalAPI.horraireDateFin;
            accueilASP.nomBrasserie = accueilDalAPI.nomBrasserie;
            return accueilASP;
        }
        public static BiereASP GetBiereASP(this BiereDalAPI biereDalAPI)
        {
            BiereASP biereASP = new BiereASP();
            biereASP.biereDescription = biereDalAPI.biereDescription;
            biereASP.biereId = biereDalAPI.biereId;
            biereASP.biereImage = biereDalAPI.biereImage;
            biereASP.biereNom = biereDalAPI.biereNom;
            biereASP.bierePrix = biereDalAPI.bierePrix;
            biereASP.biereRobe = biereDalAPI.biereRobe;
            biereASP.nomBrasserie = biereDalAPI.nomBrasserie;
            biereASP.pourcentageAlcool = biereDalAPI.pourcentageAlcool;
            biereASP.typeBiereNom = biereDalAPI.typeBiereNom;
            RecompenseApiService apiService =  RecompenseApiService.GetLoadBalancer();
            biereASP.recompenseNom = apiService.GetAll(biereASP.biereId).Select(r => r.recompenseNom).ToList();
            return biereASP;
        }
        public static ClientASP GetClientASP(this ClientDalAPI clientDalAPI)
        {
            ClientASP clientASP = new ClientASP();
            clientASP.clienDateNaissance = clientDalAPI.clienDateNaissance;
            clientASP.clientId = clientDalAPI.clientId;
            clientASP.clientLogin = clientDalAPI.clientLogin;
            clientASP.clientNom = clientDalAPI.clientNom;
            clientASP.clientPrenom = clientDalAPI.clientPrenom;
            return clientASP;
        }
        public static ClientDalAPI GetClientDalAPI(this ClientASP clientASP)
        {
            ClientDalAPI clientDalAPI = new ClientDalAPI();
            clientDalAPI.clienDateNaissance = clientASP.clienDateNaissance;
            clientDalAPI.clientId = clientASP.clientId;
            clientDalAPI.clientLogin = clientASP.clientLogin;
            clientDalAPI.clientNom = clientASP.clientNom;
            clientDalAPI.clientPrenom = clientASP.clientPrenom;
            clientDalAPI.clientPwd = clientASP.clientPwd;
            return clientDalAPI;
        }
        public static CommandeASP GetCommandeASP(this CommandeDalAPI commandeDalAPI)
        {
            CommandeASP commandeASP = new CommandeASP();
            commandeASP.biereNom = commandeDalAPI.biereNom;
            commandeASP.bierePrix = commandeDalAPI.bierePrix;
            commandeASP.clientLogin = commandeDalAPI.clientLogin;
            commandeASP.commandeDate = commandeDalAPI.commandeDate;
            commandeASP.commandeId = commandeDalAPI.commandeId;
            commandeASP.commandeQuantite = commandeDalAPI.commandeQuantite;
            return commandeASP;
        }
        public static CommandeDalAPI GetCommandeDalAPI(this CommandeASP commandeASP)
        {
            CommandeDalAPI commandeDalAPI = new CommandeDalAPI();
            commandeDalAPI.biereNom = commandeASP.biereNom;
            commandeDalAPI.bierePrix = commandeASP.bierePrix;
            commandeDalAPI.clientLogin = commandeASP.clientLogin;
            commandeDalAPI.commandeDate = commandeASP.commandeDate;
            commandeDalAPI.commandeId = commandeASP.commandeId;
            commandeDalAPI.commandeQuantite = commandeASP.commandeQuantite;
            return commandeDalAPI;
        }
        public static ContactASP GetContactASP(this ContactDalAPI contactDalAPI)
        {
            ContactASP contactASP = new ContactASP();
            contactASP.adCodePostal = contactDalAPI.adCodePostal;
            contactASP.adNumero = contactDalAPI.adNumero;
            contactASP.adRue = contactDalAPI.adRue;
            contactASP.adVille = contactDalAPI.adVille;
            contactASP.contactId = contactDalAPI.contactId;
            contactASP.mailInfon = contactDalAPI.mailInfon;
            contactASP.nomBrasserie = contactDalAPI.nomBrasserie;
            contactASP.telephone = contactDalAPI.telephone;
            return contactASP;
        }
        public static EvenementASP GetEvenementASP(this EvenementDalAPI evenementDalAPI)
        {
            EvenementASP evenementASP = new EvenementASP();
            evenementASP.brasserieId = evenementDalAPI.brasserieId;
            evenementASP.eventDateDebut = evenementDalAPI.eventDateDebut;
            evenementASP.eventDateFin = evenementDalAPI.eventDateFin;
            evenementASP.eventDescription = evenementDalAPI.eventDescription;
            evenementASP.eventId = evenementDalAPI.eventId;
            return evenementASP;
        }
        public static MessageASP GetMessageASP(this MessageDalAPI messageDalAPI)
        {
            MessageASP messageASP = new MessageASP();
            messageASP.messageAlertId = messageDalAPI.messageAlertId;
            messageASP.messageContenu = messageDalAPI.messageContenu;
            messageASP.messageDateDebut = messageDalAPI.messageDateDebut;
            messageASP.messageDateFin = messageDalAPI.messageDateFin;
            messageASP.nomBrasserie = messageDalAPI.nomBrasserie;
            return messageASP;
        }
        public static OffreEmploiASP OffreEmploiASP(this OffreEmploiDalAPI offreEmploiDalAPI)
        {
            OffreEmploiASP offreEmploiASP = new OffreEmploiASP();
            offreEmploiASP.diplomeMin = offreEmploiDalAPI.diplomeMin;
            offreEmploiASP.experienceMin = offreEmploiDalAPI.experienceMin;
            offreEmploiASP.fonction = offreEmploiDalAPI.fonction;
            offreEmploiASP.jobDescription = offreEmploiDalAPI.jobDescription;
            offreEmploiASP.mailRecrutement = offreEmploiDalAPI.mailRecrutement;
            offreEmploiASP.nomBrasserie = offreEmploiDalAPI.nomBrasserie;
            offreEmploiASP.offreEmploiId = offreEmploiDalAPI.offreEmploiId;
            return offreEmploiASP;
        }
        public static ClientASP GetClientAspFromFormClient(this FormCreateClient createClient)
        {
            ClientASP clientASP = new ClientASP();
            clientASP.clienDateNaissance = createClient.clientDateNaissance;
            clientASP.clientLogin = createClient.clientLogin;
            clientASP.clientNom = createClient.clientNom;
            clientASP.clientPrenom = createClient.clientPrenom;
            clientASP.clientPwd = createClient.clientPwd;
            return clientASP;
        }
        public static CommandeASP GetCommandeASPFromFormCommande(this FormCommande formCommande)
        {
            CommandeASP commandeASP = new CommandeASP();
            commandeASP.commandeDate = DateTime.Now;
            commandeASP.commandeQuantite = formCommande.commandeQuantite;
            commandeASP.biereNom = formCommande.biereNom;
            commandeASP.clientLogin = formCommande.clientLogin;
            return commandeASP;
        }
        public static ClientASP GetCommandeASPFromEditClient(this EditClient editClient)
        {
            ClientASP clientASP = new ClientASP();
            clientASP.clientLogin = editClient.clientLogin;
            clientASP.clientPwd = editClient.clientPwd;
            clientASP.clientId = editClient.clientId;
            return clientASP;
        }
        public static EditClient GetEditClient(this ClientASP clientASP)
        {
            EditClient editClient = new EditClient();
            editClient.clientId = clientASP.clientId;
            //editClient.clientPwd = clientASP.clientPwd;
            editClient.clientLogin = clientASP.clientLogin;
            return editClient; 
        }
        public static Boulette GetBoulette(this BiereASP biereASP)
        {
            Boulette boulette = new Boulette();
            boulette.biereDescription = biereASP.biereDescription;
            boulette.biereId = biereASP.biereId;
            boulette.biereImage = biereASP.biereImage;
            boulette.biereNom = biereASP.biereNom;
            boulette.bierePrix = biereASP.bierePrix;
            boulette.biereRobe = biereASP.biereRobe;
            boulette.nomBrasserie = biereASP.nomBrasserie;
            boulette.pourcentageAlcool = biereASP.pourcentageAlcool;
            RecompenseApiService apiService = new RecompenseApiService();
            boulette.recompenseNom = apiService.GetAll(boulette.biereId).Select(r => r.recompenseNom).ToList();
            boulette.typeBiereNom = biereASP.typeBiereNom;
            return boulette;
        }
    }
}