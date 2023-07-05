using Google.Cloud.Firestore;

namespace WoWNewsApi.Firestore.Core
{
    public interface IConnectFirestore
    {
        Task<FirestoreDb> FirestoreContextAsync();
        
    }
}
