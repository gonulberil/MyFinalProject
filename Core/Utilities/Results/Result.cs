using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        //this class ın adına Resulta  çalışır. tek parametreli olan constructorına succesi yolla 
        //hem 2.ci constructor 16. satır  hem de 11.satır çalışacak
        public Result(bool success, string message) : this(success)
        {
            Message = message; //mesajı message olarak set et
           
        }
        public Result(bool success)
        {
            
            Success = success;
        }

        //sadece get olduğu için return edilcek
        //getter lar read only dir ve constructor da set edilebilir.
        public bool Success { get; }

        public string Message { get; }
    }
}
