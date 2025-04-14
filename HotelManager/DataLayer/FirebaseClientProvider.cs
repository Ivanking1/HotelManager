using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;

namespace DataLayer
{
    public static class FirebaseClientProvider
    {
        private static readonly Lazy<IFirebaseClient> _client = new Lazy<IFirebaseClient>(() =>
        {
            var config = new FirebaseConfig
            {
                AuthSecret = "Ql4IbAHsFZDstc70rks8mgl3QBeYQaW3DO4Cfbos",
                BasePath = "https://hotelmanager-e070f-default-rtdb.firebaseio.com/"
            };

            return new FireSharp.FirebaseClient(config);
        });

        public static IFirebaseClient Client => _client.Value;
    }
}
