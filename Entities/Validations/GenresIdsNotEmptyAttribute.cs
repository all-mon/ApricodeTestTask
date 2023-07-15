using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace Entities.Validations
{
    public class GenresIdsNotEmptyAttribute : ValidationAttribute
    {

        public GenresIdsNotEmptyAttribute()
        {
            ErrorMessage = "Список id жанров должен содержать мин 1 эл-т";
        }
        public override bool IsValid(object? value)
        {
            if (value is ICollection collection)
            {
                return collection.Count > 0;
            }
            if (value is IEnumerable enumerable)
            {
                return enumerable.GetEnumerator().MoveNext();
            }
            return false;
        }
    }
}
