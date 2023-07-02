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

namespace WoWNewsApi.FirestoreDbManager
{

    public class FirestoreManager : IFirestoreManager

    {
        private readonly IUnitOfWork _uniofwork;
        private readonly IUserService _userService;
        int x = 1;

        public FirestoreManager(IUnitOfWork uniofwork, IUserService userService)
        {
            _uniofwork = uniofwork;
            _userService = userService;
        }

        public async Task RetrieveAllDocuments(string project)
        {

            //Firestore credential
            try
            {
                var filepath = @"C:\\Users\\yhyk\\Desktop\\WoW News\\wownews-8d9b8-firebase-adminsdk-phqt7-6c6ea24f27.json";
                Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filepath);


            }
            catch (FileNotFoundException ex) { Console.WriteLine(ex.Message); }


            //Get Instance From FireStore
            FirestoreDb db = FirestoreDb.Create(project);


            //Collecting Data...
            CollectionReference datas = db.Collection("device_tokens");
            QuerySnapshot snapshot = await datas.GetSnapshotAsync();
            foreach (DocumentSnapshot document in snapshot.Documents)
            {
                Dictionary<string, object> mappedDocuments = document.ToDictionary();

                User user = new User();

                if (mappedDocuments.ContainsKey("email"))
                {
                    object value = mappedDocuments["email"];

                    user.Email = value.ToString();
                   
                }

                if (mappedDocuments.ContainsKey("uid"))
                {
                    object value = mappedDocuments["uid"];

                    user.Uid = value.ToString();
                   
                }
                if (mappedDocuments.ContainsKey("token"))
                {
                    object value = mappedDocuments["token"];

                    user.Token = value.ToString();
              
                }
                if (mappedDocuments.ContainsKey("date"))
                {
                    object value = mappedDocuments["date"];

                    user.CreatedDate = value.ToString();
                 
                }



                //Verify data existence in MsSql
                //Then adding new User
                
                
               var checkUser = await _userService.GetByUidAsync(user.Uid);
                
                if (user.Uid != checkUser?.Uid)
                {
                    try
                    {
                        await _userService.AddAsync(user);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.StackTrace);
                    }
                    
                    Console.WriteLine($"Added total user:  {x}");
                    x++;
                }


                else
                {
                    Console.WriteLine("There is an already existing user ");
                   
                }
                
            }
            Console.WriteLine("");



        }
    }
}
