using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public static class UserExceptions
    {
        public const string UserNotFound = "Kullanıcı Bulunamadı";
        public const string LoginFailed = "Giriş Başarısız";
        public const string ChangePasswordFailed = "Şifre Değiştirme İşlemi Başarısız Oldu";

    }
}
