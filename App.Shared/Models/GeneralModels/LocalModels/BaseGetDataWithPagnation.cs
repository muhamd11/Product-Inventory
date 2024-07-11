using System.Collections.Generic;

namespace App.Shared.Models.General.LocalModels
{
    public class BaseGetDataWithPagnation<T>
    {
        public IEnumerable<T> Data { get; set; }
        public Pagination Pagination { get; set; }
    }
}