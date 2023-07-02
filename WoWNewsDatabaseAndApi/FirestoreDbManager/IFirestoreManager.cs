namespace WoWNewsApi.FirestoreDbManager
{
    public interface IFirestoreManager
    {
        Task RetrieveAllDocuments(string v);
    }
}
