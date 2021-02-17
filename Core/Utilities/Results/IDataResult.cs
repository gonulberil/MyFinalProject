using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    //Hangi tipin döndürülüceğini söyle <T>
    public interface IDataResult<T>  :IResult
    {
        T Data { get;  }
    }
}
