using Google.Apis.Auth.OAuth2;
using Microsoft.Identity.Client.Platforms.Features.DesktopOs.Kerberos;
using FirebaseAdmin;
using FirebaseAdmin.Auth;
using Google.Cloud.Firestore;
using Google.Cloud.Firestore.V1;
using WoWNewsApi.Models;
using System.Data.SqlTypes;
using WoWNewsApi.UnitOfWork;
using WoWNewsApi.Services.Contracts;
using WoWNewsApi.Services;
using Microsoft.IdentityModel.Tokens;
using Google.Protobuf.WellKnownTypes;
using System.Linq.Expressions;
using WoWNewsApi.Firestore.Core;

namespace WoWNewsApi.Firestore.Repo
{

    public class ConnectFirestore : IConnectFirestore

    {
        

        public async Task<FirestoreDb> FirestoreContextAsync()
        {

            //Firestore credential
            try
            {
                var filepath = @"C:\\Users\\yhyk\\Desktop\\WoW News\\wownews-8d9b8-firebase-adminsdk-phqt7-6c6ea24f27.json";
                Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filepath);

            }catch (FileNotFoundException ex) { Console.WriteLine(ex.Message); }


            //Get Instance From FireStore
             return await FirestoreDb.CreateAsync("wownews-8d9b8");
         
        }
        
    }
}
