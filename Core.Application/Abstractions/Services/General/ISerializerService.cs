using Core.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Abstractions.Services.General
{
    public interface ISerializerService:ITransientService
    {
        T Deserialize<T>(string text);
        string Serialize<T>(T obj);
        string Serialize<T>(T obj,Type type);
    }
}
