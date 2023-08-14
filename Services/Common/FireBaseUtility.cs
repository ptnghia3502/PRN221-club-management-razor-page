using Firebase.Auth;
using Firebase.Storage;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubManagementServices.Common
{
    public record FireBaseFile
    {
        public string URL { get; set; } = default!;
        public string FileName { get; set; } = default!;
    }
    public static class FireBaseUtility
    {
        // Vulnurable Data
        private static string API_KEY = "AIzaSyCKoQE5sWvYe_CR3OWkU6g-ykieAjZcz2I";
        private static string Bucket = "club-management-prn221.appspot.com";
        private static string AuthEmail = "admin1@gmail.com";
        private static string AuthPassword = "@Admin123";

        public static async Task<FireBaseFile> UploadFileAsync(this IFormFile fileUpload,string fileName)
        {
            if (fileUpload.Length > 0)
            {
                var fs = fileUpload.OpenReadStream();
                var auth = new FirebaseAuthProvider(new FirebaseConfig(API_KEY));
                var a = await auth.SignInWithEmailAndPasswordAsync(AuthEmail, AuthPassword);
                var cancellation = new FirebaseStorage(
                    Bucket,
                    new FirebaseStorageOptions
                    {
                        AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
                        ThrowOnCancel = true

                    }
                    ).Child("assets").Child(fileName)
                    .PutAsync(fs, CancellationToken.None);
                try
                {
                    var result = await cancellation;

                    return new FireBaseFile
                    {
                        FileName = fileName,
                        URL = result
                    };
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }

            }
            else throw new Exception("File is not existed!");
        }

        public static async Task<bool> RemoveFileAsync(this string fileName)
        {
            var auth = new FirebaseAuthProvider(new FirebaseConfig(API_KEY));
            var loginInfo = await auth.SignInWithEmailAndPasswordAsync(AuthEmail, AuthPassword);
            var storage = new FirebaseStorage(Bucket, new FirebaseStorageOptions
            {
                AuthTokenAsyncFactory = () => Task.FromResult(loginInfo.FirebaseToken),
                ThrowOnCancel = true
            });
            await storage.Child("assets").Child(fileName).DeleteAsync();
            return true;

        }

    }
}
