using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public static class PasteExceptions
    {
        public readonly static string TitleAndContentisNull = "Başlık ya da içerikten biri dolu olmalıdır";
        public readonly static string DbError = "İçeriği Eklemeye Çalışırken bir sorun oluştu";
        public readonly static string PasteNoFound = "İçerik Bulunamadı";
    }
}
