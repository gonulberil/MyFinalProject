using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    //temel voidler için başlangıç
    //klasörlemeyi abstract concrete de yapılabilridi
    public interface IResult
    {
        //propertyler 2 noktada kullanılıyor 1 get 2 set get okunması için 
        bool Success { get; } //başarılı mı başarısız mı
        string Message { get; } //yaptığın işlem başarılı veya başarısız sonucu verir.
    }
}
