using FluentValidation.Results;

namespace DG.API.Extensions;

public static class ValidationFailureListExtensions
{
    public static string ValidationFailureListToString(
        this List<ValidationFailure> list)
    {
        var str = "";

        for (var i = 0; i < list.Count; i++)
        {
            str += list[i];

            if (i < list.Count - 1)
            {
                str += "\n";
            }
        }

        return str;
    }
    
}
