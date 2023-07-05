using Google.Cloud.Firestore;
using WoWNewsApi.Firestore.Core;
using WoWNewsApi.Firestore.Repo;
using WoWNewsApi.Models;
using WoWNewsApi.Services;
using WoWNewsApi.Services.Contracts;
using WoWNewsApi.UnitOfWork;

namespace WoWNewsApi.FirestoreDbManager
{
    public class AddFirestoreDataToSql : IAddFirestoreDataToSql
    {
        int addeduser;
        int scannedUser;

        private readonly IConnectFirestore _connectFirestore;
        private readonly IUnitOfWork _uniofwork;
        private readonly IUserService _userService;

        public AddFirestoreDataToSql(IConnectFirestore connectFirestore, IUnitOfWork uniofwork, IUserService userService)
        {
            _connectFirestore = connectFirestore;
            _uniofwork = uniofwork;
            _userService = userService;
        }

        public async Task TakeUserData()
        {
            
            var db = await _connectFirestore.FirestoreContextAsync();


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


                var checkUser = await _userService.GetByUidAsync(user.Uid);

                if (user.Uid != checkUser?.Uid)
                {
                    try
                    {
                        await _userService.AddAsync(user);
                        addeduser++;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.StackTrace);
                    }
                }
                else
                    Console.WriteLine("There is an already existing user ");
                
            }
            Console.WriteLine($"The total number of users written to the database is {addeduser}");
            





        }

    }

}



