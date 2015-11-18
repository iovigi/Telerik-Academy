namespace DropboxAlbum
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using Spring.Social.Dropbox.Connect;
    using Spring.Social.OAuth1;
    using Spring.Social.Dropbox.Api;
    using Spring.IO;

    public class StartUp
    {
        // Register your own Dropbox app at https://www.dropbox.com/developers/apps
        // with "Full Dropbox" access level and set your app keys and app secret below
        private const string DropboxAppKey = "p5wvlbzduwq4sbp";
        private const string DropboxAppSecret = "zas74mv7g4mpzbg";

        private const string OAuthTokenFileName = "OAuthTokenFileName.txt";

        public static void Main()
        {
            DropboxServiceProvider dropboxServiceProvider =
                new DropboxServiceProvider(DropboxAppKey, DropboxAppSecret, AccessLevel.AppFolder);

            if (!File.Exists(OAuthTokenFileName))
            {
                AuthorizeAppOAuth(dropboxServiceProvider);
            }
            OAuthToken oauthAccessToken = LoadOAuthToken();

            var api = dropboxServiceProvider.GetApi(oauthAccessToken.Value, oauthAccessToken.Secret);

            Entry uploadFileEntry = api.UploadFileAsync(
              new FileResource("1.jpg"),"1.jpg").Result;
            Console.WriteLine("Uploaded a file: {0}", uploadFileEntry.Path);

            uploadFileEntry = api.UploadFileAsync(
              new FileResource("2.jpg"), "2.jpg").Result;
            Console.WriteLine("Uploaded a file: {0}", uploadFileEntry.Path);
        }

        private static OAuthToken LoadOAuthToken()
        {
            string[] lines = File.ReadAllLines(OAuthTokenFileName);
            OAuthToken oauthAccessToken = new OAuthToken(lines[0], lines[1]);
            return oauthAccessToken;
        }

        private static void AuthorizeAppOAuth(DropboxServiceProvider dropboxServiceProvider)
        {
            // Authorization without callback url
            Console.Write("Getting request token...");
            OAuthToken oauthToken = dropboxServiceProvider.OAuthOperations.FetchRequestTokenAsync(null, null).Result;
            Console.WriteLine("Done.");

            OAuth1Parameters parameters = new OAuth1Parameters();
            string authenticateUrl = dropboxServiceProvider.OAuthOperations.BuildAuthorizeUrl(
                oauthToken.Value, parameters);
            Console.WriteLine("Redirect the user for authorization to {0}", authenticateUrl);
            Process.Start(authenticateUrl);
            Console.Write("Press [Enter] when authorization attempt has succeeded.");
            Console.ReadLine();

            Console.Write("Getting access token...");
            AuthorizedRequestToken requestToken = new AuthorizedRequestToken(oauthToken, null);
            OAuthToken oauthAccessToken =
                dropboxServiceProvider.OAuthOperations.ExchangeForAccessTokenAsync(requestToken, null).Result;
            Console.WriteLine("Done.");

            string[] oauthData = new string[] { oauthAccessToken.Value, oauthAccessToken.Secret };
            File.WriteAllLines(OAuthTokenFileName, oauthData);
        }
    }
}
